Console.WriteLine("Squishing lots of text files together into single-letter files, based on initial letter in filename");

if( args.Length < 5)
{
    Console.WriteLine("SquishTextFiles kind dir1 dir2 langcode1 langcode2");
    Console.WriteLine("  kind = all | long");
    return;
}

var kind = args[0].ToLowerInvariant();

var lang1 = args[1];
var lang2 = args[2];

var langcode1 = args[3];
var langcode2 = args[4];

Console.WriteLine("Squishing {2} {0} and {1}", lang1, lang2, kind);

CleanDestFiles(lang1);

CleanDestFiles(lang2);

SquishFilesIn(lang1, lang2, langcode1, langcode2, kind);

void CleanDestFiles(string lang1)
{
    var orgFiles = Directory.GetFiles(lang1, "?_??.txt");
    foreach (var f in orgFiles)
        File.Delete(f);
}

void SquishFilesIn(string orgDir, string langDir, string orgLang, string langCode, string kind)
{
    var orgFiles = Directory.GetFiles(orgDir, "*.txt");
    var langFiles = Directory.GetFiles(langDir, "*.txt");
    var orgNames = orgFiles.Select(f => Path.GetFileNameWithoutExtension(f).ToLowerInvariant()).Select( s => s.Substring(0, s.Length -3));
    var langNames = langFiles.Select(f => Path.GetFileNameWithoutExtension(f).ToLowerInvariant()).Select(s => s.Substring(0, s.Length - 3)); ;
    foreach (var orgFile in orgFiles)
    {
        var orgFileName = Path.GetFileName(orgFile).ToLowerInvariant();
        var orgName = Path.GetFileNameWithoutExtension(orgFile).ToLowerInvariant();
        orgName = orgName.Substring(0, orgName.Length - 3);
        if (langNames.Contains(orgName))
        {
            SquishFile(orgDir, langDir, orgFileName, orgLang, langCode, kind);
        }
        else
            Console.Error.WriteLine("Skipping {0}", orgName);
    }
}

void SquishFile(string orgDir, string langDir, string fileName, string orgLang, string langCode, string kind)
{
    var baseName = Path.GetFileNameWithoutExtension(fileName).ToLowerInvariant();
    if (baseName.Length < 5)
        return;
    baseName = baseName.Substring(0, baseName.Length - 3); 
    var orgFile = Path.Combine(orgDir, $"{baseName}_{orgLang}.txt");
    var langFile = Path.Combine(langDir, $"{baseName}_{langCode}.txt");
    var orgDest = Path.Combine(orgDir, $"{baseName[0]}_{orgLang}.txt");
    var langDest = Path.Combine(langDir, $"{baseName[0]}_{langCode}.txt");

    if (kind == "all")
    {
        File.AppendAllText(orgDest, File.ReadAllText(orgFile) + "\r\n\r\n");
        File.AppendAllText(langDest, File.ReadAllText(langFile) + "\r\n\r\n");
    }
    else
    {
        var org = File.ReadAllLines(orgFile);
        var lang = File.ReadAllLines(langFile);
        for(int i = 0; i< org.Length; i++)
        {
            if (org[i].Length < 40)
            {
                org[i] = "";
                if( i < lang.Length)
                    lang[i] = "";
            }
        }
        var orgLines = string.Join("\r\n", org.Where( s => s.Length > 5));
        var langLines = string.Join("\r\n", lang.Where(s => s.Length > 5));

        File.AppendAllText(orgDest, orgLines + "\r\n\r\n");
        File.AppendAllText(langDest, langLines + "\r\n\r\n");

    }
}
