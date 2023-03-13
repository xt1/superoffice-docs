using SuperOffice.SM.Resources;
using System.Collections;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;

Console.WriteLine("Generating glossary!");
string? basefilename = null;
string? allResourcesFilename = null;
if ( args.Length > 0)
{
    basefilename = args[0];
    Console.WriteLine("  using {0} as base.", basefilename);
}

if (args.Length > 1)
{
    allResourcesFilename = args[1];
    Console.WriteLine("  writing all resources to {0}", allResourcesFilename);
}

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

    filename = $"glossary-en-{langCode}.tmx";
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
        }
    }

    WriteLine("SR_COMMON_CONTACT");
    WriteLine("SR_BULKUPDATE_PLURAL_CONTACTS");

    WriteLines("SR_ARCHIVE_OUR_CONTACT", "SR_LIST_CATEGORY", "SR_ADMIN_TICKET_CATEGORIES", "SR_LIST_BUSINESS");
    WriteLine("SR_CONTACTSELECTIONARCHIVE_PERSONTARGET");
    WriteLine("SR_PL_PERSONS");

    WriteLines("SR_CRITERIONTYPE_PROJECT", "SR_PL_PROJECT_MEMBERS", "SR_PROJECTARCHIVE_TYPE", "SR_PROJECT_GUIDE_TABHEADER", "SR_LABELS_PROJECTMEMBERS", "SR_SINGULAR_PROJECTMEMBER");
    WriteLines("SR_PL_PROJECTS", "SR_FIND_PROJECT", "SR_LIST_PROJTYPE", "SR_PROJECT_GUIDE_TABHEADER");

    WriteLine("SR_SINGULAR_SALE");
    WriteLine("SR_PL_SALES");
    WriteLines("SR_ADMIN_SALE_TYPE_LABEL", "SR_ADMIN_SAINT_NAVITEM", "SR_ADMIN_SAINT", "SR_NETSERVER_LABEL_RIGHTS_SAINT", "SR_STATUS_MONITOR", "SR_ADMIN_STATUSMONITORS", "SR_STATUS_MONITORS", "SR_COUNTERS", "SR_ASN_LIST_COUNTER");

    WriteLines("SR_LIST_ASSOCIATE", "SR_ADMIN_LIST_TAB_USERGROUP", "SR_UDEF_PAGE1_USERGROUP", "SR_ADMIN_ROLE_MENUTEXT", "SR_ADMIN_USERS_LIST_LEVEL");
    WriteLine("SR_ADMIN_ROLE_EMPLOYEES");
    WriteLine("SR_ADMIN_ROLE_RELATION_OTHER");

    WriteLine("SR_SINGULAR_DOCTMPL");
    WriteLines("SR_LABEL_CHATADDRESS", "SR_CHAT_CHATS", "SR_CHAT_CHANNEL", "SR_CHAT_CHANNELS", "SR_SINGULAR_CHAT_CONVERSATION", "SR_PL_CHAT_CONVERSATION");
    WriteLine("SR_CHAT_REPLY_TEMPLATES");
    WriteLine("SR_FIELD_EJ_CATEGORY_REPLY_TEMPLATE_NAME");

    WriteLines("SR_CCC_CONFIGURATION", "SR_ORIGIN_CUSTCTR", "SR_TICKETARCHIVE_CUSTOMER", "SR_TICKETARCHIVE_CUSTOMERS");
    WriteLines("SR_SINGULAR_TICKET", "SR_PLURAL_TICKET", "SR_FIND_TICKET");
    WriteLines("SR_SINGULAR_SELECTION", "SR_FIND_SELECTION", "SR_BULKUPDATE_PLURAL_SELECTIONS");
    WriteLines(
        "SR_COMMON_APPOINTMENT",
        "SR_PLURAL_APPOINTMENT",
        "SR_AA_FOLLOWUPS",
        "SR_DA_TODO",
        "SR_CALL_BTN",
        "SR_PLURAL_PHONECALL",
        "SR_ACTIVITY_PHONE",
        "SR_BUTT_RING",
        "SR_MAIL_TASKS",
        "SR_ACTIVITY_TODO",
        "SR_SINGULAR_DOCTMPL",
        "SR_BUTT_DOCUMENT",
        "SR_AA_DOCUMENTS",
        "SR_DOC_TYPE",
        "SR_ADMIN_LIST_SHOW_CONTACTCARD",
       "SR_ADMIN_LIST_SHOW_PERSONCARD",
       "SR_ADMIN_LIST_SHOW_PROJECTCARD",
       "SR_ADMIN_LIST_SHOW_SELECTIONCARD",
       "SR_ADMIN_LIST_SHOW_SALEDIALOG",
       "SR_PANEL",
       "SR_COMMON_WEB_PANEL",
       "SR_WEBPANELS",
       "SR_FEATURES_FINDPANEL",
       "SR_FEATURES_MINICARDS",
       "SR_ADMIN_LIST_MINICARD",
       "SR_FEATURES_CARDS",
       "SR_COMMON_DASHBOARD",
       "SR_ADMIN_LIST_SHOW_DASHBOARD",
       "SR_DASHBOARD_NAV_TILES_PREVIEW_LABEL",
       "SR_DASHBOARD_NAV_NO_TILES",
       "SR_DIARY",
       "SR_EMAIL",
       "SR_ADMIN_USERS",
       "SR_USERS_OTHERS",
       "SR_FEATURES_NAVIGATOR",
       "SR_PL_RELATIONS",
       "SR_SINGULAR_RELATION",
       "SR_CRITERIONTYPE_TICKET",
       "SR_TICKET_MESSAGES1",
       "SR_CHAT_REQUEST_MESSAGE",
       "SR_DIALOG",
       "SR_PD_FilterDialog_NAME",
       "SR_ADMIN_LIST_SHOW_DOCUMENTDIALOG",
       "SR_FIND_BTN",
       "SR_FIND_COMPANY",
       "SR_FIND_PERSON",
       "SR_FIND_PROJECT",
       "SR_FIND_APPOINTMENT",
       "SR_SEARCH_DATE_CAPTION",
       "SR_FIND_TICKET",
       "SR_FIND_SELECTION",
       "SR_FIND_DOCUMENT",
       "SR_FIND_MAILING",
       "SR_FIND_SALE",
       "SR_SEARCH_FIND_COMPANIES",
       "SR_SEARCH_FIND_SALES",
       "SR_SEARCH_FIND_DOCUMENTS",
       "SR_SEARCH_FIND_PROJECTS",
       "SR_SEARCH_FIND_SELECTIONS",
       "SR_SEARCH_FIND_DOCUMENTS",
       "SR_SEARCH_FIND_APPOINTMENTS",
       "SR_FREETEXT",
       "FTS_CAPTION",
       "SR_QUOTE_SINGULAR_QUOTE", "SR_QUOTE_QUOTES_PLURAL",
       "SR_SINGULAR_QUOTECONNECTION",
       "SR_SINGULAR_QUOTEALTERNATIVE",
       "SR_SINGULAR_QUOTEVERSION",
       "SR_SINGULAR_PRODUCT",
       "SR_PRODUCT_PLURAL_PRODUCTS",
       "SR_PRODUCT_PRODUCTTYPE",
       "SR_PRODUCT_FAMILY_TOOLTIP",
       "SR_PRODUCT_CATEGORY_TOOLTIP",
       "SR_FIND_QUOTELINE",
       "SR_PL_MAILINGS",
       "SR_SINGULAR_MAILING",
       "SR_PERSONARCHIVE_NOMAILINGS",
       "SR_BULKUPDATE_FIELDVALUE_CONTACT_NOMAILINGS"
       );

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

void WriteEnder()
{
    xmlf.WriteEndElement(); // /body
    xmlf.WriteEndElement(); // /tmx
}

void WriteTerms(string a, string b)
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

void WriteLine(string rc)
{
    var a = en.GetString(rc)?.Replace('\t', ' ');
    var b = rs.GetString(rc)?.Replace('\t', ' ');
    if (a == null || b == null)
        Console.Error.WriteLine("Missing {0}", rc);
    else
        WriteTerms(a, b);
}

void WriteLines(params string[] args)
{
    foreach (var arg in args)
        WriteLine(arg);
}