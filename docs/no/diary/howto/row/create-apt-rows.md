---
title: Opprette en avtale via radsamling (Rader)
description: Slik oppretter du en avtale via radsamling (Rader).
keywords: dagbok, kalender, avtale, API, rader, samling, AppointmentRows
uid: create_appointment_rows-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en avtale via radsamling (Rader)

`Rows` -typen består av en samling av rader, slik som `AppointmentRows` type, består av en samling av [AvtaleÅr][3] typer.

Derfor er det mulig å opprette en `AppointmentRow` med `AppointmentRows` klassen.

## Koden

[!code-csharp[CS](includes/create-apt-rows.cs)]

## Gjennomgang

En `AppointmentRow` kan opprettes på samme måte som i [dette eksempelet][1].

Neste fase av kodesegmentet er å starte en `AppointmentRows` klasse. Forekomsten kan deretter legges til i samlingen med kjøringen av `Add` metoden.

[!code-csharp[CS](includes/create-apt-rows.cs?range=20,23,26)]

Når `AppointmentRow` samlingen er lagt til, kan den lagres ved å kjøre `Save` metoden, noe som sikrer at den opprettede enheten legges til [avtaletabell][2] i databasen.

<!-- Referenced links -->
[1]: create-apt-row.md
[2]: ../../../database/tables/appointment.md
[3]: <xref:SuperOffice.CRM.Rows.AppointmentRow>
