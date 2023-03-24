---
title: Opprette en Person enhet via en enhetssamling
description: Slik oppretter du en Person enhet via en samling av personhenrettelsesenhet.
keywords: Person, firma, enhet, API, samling, ContactCollection
uid: create_contact_entity_in_collection-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Person enhet via en enhetssamling

Navneområdet `SuperOffice.CRM.Entities` eksponerer entitetssamlinger, for eksempel `ContactCollection` og `PersonCollection`. Det er derfor mulig å opprette en `Contact` enhet og tildele den til samlingen, og dermed lagre samlingen vil `Contact` enheten bli lagret.

## Koden

[!code-csharp[CS](includes/create-contact-entity-in-collection.cs)]

## Gjennomgang

I koden ovenfor `Contact` er det opprettet en enhet, og den har blitt tildelt den øyeblikkelige `ContactCollection`.

Da har samlingen blitt lagret slik:

[!code-csharp[CS](includes/create-contact-entity-in-collection.cs?range=35-36)]
