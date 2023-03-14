---
title: Dagbok
description: Introduksjon til dagboken og arbeid med avtaler.
uid: diary-overview-no
author: Bergfrid Skaara Dias
so.date: 03.22.2022
keywords: diary, calendar, appointment, associate, call, task, todo, follow-up
so.topic: concept
---

# Dagbok

Avtaler er grunnlaget for den SuperOffice dagboken.

![Dagbok skjerm -skjermbilde][img1]

Dagboken består av en kalender og en todoliste og brukes på samme måte som en Filofax med separate sider for hver dag, uke og måned.

* **Kalender**: Viser oppføringer som er tildelt et bestemt klokkeslett eller en bestemt dato
* **Todo-liste**: Viser ting du ennå ikke har fullført, for det meste samtaler og oppgaver uten tid eller dato

I brukergrensesnittet er begge nært knyttet til **Dagbok-skjermen**.

## Tre typer oppfølging

I SuperOffice CRM  er **oppfølging** en samlebetegnelse for **avtaler**, **telefonsamtaler** og **oppgaver** . Disse enhetene er alltid knyttet til [kollega][9] en  og har en form for tidsreferanse.

| type | Starttid | Sluttid | varighet | frist | Vises | beskrivelse | eksempel |
|---|:-:|:-:|:-:|:-:|---|---|---|
| avtale | x | x | kalkulert | | kalender | aktivitet m/definert start- og sluttidspunkt | Møter |
| oppgave/gjøremål | | | | x | Todo-liste | oppfølging m/ingen starttid | påminnelse om ting som forfaller innen et bestemt tidspunkt |
| kalle | x | | x | | Todo-liste | Telefonsamtale | |

> [!NOTE]Forfalte avtaler vil som standard også vises i todo-listen!
> >
> Loggførte telefonsamtaler vises også i kalenderen.

### Tidsstempelverdier

| Felt | Beskrivelse |
|:---|:---|
| registrert | UtcDateTime for registrering          |
| Oppdatert    | UtcDateTime for siste oppdatering           |
| gjort       | Når en oppgave ble fullført (DateTime) |
| do_by      | Planlagt tidsfrist for aktivitet (DateTime) |
| aktivDate | Vis dato (DateTime)              |
| endDate    | Planlagt fullføringstid (DateTime)   |

### Databasefelt som brukes ofte

| Felt | Beskrivelse |
|:---|:---|
| appointment_id | ID |
| associate_id   | eier |
| contact_id     | firma |
| person_id      | deltaker hvis et møte |
| task_idx       |FK Oppgave liste|
| type           | EnumAppointmentType |
| status         | EnumAppointmentStatus |
| mother_id      | For gruppereservasjoner og invitasjoner |
| plassering       | Egendefinert streng eller informasjon fra en bestilt ressurs |
| alldayEvent    | 0 = Nei; 1 = ja  |
| freeBusy       | 0 = opptatt; 1 = gratis |

Hvis du vil ha en fullstendig liste over felt, kan du se [database referanse][4].

## Avtaler

En **avtale** er en type **oppfølging** med et definert start- og sluttidspunkt, for eksempel et møte. Det vil bli vist i kalenderen til eierens dagbok.

[Medarbeider][9] fungerer som eier av avtalen. Hvis du ikke tilordner en tilknyttet til egenskapen for `Associate` avtalen,  blir gjeldende bruker eier av avtalen, og bare én rad legges til i [avtale][5] tabellen når avtalen lagres.

### Vanlige scenarier

| scenario | ressurs | 2+ deltakere | beskrivelse |
|---|:-:|:-:|---|
| egen tid reservert | | | du har satt av tid til å jobbe med noe, alene |
| egen tid og ressurs reservert   | x | | som ovenfor + trenger rom eller utstyr |
| møte m/ flere deltakere | x | x | et møte, vanligvis også m/ en ressurs eller et sted  |

**Også:**

* Avtaler kan være enkelthendelser eller en del av en gjentakende serie.
* Forfalte og fullførte avtaler vil være i todo-listen i tillegg til i kalenderen.
* Avtaler som involverer en ressurs og/eller flere deltakere kalles **bestillinger** (eller gruppereservasjon).
* Avtaler kan opprettes av eieren eller tildeles/delegeres til en tilknyttet.

### Typer

| Type | Beskrivelse |
|:----:|:--|
| 0 | Udefinert/initialisert |
| 1 | I kalender, hvis forfalt eller gjort i dag, også i todo liste |
| 2 | I todo-listen (ingen starttid) |
| 6 | Møteinvitasjon (endres til 1 når den godtas) |
| 7 | Ventende tildeling (endres til 2 når den godtas) |

### Status

| Status | Beskrivelse |
|:-:|:--|
| 0 | Ukjent/ en post-it |
| 1 | Ikke startet |
| 2 | Startet |
| 3 | Fullført |
| 4 | Skjult |
| 5-10 | Booking |
| 11-13 | Oppdrag |

## Todo-liste

En **oppgave** er en oppfølging uten starttid. Det har vanligvis ikke en varighet heller, men det har alltid en **frist**.
Oppgaver brukes vanligvis til ting du må huske å gjøre innen en viss tid.

Som standard finner du oppgaver i dagbokens todo-liste, der de kan krysses av når de er fullført.

## Samtaler

En **samtale** er en oppfølging som representerer en veldig spesifikk handling - telefonsamtalen.

Det er også ganske hybrid mellom en avtale og en oppgave:

* Når du først planlegger en samtale, lever den i todo-listen med en frist som ligner på en oppgave.
* Når du ringer, blir det løst i tide og ligner nå en avtale.
  * Starttidspunktet blir gjeldende klokkeslett og dagens dato.
  * Standard varighet er 15 minutter.

## Oppfølginger kontra andre enheter

Oppfølginger er en del av en bredere gruppe enheter merket **aktiviteter**:

* Oppfølging
  * avtale
  * oppgave
  * kalle
* Dokumenter
  * [dokument][11]
  * [E-post][10]
* utsendelser og skjemainnleveringer
* [Chat-økter][12]

Når du arbeider med oppfølging, vil data ofte krysse med følgende enheter:

* [firma][1] (kontakt tabell)
* [kontakt][2] (person tabell)
* [prosjekt][4]
* [salg][3]

## Les også

* [Regelmessige avtaler][6]
* [Invitasjoner][7]
* [Arbeide med avtaler i API][8]

<!-- Referenced links -->
[1]: ../company/index.yml
[2]: ../contact/index.yml
[3]: ../sale/index.yml
[4]: ../project/index.yml
[5]: ../database/tables/appointment.md
[6]: recurring-appointments.md
[7]: invitations.md
[8]: howto/index.md
[9]: ../contact/associate.md
[10]: ../email/index.yml
[11]: ../document/index.yml
[12]: ../automation/chatbot/index.md

<!-- Referenced images -->
[img1]: media/diary-screen.png
