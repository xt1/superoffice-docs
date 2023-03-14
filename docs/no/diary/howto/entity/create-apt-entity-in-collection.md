---
title: Opprette en Avtale enhet gjennom en enhetssamling
description: Hvordan lage en Avtale enhet gjennom en enhetssamling på NetServer-datalaget.
uid: create_appointment_entity_in_collection-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
keywords: diary, calendar, appointment, API, entity, collection, AppointmentCollectio
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Avtale enhet gjennom en enhetssamling

 `SuperOffice.CRM.Entities` Navneområdet eksponerer, [Enhetssamlinger][1] for eksempel `AppointmentCollection` og `PersonCollection`. Det er derfor mulig å opprette en `Appointment` enhet og tilordne den til samlingen og dermed lagre samlingen den Avtale enheten vil bli lagret.

Følgende eksempel viser metoden for å gjøre det ovennevnte.

## Kode

[!code-csharp[CS]](includes/create-apt-entity-in-collection.cs)

## Gjennomgang

Når du har opprettet en forekomst av `Appointment` enheten og tilordnet de ønskede verdiene, er neste trinn å tilordne den opprettede avtalen til samlingen.

Først oppretter vi en `AppointmentCollection` og legger deretter avtalen til samlingen ved hjelp av `Add` metoden.

Når den er lagt til, kan samlingen lagres:

[!code-csharp[CS]](includes/create-apt-entity-in-collection.cs?range=28,31-32)

<!-- Referenced links -->
[1]: ../../../api/entities/collections.md
