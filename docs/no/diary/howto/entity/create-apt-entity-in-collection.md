---
title: Opprette en Avtale enhet via en enhetssamling
description: Slik oppretter du en Avtale enhet via en enhetssamling på NetServer-datalaget.
keywords: dagbok, kalender, avtale, API, enhet, samling, AppointmentCollectio
uid: create_appointment_entity_in_collection-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Avtale enhet via en enhetssamling

Navneområdet `SuperOffice.CRM.Entities` eksponerer [enhetssamlinger][1] slike som `AppointmentCollection` og `PersonCollection`. Det er derfor mulig å opprette en enhet `Appointment` og tildele den til samlingen, og dermed lagre samlingen Avtale enhet vil bli lagret.

Eksemplet nedenfor viser hvordan du gjør det ovennevnte.

## Koden

[!code-csharp[CS](includes/create-apt-entity-in-collection.cs)]

## Gjennomgang

Etter å ha opprettet en forekomst av `Appointment` enheten og fordelt ønskede verdier, er neste trinn å tildele den opprettede avtalen til samlingen.

Først oppretter vi en `AppointmentCollection` og legger deretter til avtalen i samlingen ved hjelp av `Add` metoden.

Når den er lagt til, kan samlingen lagres:

[!code-csharp[CS](includes/create-apt-entity-in-collection.cs?range=28,31-32)]

<!-- Referenced links -->
[1]: ../../../api/entities/collections.md
