---
title: Slik setter du en interesse på eller av
description: Slik setter du en interesse på eller av for en person ved hjelp av enheter
keywords: person, firma, interesse, enhet, API, PersonInterestHelper, SetItemSelection
uid: toggle_contact_interest_entity-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Slik angir du en interesse for en person (datalag)

Du kan søke etter en [Interesse][1] og deretter sette interessen til sann eller usann. Her bruker vi . `ContactInterestHelper`

## Koden

[!code-csharp[CS](includes/toggle-interest-entity.cs)]

## Gjennomgang

Metoden `Find` som er tilgjengelig via `Contact` klassens `InterestHelper.RootItems` , kan brukes til å søke etter oss.

[!code-csharp[CS](includes/toggle-interest-entity.cs?range=14-18)]

Metoden returnerer en `ISoListItem` og krever en representant som definerer elementet som vi bør søke etter for å bli sendt inn i metoden. Metoden returnerer da eventuell interesse som samsvarer med vår søkeinteresse, ved å bruke `Equals` metoden.

Deretter går vi videre til å sette interessen til sann eller falsk. For å gjøre dette bruker vi metoden `SetItemSelection` tilgjengelig `ContactInterestHelper` klasse. Metoden krever at interesse-IDen og den nye utvalgsstatusen (sann eller usann) sendes.

<!-- Referenced links -->
[1]: ../../interests.md
