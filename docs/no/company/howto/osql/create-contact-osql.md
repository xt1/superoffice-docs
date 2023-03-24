---
title: Opprette en person via OSQL
description: Slik oppretter du en person via OSQL
keywords: person, firma, OSQL, API
uid: create_contact_osql-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en person via OSQL

[!include [viktige OSQL-navneområder](../../../api/includes/using-osql.md)]

Eksemplet nedenfor viser hvordan vi kan opprette en person ved hjelp av OSQL.

## Koden

[!code-csharp[CS](includes/create-contact-osql.cs)]

## Gjennomgang

Etter at du har importert ønskede navneområder, må du opprette et datasett for de påkrevde tabellene. I så fall tabellen `contact` .

[!code-csharp[CS](includes/create-contact-osql.cs?range=8)]

Det neste trinnet er å opprette en forekomst av `Insert` klassen som brukes til å oppdatere `contact` tabellen.

[!code-csharp[CS](includes/create-contact-osql.cs?range=11)]

Etter at `Insert` forekomsten er opprettet, bør ønsket felt legges til med `Add` metoden for `FieldValuePairs` egenskapen som vises i `Insert` klassen. Kolonnenavnet og verdien bør sendes som vist nedenfor:

[!code-csharp[CS](includes/create-contact-osql.cs?range=14-15)]

Når alle ønskede felt er lagt til, oppretter vi en `SoConnection` forekomst med bruk av `ConnectionFactory`metoden , `GetConnection` .

[!code-csharp[CS](includes/create-contact-osql.cs?range=29)]

Deretter oppretter `SoCommand` og `SoTransaction` forekomster som vist nedenfor, og tilordner den øyeblikkelige transaksjonen til egenskapen til `Transaction` den øyeblikkelige `SoCommand`.

[!code-csharp[CS](includes/create-contact-osql.cs?range=32-33,36-37)]

For å kunne kjøre den opprettede innsettingssetningen må vi tildele den til egenskapen til `SqlCommand` den opprettede `SoCommand` forekomsten og deretter kjøre `ExecuteNonQuery` metoden for den.

[!code-csharp[CS](includes/create-contact-osql.cs?range=40-41)]

Når kommandoen er utført, utføres transaksjonen, og koblingen til databasen lukkes.

[!code-csharp[CS](includes/create-contact-osql.cs?range=44-45)]
