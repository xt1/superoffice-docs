using System.Text.RegularExpressions;

Console.WriteLine("Fix Meta-data in Markdown files");
if( args.Length < 3)
{
    Help();
    return;
}

var verb = args[0].ToLowerInvariant();
var lang = args[1].ToLowerInvariant();
var dir = args[2];
if (verb != "save" && verb != "load")
{
    Help();
    return;
}

ProcessDir(verb, lang, dir);

void Help()
{
    Console.WriteLine("FixMetadata.exe VERB  lang  dir");
    Console.WriteLine();
    Console.WriteLine("VERB:");
    Console.WriteLine("  save    save metadata from MD files into .meta files.");
    Console.WriteLine("  load    load metadata from .meta files back into MD files.");
    Console.WriteLine("lang       ISO language code");
    Console.WriteLine("dir        Root directory");
}

void ProcessDir(string verb, string lang, string dir)
{
    foreach(var file in Directory.GetFiles(dir))
    {
        if( Path.GetExtension(file).Equals(".md", StringComparison.OrdinalIgnoreCase))
            ProcessMarkdownFile(verb, lang, file);
        if (Path.GetExtension(file).Equals(".yml", StringComparison.OrdinalIgnoreCase))
            ProcessYamlFile(verb, lang, file);
    }
    foreach (var subdir in Directory.GetDirectories(dir))
        ProcessDir(verb, lang, subdir);
}

void ProcessYamlFile(string verb, string lang, string filename)
{
    if (verb == "save")
        CreateYamlMdFile(filename, lang);
    if (verb == "load")
        LoadYamlMdFile(filename, lang);
}


void CreateYamlMdFile(string filename, string lang)
{
    string[] lines = File.ReadAllLines(filename); // foo.yml
    var mdFilename = Path.ChangeExtension(filename, ".yml.md");
    var mdFile = File.CreateText(mdFilename);
    var inFront = false;
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        var match = Regex.Match(line, @"(\w+) *: *([^#]+)");
        if( match.Success)
        {
            if (match.Groups.Count > 2)
            {
                var keyword = match.Groups[1].Value;
                var words = match.Groups[2].Value;
                if( keyword == "title" || keyword == "name" || keyword == "description" || keyword == "summary" || keyword == "text" )
                {
                    mdFile.WriteLine("{0}: {1}", i, words);
                    var prefix = $"{keyword} *:";
                    lines[i] = Regex.Replace(line, prefix + " *.*", $"{keyword}: [{i}]");
                }
            }
        }
    }
    mdFile.Flush();
    mdFile.Close();
    File.WriteAllLines(filename, lines);
}

void LoadYamlMdFile(string filename, string lang)
{
    string[] lines = File.ReadAllLines(filename); // foo.yml
    List<string> output = new();
    var mdFilename = Path.ChangeExtension(filename, ".yml.md");
    if (!File.Exists(mdFilename))
        return; // markdown does not belong yml file
    var links = ReadYmlMd(mdFilename);

    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        var match = Regex.Match(line, @"(\w+) *: *\[(\d+)\]");
        if (match.Success)
        {
            if (match.Groups.Count > 2)
            {
                var keyword = match.Groups[1].Value;
                var id = match.Groups[2].Value;
                if (keyword.Equals("title") || keyword == "description" || keyword == "summary" || keyword == "text")
                {
                    var prefix = $"{keyword} *:";
                    var words = links[id];
                    lines[i] = Regex.Replace(line, prefix + " *.*", $"{keyword}: {words}");
                }
            }
        }
    }
    File.WriteAllLines(filename, lines);
    File.Delete(mdFilename);
}

Dictionary<string,string> ReadYmlMd(string mdFilename)
{
    var res = new Dictionary<string, string>();
    var lines = File.ReadAllLines(mdFilename); // foo.yml.md
    foreach(var line in lines)
    {
        var match = Regex.Match(line, @"(\d+) *: *(.*)");
        if (match.Success)
        {
            if (match.Groups.Count > 2)
            {
                var id = match.Groups[1].Value;
                var words = match.Groups[2].Value;
                res[id] = words;
            }
        }
    }
    return res;
}

