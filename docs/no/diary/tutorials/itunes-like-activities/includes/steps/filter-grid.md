<!-- markdownlint-disable-file MD041 -->Når dataene er hentet, kan vi filtrere dataene i henhold til søketeksten spesifisert av brukeren.

[!code-csharp[CS]](../itunes-searchtext.cs)

Samlingen `DataGridViewRow` av datarutenettvisningen gjentas for hver aktivitetsdatarad, og Beskrivelse-kolonnen kontrolleres for å se om beskrivelsen inneholder søketeksten. Hvis aktivitetsbeskrivelsen ikke inneholder den angitte teksten, usynliggjøres raden. Denne metoden påkalles i `TextChanged` tilfelle søketekstboksen som vist nedenfor.

```csharp
using (SoSession newSession = SoSession.Authenticate("p", "p"))
{
  // populate the grid with all the activities for the given period
  this.setDataGrid();

  // filter the records
  this.searchText();
}
```
