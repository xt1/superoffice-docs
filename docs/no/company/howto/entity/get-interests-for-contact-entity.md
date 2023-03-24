---
title: Slik viser du alle valgte interesser for en person
description: Slik viser du alle valgte interesser for en person ved hjelp av enheter
keywords: person, firma, interesse, enhet, API, PersonInterestHelper, SelectHeadingItems, SelectRootItems
uid: list_contact_interests_entity-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Slik viser du alle valgte interesser for en person

Du kan vise alle som er valgt [Interesser][1] for en bestemt person, ved hjelp av `ContactInterestHelper` klassen.

Du kan oppnå det samme med `PersonInterestHelper` klassen.

Hjelpeklassene gir deg funksjonaliteten som kombinerer MDO-listene og hva du skal velge (de kombinerer enhetsundersamlinger med MDO-lister).

## Koden

[!code-csharp[CS](includes/list-interests-entity.cs)]

## Gjennomgang

I koden ovenfor, når vi har opprettet en forekomst av `Contact` enheten ved hjelp av `Contact` klassen, bruker vi personens `InterestHelper` til å hente de valgte interessene. Som vist ovenfor kan vi hente interessen på to måter:

* ved hjelp av egenskapen `SelectHeadingItems` 
* ved hjelp av egenskapen `SelectRootItems` 

<!-- Referenced links -->
[1]: ../../interests.md
