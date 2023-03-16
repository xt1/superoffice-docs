using CommandLine;
using Microsoft.Playwright;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using YamlDotNet.Core;
using System.Collections.Generic;

namespace Webshooter
{
    internal class Program
    {
        private static IPlaywright _playwright;
        private static IBrowserType _chrome;
        private static IBrowser _browser;
        private static IPage _page;
        private static IDeserializer _yamlDeserializer;

        static int Main(string[] args)
        {
            Console.WriteLine("Webshooter v0.1 - Christian Mogensen (c) 2023");
            int result = 0;
            var parser = new CommandLine.Parser( opt => { 
                opt.AllowMultiInstance = true;
                opt.HelpWriter = Console.Out;
                opt.AutoHelp= true;
                opt.AutoVersion= true;
            });
            parser.ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(o => 
                {
                    // Verify files first
                    bool isOk = ShotFileHelp(o);
                    isOk = isOk && VerifyFilesAreOk(o);
                    if (!isOk)
                    {
                        result = 1;
                        return;
                    }
                    StartShooting(o);
                    foreach (var arg in o.BaseFolder)
                    {
                        if( File.Exists(arg) )
                        {
                            if (o.Verbose)
                                Console.WriteLine("Shooting file '{0}'", arg);
                            ProcessShotsInFile(o, arg);
                        }
                        if (Directory.Exists(arg))
                        {
                            if (o.Verbose)
                                Console.WriteLine("Shooting files in '{0}'", arg);
                            ProcessShotsInFolder(o, arg);
                        }
                    }
                    FinishShooting(o);
                });
            return result;
        }

        private static bool VerifyFilesAreOk(CommandLineOptions o)
        {
            bool isOk = true;
            foreach (var arg in o.BaseFolder)
            {
                if (File.Exists(arg))
                {
                    var shots = ReadShotsFile(o, arg);
                    isOk = isOk && shots != null;
                }
                else
                if (!Directory.Exists(arg))
                {
                    Console.Error.WriteLine("{0}: File or directory not found", arg);
                    isOk = false;
                }
            }
            return isOk;
        }

