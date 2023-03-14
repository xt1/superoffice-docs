---
title: Lag en Person ved hjelp av tjenester
description: Hvordan opprette en kontakt ved hjelp av tjenester.
uid: create_contact_services-no
author: {github-id}
so.date: 11.04.2021
keywords: contact, company, services, API, api-services, ContactAgent, CreateDefaultContactEntity
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en Person ved hjelp av tjenester

Dette eksemplet viser hvordan du oppretter en ny kontakt og tilordner verdier til egenskapene for enheten via NetServer Services-laget.

## Kode

[!code-csharp[CS]](includes/create-contact-services.cs)

## Gjennomgang

Her har vi brukt `ContactAgent` en  og `CreateDefaultContactEntity` metoden for å opprette en ny kontaktenhet med standardverdier fylt ut. Vi satte først noen av de grunnleggende verdiene som navn og avdeling.

Deretter har vi satt verdier til egenskaper for komplekse datatyper `EntityElement[]` som typer, enhetstyper som , enhetsinnsamlingstyper som , og `Associate` `Persons` typer.`LocalizedField` 

Til slutt lagres den nyopprettede kontaktenheten i databasen ved hjelp `SaveContactEntity` av agentmetoden. Med dette vil en ny post bli lagt til i kontakttabellen i databasen med feltene satt til verdier som er tilordnet.

Enheten returneres med den tildelte ID-en fylt ut.
