using SuperOffice.SM.Resources;
using System.Collections;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;

Console.WriteLine("Generating glossary");
string? basefilename = null;
string? allResourcesFilename = null;
if (args.Length == 0)
{
    Console.WriteLine("GenGlossary.exe outputFilename.ext  [basedOn.tsv]  [allresourceFilename.align]");
    return;
}

string outputFilename = args[0];

if ( args.Length > 1)
{
    basefilename = args[1];
    Console.WriteLine("  using {0} as base.", basefilename);
}

if (args.Length > 2)
{
    allResourcesFilename = args[2];
    Console.WriteLine("  writing all resources to {0}", allResourcesFilename);
}

bool isTmx = Path.GetExtension(outputFilename).Equals(".tmx", StringComparison.OrdinalIgnoreCase);

var en = ResourceStrings.ResourceManager.GetResourceSet(CultureInfo.GetCultureInfo("en"), true, true);
var rs = ResourceStrings.ResourceManager.GetResourceSet(CultureInfo.GetCultureInfo("sv"), true, true);
StreamWriter outf;
XmlTextWriter xmlf;
string langCode;
string filename;

string[] langs = { "no", "de", "nl", "sv", "da", "fr" };
foreach (var lang in langs)
{
    langCode = lang;
    if (lang == "no")
        langCode = "nb";

    rs = ResourceStrings.ResourceManager.GetResourceSet(CultureInfo.GetCultureInfo(lang), true, true);

    if (allResourcesFilename != null && en != null && rs != null)
    {
        GenerateAllResourceFile(allResourcesFilename, rs, langCode);
    }

    filename = $"{Path.GetFileNameWithoutExtension(outputFilename)}-en-{langCode}{Path.GetExtension(outputFilename)}";
    Console.WriteLine("Creating {0}", filename);
    outf = File.CreateText(filename);
    xmlf = new XmlTextWriter(outf);

    WriteHeader("en", langCode);
    if (basefilename != null)
    {
        var lines = File.ReadAllLines(basefilename);
        foreach (var line in lines)
        {
            var parts = line.Split('\t');
            if (parts.Length > 1)
            {
                WriteTerms(parts[0], parts[1]);
            }
            else
            {
                WriteLine(parts[0].Trim());
            }
        }
    }
    WriteEnder();
    xmlf.Flush();
    outf.Flush();
    xmlf.Close();
    outf.Close();
}

string Sanitize(string b)
{
    b = b.Replace("...", " ");
    b = b.Replace("\\t", " ");
    b = b.Replace("\\r", " ");
    b = b.Replace("\\n", " ");
    b = b.Replace("\r", " ");
    b = b.Replace("\n", " ");
    b = b.Trim();
    return b;
}

void GenerateAllResourceFile(string allResourcesFilename, ResourceSet rs, string langCode)
{
    var tmpResourcesFilename = Path.Combine(Path.GetDirectoryName(allResourcesFilename), Path.GetFileNameWithoutExtension(allResourcesFilename));
    tmpResourcesFilename += "-" + langCode;
    int count = 1;
    var enResourceFilename = tmpResourcesFilename + count + "_en.align";
    var rsResourcesFilename = tmpResourcesFilename + count + "_" + langCode + ".align";
    Console.WriteLine("Creating {0}", rsResourcesFilename);
    var enf = File.CreateText(enResourceFilename);
    var outf = File.CreateText(rsResourcesFilename);
    int n = 0;
    foreach (DictionaryEntry r in en)
    {
        var key = r.Key as string;
        if (!string.IsNullOrEmpty(key))
        {
            var v = r.Value as string;
            if (! string.IsNullOrEmpty(v) && !v.Contains("~") && !v.Contains("<") && Regex.Match(v, @"^\w").Success)
            {
                var b = rs.GetString(key) ?? "";
                b = Sanitize(b);
                v = Sanitize(v);
                if( !string.IsNullOrEmpty(b) && !string.IsNullOrEmpty(v) && b.Length > 2 && v.Length > 2)
                {
                    enf.WriteLine(v);
                    outf.WriteLine(b);
                    n++;
                    if (n % 10 == 0)
                    {
                        enf.WriteLine();
                        outf.WriteLine();
                    }
                    if (n % 100 == 0)
                    {
                        enf.WriteLine();
                        outf.WriteLine();
                    }
                    if (n % 50000 == 0)
                    {
                        outf.Flush();
                        outf.Close();
                        enf.Flush();
                        enf.Close();
                        count++;
                        enResourceFilename = tmpResourcesFilename + count + "_en.align";
                        rsResourcesFilename = tmpResourcesFilename + count + "_" + langCode + ".align";
                        enf = File.CreateText(enResourceFilename);
                        outf = File.CreateText(rsResourcesFilename);
                    }
                }
            }
        }
    }
    outf.Flush();
    outf.Close();
    enf.Flush();
    enf.Close();
}

void WriteHeader(string langCode1, string langCode2)
{
    if (isTmx)
    {
        // xmlf.WriteStartDocument();
        xmlf.Formatting = Formatting.Indented;
        xmlf.WriteStartElement("tmx", "http://www.lisa.org/tmx14");
        xmlf.WriteAttributeString("version", "1.4");
        xmlf.WriteStartElement("header");
        xmlf.WriteAttributeString("creationtool", "superoffice");
        xmlf.WriteAttributeString("creationtoolversion", "1.0");
        xmlf.WriteAttributeString("datatype", "plaintext");
        xmlf.WriteAttributeString("segtype", "phrase");
        xmlf.WriteAttributeString("srclang", langCode1);
        xmlf.WriteAttributeString("o-tmf", "SuperOfficeResources");
        xmlf.WriteEndElement();

        xmlf.WriteStartElement("body");
    }
    else
    {
        outf.WriteLine("{0}\t{1}", langCode1, langCode2);
    }
}

void WriteEnder()
{
    if (isTmx)
    {
        xmlf.WriteEndElement(); // /body
        xmlf.WriteEndElement(); // /tmx
    }
    else
    {
        outf.WriteLine();
    }
}

void WriteTerms(string a, string b)
{
    if (isTmx)
    {
        xmlf.WriteStartElement("tu");

        xmlf.WriteStartElement("tuv");
        xmlf.WriteAttributeString("xml", "lang", null, "en");
        xmlf.WriteStartElement("seg");
        xmlf.WriteString(a);
        xmlf.WriteEndElement();
        xmlf.WriteEndElement();

        xmlf.WriteStartElement("tuv");
        xmlf.WriteAttributeString("xml", "lang", null, langCode);
        xmlf.WriteStartElement("seg");
        xmlf.WriteString(b);
        xmlf.WriteEndElement();
        xmlf.WriteEndElement();

        xmlf.WriteEndElement(); // /tu
    }
    else
    {
        outf.WriteLine("{0}\t{1}", a, b);
    }

}

void WriteLine(string rc)
{
    var a = en.GetString(rc)?.Replace('\t', ' ');
    var b = rs.GetString(rc)?.Replace('\t', ' ');
    if (a == null || b == null)
        Console.Error.WriteLine("Missing {0}", rc);
    else
    {
        WriteTerms(a, b);
        WriteTerms($"**{a}**", $"**{b}**");
    }
}

void WriteLines(params string[] args)
{
    foreach (var arg in args)
        WriteLine(arg);
}