<!-- markdownlint-disable-file MD041 -->
Seksjon 1 i koden viser hvordan parameterne som kreves av `GetArchiveListByColumns` metoden, opprettes:

* kolonnene som skal inkluderes i utvalget
* søkebegrensningene
* i hvilken rekkefølge resultatene skal sorteres
* hvilke enheter som skal inkluderes i søket

[!code-csharp[CS](../itunes-setdatagrid.cs?range=1-45)]

Deretter opprettes et `ArchiveAgent` objekt. Da `GetArchiveListByColumns` aktiveres metoden for å hente aktivitetsinformasjonen.
