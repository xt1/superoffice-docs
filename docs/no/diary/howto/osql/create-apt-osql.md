---
title: Opprette en avtale via OSQL
description: Slik oppretter du en avtale via OSQL.
keywords: dagbok, kalender, avtale, API, OSQL, AppointmentTableInfo
uid: create_appointment_osql-no
author: Bergfrid Skaara Dias
so.date: 03.02.2022
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en avtale via OSQL

[!include [viktige OSQL-navneområder](../../../api/includes/using-osql.md)]

Eksempelet nedenfor viser hvordan vi kan opprette en avtale ved hjelp av OSQL.

## Koden

[!code-csharp[CS](includes/create-apt-osql.cs)]

## Gjennomgang

Siden vi skal opprette en avtale, må vi opprette en forekomst av  med [AvtaleTableInfo][3] bruk av `TablesInfo` klassens [GetAppointmentTableInfo()][2]:

[!code-csharp[CS](includes/create-apt-osql.cs?range=8)]

Deretter oppretter vi en forekomst av `Insert` klassen som kan brukes til å oppdatere [avtaletabell][1]. Etter at forekomsten er opprettet, kan vi bruke forekomsten til å oppdatere feltene i `appointment` tabellen.

[!code-csharp[CS](includes/create-apt-osql.cs?range=11,14-15)]

Når ønskede felt er lagt til, opprettes det en databaseforbindelse ved bruk av feltene, `ConnectionFactory` og verdiene settes inn i databasen med `ExecuteNonQuery` metoden.

> [!NOTE]I OSQL finnes det ingen metode som gir standardverdier. Det er nødvendig å sette inn verdier i alle obligatoriske kolonner. Hvis det ikke oppstår et kjøretidsunntak, vil det forekomme.
> 
<!-- Referenced links -->
[1]: ../../../database/tables/appointment.md
[2]: <xref:SuperOffice.Data.TablesInfo.GetAppointmentTableInfo>
[3] <xref:SuperOffice.CRM.Data.AppointmentTableInfo>

<!-- Referenced images -->
