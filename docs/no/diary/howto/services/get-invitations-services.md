---
title: Slik får du frem en liste over invitasjoner (tjenester)
description: Slik får du frem en liste over invitasjoner ved hjelp av NetServer-tjenester
keywords: dagbok, kalender, avtale, API, webtjenester, archiveprovider
uid: get_invitation_services-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
# so.envir:
# so.client:
---

# Slik får du frem en liste over invitasjoner (tjenester)

Koden nedenfor brukes til å hente en liste over [Invitasjoner][1] for en bestemt medarbeider med [NetServer-tjenester][2].

## Koden

[!code-csharp[CS](includes/get-invitations-services.cs)]

## Gjennomgang

I koden har vi brukt en forekomst av [InvitasjonSbelønning][3] og noen av metodene for å begrense og ordne utdata som tilbys av leverandøren.

| Metoden | Beskrivelse |
|---|---|
| Angi ordre fra | sortere utdataene etter ID |
| SetPageInfo | begrenser antall rader som returneres til de første 100 radene |
| SetDesiredColumns | brukes til å identifisere hvilke kolonner som skal returneres av leverandøren |
| SetRestriction | angir spørsmålsbegrensningen for tilbyderen |
| GetRows | kan brukes til å hente ut radene som tilbyderen har returnert |

Leverandøren returnerer en samling av `ArchiveRow` typer. Ved å gå gjennom hver `ArchiveRow` av dem kan vi få informasjon om en invitasjon til medarbeideren. Resultatet av kjøringen av koden ovenfor vises nedenfor.

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
