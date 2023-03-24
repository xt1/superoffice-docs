---
title: Opprette en Person ved hjelp av tjenester
description: Slik oppretter du en person ved hjelp av tjenester.
keywords: person, firma, tjenester, API, api-tjenester, ContactAgent, CreateDefaultContactEntity
uid: create_contact_services-no
author: {github-id}
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Person ved hjelp av tjenester

Dette eksemplet viser hvordan du oppretter en ny person og tilordner verdier til egenskapene til enheten gjennom NetServer Services-laget.

## Koden

[!code-csharp[CS](includes/create-contact-services.cs)]

## Gjennomgang

Her har vi brukt a `ContactAgent` og `CreateDefaultContactEntity` metoden for å opprette en ny personenhet med standardverdier fylt ut. Vi setter først noen av de grunnleggende verdiene som navn og avdeling.

Deretter har vi satt verdier til egenskaper for komplekse datatyper, for eksempel `EntityElement[]` typer, enhetstyper som `Associate`, enhetsinnsamlingstyper som `Persons`, og `LocalizedField` typer.

Til slutt lagres den nyopprettede personenheten i databasen ved hjelp `SaveContactEntity` av agentens metode. Med dette blir en ny oppføring lagt til i persontabellen i databasen med feltene satt til verdier som er tildelt.

Enheten returneres med den tildelte IDen fylt ut.
