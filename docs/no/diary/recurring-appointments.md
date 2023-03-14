---
title: Regelmessige avtaler
description: Gjentakende avtale
uid: recurring_appointment-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
keywords: diary, calendar, appointment, recurrence, recurrencerule, frequency, pattern
so.topic: concept
---

# Regelmessige avtaler

En gjentatt oppfølging er en serie med avtaler, oppgaver eller samtaler som er planlagt å skje med jevne mellomrom. For eksempel et ukentlig statusmøte. En gjentakende avtale lagres i to deler:

* En gjentakelsesregel, som definerer mønsteret for gjentakelsen
* Alle avtalene som er opprettet av gjentakelsen, opprettes i [avtale tabell][3], og hver peker på gjentakelsesregelen som definerer den.

> [!CAUTION]
> Å endre start- eller sluttdatoen på en gjentakende avtale etter at den er lagret, er en dårlig idé. Endring av klokkeslettet på en gjentakende avtale vil fungere fint, men endring av datoen vil bare føre til forvirring. **Hvis du endrer starttidspunktet for en avtale, utløses en oppdatering på alle tilbakefall av delsekvenser** hvis du har satt oppdateringsmodus til denne og fremover.

## Frekvens

| Verdi | Beskrivelse | Kommentar | Eksempel |
|:--|:--|:--|:--|
| daglig |hver  arbeidsdag hver<br>dag i uken | eller tilpasset | annenhver dag |
| ukentlig | hver uke på en gitt dag | må sette ukedag | hver 3. uke på tirsdag |
| månedlig | hver måned på en gitt dag | må angi dag i måneden  | på den 5. i måneden, hver 4. måned |
| årlig | hvert år på gitt dato | må angi dag og måned | hver 23 september |

En **syklus** er antall dager mellom hver gjentakelse.

Opplistingsverdiene samsvarer med det du ser i  dialogboksen **Mønster**.

![Tilbakevendende oppfølgingsdialog - skjermbilde][img1]

### Enum RecurrencePattern

| Verdi | Beskrivelse |
|:-:|:--|
| 0 | ukjent |
| 1 | daglig |
| 2 | ukentlig |
| 3 | månedlig |
| 4 | årlig |
| 5 | skikk |

### Enum RecurrenceSubPattern

| Verdi | Navn | Type | Beskrivelse |
|:-:|:--|---|---|
| 0 | Ukjent | | |
| 1 | Hver arbeidsdag| daglig | Man-fre |
| 2 | EveryWeekday | daglig | Man-søn |
| 3 | EveryCyclicDay | daglig | Syklisk intervall på dager |
| 4 | DagOfMonth | ukentlig | Gjenta på dag n i måneden<br>ex: den 17. dagen i hver 2. måned |
| 5 | UkedagOfMonth | ukentlig | gjenta på gitt ukedag <br>ex: den 3. torsdag i hver 3. måned |
| 6 | DagOfMonth | årlig | Gjenta på gitt dato hvert år |
| 7 | UkedagOfMonth | årlig | gjenta på gitte hverdager i måneden<br>eks: den 3. torsdag i hver august |

> [!CAUTION]
>  **Undermønsteret skal samsvare med mønsteret**. Det er lite feilkontroll hvis du blander feil sett. Du kan sette mønster = årlig og sub-mønster = dagligEveryDay og noe rart vil trolig skje.

#### Ukedager

| Verdi | Hverdag |
|:-:|:--|
| 0 | Ukjent |
| 1 | Mandag |
| 2 | Tirsdag |
| 4 | Onsdag |
| 8 | Torsdag |
| 16 | Fredag |
| 32 | Lørdag |
| 64 | Søndag |

> [!TIP]Opplistingsflaggverdier kan kombineres.
> 
#### Uke i måneden

| Verdi | Beskrivelse |
|:-:|:--|
| 0 | Ukjent |
| 1 | 1. uke i måneden |
| 2 | Den 2. uken i måneden |
| 3 | Den 3. uken i måneden |
| 4 | Den 4. uken i måneden |
| 5 | Den siste uken i måneden |

## Eksempel (SQL)

Systemet genererer avtaleposter for alle gjentakelsesforekomstene:

```SQL
SELECT appointment_id, associate_id, activeDate, type, status, recurrenceRuleId 
FROM appointment WHERE recurrenceRuleId = 1
```

| appointment_id | associate_id | aktivDate | type | status | gjentakelseRuleId |
|---|---|---|---|---|---|
| 264 | 15 | 2021-11-04 11:30:00 | 1 | 1 | 1 |
| 267 | 15 | 2021-11-09 11:30:00 | 1 | 1 | 1 |
| 268 | 15 | 2021-11-11 11:30:00 | 1 | 1 | 1 |
| 269 | 15 | 2021-11-16 11:30:00 | 1 | 1 | 1 |
| 270 | 15 | 2021-11-18 11:30:00 | 1 | 1 | 1 |
| 271 | 15 | 2021-11-23 11:30:00 | 1 | 1 | 1 |

La oss se på regelen:

```SQL
SELECT * FROM recurrencerule WHERE recurrencerule_id = 1
```

| RecurrenceRule_id | mønster | subPattern | startDate | endDate | syklisk dag | sykliskUke | cyclicMonth|
|---|---|---|---|---|---|---|---|
| 1 | 2 | 0 | 2021-11-04 11:30:00 | 2022-01-27 12:00:00 | 0 | 1 | 0 |

Denne gjentakelsesregelen har:

* mønster = 2 (ukentlig) (tilsvarer radioknappvalget i dialogboksen).
* subPattern = 0 (ingen)
* cyclicWeek = 1 = "hver 1 uke (er)"

## Redigering

Hvis du bestemmer deg for å endre regelmønsteret midt i en serie avtaler, opprettes en ny regel, og den gamle regelen stoppes på det punktet der bruddet oppstår.

Hvis du endrer starttidspunktet for en enkelt avtale, påvirkes ikke regelen. Oppnevningen behandles som et unntak fra regelen. Unntaket kan gjøres ueksepsjonelt ved å flytte det tilbake på linje med de andre avtalene.

## Slik gjør du det

* [Opprette regelmessig avtale - CRMScript][6]
* [Opprette gjentakende avtale – webtjenester][4]
* [Opprette regelmessig avtale – enhetslag][2]

## Les også

* [Tabell for gjentakelsesregel][1]
* [GjentakelsePattern enum][5]

<!-- Referenced links -->
[1]: ../database/tables/recurrencerule.md
[2]: howto/entity/create-recurring-appointment-entity.md
[3]: ../database/tables/appointment.md
[4]: howto/services/create-recurring-appointment-services.md
[5]: ../database/tables/enums/recurrencepattern.md
[6]: howto/crmscript/create-recurring-appointment.md

<!-- Referenced images -->
[img1]: media/recurrence-dialog.png
