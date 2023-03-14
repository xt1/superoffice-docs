---
title: Hvordan lage en invitasjon (datalag)
description: Hvordan lage en invitasjon ved hjelp av enheter på NetServer-datalaget.
uid: create_invitation_entity-no
author: Bergfrid Skaara Dias
so.date: 03.04.2022
keywords: diary, calendar, appointment, API, entity, ParticipantInfo, AddParticipant, AppointmentMatrix
so.topic: howto
# so.envir:
# so.client:
---

# Hvordan lage en invitasjon (datalag)

Etter at du har opprettet en avtale, må du kanskje [Inviter medlemmer][2]. Følgende eksempel viser hvordan dette gjøres.

[!code-csharp[CS]](includes/create-invite-entity.cs)

I dette eksemplet har vi opprinnelig opprettet en avtale og angitt visse egenskaper for den.

## Deltakere

En `Person` enhet brukes til å legge til som deltaker i denne avtalen.

I den siste delen av eksemplet har vi satt noen egenskaper til deltakeren som `AssociateId`, `PersonId`og `SendEmail`. Du kan lage en matrise av [Deltakerinfo][4] som vi har gjort ovenfor.

## AvtaleMatrix

En forekomst av  den `AppointmentMatrix` opprettes ved å sende den nyopprettede avtalen. Du kan legge til deltakerne i matrisen ved hjelp av metoden `AddParticipant` .

Når den `AppointmentMatrix` er lagret, vil 2 poster bli lagt til [avtale tabell][1]:

* En som tilsvarer skaperen av avtalen
* En som refererer til deltakeren

Hvis vi har lagt til flere deltakere, vil flere poster bli lagt inn i `appointment` tabellen.

## Les også

* [Avtale tabell][1]
* [Invitasjoner][2]

<!-- Referenced links -->
[1]: ../../../database/tables/appointment.md
[2]: ../../invitations.md
[4]: <xref:SuperOffice.CRM.Services.ParticipantInfo>

<!-- Referenced images -->
