---
title: Hvordan få en liste over invitasjoner (tjenester)
description: Hvordan få en liste over invitasjoner ved hjelp av NetServer-tjenester
uid: get_invitation_services-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: diary, calendar, appointment, API, web services, archiveprovider
so.topic: howto
# so.envir:
# so.client:
---

# Hvordan få en liste over invitasjoner (tjenester)

Koden nedenfor brukes til å hente en liste [Invitasjoner][1] over for en bestemt tilknytning til [NetServer-tjenester][2].

## Kode

[!code-csharp[CS]](includes/get-invitations-services.cs)

## Gjennomgang

I koden har vi brukt en forekomst  av og [InvitationProvider][3] noen av dens metoder for å begrense og ordne utdataene som returneres av leverandøren.

| Metode | Beskrivelse |
|---|---|
| SetOrderBy | Sorterer utdataene etter ID |
| SetPageInfo | Begrenser antall rader som returneres til de første 100 radene |
| SetDesiredColumns | brukes til å identifisere hvilke kolonner som skal returneres av leverandøren |
| SetRestriction | Angir spørringsbegrensningen for leverandøren |
| GetRows | kan brukes til å hente radene som returneres av leverandøren |

Leverandøren returnerer en samling av `ArchiveRow` typer. Ved å sløyfe gjennom hver `ArchiveRow` kan vi få detaljer om en invitasjon til medarbeideren. Resultatet av å utføre koden ovenfor er vist nedenfor.

```text
associate/contactFullName    date        endDate           appointmentId
StateZeroDatabase       [D:07/05/2007]    [D:07/05/2007]    [I:186]
StateZeroDatabase       [D:07/26/2007]    [D:07/26/2007]    [I:179]
StateZeroDatabase       [D:04/28/2007]    [D:04/28/2007]    [I:172]
StateZeroDatabase       [D:06/14/2007]    [D:06/14/2007]    [I:161]
StateZeroDatabase       [D:04/28/2007]    [D:04/28/2007]    [I:150]
```

<!-- Referenced links -->
[1]: ../../invitations.md
[2]: ../../../api/web-services/index.md
[3]: ../../../api/archive-providers/reference/invitation.md
