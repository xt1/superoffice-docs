---
title: Slik oppretter du en invitasjon (tjenester)
description: Slik oppretter du en invitasjon ved hjelp av tjenester
keywords: dagbok, kalender, avtale, API, webtjenester
uid: create_invitation_ws-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
# so.envir:
# so.client:
---

# Slik oppretter du en invitasjon (tjenester)

Etter at du har opprettet en avtale, må du kanskje [invitere medlemmer][1]. Eksemplet nedenfor viser hvordan dette gjøres med [NetServer-tjenester][2].

## Eksempel 1

[!code-csharp[CS](includes/create-invite-services-1.cs)]

Her har vi først opprettet en [AvtaleAgent][3]. Enheten `Appointment` har egenskapene satt til standardverdier. Angis for eksempel `Associate` automatisk til gjeldende bruker (SAL0).

> [!NOTE]Medarbeider er en egenskap for 
> * enhetsdatatype som er en SuperOffice spesifikk type.*

I eksemplet ovenfor har vi imidlertid tildelt en Medarbeider eksplisitt, vil bli tildelt avtalen, og den vil vises i dialogboksen for invitasjoner der medarbeideren kan godta eller avslå den.

Når vi lagrer denne avtalen ved hjelp av `SaveAppointmentEntity` metoden som vises i `AppoinmentAgent`, legges det til to rader i avtaletabellen.

Den første raden er en `Appointment` i avtaleeierens egen dagbok. Den andre raden er en invitasjon til SAL0 fra eieren om å delta på samme møte. Når den påloggede brukeren (SAL0) logger seg på, får de en ny invitasjon som tilsvarer denne avtalen.

## Eksempel 2

[!code-csharp[CS](includes/create-invite-services-2.cs)]

Her er det ingen referanse til en invitasjon, når vi inviterer en person til avtalen vi har opprettet, opprettes invitasjonen for vedkommende.

Først har vi opprettet en avtaleagent, og etter å ha angitt startdato, sluttdato og beskrivelse har vi opprettet en `ParticipantInfo` matrise. I matrisen har vi gitt `AssociateId` en bruker og en ressurs, og en `PersonId` av noen som ikke er bruker – en person vi ønsker å invitere til den nyopprettede avtalen.

Ovennevnte `Save` vil opprette 3 avtaler, en for hver deltaker. Tjenesten oppretter ingen avtale for gjeldende bruker med mindre du legger til et deltakerobjekt i listen. Hvis du vil inkludere den gjeldende brukeren som deltaker, må du huske å legge til et deltakerobjekt med den aktuelle brukeren som en deltakende medarbeider.

Den første deltakeren får ingen invitasjon, siden den første deltakeren regnes som invitert. Avtalen vises bare i den første deltakerens dagbok.

> [!NOTE]
> - `AssociateId` `PersonId`og -knappen `ContactId` du angir i deltakerinformasjonsobjektet **, må være konsekvent** . Hvis du angir mer enn ett felt for en deltaker, må de være enige om informasjonen i databasen. Hvis du angir flere verdier for ett enkelt deltakerobjekt, blir det ikke opprettet flere invitasjoner. Hvert deltakerobjekt er bare én invitasjon.

<!-- Referenced links -->
[1]: ../../invitations.md
[2]: ../../../api/web-services/index.md
[3]: ../../../api/reference/restful/agent/Appointment_Agent/index.md
