---
title: Slik oppretter du en gjentakende avtale (tjenester)
description: Slik oppretter du en gjentakende avtale ved hjelp av tjenester
keywords: dagbok, kalender, avtale, API, webtjenester, gjentakelse
uid: create_recurring_appointment_ws-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
# so.envir:
# so.client:
---

# Slik oppretter du en regelmessig avtale (tjenester)

Dette viser hvordan du oppretter [gjentakende avtaler][2] med [NetServer-tjenester][1].

I det følgende eksempelet skal vi opprette en avtale kl. 14.00 i morgen som vil gjenta seg de neste 8 arbeidsdagene.

## Koden

[!code-csharp[CS](includes/create-recurring-apt-services.cs)]

## Gjennomgang

Når du oppretter en gjentakende avtale, opprettes det først en avtale, og da må informasjonen om gjentagelse angis i henhold til kravet. I koden ovenfor har vi opprettet en `AppointmentAgent`, som vi deretter bruker til å opprette en ny `AppointmentEntity`. Deretter angis avtaleteksten, personen og varigheten.

Informasjonen om gjentagelse angis ved å opprette et **mønster for gjentakelse** . Her vil vi at avtalen skal gjentas daglig i 8 dager som starter fra i morgen. Dermed settes gjentakelsesmønstret til *Daglig* og angis ytterligere som *EveryWorkday*. `RecurrencePattern`  og `RecurrenceDailyPattern` er opplistinger.

[!code-csharp[CS](includes/create-recurring-apt-services.cs?range=31-34)]

Siden den skal gjentas i 8 arbeidsdager, kan vi ikke angi en sluttdato direkte. Antall gjentalser settes i stedet til 8, og sluttdatoen for gjentakelse beregnes basert på antall gjentakelser:

[!code-csharp[CS](includes/create-recurring-apt-services.cs?range=38-39)]

Deretter opprettes gjentakelsesmønstret ved hjelp `CalculateDays` av agentens metode.  Til slutt tildeles den gjentakende informasjonen til , `AppointmentEntity` og avtalen lagres i databasen.

<a href="../../../../assets/downloads/api/createarecurringappointment.zip" download>Hent kildekoden (zip)</a>

<!-- Referenced links -->
[1]: ../../../api/web-services/index.md
[2]: ../../recurring-appointments.md

<!-- Referenced images -->
