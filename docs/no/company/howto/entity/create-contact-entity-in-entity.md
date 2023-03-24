---
title: Opprette en Person enhet via en enhet
description: Slik oppretter du en Person enhet på to måter.
keywords: person, firma, enhet, API,
uid: create_contact_entity_in_entity-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Person enhet via en enhet

Du kan opprette en person via en enhet på to forskjellige måter:

[!include [ALT](../../../api/includes/create-entity-options.md)]

## Eksempel 1

[!code-csharp[CS](includes/create-contact-entity-in-entity-1.cs)]

I eksempelet ovenfor oppretter vi en ny person som forklart i [dette eksempelet][1]. Forskjellen er at vi ikke lagrer den opprettede personen. I stedet tilordner vi den til en annen enhet, for eksempel enheten, `Person` og deretter lagrer vi følgende `Person`:

[!code-csharp[CS](includes/create-contact-entity-in-entity-1.cs?range=44,47)]

## Eksempel 2

Nedenfor er eksempelet på å opprette en `Contact` enhet, som er en egenskap for en annen enhet, for eksempel `Person`.

[!code-csharp[CS](includes/create-contact-entity-in-entity-2.cs)]

Forskjellen mellom eksempel 1 og eksempel 2 er at her får du `Contact` tilgang til egenskapene for enheten gjennom forekomsten av `Person` enheten som vist nedenfor. Uttalelsene kan imidlertid variere litt, avhengig av datatypen.

[!code-csharp[CS](includes/create-contact-entity-in-entity-2.cs?range=12)]

Når du lagrer `Person` enheten ved bruk av `Save` metoden, lagres også den nye `Contact` NestedPersistent.

> [!NOTE]
> Når du bruker ovennevnte kodetype, opprettes også hovedenheten (for eksempel `Person` enheten ovenfor). Når du henter en person, kan det hende at den allerede har tildelt en person. Så når du legger til verdier i egenskapene til `Contact` i en slik enhet, er det vi faktisk ville gjøre, å oppdatere den eksisterende `Contact` informasjonen.

<!-- Referenced links -->
[1]: create-contact-entity.md
