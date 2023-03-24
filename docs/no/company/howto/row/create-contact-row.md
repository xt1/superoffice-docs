---
title: Opprette en personrad
description: Opprette en personrad
keywords: firma, person, API, rad, ContactRow
uid: create_contact_row-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en personrad

For å opprette en `ContactRow` bruker vi navneområdet `SuperOffice.CRM.Rows` .

Eksempelet nedenfor viser hvordan vi oppretter en person ved hjelp av `ContactRow` klassen.

## Koden

[!code-csharp[CS](includes/create-contact-row.cs)]

## Gjennomgang

Det første trinnet er å øyeblikkeliggjøre `ContactRow` klassen, og deretter er neste trinn å angi standardverdiene for den med `SetDefaults` metoden.

[!code-csharp[CS](includes/create-contact-row.cs?range=6,9)]

For å få tilgang til individuelle egenskaper som eksponeres gjennom `ContactRow` klassen, bruker vi slike uttalelser:

[!code-csharp[CS](includes/create-contact-row.cs?range=10)]

Når du kaller `Save()` tilgjengelig i `ContactRow` klassen, lagres den øyeblikkelige `ContactRow` forekomsten  i `contact` tabellen.
