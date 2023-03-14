---
title: Opprett en kontakt via OSQL
description: Hvordan lage en kontakt gjennom OSQL
uid: create_contact_osql-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
keywords: contact, company, OSQL, API
so.topic: howto
# so.envir:
# so.client:
---

# Opprett en kontakt gjennom OSQL

[!include [importere OSQL-navneområder](../../../api/includes/using-osql.md)]

Følgende eksempel viser hvordan vi kan opprette en kontakt ved hjelp av OSQL.

## Kode

[!code-csharp[CS]](includes/create-contact-osql.cs)

## Gjennomgang

Når du har importert de nødvendige navneområdene, må du opprette et datasett med de nødvendige tabellene. I dette tilfellet tabellen `contact` .

[!code-csharp[CS]](includes/create-contact-osql.cs?range=8)

Det neste trinnet er å opprette en forekomst av `Insert` klassen som brukes til å oppdatere `contact` tabellen.

[!code-csharp[CS]](includes/create-contact-osql.cs?range=11)

Når `Insert` forekomsten er opprettet, skal det obligatoriske feltet legges til med `Add` metoden for egenskapen `FieldValuePairs` som vises i `Insert` klassen. Kolonnenavnet og verdien skal sendes som vist nedenfor:

[!code-csharp[CS]](includes/create-contact-osql.cs?range=14-15)

Når alle obligatoriske felt er lagt til, oppretter vi en `SoConnection` forekomst med bruk av `ConnectionFactory`, `GetConnection` metoden.

[!code-csharp[CS]](includes/create-contact-osql.cs?range=29)

Deretter oppretter vi `SoCommand`  og `SoTransaction` forekomster som vist nedenfor og tilordner den instantierte transaksjonen  til `Transaction` eiendommen til den instansierte `SoCommand`.

[!code-csharp[CS]](includes/create-contact-osql.cs?range=32-33,36-37)

For å utføre den opprettede innsettingssetningen må vi tilordne den til egenskapen til `SqlCommand` den  opprettede `SoCommand` forekomsten og deretter utføre metoden for `ExecuteNonQuery` den.

[!code-csharp[CS]](includes/create-contact-osql.cs?range=40-41)

Når kommandoen er utført, vil transaksjonen bli begått og forbindelsen til databasen vil bli stengt.

[!code-csharp[CS]](includes/create-contact-osql.cs?range=44-45)
