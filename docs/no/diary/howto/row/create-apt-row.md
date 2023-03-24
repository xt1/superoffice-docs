---
title: Opprette en avtalerad
description: Slik oppretter du en avtalerad.
keywords: dagbok, kalender, avtale, API, rad, AvtaleRow
uid: create_appointment_row-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en avtalerad

En [AvtaleÅr][2] refererer til en rad i [tabell for avtaledatabase][1]. Den består derfor av grunnleggende datatyper som støttes av SQL. For å opprette en `AppointmentRow` bruker vi navneområdet `SuperOffice.CRM.Rows` .

Eksempelet nedenfor viser hvordan vi oppretter en avtale ved hjelp av `AppointmentRow` klassen.

## Koden

[!code-csharp[CS](includes/create-apt-row.cs)]

## Gjennomgang

Det første trinnet i eksempelet viser hvordan du umiddelbart angir en `AppointmentRow` klasse, og deretter angir neste trinn standardverdiene for den med `SetDefaults` metoden.

[!code-csharp[CS](includes/create-apt-row.cs?range=6,9)]

De neste uttalelsene viser hvordan de ulike egenskapene til disse `AppointmentRow` er tildelt. Når slike fordelinger er gjort, kan raden lagres med `Save` metoden som er tilgjengelig i `AppointmentRow` klassen.

<!-- Referenced links -->
[1]: ../../../database/tables/appointment.md
[2]: <xref:SuperOffice.CRM.Rows.AppointmentRow>
