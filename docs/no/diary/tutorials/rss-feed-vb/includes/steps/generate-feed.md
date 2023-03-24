<!-- markdownlint-disable-file MD041 -->
[!kode-vb [100 000 00](../rss-page.vb?range=71-174)

[!kode-vb[VB](../rss-page.vb?range=199-208)]

Seksjon 2 viser hvordan du genererer RSS-feeden ved hjelp av spørringsresultatene. Her har vi valgt å iteratere over den hentet `ArchiveListItem` samlingen. Den henter ut dataverdier for hver `ArchiveListItem` og lagrer dataverdiene i en `ListDictionary`.

Her `ListDictionary` finner du detaljer om én aktivitet om gangen. Deretter angis følgende `item` underelementverdier basert på data i `ListDictionary`:

* Tittel
* Link
* Beskrivelse
* pubDato
* dc:skaper

Som det fremgår av feedkode-segmentet, er dette dataene  som `<%= _items %>` det databindende uttrykket henviser til.

<!-- Referenced links -->
