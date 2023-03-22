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
            if (line.StartsWith("keywords:", StringComparison.OrdinalIgnoreCase))
            {
                lines[i] = line.Replace("keywords:", "3:", StringComparison.OrdinalIgnoreCase);
                // leave it - but sanitize the keyword so it does not get translated
            }
            else
            {
                if (line.StartsWith("uid:", StringComparison.OrdinalIgnoreCase))
                {
                    if (line.Contains("-en-"))
                        line = line.Replace("-en-", "-" + lang + "-");
                    else
                    if (line.EndsWith("-en"))
                        line = line.Substring(0, line.Length-3) + "-" + lang;
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
            line = line.Replace("3:", "keywords:");
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
                    output.Add(line.Replace(" ", "")); // fallback - just trim the spaces.
            }
            else // not a link
            {
                line = Unfuck(line);
                output.Add(line);
            }
        }
    }
    File.WriteAllLines(filename, output);
    File.Delete(metaFilename);
}

string Unfuck(string line)
{
    // ** dialogboksene** Avtale**, Oppgave**, **Samtale** og **Dokument**: 
    if (CountBolds(line) % 2 == 1)
    {
        // line = Regex.Replace(line, @"\*\*([,.]+) (\w+)\*\*", "**$1 **$2**");

    }


    line = line.Replace("** .", "**."); // Closing bold
    line = line.Replace("** :", "**:");
    line = line.Replace(" ] [", "][");
    line = line.Replace("] [", "][");

    // Fix malformed markdown bold text
    // from: "something here ** Legg til hendelse ** and more here**matches here ** too, and maybe even ** one more**test."
    //   to: "something here **Legg til hendelse** and more here **matches here** too, and maybe even **one more** test."

    line = Regex.Replace(line, @"\s?\*\*(.*?)\*\*\s?", m => $" **{m.Groups[1].Value.Trim()}** ");

    // Fix uppercased image links
    // from: "Here is a sentence that should contain an image link that looks like this [Img][33], so [Img33][33] does this work [Img3][4], [Img33][4]? Does this work on normal [Something][3] too`?";
    //   to: "Here is a sentence that should contain an image link that looks like this [img][33], so [img33][33] does this work [img3][4], [img33][4]? Does this work on normal [Something][3] too`?";
    // _container.RegularExpressions.Add(@"\[Img\d*\]\[\d+\]", m => $"{m.Groups[0].Value.ToLower()}");
    line = Regex.Replace(line, @"\[Img", m => $"{m.Groups[0].Value.ToLower()}");

    // Fix malformed markdown NOTE and TIP and WARN text
    // from: "something here [! TIP] and [! WARN] and [! NOTE] here."
    //   to: "something here [!TIP] and [!WARN] and [!NOTE] here."
    line = Regex.Replace(line, @"\[\s?!\s?\w+\s?\]", m => $"{m.Groups[0].Value.Replace(" ", "")}");

    // Fix malformed markdown image links
    // from: "I tjeneste: Velg ! [ikon] [img2] va da ![ some] [more ] here and one more with a digit ![ some] [4 ].""
    //   to: "I tjeneste: Velg ![ikon][img2] va da ![some][more] here and one more with a digit ![some] [4].""
    // _container.RegularExpressions.Add(@"\!\s?\[\s?|\w*\]\s?\[\s?\w+\s?\]", m => $"{m.Groups[0].Value.Replace(" ", string.Empty)}");

    // Fix instances where there is no space between a word and a markdown image link.
    // from: "I tjeneste: Velg![ikon][img2]"
    //   to: "I tjeneste: Velg ![ikon][img2]"
    line = Regex.Replace(line, @"[a-zA-Z]\!\s?\[", m => $"{m.Groups[0].Value.Replace("!", " !")}");

    return line;
}

int CountBolds(string line)
{
    int c = 0;
    int idx = line.IndexOf("**");
    while( idx < line.Length && idx > 0)
    {
        c++;
        idx = line.IndexOf("**", idx);
    }
    return c;
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