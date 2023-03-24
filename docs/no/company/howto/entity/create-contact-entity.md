---
title: Opprette en Person enhet
description: Opprette en personenhet
keywords: person, firma, enhet, API, deklarer, SetDefaults
uid: create_contact_entity-no
author: Bergfrid Dias
so.date: 02.22.2022
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Person enhet

Bruk av eksponert `Contact` [Enhet][1] i navneområdet `SuperOffice.CRM.Entities` er en av de letteste måtene å opprette en avtale på, som vist i eksempelet nedenfor.

## Koden

[!code-csharp[CS](includes/create-contact-entity.cs)]

## Gjennomgang

Etter at en `SoSession` forekomst er opprettet og brukeren autentisert, kan vi fortsette å opprette en person.

For å opprette en person oppretter vi en forekomst av `Contact` enheten ved hjelp  av `CreateNew` metodene som eksponeres i `Contact` klassen, hvoretter standardverdiene for enheten settes ved hjelp av `SetDefaults` metoden slik:

[!code-csharp[CS](includes/create-contact-entity.cs?range=7,11)]

Den neste delen av koden vises [hvordan verdier tildeles egenskaper][2] av enheten.

Når ønskede verdier til egenskapene for `Contact` enheten er lagt til eller tildelt, kan den lagres med `Save` metoden.

## Bruke påslag

[!code-csharp[CS](includes/create-contact-assert.cs)]

<!-- Referenced links -->
[1]: ../../../api/entities/index.md
[2]: ../../../api/entities/create-entity.md
