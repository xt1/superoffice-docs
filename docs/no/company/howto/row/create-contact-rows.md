---
title: Opprette en person via radsamling (Rader)
description: Slik oppretter du en person via radsamling (ContactRows).
keywords: firma, person, API, rader, ContactRows, samling
uid: create_contact_rows-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en person via radsamling (Rader)

Siden `Rows` typen består av en samling objekter `Row` , er det mulig å opprette en `ContactRow` med `ContactRows` klassen.

## Koden

[!code-csharp[CS](includes/create-contact-rows.cs)]

## Gjennomgang

1. Øyeblikkeliggjør `ContactRows` klassen ved hjelp av `CreateNew` metoden.

2. Tildel en `ContactRow` klasse og fordel de nødvendige verdiene til den. Forekomsten kan deretter legges til i samlingen med kjøringen av `Add` metoden.

3. Lagre personen:

    [!code-csharp[CS](includes/create-contact-rows.cs?range=14,16)]
