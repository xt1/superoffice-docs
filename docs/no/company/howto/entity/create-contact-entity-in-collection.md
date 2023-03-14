---
title: Opprett en Person enhet gjennom en enhetssamling
description: Slik oppretter du en Person enhet gjennom en ContactCollection-enhetssamling.
uid: create_contact_entity_in_collection-no
author: {github-id}
so.date: 05.11.2016
keywords: contact, company, entity, API, collection, ContactCollection
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Person enhet gjennom en enhetssamling

 `SuperOffice.CRM.Entities` Navneområdet viser enhetssamlinger som `ContactCollection` og `PersonCollection`. Det er derfor mulig å opprette en `Contact` enhet og tilordne den til samlingen og dermed lagre samlingen enheten `Contact` vil bli lagret.

## Kode

[!code-csharp[CS]](includes/create-contact-entity-in-collection.cs)

## Gjennomgang

I koden ovenfor er det opprettet en `Contact` enhet, og deretter er den tilordnet til den instansierte `ContactCollection`.

Da er samlingen lagret slik:

[!code-csharp[CS]](includes/create-contact-entity-in-collection.cs?range=35-36)
