---
title: Opprette en Avtale enhet
description: Slik oppretter du en avtaleenhet.
keywords: dagbok, kalender, avtale, API, enhet, SuperOffice.CRM. Enheter
uid: create_appointment_entity-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Avtale enhet

Bruk av eksponert `Appointment` [Enhet][1] i navneområdet `SuperOffice.CRM.Entities` er en av de letteste måtene å opprette en avtale på, som vist i eksempelet nedenfor.

## Koden

[!code-csharp[CS](includes/create-apt-entity.cs)]

## Gjennomgang

Etter at en `SoSession` er opprettet, fortsetter vi med å opprette en avtale.

For å opprette en avtale må det opprettes en forekomst av `Appointment` enheten ved hjelp  av `CreateNew` metoden som eksponeres i `Associate` klassen, hvoretter standardverdiene for enheten settes ved hjelp av `SetDefaults` metoden slik:

[!code-csharp[CS](includes/create-apt-entity.cs?range=6,9)]

Den neste delen av koden vises [hvordan verdier tildeles egenskaper][2] av enheten. Vær oppmerksom på hvordan vi tildeler `Alarm` eiendommen:

[!code-csharp[CS](includes/create-apt-entity.cs?range=17-18)]

Egenskapen `HasAlarm` bør tildeles **først** før verdien for egenskapen `Alarm` tildeles.

Når ønskede verdier til egenskapene for `Appointment` enheten er lagt til eller tilordnet, kan den lagres med `Save` metoden:

[!code-csharp[CS](includes/create-apt-entity.cs?range=28)]

<!-- Referenced links -->
[1]: ../../../api/entities/index.md
[2]: ../../../api/entities/create-entity.md
