---
title: Hvordan lage en invitasjon (tjenester)
description: Hvordan lage en invitasjon ved hjelp av tjenester
uid: create_invitation_ws-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: diary, calendar, appointment, API, web services
so.topic: howto
# so.envir:
# so.client:
---

# Hvordan lage en invitasjon (tjenester)

Etter at du har opprettet en avtale, må du kanskje [Inviter medlemmer][1]. Følgende eksempel viser hvordan dette gjøres med [NetServer-tjenester][2].

## Eksempel 1

[!code-csharp[CS]](includes/create-invite-services-1.cs)

Her har vi først laget en [AvtaleAgent][3]. Enheten `Appointment` har egenskapene satt til standardverdier. For eksempel settes den `Associate` automatisk til gjeldende bruker (SAL0).

> [!NOTE]Medarbeider er en egenskap av 
> *datatypen Enhet*, som er en SuperOffice-spesifikk type.

I eksemplet ovenfor har vi imidlertid tildelt en Medarbeider eksplisitt, vil bli tildelt avtalen, og den vil bli vist i invitasjonsdialogen der medarbeideren kan godta eller avslå den.

Når vi lagrer denne avtalen ved hjelp av `SaveAppointmentEntity` metoden som er eksponert i `AppoinmentAgent`, vil 2 rader bli lagt til i avtaletabellen.

Første rad er en `Appointment` i avtaleeierens egen dagbok. Den andre raden er en invitasjon til SAL0 fra eieren om å delta på det samme møtet. Når den innloggede brukeren (SAL0) logger på, vil de bli vist en ny invitasjon som tilsvarer denne avtalen.

## Eksempel 2

[!code-csharp[CS]](includes/create-invite-services-2.cs)

Her er det ingen referanse til en invitasjon, når vi inviterer en person til avtalen vi har opprettet, vil invitasjonen bli opprettet for den personen.

Først har vi opprettet en avtaleagent, og etter å ha satt startdato, sluttdato og beskrivelse har vi opprettet en `ParticipantInfo` matrise. I matrisen har vi gitt `AssociateId` av en bruker og en  ressurs, og  en `PersonId` av noen som ikke er en bruker - en person vi ønsker å invitere til den nyopprettede avtalen.

Ovennevnte `Save` vil opprette 3 avtaler, en for hver deltaker. Tjenesten oppretter ikke en avtale for gjeldende bruker med mindre du legger til et deltakerobjekt i listen. Hvis du vil inkludere gjeldende bruker som deltaker, må du huske å legge til et deltakerobjekt med gjeldende bruker som deltaker.

Den første deltakeren får ikke en invitasjon siden den første deltakeren regnes som den som inviterte. Avtalen vises bare i den første deltakerens dagbok.

> [!NOTE]
> Objektet `AssociateId`, `PersonId` , og det `ContactId` du angir i deltakerinformasjonsobjektet, **må være konsekvent**. Hvis du angir mer enn ett felt for en deltaker, må de være enige i informasjonen i databasen. Hvis du angir flere verdier på et enkelt deltakerobjekt, opprettes det ikke flere invitasjoner. Hvert deltakerobjekt er en enkelt invitasjon.

<!-- Referenced links -->
[1]: ../../invitations.md
[2]: ../../../api/web-services/index.md
[3]: ../../../api/reference/restful/agent/Appointment_Agent/index.md
