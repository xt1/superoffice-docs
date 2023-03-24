<!-- markdownlint-disable-file MD041 -->Når dataene er hentet, kan vi filtrere dataene i henhold til søketeksten som er angitt av brukeren.

[!code-csharp[CS](../itunes-searchtext.cs)]

Innsamlingen `DataGridViewRow` av datarutenettvisningen gjentas for hver aktivitetsdatarad, og det er merket av i kolonnen Beskrivelse for å se om beskrivelsen inneholder søketeksten. Hvis aktivitetsbeskrivelsen ikke inneholder den angitte teksten, blir raden ikke synlig. Denne metoden aktiveres ved `TextChanged` søk i tekstboksen som vist nedenfor.

```csharp
using (SoSession newSession = SoSession.Authenticate("p", "p"))
{
  // populate the grid with all the activities for the given period
  this.setDataGrid();

  // filter the records
  this.searchText();
}
```
