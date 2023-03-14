---
title: Opprette en Person enhet gjennom en enhet
description: Hvordan lage en Person enhet gjennom en enhet på to måter.
uid: create_contact_entity_in_entity-no
author: {github-id}
so.date: 05.11.2016
keywords: contact, company, entity, API,
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Person enhet gjennom en enhet

Oppretting av en kontakt gjennom en enhet kan gjøres på to forskjellige måter:

[!include [ALT](../../../api/includes/create-entity-options.md)]

## Eksempel 1

[!code-csharp[CS]](includes/create-contact-entity-in-entity-1.cs)

I eksemplet ovenfor oppretter vi en ny kontakt som forklart i [dette eksemplet][1]. Forskjellen er at vi ikke lagrer den opprettede kontakten. I stedet tilordner vi den til en annen enhet, for eksempel enheten, `Person` og lagrer deretter `Person`:

[!code-csharp[CS]](includes/create-contact-entity-in-entity-1.cs?range=44,47)

## Eksempel 2

Nedenfor er eksemplet på å opprette `Contact` en enhet,  som er en eiendom for en annen enhet, for eksempel `Person`.

[!code-csharp[CS]](includes/create-contact-entity-in-entity-2.cs)

Forskjellen mellom eksempel 1 og eksempel 2 er at her er egenskapene `Contact` til enheten tilgjengelig gjennom forekomsten av enheten `Person` som vist nedenfor. Uttalelsene kan imidlertid variere litt avhengig av datatypen.

[!code-csharp[CS]](includes/create-contact-entity-in-entity-2.cs?range=12)

Når du lagrer `Person` enheten ved bruk av metoden, `Save` lagres  også den nye `Contact` NestedPersistent).

> [!NOTE]
> Når du bruker ovennevnte type kode, bør hovedenheten (for eksempel `Person` enheten ovenfor) også opprettes. Når du henter en person, kan det hende at den allerede har en kontakt tilordnet. Så derfor når vi legger til verdier til egenskapene til `Contact` i en slik enhet, er det vi faktisk ville gjøre å oppdatere eksisterende `Contact` informasjon.

<!-- Referenced links -->
[1]: create-contact-entity.md
