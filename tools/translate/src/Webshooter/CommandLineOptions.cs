using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshooter
{
    internal class CommandLineOptions
    {
        [Value(0, Required = true, HelpText = "YML file or folders to search for .shot files")]
        public IEnumerable<string> BaseFolder { get; set; }

        [Option('p', "prop", Required = false, HelpText = "Define property that can be {{referenced}} in shot files")]
        public IEnumerable<string> Prop { get; set; }


        [Option('v', "verbose", Required = false, FlagCounter = true, HelpText = "Set output to verbose messages. Use -vv for more verbosity.")]
        public int VerboseCount { get; set; }

        public bool Verbose { get; set; }
        public bool VeryVerbose { get; set; }

        [Option('s', "show", Required = false, HelpText = "Show browser window.")]
        public bool ShowBrowser{ get; set; }

        [Option('u', "url", Required = false, HelpText = "Base URL to use for requests.")]
        public string BaseUrl { get; set; }

        [Option('o', "outputDir", Required = false, HelpText = "Output directory for images.")]
        public string OutputDir { get; set; }

        [Option('H', "shotFileHelp", Required = false, HelpText = "Describe shot file format.")]
        public bool ShotFileHelp { get; set; }

        public CommandLineOptions()
        {
            BaseFolder = Array.Empty<string>();
            Prop = Array.Empty<string>();
            BaseUrl = "";
            OutputDir = "";
        }
    }
}
