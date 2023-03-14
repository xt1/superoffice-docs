---
title: Opprett en avtale gjennom OSQL
description: Hvordan lage en avtale gjennom OSQL.
uid: create_appointment_osql-no
author: Bergfrid Skaara Dias
so.date: 03.02.2022
keywords: diary, calendar, appointment, API, OSQL, AppointmentTableInfo
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en avtale gjennom OSQL

[!include [importere OSQL-navneområder](../../../api/includes/using-osql.md)]

Følgende eksempel viser hvordan vi kan opprette en avtale ved hjelp av OSQL.

## Kode

[!code-csharp[CS]](includes/create-apt-osql.cs)

## Gjennomgang

Siden vi oppretter en avtale, må vi opprette en forekomst av med [AppointmentTableInfo][3] bruk av `TablesInfo` klassens [GetAppointmentTableInfo()][2]:

[!code-csharp[CS]](includes/create-apt-osql.cs?range=8)

Deretter oppretter vi en forekomst av `Insert` klassen som kan brukes til å oppdatere [avtale tabell][1]. Når forekomsten er opprettet, kan vi bruke forekomsten til å oppdatere feltene i `appointment` tabellen.

[!code-csharp[CS]](includes/create-apt-osql.cs?range=11,14-15)

Når de nødvendige feltene er lagt til, vil en databaseforbindelse bli opprettet ved bruk av og `ConnectionFactory` verdiene vil bli satt inn i databasen med metoden `ExecuteNonQuery` .

> [!NOTE]I OSQL finnes det ingen metode som angir standardverdier. Det er nødvendig å sette inn verdier i alle obligatoriske kolonner. Hvis ikke vil det oppstå et kjøretidsunntak.
> 
<!-- Referenced links -->
[1]: ../../../database/tables/appointment.md
: [2]: <xref:SuperOffice.Data.TablesInfo.GetAppointmentTableInfo>
[3] <xref:SuperOffice.CRM.Data.AppointmentTableInfo>

<!-- Referenced images -->
