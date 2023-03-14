<!-- markdownlint-disable-file MD041 -->
Seksjon 1 i koden viser hvordan parametrene som kreves av `GetArchiveListByColumns` metoden er opprettet:

* kolonnene som skal inkluderes i utvalget
* Søkebegrensningene
* rekkefølgen resultatene skal sorteres i
* enhetene som skal inkluderes i søket

[!code-csharp[CS]](../itunes-setdatagrid.cs?range=1-45)

Deretter opprettes et `ArchiveAgent` objekt. Deretter `GetArchiveListByColumns` påkalles metoden for å få aktivitetsinformasjonen.
