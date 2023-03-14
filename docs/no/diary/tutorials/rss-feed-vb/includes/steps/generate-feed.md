<!-- markdownlint-disable-file MD041 -->
[!kode-vb [VB](../rss-page.vb?range=71-174)]

[!kode-vb[VB](../rss-page.vb?range=199-208)]

Avsnitt 2 viser hvordan du ved hjelp av spørringsresultatene genererer RSS-feeden. Her har vi valgt å iterere over den hentede samlingen `ArchiveListItem` . Den trekker ut dataverdier for hver `ArchiveListItem` og lagrer dem i en `ListDictionary`.

Den `ListDictionary` inneholder detaljer om en aktivitet om gangen. Deretter settes følgende `item` underelementverdier basert på data i `ListDictionary`:

* tittel
* lenke
* beskrivelse
* pubDate
* dc:skaper

Som vist i feedkodesegmentet er dette dataene det refereres til i `<%= _items %>` det databindende uttrykket.

<!-- Referenced links -->
