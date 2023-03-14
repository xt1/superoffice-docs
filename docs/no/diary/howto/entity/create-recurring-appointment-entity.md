---
title: Hvordan lage en gjentakende avtale (datalag)
description: Slik oppretter du en regelmessig avtale ved hjelp av enheter på NetServer-datalaget.
uid: create_recurring_appointment_entity-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
keywords: diary, calendar, appointment, API, entity, AppointmentMatrix, RecurrencePattern, RecurrenceDailyPattern
so.topic: howto
# so.envir:
# so.client:
---

# Slik oppretter du en regelmessig avtale (datalag)

Dette demonstrerer bruken av [AvtaleMatrix][1] å lage [Regelmessige avtaler][2]. `SuperOffice.CRM.Entities.AppointmentMatrix`  er en matrise som inneholder informasjon om gjentatte avtaler og deres deltakere.

I det følgende eksemplet vil vi opprette en avtale kl. 14.00 i morgen som vil gjenta seg de neste 8 virkedagene.

## Kode

[!code-csharp[CS]](includes/create-recurring-apt-entity.cs)

## Gjennomgang

Først har vi opprettet avtalen som skal gjenta seg, ved hjelp av `CreateNew` metoden som er eksponert i `Appointment` enheten. Avtaleteksten angis deretter, etterfulgt av innstilling av kontakt, avtaletype og status for avtalen.

Deretter har vi opprettet avtalematrisen som passerer avtalen for å gjenta seg.

Når du oppretter regelmessige avtaler, er den viktigste delen **å angi informasjonen om regelmessighet.** Dette gjøres ved å lage et gjentakelsesmønster. I dette eksemplet er mønsteret som sådan at avtalen skal gjenta seg daglig i 8 dager fra i morgen. Dermed er gjentakelsesmønsteret satt til *Daglig* og videre spesifisert som *EveryWorkday*. Den `RecurrencePattern` og `RecurrenceDailyPattern` er oppregninger.

Deretter har vi satt start- og sluttdato for repetisjonsmønsteret. Ved hjelp av `CalculateDays` metoden opprettes dagene for gjentakelsesmønsteret.

Til slutt tilordnes gjentakelsesinformasjonen til matrisen og matrisen lagres i databasen.

<a href="../../../../assets/downloads/api/howtocreaterecurringappointment.zip" download>Få kildekoden (zip)</a>

<!-- Referenced links -->
[1]: appointment-matrix.md
[2]: ../../recurring-appointments.md

<!-- Referenced images -->
