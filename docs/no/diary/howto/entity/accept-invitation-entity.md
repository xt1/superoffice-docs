---
title: Slik godtar du en invitasjon (datalag)
description: Slik godtar du en invitasjon ved hjelp av enheter på NetServer-datalaget.
keywords: dagbok, kalender, avtale, API, enhet, InvitationProvider, ArchiveRows, AppointmentMatrix
uid: accept_invitation_entity-no
author: Bergfrid Skaara Dias
so.date: 03.04.2022
so.topic: howto
# so.envir:
# so.client:
---

# Slik godtar du en invitasjon (datalag)

Når du forsøker å godta en [Invitasjon][2], tenker du på to ting:

* Hva er metoden for å hente invitasjonene?
* Hva er invitasjonene vi skal godta?

Vi skal bygge et eksempel som bruker leverandørene til å hente en invitasjon. La oss deretter godta den første invitasjonen i listen som har en invitasjonsdato som er større enn i dag.

## Koden

[!code-csharp[CS](includes/accept-invite-entity.cs)]

## Gjennomgang

> [!NOTE]Leverandørkonseptet er et svært kraftig verktøy som finnes i NetServer. Det finnes mange typer leverandører, og hovedformålet til leverandørene er å hente noen spesifikke data ved hjelp av noen restriksjoner vi ønsker.
> 
I eksemplet ovenfor har vi brukt `InvitationProvider` for å få de invitasjonene vi ønsker (for de angitte begrensningskriteriene). I en leverandør kan vi angi kolonnene vi ønsker å hente, i så fall `appointmentId`. Vi har også angitt hvordan vi vil at dataene skal sorteres ved hjelp `setOrderBy` av leverandørens metode.

I - `InvitationProvider`- en begrensning for `associateId` er det et must, siden vi prøver å hente ut invitasjoner fra en medarbeider. Hvis du ikke angir denne begrensningen, vil NetServer gi et unntak. Etter å ha angitt den obligatoriske begrensningen, kan du gi andre begrensninger, i så fall invitasjoner som ligger før gjeldende dato.

Nå har vi gitt all informasjon til leverandøren, og alt som gjenstår er å utføre den og få resultatene.

Leverandøren kjøres ved å ringe `GetRows` metoden til leverandøren, som vil returnere et sett med `ArchiveRows` at vi kan sløyfe gjennom. Dataene i radene er representert som nøkkelverdipar.

Leverandørene tilbyr flere måter å hente data på. Her har vi brukt `GetDisplayValue` for å få verdien av kolonnen vi gir som parameter til metoden. Nærmere bestemt verdien for `appointmentId` kolonnen.

Verdiene som returneres, formateres på en spesiell måte som er unik for NetServer, slik at for å formatere verdiene som en normal streng som passer til formateringen av regionen din, kan vi bruke metodene [CultureDataFormatter-klasse][1] som finnes i `SuperOffice.CRM.Globalization` navnerommet.

Hvis du analyserer koden ovenfor, kan du se at vi har hoppet ut av løkken vår som går gjennom de returnerte postene. Det er fordi vi i begynnelsen har satt oss en antagelse om at vi skal akseptere den første invitasjonen i den returnerte listen.

Til slutt har vi brukt [AvtaleMatrix][3] til å godta invitasjonen vi hentet. Matrisen brukes i NetServer til å håndtere ulike typer invitasjoner som finnes i SuperOffice applikasjonen.

> [!NOTE]
> Som standard `InvitationProvider` filtrerer den bare avtalen som følger under følgende statusdefinisjoner. Det har NetServer gjort siden du bare vil godta avtalene som har følgende statusdefinisjoner:

| Statustype | ID | Kommentar
|---|---|---|
| Booking | 5 | Du er invitert (første status) |
| Bestillingen er flyttet | 6 | Du har kanskje sett, avslått eller godtatt bestillingen, men den er flyttet, så du vil bli spurt på nytt. |
| Booking sett | 7 | Du har sett bestillingen, men ikke avslått eller akseptert den. |
| Bestilling flyttet sett | 8 | Bestillingen er flyttet og du har sett endringen, men ikke avslått eller akseptert den. |
| Tildeling | 11 | Du får tildelt denne avtalen. |
| Oppdrag sett | 12 | Du har sett fordelingen, men ikke godtatt eller avslått den |

## Se også

* [Avtale tabell][5]
* [Invitasjoner][2]

<!-- Referenced links -->
[1]: ../../../globalization-and-localization/culture/culturedataformatter.md
[2]: ../../invitations.md
[3]: appointment-matrix.md
[5]: ../../../database/tables/appointment.md

<!-- Referenced images -->
