---
title: Slik godtar du en invitasjon (tjenester)
description: Slik godtar du en invitasjon via NetServer-tjenester
keywords: dagbok, kalender, avtale, invitasjon, API, webtjenester
uid: accept_invitation_services-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
# so.envir:
# so.client:
---

# Slik godtar du en invitasjon (tjenester)

Dette eksemplet viser hvordan du godtar en [Invitasjon][2] via [NetServer-tjenester][3] laget med bare noen få kodeerklæringer.

Vi bruker NetServer-leverandører (plugins opprettet med en fabrikkklasse) for å hente informasjon om invitasjoner til en bestemt medarbeider.

`IArchiveProvider` er det eksterne standardgrensesnittet til arkivleverandører som er eksponert for servicelaget og verden generelt. Grensesnittet samler de utvidbare egenskapene og leverandøregenskapene til klasser som `ActivityArchiveProvider`, `ProjectMemberProvide`og `InvitationProvider`. Dette fungerer som et mellomliggende trinn mellom det rene egenskapsgrensesnittet og den faktiske leverandørklassen som har spørsmål.

Etter å ha fått en oversikt via [registrere invitasjoner til en medarbeider][1], planlegger vi å godta invitasjonen med `appointmentId = 150`. Dette gjøres ved hjelp av [AvtaleAgent][4] fra navneområdet `SuperOffice.CRM.Services` . Alle samtaler til agenten tilsvarer en samtale om webtjenester.

## Koden

[!code-csharp[CS](includes/accept-invite-services.cs)]

## Gjennomgang

I eksempelet har vi laget en forekomst av metoden `AppointmentAgent` og kaller den tilhørende `Accept` metoden som passerer `appointmentId` og `UpdateMode`.

 **Utgang:** 

```text
associate/contactFullName    date        endDate           appointmentId
StateZeroDatabase       [D:07/05/2007]    [D:07/05/2007]    [I:186]
StateZeroDatabase       [D:07/26/2007]    [D:07/26/2007]    [I:179]
StateZeroDatabase       [D:04/28/2007]    [D:04/28/2007]    [I:172]
StateZeroDatabase       [D:06/14/2007]    [D:06/14/2007]    [I:161
```

Grunnen til at detaljene for en invitasjon med `appointmentId` 150 ikke vises (slik den gjorde da vi [den vises i listen][1]), er at når invitasjonen er godtatt, blir den vanlig avtale uten invitasjonsstatussettet, og den kan ikke lenger hentes ved hjelp av [InvitasjonSbelønning][5].

<!-- Referenced links -->
[1]: get-invitations-services.md
[2]: ../../invitations.md
[3]: ../../../api/web-services/index.md
[4]: ../../../api/reference/restful/agent/Appointment_Agent/index.md
[5]: ../../../api/archive-providers/reference/invitation.md
