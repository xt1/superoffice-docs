---
title: Slik oppretter du en gjentakende avtale (datalag)
description: Slik oppretter du en gjentakende avtale ved hjelp av enheter på NetServer-datalaget.
keywords: dagbok, kalender, avtale, API, enhet, AppointmentMatrix, RecurrencePattern, RecurrenceDailyPattern
uid: create_recurring_appointment_entity-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Slik oppretter du en gjentakende avtale (datalag)

Dette demonstrerer bruken av [AvtaleMatrix][1] å opprette [gjentakende avtaler][2]. `SuperOffice.CRM.Entities.AppointmentMatrix`  er en matrise som inneholder informasjon om repeterende avtaler og deltakerne.

I det følgende eksempelet skal vi opprette en avtale kl. 14.00 i morgen som vil gjenta seg de neste 8 arbeidsdagene.

## Koden

[!code-csharp[CS](includes/create-recurring-apt-entity.cs)]

## Gjennomgang

Først har vi opprettet avtalen som skal gjentas, ved hjelp av `CreateNew` metoden som eksponeres i `Appointment` enheten. Teksten om avtalen angis nå, etterfulgt av å angi person, avtaletype og status for avtalen.

Deretter har vi opprettet matrisen for avtaler som passerer avtalen for å gjenta seg.

Når du skal opprette regelmessige avtaler, er det viktigste **å angi informasjon om gjentakelse** . Dette gjøres ved å opprette et mønster for gjentakelse. I dette eksempelet er mønsteret at avtalen skal gjentas daglig i 8 dager som starter fra i morgen. Dermed settes gjentakelsesmønstret til *Daglig* og angis ytterligere som *EveryWorkday*. Og `RecurrencePattern` `RecurrenceDailyPattern` er opplistinger.

Deretter har vi angitt start- og sluttdatoer for repetisjonsmønstret. Med `CalculateDays` metoden opprettes dagene for gjentakelsesmønstret.

Til slutt tildeles den gjentakende informasjonen til matrisen, og matrisen lagres i databasen.

<a href="../../../../assets/downloads/api/howtocreaterecurringappointment.zip" download>Hent kildekoden (zip)</a>

<!-- Referenced links -->
[1]: appointment-matrix.md
[2]: ../../recurring-appointments.md

<!-- Referenced images -->
