using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml;

Console.WriteLine("Translate folder!");
if( args.Length < 4 )
{
    Console.WriteLine("TranslateFolder  source-folder  dest-folder  to-langcode  categoryId  [glossary-file] [...]");
    return;
}
var sourceDir = args[0];
var destDir = args[1];
var toLangCode = args[2];
var categoryId = args[3];
var glossaryFile = args.Length > 4 ? args[4] : "";
var rest = args.Skip(5);

if( glossaryFile.Length > 1)
    Console.WriteLine("with glossary '{0}'", glossaryFile);

TranslateFolder(sourceDir, destDir, toLangCode, categoryId, glossaryFile, rest);

void TranslateFolder(string sourceDir, string destDir, string toLangCode, string categoryId, string glossaryFile, IEnumerable<string> rest)
{
    Console.WriteLine("Translating {0} to {1}", sourceDir, destDir);
    var doctr = Environment.GetEnvironmentVariable("DOCTR") ?? "doctr.exe";
    ProcessStartInfo info = new ProcessStartInfo(doctr);

    info.ArgumentList.Add("translate");
    info.ArgumentList.Add(sourceDir);
    info.ArgumentList.Add(destDir);
    info.ArgumentList.Add("--from:en");
    info.ArgumentList.Add("--to:" + toLangCode);
    info.ArgumentList.Add("--category:" + categoryId);
    if (glossaryFile.Length > 1)
    {
        info.ArgumentList.Add("--glossary");
        info.ArgumentList.Add(glossaryFile);
    }
    foreach(var arg in rest)
        info.ArgumentList.Add(arg);

    info.CreateNoWindow = true;
    info.UseShellExecute = false;

    var proc = Process.Start(info);
    proc?.WaitForExit();

    // UnfuckFilesIn(destDir);

    var subdirs = Directory.GetDirectories(sourceDir);
    foreach(var subdir in subdirs)
    {
        //C:\Git\superoffice-docs\docs\en\admin
        var name = Path.GetFileName(subdir);
        TranslateFolder(subdir, Path.Combine(destDir, name), toLangCode, categoryId, glossaryFile, rest);
    }
}

void UnfuckFilesIn(string destDir)
{
    var files = Directory.GetFiles(destDir);
    foreach (var file in files)
    {
        UnfuckFile(file);
    }
}

void UnfuckFile(string file)
{
    var lines = File.ReadAllLines(file);
    for (int i = 0; i < lines.Length; ++i)
        lines[i] = UnfuckLine(lines[i]);
    File.WriteAllLines(file, lines);
}

string UnfuckLine(string line)
{
    // ** dialogboksene** Avtale**, Oppgave**, **Samtale** og **Dokument**: 
    line = Regex.Replace(line, @"\*\*([,.]+) (\w+)\*\*", "**$1 **$2**");
    line = Regex.Replace(line, @"\*\*([,.]+) (\w+)\*\*", "**$1 **$2**");

    line = Regex.Replace(line, @"\*\* (\w+)\*\* ", "$1 **");
    return line;
}