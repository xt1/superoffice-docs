---
title: Opprette en Person enhet
description: Opprett en kontaktenhet
uid: create_contact_entity-no
author: Bergfrid Dias
so.date: 02.22.2022
keywords: contact, company, entity, API, assert, SetDefaults
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Person enhet

Bruk av `Contact` eksponert [enhet][1]  i `SuperOffice.CRM.Entities` navneområdet er en av de enkleste måtene å opprette en avtale på, som vist i eksemplet nedenfor.

## Kode

[!code-csharp[CS]](includes/create-contact-entity.cs)

## Gjennomgang

Etter at `SoSession` en  forekomst er opprettet og brukeren autentisert, kan vi fortsette å opprette en kontakt.

For å opprette en kontakt oppretter vi en forekomst `Contact` av enheten ved hjelp av  metodene som vises i `CreateNew` klassen, hvoretter standardverdiene for enheten angis ved hjelp av `Contact` metoden slik:`SetDefaults` 

[!code-csharp[CS]](includes/create-contact-entity.cs?range=7,11)

Den neste delen av koden viser [Hvordan verdier tilordnes til egenskaper][2] eksponert av enheten.

Når de nødvendige verdiene til egenskapene for `Contact` enheten er lagt til eller tilordnet, kan de lagres med `Save` metoden.

## Bruke påstand

[!code-csharp[CS]](includes/create-contact-assert.cs)

<!-- Referenced links -->
[1]: ../../../api/entities/index.md
[2]: ../../../api/entities/create-entity.md
