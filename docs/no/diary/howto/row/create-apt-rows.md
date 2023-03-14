---
title: Opprette en avtale gjennom radsamling (rader)
description: Slik oppretter du en avtale gjennom radsamling (rader).
uid: create_appointment_rows-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
keywords: diary, calendar, appointment, API, rows, collection, AppointmentRows
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en avtale via radsamling (rader)

`Rows`Type består av en samling  rader, for eksempel Type, består av en samling `AppointmentRows` typer [AppointmentRow][3] .

Derfor er det mulig å lage en `AppointmentRow` med klassen `AppointmentRows` .

## Kode

[!code-csharp[CS]](includes/create-apt-rows.cs)

## Gjennomgang

En `AppointmentRow` kan opprettes som i [dette eksemplet][1].

Den neste fasen av kodesegmentet er å starte en `AppointmentRows` klasse. Forekomsten kan deretter legges til samlingen med utførelsen av `Add` metoden.

[!code-csharp[CS]](includes/create-apt-rows.cs?range=20,23,26)

Når samlingen `AppointmentRow` er lagt til, kan den lagres ved å utføre `Save` metoden, som sikrer at den opprettede enheten legges til [avtale tabell][2] i databasen.

<!-- Referenced links -->
[1]: create-apt-row.md
[2]: ../../../database/tables/appointment.md
[3]: <xref:SuperOffice.CRM.Rows.AppointmentRow>
