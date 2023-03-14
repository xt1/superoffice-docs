---
title: Opprette en kontakt gjennom radsamling (rader)
description: Hvordan lage en kontakt gjennom radsamling (ContactRows).
uid: create_contact_rows-no
author: {github-id}
so.date: 05.11.2016
keywords: company, contact, API, rows, ContactRows, collection
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en kontakt via radsamling (rader)

Fordi `Rows` typen består av en samling `Row` objekter, er det mulig å lage en `ContactRow` med klassen `ContactRows` .

## Kode

[!code-csharp[CS]](includes/create-contact-rows.cs)

## Gjennomgang

1. Start `ContactRows` klassen ved hjelp av `CreateNew` metoden.

2. Start en `ContactRow` klasse og tilordne de nødvendige verdiene til den. Forekomsten kan deretter legges til samlingen med utførelsen av `Add` metoden.

3. Lagre kontakten:

    [!code-csharp[CS]](includes/create-contact-rows.cs?range=14,16)