void ProcessMarkdownFile(string verb, string lang, string filename)
{
    if (filename.EndsWith(".yml.md", StringComparison.OrdinalIgnoreCase))
        return;
    if (verb == "save")
        CreateFile(filename, lang);
    if (verb == "load")
        LoadFile(filename, lang);
}

void CreateFile(string filename, string lang)
{
    string?[] lines = File.ReadAllLines(filename);
    var metaFilename = Path.ChangeExtension(filename, ".meta");
    var metaFile = File.CreateText(metaFilename);
    var inFront = false;
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        if (line.StartsWith("---"))
        {
            metaFile.WriteLine(line);
            inFront = !inFront;
            continue;
        }
        if (inFront)
        {
            if (line.StartsWith("title:", StringComparison.OrdinalIgnoreCase))
            {
                lines[i] = line.Replace("title:", "1:", StringComparison.OrdinalIgnoreCase);
                // leave it
            }
            else
            if (line.StartsWith("description:", StringComparison.OrdinalIgnoreCase))
            {
                lines[i] = line.Replace("description:", "2:", StringComparison.OrdinalIgnoreCase);
                // leave it - but sanitize the keyword so it does not get translated
            }
            else
            {
                if (line.StartsWith("uid:", StringComparison.OrdinalIgnoreCase))
                {
                    if (line.Contains("-en-"))
                        line = line.Replace("-en-", "-" + lang + "-");
                    else
                        line = line.TrimEnd() + "-" + lang;
                }
                if (line.StartsWith("language:", StringComparison.OrdinalIgnoreCase))
                    line = "language: " + lang;
                metaFile.WriteLine(line); // save for later
                lines[i] = null; // remove from file
            }
        }
        else // not in front-matter
        {
            // Link definitions
            var match = Regex.Match(line, @"^\s*\[\w+\]\s*:\s*");
            if (match.Success)
            {
                metaFile.WriteLine(line);
            }
        }
    }
    metaFile.Flush();
    metaFile.Close();
    IEnumerable<string> newLines = lines.Where(l => l != null);
    File.WriteAllLines(filename, newLines);
}

void LoadFile(string filename, string lang)
{
    string?[] lines = File.ReadAllLines(filename);
    List<string> output = new ();
    var metaFilename = Path.ChangeExtension(filename, ".meta");
    if (!File.Exists(metaFilename))
        return; // markdown belongs to yml file
    var (frontmatter, links) = ReadMetafile(metaFilename);
    var inFront = false;
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        if (line.StartsWith("---"))
        {
            if (inFront)
            {
                output.AddRange(frontmatter);
            }
            inFront = !inFront;
            output.Add(line);
            continue;
        }
        if (inFront)
        {
            // keep it
            line = line.Replace("1:", "title:");
            line = line.Replace("2:", "description:");
            output.Add(line);
        }
        else // not in front-matter
        {
            // Link definitions
            var match = Regex.Match(line, @"^\s*\[(\w+)\]\s*:\s*");
            if (match.Success)
            {
                var key = match.Groups[0].Value;
                if (links.TryGetValue(key, out string link))
                    output.Add(link);
                else
                    output.Add(line.Replace(" ", ""));
            }
            else // not a link
            {
                output.Add(line);
            }
        }
    }
    File.WriteAllLines(filename, output);
    File.Delete(metaFilename);
}

(string[] frontmatter, Dictionary<string,string> links) ReadMetafile(string metaFilename)
{
    var lines = File.ReadAllLines(metaFilename);
    var inFront = false;
    var frontmatter = new List<string>();
    var links = new Dictionary<string, string>();
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        if (line.StartsWith("---"))
        {
            inFront = !inFront;
            continue;
        }
        if (inFront)
        {
            frontmatter.Add(line);
        }
        else // body
        {
            // Link definitions
            var match = Regex.Match(line, @"^\s*\[(\w+)\]\s*:\s*");
            if (match.Success)
            {
                var key = match.Groups[0].Value;
                links[key] = line;
            }
        }
    }
    return (frontmatter.ToArray(), links);
}