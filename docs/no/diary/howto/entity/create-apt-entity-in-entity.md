---
title: Opprette en Avtale enhet gjennom en enhet
description: Hvordan opprette en Avtale enhet gjennom en annen enhet.
uid: create_appointment_entity_in_entity-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
keywords: diary, calendar, appointment, API, entity
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Avtale enhet gjennom en enhet

Oppretting av en avtale gjennom en enhet kan gjøres på 2 forskjellige måter:

[!include [ALT](../../../api/includes/create-entity-options.md)]

## Eksempel 1

[!code-csharp[CS]](includes/create-apt-entity-in-entity-1.cs)

I eksemplet ovenfor har vi opprettet en avtale som forklart i [dette eksemplet][1]. Forskjellen er at her lagrer vi ikke den opprettede avtalen. I stedet tilordner vi den til egenskapen til `Appointments` forekomsten  som er `Contact` opprettet, og lagrer deretter `Contact`:

[!code-csharp[CS]](includes/create-apt-entity-in-entity-1.cs?range=28,31,34)

## Eksempel 2

Nedenfor er et eksempel på hvordan vi kan bruke metoden som er `AddNew` tilgjengelig i `Appointments` egenskapen `Contact` for klassen til å opprette en ny avtale.

[!code-csharp[CS]](includes/create-apt-entity-in-entity-2.cs)

Forskjellen mellom eksempel 1 og eksempel 2 er at her har vi opprettet en forekomst av de  som `Appointment` skal legges til samlingen, `Appointments` og ved å indeksere gjennom samlingen har vi tildelt de ønskede verdiene for den spesifikke avtalen som vist nedenfor.

[!code-csharp[CS]](includes/create-apt-entity-in-entity-2.cs?range=8,16,27)

Den `Appointment` opprettede lagres når du lagrer `Contact` enheten ved bruk av `Save` metoden.

> [!NOTE]
> Når du legger til en avtale ved å indeksere gjennom den Avtale samlingen av en enhet, bør du være forsiktig med å identifisere og legge til i den nylig opprettede , uten å `Appointment`oppdatere en tidligere `Appointment`.
>
> I eksempel 2 hvis det allerede eksisterte en avtale `Appointment[0]` på stedet når du tilordnet verdier til egenskaper, er det som faktisk ville skje, en oppdatering i stedet for en innsetting, siden verdiene som allerede finnes i den 0. plasseringen, endres.

<!-- Referenced links -->
[1]: create-apt-entity.md
