---
title: Hvordan liste opp alle valgte interesser
description: Slik viser du alle valgte interesser for en kontakt ved hjelp av tjenester
uid: list_contact_interests_ws-no
author: {github-id}
so.date: 11.04.2021
keywords: contact, company, services, API, interest, ContactAgent, SelectableMDOListItem
so.topic: howto
# so.envir:
# so.client:
---

# Slik viser du alle valgte interesser for en kontakt (tjenester)

Du kan bruke  `SuperOffice.Services` `SuperOffice.Services.Impl` DLL-filer til å liste opp alle som er valgt [Interesser][1] for en bestemt kontakt.

## Kode

[!code-csharp[CS]](includes/list-interests-services.cs)

## Gjennomgang

Ved hjelp av `ContactAgent`, henter vi først en `Contact` enhet. Neste er å hente de tilgjengelige interessene til kontakten. Vi bruker `Interests` eiendommen til enheten og henter interesselisten i en `SelectableMDOListItem` matrise.

Ved å iterere på matrisen kan vi hente detaljer om hver interesse som er tilgjengelig. Siden vi bare vil ha den *valgte* interessen, legger vi til en if-betingelse for å filtrere ut ethvert element som ikke er valgt.

Ved å sammenligne **interessefanen** ** på Firma-kortet i SuperOffice og vår oppnådde utgang kan vi bekrefte resultatene våre.**

<!-- Referenced links -->
[1]: ../../interests.md

<!-- Referenced images -->