        private static bool ShotFileHelp(CommandLineOptions o)
        {
            if( o.ShotFileHelp)
            {
                Console.WriteLine(
@"Shot files

Shot files are YAML files that contain description of web-page elements and instruction 
on how to take the screenshot.
Properties or environment variables are substituted for {{name}}s in strings, so
that you don't need to check in secrets.

Output: string - path to write PNG screenshot to, relative to the output directory.
        Blank = don't take screenshot.
Url: string - URL to load. Optional. Can be relative to BaseUrl (if specified). 
        Blank = continue with current browser state.
WindowSize: string '900x600' - width x height in pixels. Optional. Resizes window.
Element: string - CSS or XPath locator for element to take screenshot of. 
        Blank = whole screen.
Before: array of Steps to do before taking the shot. Optional.
After: array of Steps to do after taking the shot. Optional.

Steps: one of the following.

Click: string - CSS or XPath locator of element to click. Waits for element 
        to be visible.
WaitForVisible: string - CSS or XPath locator of element to wait for.
WaitForHidden: string - CSS or XPath locator of element to wait for.
WaitForUrl: string - URL glob expression. Waits for URL to match expression.
Type: TypeStep - enters text into a location.
 - Element: string - CSS or XPath locator of element to type into.
 - Text: string - text to enter into the element.

Example:

    - Output: login.png
      WindowSize: 800x800
      Url: http://sod.superoffice.com/
      Element: "".containerInner""
      Before:
        - Type: 
            Element: ""#Username""
            Text: ""username@example.com""
        - Click: ""#nextButton""
        - Type: 
            Element: ""#Password""
            Text: ""{{LoginPassword}}"" # substitute with prop or env.var
      After:
        - Click: ""#loginButton""

");
            }
            return !o.ShotFileHelp;
        }

        private static void StartShooting(CommandLineOptions o)
        {
            o.Verbose = (o.VerboseCount > 0);
            o.VeryVerbose = (o.VerboseCount > 1);

            if (o.Verbose) Console.WriteLine("Starting Chromium browser");

            _playwright = Playwright.CreateAsync().Result;
            _chrome = _playwright.Chromium;
            BrowserTypeLaunchOptions? launchOptions = new BrowserTypeLaunchOptions()
            {
                Headless= !o.ShowBrowser,
            };
            _browser = _chrome.LaunchAsync(launchOptions).Result;

            BrowserNewPageOptions? options = new BrowserNewPageOptions()
            {
                ScreenSize = new ScreenSize() { Height = 600, Width = 900}
            };
            if (!string.IsNullOrEmpty(o.BaseUrl))
                options.BaseURL = o.BaseUrl;

            var page = _browser.NewPageAsync(options).Result;
            if (page.ViewportSize != null)
            {
                page.ViewportSize.Width = options.ScreenSize.Width;
                page.ViewportSize.Height = options.ScreenSize.Height;
            }
            if (string.IsNullOrEmpty(o.BaseUrl))
            {
                if (o.Verbose) Console.WriteLine("Opening {0}", o.BaseUrl);
                page.GotoAsync(o.BaseUrl).Wait();
                page.WaitForLoadStateAsync(LoadState.Load).Wait();
            }
            _page = page;
        }

        private static void ProcessShotsInFolder(CommandLineOptions o, string folder)
        {
            var files = Directory.GetFiles(folder, "*.shot");
            var dirs = Directory.GetDirectories(folder);

            // First each sub-dir
            foreach (var dir in dirs)
            {
                ProcessShotsInFolder(o, dir);
            }

            // Now all files in this dir
            foreach ( var file in files) 
            {
                ProcessShotFile(o, file);
            };
        }

        private static void ProcessShotsInFile(CommandLineOptions o, string filename)
        {
            Shot[]? shots = ReadShotsFile(o, filename);
            if (shots != null)
                foreach (var shot in shots)
                {
                    var f = shot.Output;
                    ProcessShot(o, shot, f);
                }
        }



        private static void ProcessShotFile(CommandLineOptions o, string filename)
        {
            filename = ProcessProps(o, filename);
            if (o.Verbose) Console.WriteLine("Shooting '{0}'", filename);
            Shot? shot = ReadShotFile(o, filename);
            if (shot != null)
                ProcessShot(o, shot, filename);           
        }

        private static void ProcessShot(CommandLineOptions o, Shot shot, string filename)
        {
            if (!string.IsNullOrEmpty(filename) && !Path.IsPathRooted(filename) && !string.IsNullOrEmpty(o.OutputDir))
                filename = Path.Combine(o.OutputDir, filename);

            try
            {
                PrepareTheShot(o, shot);
                TakeTheShot(o, filename, shot);
                CleanUpAfterTheShot(o, filename, shot);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("{0}: {1}", filename, ex.Message);
            }
        }

        private static void CleanUpAfterTheShot(CommandLineOptions o, string filename, Shot shot)
        {
            if (shot.After != null)
            {
                foreach (var step in shot.After)
                {
                    PerformStep(o, step);
                }
            }
        }

        private static Shot? ReadShotFile(CommandLineOptions o, string file)
        {
            try
            {
                InitYamlDetserializer();
                var yml = File.ReadAllText(file);
                if (yml != null)
                {
                    var shot = _yamlDeserializer.Deserialize<Shot>(yml);
                    return shot;
                }
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine("{0}: File error: {1}", file, ex.Message);
            }
            catch (YamlException ex)
            {
                Console.Error.WriteLine("{0}: {2}-{3}\nYAML Parsing: {1}", file, ex.Message, ex.Start, ex.End);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("{0}: Error: {1}", file, ex.Message);
            }
            return null;
        }

        private static void InitYamlDetserializer()
        {
            if (_yamlDeserializer == null)
            {
                _yamlDeserializer = new DeserializerBuilder()
                    .WithNamingConvention(PascalCaseNamingConvention.Instance)
                    .Build();
            }
        }

        private static Shot[]? ReadShotsFile(CommandLineOptions o, string file)
        {
            try
            {
                InitYamlDetserializer();
                var yml = File.ReadAllText(file);
                if (yml != null)
                {
                    var shots = _yamlDeserializer.Deserialize<Shot[]>(yml);
                    return shots;
                }
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine("{0}: File error: {1}", file, ex.Message);
            }
            catch( YamlException ex)
            {
                Console.Error.WriteLine("{0}: {2}-{3}\nYAML Parsing: {1}", file, ex.Message, ex.Start, ex.End);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("{0}: Error: {1}", file, ex.Message);
            }
            return null;
        }

        private static void PrepareTheShot(CommandLineOptions o, Shot shot)
        {
            if (!string.IsNullOrEmpty(shot.WindowSize))
            {
                var parts = ProcessProps(o, shot.WindowSize).Split('x');
                if (parts.Length > 1)
                {
                    int.TryParse(parts[0], out var width);
                    int.TryParse(parts[1], out var height);
                    if (_page.ViewportSize != null && width > 1 && height > 1)
                    {
                        if( o.VeryVerbose )
                            Console.WriteLine("Resizing to {0},{1}", width, height);
                        _page.ViewportSize.Width = width;
                        _page.ViewportSize.Height = height;
                    }
                }
            }
            if (!string.IsNullOrEmpty(shot.Url))
            {
                shot.Url = ProcessProps(o, shot.Url);
                if( o.Verbose) Console.WriteLine("Opening {0}", shot.Url);
                _page.GotoAsync(shot.Url).Wait();
                _page.WaitForLoadStateAsync(LoadState.Load).Wait();
            }
            if( shot.Before != null)
            {
                foreach(var step in shot.Before)
                {
                    PerformStep(o, step);
                }
            }
        }


        private static void PerformStep(CommandLineOptions o, ShotStep step)
        {
            if (!string.IsNullOrEmpty(step.Click))
                PerformClickStep(o, step);
            else
            if (step.Type != null)
            {
                if( !string.IsNullOrEmpty(step.Type.Text))
                    PerformTypeStep(o, step);
            }
            else
            if (!string.IsNullOrEmpty(step.WaitForUrl)) 
            { 
                PerformWaitForUrlStep(o, step);
            }
            else
            if (!string.IsNullOrEmpty(step.WaitForVisible))
            {
                PerformWaitForElementStep(o, step, true);
            }
            else
            if (!string.IsNullOrEmpty(step.WaitForHidden))
            {
                PerformWaitForElementStep(o, step, false);
            }
        }

        private static void PerformClickStep(CommandLineOptions o, ShotStep step)
        {
            step.Click = ProcessProps(o, step.Click);
            if (o.VeryVerbose) Console.WriteLine("  Clicking {0}", step.Click);
            var locator = GetLocator(step.Click);
            locator.ClickAsync().Wait();
        }

        private static void PerformTypeStep(CommandLineOptions o, ShotStep step)
        {
            step.Type.Element = ProcessProps(o, step.Type.Element);
            step.Type.Text = ProcessProps(o, step.Type.Text);
            if (o.VeryVerbose) Console.WriteLine("  Typing '{1}' into {0}", step.Type.Element, step.Type.Text);
            var locator = GetLocator(step.Type.Element);
            locator.ClickAsync().Wait();
            locator.FillAsync(step.Type.Text).Wait();
        }

        private static void PerformWaitForUrlStep(CommandLineOptions o, ShotStep step)
        {
            step.WaitForUrl = ProcessProps(o, step.WaitForUrl);

            if (o.VeryVerbose) Console.WriteLine("  Waiting for URL {0}\n  Current: {1}", step.WaitForUrl, _page.Url);
            _page.WaitForURLAsync(step.WaitForUrl).Wait();
        }

        private static void PerformWaitForElementStep(CommandLineOptions o, ShotStep step, bool visible)
        {
            var element = step.WaitForVisible != null ? step.WaitForVisible : step.WaitForHidden;
            element = ProcessProps(o, element);
            if (o.VeryVerbose) Console.WriteLine("  Waiting for element {0}", element);
            var options = new PageWaitForSelectorOptions() { 
                State = (visible ? WaitForSelectorState.Visible : WaitForSelectorState.Hidden) ,
                Strict = false,
                Timeout = 30000,
            };
            Thread.Sleep(100);
            var locator = GetLocator(element);
            var page = locator.Page;
            var elem = page.WaitForSelectorAsync(element, options).Result;
            bool isVis = elem?.IsVisibleAsync().Result ?? false;
            _page.WaitForTimeoutAsync(250).Wait(); // wait a little extra for luck
            Thread.Sleep(100);
        }

        private static void TakeTheShot(CommandLineOptions o, string file, Shot shot)
        {
            if (string.IsNullOrEmpty(file))
                return;

            // Save to same name as shot file
            file = ProcessProps(o, file);
            var fullname = Path.GetFullPath(file);
            fullname = Path.ChangeExtension(fullname, "png");
            // Locate element
            if (string.IsNullOrEmpty(shot.Element))
            {
                // Full-page shot
                var shotOptions = new PageScreenshotOptions()
                {
                    Path = fullname,
                    Type = ScreenshotType.Png,
                    FullPage= true,
                    Scale = ScreenshotScale.Device,
                };
                _page.ScreenshotAsync(shotOptions).Wait();
            }
            else
            {
                var locator = GetLocator(shot.Element);
                if (locator != null)
                {
                    var elemShotOptions = new LocatorScreenshotOptions()
                    {
                        Path = fullname,
                        Type = ScreenshotType.Png,
                        Scale = ScreenshotScale.Device,
                        
                    };
                    locator.ScreenshotAsync(elemShotOptions).Wait();
                }
                else
                    Console.Error.WriteLine("{0}: Failed to locate element: {1}", file, shot.Element);
            }
        }

        private static void FinishShooting(CommandLineOptions o)
        {
        }

        private static ILocator GetLocator(string element)
        {
            var locator = _page.Locator(element);
            if (!locator.IsVisibleAsync().Result)
            {
                // Check frames for locator
                var frames = _page.Frames;
                foreach (var frame in frames)
                {
                    frame.WaitForLoadStateAsync(LoadState.Load).Wait();
                    if (frame.Name == "") // main page - already checked
                        continue;

                    Thread.Sleep(100); // Wait a bit
                    var frameLocator = _page.FrameLocator("#" + frame.Name);
                    var locator1 = frameLocator.Locator(element);
                    if (locator1.IsVisibleAsync().Result)
                        return locator1;
                    var locator2 = frame.Locator(element);
                    if (locator2.IsVisibleAsync().Result)
                        return locator2;
                }
            }
            return locator;
        }

        private static string ProcessProps(CommandLineOptions o, string s)
        {
            s = s ?? "";
            var startPos = s.IndexOf("{{");
            while (startPos > -1)
            {
                var endPos = s.IndexOf("}}", startPos);
                var len = endPos - startPos - 2;
                var replacement = "";
                if (endPos > -1 && len > 0)
                {
                    var sub = s.Substring(startPos + 2, len);
                    replacement = o.Prop.FirstOrDefault(p => p.StartsWith(sub + "=", StringComparison.OrdinalIgnoreCase));
                    if (string.IsNullOrEmpty(replacement))
                    {
                        // check environment if no prop found
                        replacement = Environment.GetEnvironmentVariable(sub);
                        if( !string.IsNullOrEmpty(replacement))
                            if (o.VeryVerbose) Console.WriteLine("  Substituting '{0}' with env.var value '{1}'.", sub, replacement);
                    }
                    else // prop found
                    {
                        replacement = replacement.Substring(sub.Length + 1);
                        if (o.VeryVerbose) Console.WriteLine("  Substituting '{0}' with prop value '{1}'.", sub, replacement);
                    }
                    replacement = replacement ?? "";
                    s = s.Substring(0, startPos) + replacement + s.Substring(endPos + 2);
                    endPos = startPos + replacement.Length; // skip to end of replacement
                }
                // see if there are more
                startPos = s.IndexOf("{{", endPos);
            }
            return s;
        }

    }
}