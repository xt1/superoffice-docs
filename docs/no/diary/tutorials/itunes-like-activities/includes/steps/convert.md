<!-- markdownlint-disable-file MD041 -->Det neste trinnet er å konvertere de hentede aktivitetsdataene til et format som kan vises i et datarutenett.

[!code-csharp[CS]](../itunes-setdatagrid.cs?range=46-102)

Her har vi valgt å iterere over den hentede `ArchiveListItem` samlingen og innkapsle disse dataene i en egendefinert objekttype kalt `ActivityData` som representerer et aktivitetsobjekt uavhengig av den underliggende generiske aktivitetstypen (Salg, Dokument eller Avtale).

Først har vi laget en matrise av type `ActivityData`, typen som brukes til å holde aktivitetsdata. Samlingen `ArchiveListItems` gjentas og dataverdiene trekkes ut for hver og `ArchiveListItem` lagres i  en `ListDictionary`, som inneholder detaljer om en aktivitet om gangen.

Deretter `ActivityData` opprettes objektene basert på data i `ListDictionary` matrisen `ActivityData` . Aktivitetstypen kontrolleres når objektet opprettes, og `ActivityData` enhetsspesifikk informasjon, for eksempel `SaleId`  , `AppointmentId`, og `DocumentId` tilordnes.

### AktivitetData-transportør

Ta en titt på den generiske `ActivityData` klassen, som brukes til å holde aktivitetsdata som nevnt i forrige avsnitt.

**Egenskaper:**

* Daddel
* Id
* Beskrivelse
* Aktivitetstype (Dokument, Salg eller Avtale)
* Navnet på Prosjekt som er knyttet til en aktivitet

[!code-csharp[CS]](../itunes-activitydata.cs)
