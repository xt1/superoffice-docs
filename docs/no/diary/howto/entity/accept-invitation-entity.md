---
title: Hvordan godta en invitasjon (datalag)
description: Slik godtar du en invitasjon ved hjelp av enheter på NetServer-datalaget.
uid: accept_invitation_entity-no
author: Bergfrid Skaara Dias
so.date: 03.04.2022
keywords: diary, calendar, appointment, API, entity, InvitationProvider, ArchiveRows, AppointmentMatrix
so.topic: howto
# so.envir:
# so.client:
---

# Slik godtar du en invitasjon (datalag)

Når du prøver å akseptere en [invitasjon][2], kommer to ting til tankene dine:

* Hva er metoden for å hente invitasjonene?
* Hva er invitasjonene vi skal ta imot?

Vi vil bygge et eksempel som bruker leverandørene til å hente en invitasjon. La oss deretter godta den første invitasjonen i listen som har en invitasjonsdato som er større enn i dag.

## Kode

[!code-csharp[CS]](includes/accept-invite-entity.cs)

## Gjennomgang

> [!NOTE]Leverandørkonseptet er et veldig kraftig verktøy som finnes i NetServer. Det finnes mange typer leverandører, og hovedformålet med leverandørene er å hente noen spesifikke data ved hjelp av noen begrensninger vi ønsker.
> 
I eksemplet ovenfor har vi brukt `InvitationProvider` for  å få invitasjonene vi ønsker (for de gitte begrensningskriteriene). I en leverandør kan vi angi kolonnene vi vil hente, i dette tilfellet, `appointmentId`. Vi har også angitt hvordan vi vil at dataene skal sorteres ved hjelp `setOrderBy` av leverandørens metode.

I `InvitationProvider`, en begrensning for er `associateId` et must siden vi prøver å trekke ut invitasjoner fra en medarbeider. Hvis du ikke spesifiserer denne begrensningen, vil NetServer kaste et unntak. Etter å ha spesifisert den obligatoriske begrensningen kan du gi andre begrensninger, i dette tilfellet, invitasjoner som er foran gjeldende dato.

Nå har vi gitt all informasjon til leverandøren, og alt som er igjen er å utføre den og få resultatene.

Leverandøren utføres ved å ringe `GetRows` leverandørens metode, som vil returnere et sett med som `ArchiveRows` vi kan sløyfe gjennom. Dataene i radene representeres som nøkkelverdipar.

Leverandørene tilbyr flere måter å hente data på. Her har vi brukt `GetDisplayValue` å få verdien av kolonnen vi gir som parameter til metoden. Nærmere bestemt verdien av `appointmentId` kolonnen.

Verdiene som returneres er formatert på en spesiell måte som er unik for NetServer, så for å formatere verdiene som en vanlig streng som passer for formateringen av regionen din, kan vi bruke metodene i det som [CultureDataFormatter klasse][1] finnes i `SuperOffice.CRM.Globalization` navnerommet.

Hvis du analyserer koden ovenfor, kan du se at vi har hoppet ut av løkken vår som krysser de returnerte postene. Det er fordi vi i begynnelsen har satt oss en antagelse om at vi skal godta den første invitasjonen i den returnerte listen.

Til slutt har vi brukt [AvtaleMatrix][3] til å akseptere invitasjonen vi hentet. Matrisen brukes i NetServer for å håndtere ulike typer invitasjoner som finnes i den SuperOffice applikasjonen.

> [!NOTE]
> Som standard filtreres det `InvitationProvider` bare ut avtalen som følger under følgende statusdefinisjoner. NetServer har gjort dette siden du bare vil godta avtalene som har følgende statusdefinisjoner:

| Type status | ID | Kommentar
|---|---|---|
| Booking | 5 | Du er invitert (innledende status) |
| Bookingen er flyttet | 6 | Du har kanskje sett, avslått eller akseptert bestillingen, men den er flyttet, så du vil bli spurt igjen. |
| Booking sett | 7 | Du har sett bestillingen, men ikke avslått eller akseptert den. |
| Booking flyttet sett | 8 | Bestillingen er flyttet og du har sett endringen, men ikke avslått eller godtatt den. |
| Oppdrag | 11 | Du er tildelt denne avtalen. |
| Oppgave sett | 12 | Du har sett oppdraget, men ikke godtatt eller avslått det |

## Les også

* [Avtale tabell][5]
* [Invitasjoner][2]

<!-- Referenced links -->
[1]: ../../../globalization-and-localization/culture/culturedataformatter.md
[2]: ../../invitations.md
[3]: appointment-matrix.md
[5]: ../../../database/tables/appointment.md

<!-- Referenced images -->
