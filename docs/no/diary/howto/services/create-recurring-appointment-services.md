---
title: Hvordan lage en gjentakende avtale (tjenester)
description: Hvordan lage en gjentakende avtale ved hjelp av tjenester
uid: create_recurring_appointment_ws-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: diary, calendar, appointment, API, web services, recurrence
so.topic: howto
# so.envir:
# so.client:
---

# Slik oppretter du en regelmessig avtale (tjenester)

Dette viser hvordan du oppretter [Regelmessige avtaler][2] ved hjelp av [NetServer-tjenester][1].

I det følgende eksemplet vil vi opprette en avtale kl. 14.00 i morgen som vil gjenta seg de neste 8 virkedagene.

## Kode

[!code-csharp[CS]](includes/create-recurring-apt-services.cs)

## Gjennomgang

Når du oppretter en regelmessig avtale, opprettes først en avtale, og deretter må regelmessighetsinformasjonen angis i henhold til kravet. I koden ovenfor har vi opprettet  en `AppointmentAgent`, som vi deretter bruker til å lage en ny `AppointmentEntity`. Deretter angis avtaleteksten, kontakten og varigheten.

Informasjonen om regelmessighet angis ved å opprette et **mønster for regelmessighet**. Her ønsker vi at avtalen skal gjenta seg daglig i 8 dager fra i morgen. Dermed er gjentakelsesmønsteret satt til *Daglig* og videre spesifisert som *EveryWorkday*. `RecurrencePattern`  og `RecurrenceDailyPattern` er oppregninger.

[!code-csharp[CS]](includes/create-recurring-apt-services.cs?range=31-34)

Fordi det skal gjenta seg i 8 virkedager, kan vi ikke spesifisere en sluttdato direkte. I stedet settes antall regelmessigheter til 8, og sluttdatoen for regelmessighet beregnes basert på antall regelmessigheter:

[!code-csharp[CS]](includes/create-recurring-apt-services.cs?range=38-39)

Deretter opprettes tilbakefallsmønsteret ved hjelp `CalculateDays` av agentmetoden.  Til slutt tilordnes gjentakelsesinformasjonen til og `AppointmentEntity` avtalen lagres i databasen.

<a href="../../../../assets/downloads/api/createarecurringappointment.zip" download>Få kildekoden (zip)</a>

<!-- Referenced links -->
[1]: ../../../api/web-services/index.md
[2]: ../../recurring-appointments.md

<!-- Referenced images -->
