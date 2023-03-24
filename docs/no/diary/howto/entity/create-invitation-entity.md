---
title: Slik oppretter du en invitasjon (datalag)
description: Slik oppretter du en invitasjon ved hjelp av enheter på NetServer-datalaget.
keywords: dagbok, kalender, avtale, API, enhet, ParticipantInfo, AddParticipant, AppointmentMatrix
uid: create_invitation_entity-no
author: Bergfrid Skaara Dias
so.date: 03.04.2022
so.topic: howto
# so.envir:
# so.client:
---

# Slik oppretter du en invitasjon (datalag)

Etter at du har opprettet en avtale, må du kanskje [invitere medlemmer][2]. Eksemplet nedenfor viser hvordan dette gjøres.

[!code-csharp[CS](includes/create-invite-entity.cs)]

I dette eksempelet har vi i utgangspunktet opprettet en avtale og angitt visse egenskaper for den.

## Deltakere

En `Person` enhet brukes til å legge til som deltaker i denne avtalen.

I sistnevnte del av eksempelet har vi angitt noen egenskaper for deltakeren, for eksempel `AssociateId`, `PersonId`og `SendEmail`. Du kan opprette en rekke av [DeltakerInfo][4] som vi har gjort ovenfor.

## AvtaleMatrix

En forekomst av forekomsten `AppointmentMatrix` opprettes ved å sende den nyopprettede avtalen. Du kan legge til deltakerne i matrisen ved å bruke `AddParticipant` metoden.

Når `AppointmentMatrix` lagres, legges det til to oppføringer i følgende [avtaletabell][1]:

* En som tilsvarer skaperen av avtalen
* En henviser til deltakeren

Hvis vi har lagt til flere deltakere, legges det inn flere oppføringer i `appointment` tabellen.

## Se også

* [Avtale tabell][1]
* [Invitasjoner][2]

<!-- Referenced links -->
[1]: ../../../database/tables/appointment.md
[2]: ../../invitations.md
[4]: <xref:SuperOffice.CRM.Services.ParticipantInfo>

<!-- Referenced images -->
