---
title: Opprette en avtalerad
description: Slik oppretter du en avtalerad.
uid: create_appointment_row-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
keywords: diary, calendar, appointment, API, row, AppointmentRow
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en avtalerad

En [AppointmentRow][2] refererer til en rad i [database tabell for avtaledatabase][1]. Derfor består den av grunnleggende datatyper som støttes av SQL. For å opprette en `AppointmentRow` bruker vi navnerommet `SuperOffice.CRM.Rows` .

Følgende eksempel viser hvordan vi oppretter en avtale ved hjelp av `AppointmentRow` klassen.

## Kode

[!code-csharp[CS]](includes/create-apt-row.cs)

## Gjennomgang

Det første trinnet i eksemplet viser hvordan du starter en `AppointmentRow` klasse, og deretter er neste trinn å angi standardverdiene for den med metoden `SetDefaults` .

[!code-csharp[CS]](includes/create-apt-row.cs?range=6,9)

De neste setningene viser hvordan de forskjellige egenskapene til de `AppointmentRow` tilordnes. Når slike oppgaver er gjort, kan raden lagres med metoden som er `Save` tilgjengelig i `AppointmentRow` klassen.

<!-- Referenced links -->
[1]: ../../../database/tables/appointment.md
[2]: <xref:SuperOffice.CRM.Rows.AppointmentRow>
