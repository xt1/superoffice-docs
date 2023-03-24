<!-- markdownlint-disable-file MD041 -->Det neste trinnet er å gjøre de hentet aktivitetsdataene om til et format som kan vises i et datarutenett.

[!code-csharp[CS](../itunes-setdatagrid.cs?range=46-102)]

Her har vi valgt å iterere over den hentet `ArchiveListItem` samlingen og innkapsling av disse dataene i en egendefinert objekttype som kalles, `ActivityData` som representerer et aktivitetsobjekt uavhengig av den underliggende generiske aktivitetstypen (Salg, Dokument eller Avtale).

Først har vi opprettet en type matrise `ActivityData`, typen som brukes til å holde aktivitetsdata. Samlingen `ArchiveListItems` gjentas, og dataverdiene hentes ut for hver `ArchiveListItem` og lagret i en `ListDictionary`, som inneholder detaljer om én aktivitet om gangen.

Deretter `ActivityData` opprettes objektene basert på data i `ListDictionary` og lagret i `ActivityData` matrisen. Typen aktivitet kontrolleres på tidspunktet for oppretting av `ActivityData` objektet og den enhetsspesifikke informasjonen, for eksempel `SaleId`, `AppointmentId`og `DocumentId` tilordnes.

### ActivityData-transportør

Ta en titt på den generiske `ActivityData` klassen, som brukes til å holde aktivitetsdata som nevnt i forrige seksjon.

 **Egenskaper:** 

* Dato
* Id
* Beskrivelse
* Aktivitetstype (Dokument, Salg eller Avtale)
* Navnet på Prosjekt knyttet til en aktivitet

[!code-csharp[CS](../itunes-activitydata.cs)]
