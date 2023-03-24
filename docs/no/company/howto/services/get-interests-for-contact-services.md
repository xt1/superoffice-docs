---
title: Slik viser du alle valgte interesser
description: Slik viser du alle valgte interesser for en person ved hjelp av tjenester
keywords: person, firma, tjenester, API, interesse, ContactAgent, SelectableMDOListItem
uid: list_contact_interests_ws-no
author: {github-id}
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Slik viser du alle valgte interesser for en person (tjenester)

Du kan bruke  `SuperOffice.Services` og `SuperOffice.Services.Impl` DLLer til å vise alle valgte [Interesser][1] personer.

## Koden

[!code-csharp[CS](includes/list-interests-services.cs)]

## Gjennomgang

Ved hjelp av `ContactAgent`, henter vi først en `Contact` enhet. Neste er å hente personens tilgjengelige interesser. Vi bruker egenskapen `Interests` til enheten og henter interesselisten til en `SelectableMDOListItem` matrise.

Ved å iterere på matrisen, kan vi hente ut detaljer om hver interesse som er tilgjengelig. Siden vi bare vil ha den *valgte* interessen, legger vi til en hvis-betingelse for å filtrere ut en forekomst som ikke er valgt.

Sammenligne fanen **Interesse** på **Firma** kortet i SuperOffice og vår innhentet produksjon kan vi bekrefte våre resultater.

<!-- Referenced links -->
[1]: ../../interests.md

<!-- Referenced images -->
