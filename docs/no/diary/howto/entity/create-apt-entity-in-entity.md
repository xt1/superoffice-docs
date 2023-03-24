---
title: Opprette en Avtale enhet via en enhet
description: Slik oppretter du en Avtale enhet via en annen enhet.
keywords: dagbok, kalender, avtale, API, enhet
uid: create_appointment_entity_in_entity-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Avtale enhet via en enhet

Du kan opprette en avtale via en enhet på to forskjellige måter:

[!include [ALT](../../../api/includes/create-entity-options.md)]

## Eksempel 1

[!code-csharp[CS](includes/create-apt-entity-in-entity-1.cs)]

I eksempelet ovenfor har vi opprettet en avtale som forklart i [dette eksempelet][1]. Forskjellen er at vi ikke lagrer den opprettede avtalen her. I stedet tilordner vi den til `Appointments` egenskapen til forekomsten som `Contact` er opprettet, og deretter lagrer vi følgende `Contact`:

[!code-csharp[CS](includes/create-apt-entity-in-entity-1.cs?range=28,31,34)]

## Eksempel 2

Nedenfor finner du et eksempel på hvordan vi kan bruke `AddNew` metoden som er tilgjengelig i `Appointments` `Contact` klassens egenskap, til å opprette en ny avtale.

[!code-csharp[CS](includes/create-apt-entity-in-entity-2.cs)]

Forskjellen mellom eksempel 1 og eksempel 2 er at her har vi laget en forekomst av forekomsten som `Appointment` skal legges til `Appointments` i samlingen, og ved å indeksere gjennom samlingen har vi tildelt de ønskede verdiene for den bestemte avtalen som vist nedenfor.

[!code-csharp[CS](includes/create-apt-entity-in-entity-2.cs?range=8,16,27)]

Opprettede `Appointment` lagres når du lagrer `Contact` enheten ved bruk av metoden `Save` .

> [!NOTE]
> Når du legger til en avtale ved å indeksere gjennom Avtale samling av en enhet, bør du være forsiktig med å identifisere og legge til i den nyopprettede `Appointment`, uten å oppdatere en tidligere `Appointment`.
>
> Eksempel 2 hvis det allerede finnes en avtale  på `Appointment[0]` stedet da du tildelte verdier til egenskaper som faktisk ville skje, er en oppdatering i stedet for et innlegg, siden verdiene som allerede finnes på den 0.

<!-- Referenced links -->
[1]: create-apt-entity.md
