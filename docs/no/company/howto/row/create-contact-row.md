---
title: Opprett en kontaktrad
description: Opprett en kontaktrad
uid: create_contact_row-no
author: {github-id}
so.date: 05.11.2016
keywords: company, contact, API, row, ContactRow
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en kontaktrad

For å lage en `ContactRow` bruker vi navnerommet `SuperOffice.CRM.Rows` .

Følgende eksempel viser hvordan vi oppretter en kontakt ved hjelp av `ContactRow` klassen.

## Kode

[!code-csharp[CS]](includes/create-contact-row.cs)

## Gjennomgang

Det første trinnet  er å starte `ContactRow` klassen, og deretter er neste trinn å angi standardverdiene for den med metoden `SetDefaults` .

[!code-csharp[CS]](includes/create-contact-row.cs?range=6,9)

For å få tilgang til individuelle eiendommer eksponert gjennom `ContactRow` klassen bruker vi utsagn som dette:

[!code-csharp[CS]](includes/create-contact-row.cs?range=10)

Ringer `Save()` tilgjengelig  i `ContactRow` klassen, vil den instansierte `ContactRow` bli lagret i bordet `contact` .
