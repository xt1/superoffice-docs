---
title: Opprette en Avtale enhet
description: Slik oppretter du en avtaleenhet.
uid: create_appointment_entity-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
keywords: diary, calendar, appointment, API, entity, SuperOffice.CRM.Entities
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Avtale enhet

Bruk av `Appointment` eksponert [enhet][1]  i `SuperOffice.CRM.Entities` navneområdet er en av de enkleste måtene å opprette en avtale på, som vist i eksemplet nedenfor.

## Kode

[!code-csharp[CS]](includes/create-apt-entity.cs)

## Gjennomgang

Etter at `SoSession` en  er opprettet, fortsetter vi med å opprette en avtale.

Hvis du vil opprette en avtale, er det nødvendig å opprette en forekomst `Appointment` av enheten ved hjelp av metoden  som vises i `CreateNew` klassen, hvoretter standardverdiene for enheten angis ved hjelp av `Associate` metoden slik:`SetDefaults` 

[!code-csharp[CS]](includes/create-apt-entity.cs?range=6,9)

Den neste delen av koden viser [Hvordan verdier tilordnes til egenskaper][2] eksponert av enheten. Vær oppmerksom på hvordan vi tildeler `Alarm` eiendommen:

[!code-csharp[CS]](includes/create-apt-entity.cs?range=17-18)

Eiendommen `HasAlarm` skal tildeles **først** før verdien for `Alarm` eiendommen tildeles.

Når de nødvendige verdiene til egenskapene for `Appointment` enheten er lagt til eller tilordnet, kan de lagres med `Save` metoden:

[!code-csharp[CS]](includes/create-apt-entity.cs?range=28)

<!-- Referenced links -->
[1]: ../../../api/entities/index.md
[2]: ../../../api/entities/create-entity.md
