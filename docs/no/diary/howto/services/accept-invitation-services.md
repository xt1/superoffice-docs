---
title: Hvordan godta en invitasjon (tjenester)
description: Hvordan godta en invitasjon ved hjelp av NetServer-tjenester
uid: accept_invitation_services-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: diary, calendar, appointment, invitation, API, web services
so.topic: howto
# so.envir:
# so.client:
---

# Hvordan godta en invitasjon (tjenester)

Dette eksemplet viser hvordan du godtar et [invitasjon][2] gjennomgående [NetServer-tjenester][3] lag med bare noen få kodesetninger.

Vi bruker NetServer-leverandører (plugins opprettet med en fabrikkklasse) for å hente informasjon om invitasjoner til en bestemt medarbeider.

`IArchiveProvider` er det eksterne standardgrensesnittet til arkivleverandører som er eksponert for tjenestelaget og verden for øvrig. Grensesnittet samler de utvidbare og leverandøregenskapene til klasser som `ActivityArchiveProvider`, `ProjectMemberProvide`og `InvitationProvider`. Dette fungerer som et mellomstadium mellom det rene egenskapsgrensesnittet og den faktiske leverandørklassen som har spørringer.

Etter å ha fått en oversikt av [Annonseinvitasjoner for en medarbeider][1], planlegger vi å godta invitasjonen med `appointmentId = 150`. Dette gjøres ved hjelp av [AvtaleAgent][4] fra `SuperOffice.CRM.Services` navnerommet. Alle samtaler til agenten tilsvarer en webtjenestesamtale.

## Kode

[!code-csharp[CS]](includes/accept-invite-services.cs)

## Gjennomgang

I eksemplet har vi opprettet en forekomst av  og `AppointmentAgent` kalt metoden som `Accept` passerer og `appointmentId` . `UpdateMode`

**Ytelse:**

```text
associate/contactFullName    date        endDate           appointmentId
StateZeroDatabase       [D:07/05/2007]    [D:07/05/2007]    [I:186]
StateZeroDatabase       [D:07/26/2007]    [D:07/26/2007]    [I:179]
StateZeroDatabase       [D:04/28/2007]    [D:04/28/2007]    [I:172]
StateZeroDatabase       [D:06/14/2007]    [D:06/14/2007]    [I:161
```

Årsaken til at detaljene for en invitasjon med `appointmentId` 150 ikke vises (som den gjorde da vi [oppført det][1] ), er at når invitasjonen er akseptert, blir den en vanlig avtale uten at invitasjonsstatusen er angitt, og den kan ikke lenger hentes ved å bruke [InvitationProvider][5].

<!-- Referenced links -->
[1]: get-invitations-services.md
[2]: ../../invitations.md
[3]: ../../../api/web-services/index.md
[4]: ../../../api/reference/restful/agent/Appointment_Agent/index.md
[5]: ../../../api/archive-providers/reference/invitation.md
