---
title: Hvordan sette en interesse på eller av
description: Slik angir du en interesse på eller av for en kontakt ved hjelp av enheter
uid: toggle_contact_interest_entity-no
author: {github-id}
so.date: 05.11.2016
keywords: contact, company, interest, entity, API, ContactInterestHelper, SetItemSelection
so.topic: howto
# so.envir:
# so.client:
---

# Slik setter du en interesse på eller av for en kontakt (datalag)

Du kan søke etter en [rente][1] og deretter sette interessen til sann eller usann. Her bruker vi `ContactInterestHelper`.

## Kode

[!code-csharp[CS]](includes/toggle-interest-entity.cs)

## Gjennomgang

Metoden `Find` som er  tilgjengelig gjennom `Contact` klassens `InterestHelper.RootItems` kan brukes til å gjøre søket vårt.

[!code-csharp[CS]](includes/toggle-interest-entity.cs?range=14-18)

Metoden returnerer  en `ISoListItem` og krever en representant som definerer elementet som vi skal søke etter for å bli sendt inn i metoden. Metoden returnerer deretter alle interesser som samsvarer med søkeinteressen vår ved å bruke `Equals` metoden.

Deretter går vi videre til å sette interessen til sant eller usant. For å gjøre dette bruker vi metoden `SetItemSelection` tilgjengelig `ContactInterestHelper` klasse. Metoden krever at rente-ID-en og den nye valgstatusen (sann eller usann) sendes.

<!-- Referenced links -->
[1]: ../../interests.md
