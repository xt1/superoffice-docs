---
title: Slik viser du alle valgte interesser for en kontakt
description: Slik viser du alle valgte interesser for en kontakt ved hjelp av enheter
uid: list_contact_interests_entity-no
author: {github-id}
so.date: 05.11.2016
keywords: contact, company, interest, entity, API, ContactInterestHelper, SelectHeadingItems, SelectRootItems
so.topic: howto
# so.envir:
# so.client:
---

# Slik viser du alle valgte interesser for en kontakt

Du kan liste opp alle valgte [Interesser][1] for en bestemt kontakt ved hjelp av `ContactInterestHelper` klassen.

Du kan oppnå det samme med `PersonInterestHelper` klassen.

Hjelpeklassene gir funksjonaliteten som kombinerer MDO-listene og hva de skal velge (de kombinerer enhetsundersamlinger med MDO-lister).

## Kode

[!code-csharp[CS]](includes/list-interests-entity.cs)

## Gjennomgang

I koden ovenfor, når vi har opprettet en forekomst av `Contact` enheten ved å bruke `Contact` klassen, bruker vi kontaktene `InterestHelper` til å hente de valgte interessene. Som vist ovenfor kan vi hente interessen på 2 måter:

* Bruke eiendommen `SelectHeadingItems` 
* Bruke eiendommen `SelectRootItems` 

<!-- Referenced links -->
[1]: ../../interests.md
