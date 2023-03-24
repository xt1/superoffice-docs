---
title: Gjentakende avtaler
description: Gjentakende avtale
keywords: dagbok, kalender, avtale, gjentakelse, gjentakelse, frekvens, mønster
uid: recurring_appointment-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
so.topic: concept
---

# Gjentakende avtaler

En repeterende oppfølging er en serie med avtaler, oppgaver eller samtaler som er planlagt å forekomme med regelmessige mellomrom. Et ukentlig statusmøte. En gjentakende avtale lagres i to deler:

* En gjentakelsesregel, som definerer mønsteret for gjentakelse
* Alle avtalene som opprettes av gjentakelsen, opprettes i [avtaletabell][3], og hver av dem peker på den gjentakende regelen som definerer den.

> [!CAUTION]
> Det er feil å endre start- eller sluttdatoen på en gjentakende avtale etter at den er lagret. Hvis du endrer klokkeslettet for en gjentakende avtale, går det bra å endre datoen, men hvis du endrer datoen, vil det bare føre til forvirring. **Hvis du endrer starttidsfeltet på en avtale, utløses det en oppdatering på alle gjentakelser** hvis du har satt oppdateringsmodusen til denne og videresendingen.

## Frekvens

| Verdi | Beskrivelse | Kommentar | Eksempel |
|:--|:--|:--|:--|
| Daglig | hver arbeidsdag<br>hver ukedag | eller egendefinert | annenhver dag |
| Ukentlig | hver uke på gitt dag | må angi ukedag | hver 3. uke på tirsdag |
| Månedlig | hver måned på gitt dag | må angi månedsdag  | den 5. |
| Årlig | hvert år på gitt dato | må angi dag og måned | hver 23 september |

En **syklus** er antall dager mellom hver gjentakelse.

Opplistingsverdiene samsvarer med det du ser i  dialogboksen **Mønster** .

![Gjentakende oppfølgingsdialogboks -skjermbilde][img1]

### Enum RecurrencePattern

| Verdi | Beskrivelse |
|:-:|:--|
| 0 | Ukjent |
| 1 | Daglig |
| 2 | Ukentlig |
| 3 | Månedlig |
| 4 | Årlig |
| 5 | Egendefinerte |

### Enum RecurrenceSubPattern

| Verdi | Navn | Type | Beskrivelse |
|:-:|:--|---|---|
| 0 | Ukjent | | |
| 1 | Hver arbeidsdag| Daglig | Man-fre |
| 2 | Hver ukedag | Daglig | Man-Søn |
| 3 | EveryCyclicDay | Daglig | syklisk intervall på dager |
| 4 | DagAvMonth | Ukentlig | gjenta på dag n i måneden<br>ex: den 17. dagen i hver 2. måned |
| 5 | UkedagMonth | Ukentlig | gjenta på gitt ukedag <br>ex: den tredje torsdagen i hver 3 måneder |
| 6 | DagAvMonth | Årlig | gjentas på gitt dato hvert år |
| 7 | UkedagMonth | Årlig | gjenta på gitte ukedager i måneden<br>ex: den tredje torsdagen i hver august |

> [!CAUTION]
> Undermønstret **skal samsvare med mønsteret** . Det er lite feilkontroll hvis du blander feil sett. Du kan angi mønster = årlig og undermønstret = dagligEveryDay og noe rart vil trolig skje.

#### Ukedager

| Verdi | Ukedag |
|:-:|:--|
| 0 | Ukjent |
| 1 | Mandag |
| 2 | Tirsdag |
| 4 | Onsdag |
| 8 | Torsdag |
| 16 | Fredag |
| 32 | Lørdag |
| 64 | Søndag |

> [!TIP]Nummereringsflaggverdier kan kombineres.
> 
#### Uke i måned

| Verdi | Beskrivelse |
|:-:|:--|
| 0 | Ukjent |
| 1 | Månedens første uke |
| 2 | Den andre uken i måneden |
| 3 | Den 3. uke i måneden |
| 4 | Den fjerde uken i måneden |
| 5 | Den siste uken i måneden |

## Eksempel (SQL)

Systemet genererer avtaleposter for alle forekomster av gjentagelse:

```SQL
SELECT appointment_id, associate_id, activeDate, type, status, recurrenceRuleId 
FROM appointment WHERE recurrenceRuleId = 1
```

| appointment_id | associate_id | activeDate | Type | Status | recurrenceRuleId |
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

| RecurrenceRule_id | Mønster | subPattern | startDato | sluttDato | syklisk dag | cyclicWeek | cyclicMonth|
|---|---|---|---|---|---|---|---|
| 1 | 2 | 0 | 2021-11-04 11:30:00 | 2022-01-27 12:00:00 | 0 | 1 | 0 |

Denne gjentakelsesregelen har følgende:

* mønster = 2 (ukentlig) (tilsvarer alternativknappen i dialogboksen).
* subPattern = 0 (ingen)
* cyclicWeek = 1 = "hver 1 uke(er)"

## Redigering

Hvis du bestemmer deg for å endre regelmønstret midt i en rekke avtaler, opprettes det en ny regel, og den gamle regelen stoppes på det punktet hvor pausen inntreffer.

Hvis du endrer starttidspunkt for én avtale, berøres ikke regelen. Avtalen behandles som et unntak fra regelen. Unntaket kan gjøres u eksepsjonell ved å flytte det tilbake i tråd med de andre avtalene.

## Tos

* [Opprett gjentakende avtale - CRMScript][6]
* [Opprette gjentakende avtale – webtjenester][4]
* [Opprette gjentakende avtale – enhetslag][2]

## Se også

* [gjentagelsestabell][1]
* [GjentagelsePattern-opplisting][5]

<!-- Referenced links -->
[1]: ../database/tables/recurrencerule.md
[2]: howto/entity/create-recurring-appointment-entity.md
[3]: ../database/tables/appointment.md
[4]: howto/services/create-recurring-appointment-services.md
[5]: ../database/tables/enums/recurrencepattern.md
[6]: howto/crmscript/create-recurring-appointment.md

<!-- Referenced images -->
[img1]: media/recurrence-dialog.png
