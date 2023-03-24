---
title: Dagbok
description: Introduksjon til dagboken og arbeid med avtaler.
keywords: dagbok, kalender, avtale, medarbeider, samtale, oppgave, todo, oppfølging
uid: diary-overview-no
author: Bergfrid Skaara Dias
so.date: 03.22.2022
so.topic: concept
---

# Dagbok

Avtaler er grunnlaget for den SuperOffice dagboken.

![Dagbok skjermbilde][img1]

Dagboken består av en kalender og en todoliste og brukes på samme måte som en Filofax med egne sider for hver dag, uke og måned.

* **kalender** : Viser oppføringer som er tildelt et bestemt klokkeslett eller en bestemt dato
* **todo-liste** : Viser ting du ennå ikke har utført, for det meste samtaler og oppgaver uten tid eller dato

I brukergrensesnittet er begge nært knyttet til **** Dagbok-bildet.

## Tre typer oppfølginger

I SuperOffice CRM  er **oppfølging** en samlebetegnelse for **avtaler** , **telefonsamtaler** og **oppgaver** . Disse enhetene er alltid knyttet til en [Knytte][9] og har en eller annen form for tidsreferanse.

| Type | starttid | sluttidspunkt | Varighet | Fristen | Vises | Beskrivelse | Eksempel |
|---|:-:|:-:|:-:|:-:|---|---|---|
| Avtale | X | X | Beregnet | | Kalender | aktivitet m/ definert start- og sluttidspunkt | Møter |
| oppgave/todo | | | | X | todo-liste | oppfølging m/ ingen starttid | påminnelse om ting som forfaller av et bestemt tidspunkt |
| Kaller | X | | X | | todo-liste | Telefonsamtale | |

> [!NOTE]Forfalte avtaler vil som standard også vises i todo-listen!
> >
> Loggførte samtaler vises også i kalenderen.

### Tidsstempelverdier

| Feltet | Beskrivelse |
|:---|:---|
| Registrert | UtcDateTime for registrering          |
| Oppdatert    | UtcDateTime for siste oppdatering           |
| Gjort       | Når en oppgave ble fullført (DateTime) |
| do_by      | Planlagt tidsfrist for oppgave (DateTime) |
| activeDate | Visningsdato (DateTime)              |
| sluttDato    | Planlagt sluttid (DateTime)   |

### Ofte brukte databasefelt

| Feltet | Beskrivelse |
|:---|:---|
| appointment_id | ID |
| associate_id   | Eier |
| contact_id     | Selskapet |
| person_id      | deltaker hvis et møte |
| task_idx       |FK Oppgave liste|
| Type           | EnumAppointmentType |
| Status         | EnumAppointmentStatus |
| mother_id      | For gruppereservasjoner og invitasjoner |
| Plasseringen       | Tilpasset streng eller info fra en bestilt ressurs |
| alldayEvent    | 0 = nei; 1 = ja  |
| freeBusy       | 0 = opptatt; 1 = gratis |

Hvis du vil ha en fullstendig liste over felt, kan du se [databasereferanse][4].

## Avtaler

En **avtale** er en type **oppfølging** med definert start- og sluttid, for eksempel et møte. Den vises i kalenderen til eierens dagbok.

[Medarbeider][9] fungerer som eier av avtalen. Hvis du ikke tilordner en medarbeider til eiendommen til `Associate` avtalen, blir den gjeldende brukeren eier av avtalen, og bare én rad blir lagt til i [Avtale][5] tabellen når avtalen lagres.

### Vanlige scenarioer

| Scenario | Ressurs | 2+ deltakere | Beskrivelse |
|---|:-:|:-:|---|
| egen tid reservert | | | du har satt av tid til å jobbe med noe, alene |
| egen tid og ressurs reservert   | X | | som ovenfor + trenger plass eller utstyr |
| møte m/ flere deltakere | X | X | et møte, ofte også m / en ressurs eller plassering  |

 **Også:** 

* Avtaler kan være enkle hendelser eller deler av en gjentakende serie.
* Forfalte og utførte avtaler vil stå på todolisten i tillegg til i kalenderen.
* Avtaler som involverer en ressurs og/eller flere deltakere, kalles **bestillinger** (eller gruppereservasjon).
* Avtaler kan opprettes av eieren eller tilordnet/delegert til en medarbeider.

### Typer

| Type | Beskrivelse |
|:----:|:--|
| 0 | Udefinert/initialisering |
| 1 | I kalender, hvis det er forfalt eller gjort i dag, også i todolisten |
| 2 | I todo-listen (ingen starttidsliste) |
| 6 | Møteinvitasjon (endres til 1 når det godtas) |
| 7 | Venter på tilordning (endres til 2 når de godtas) |

### Status

| Status | Beskrivelse |
|:-:|:--|
| 0 | Ukjent/post-it |
| 1 | Ikke startet |
| 2 | Startet |
| 3 | Fullført |
| 4 | Skjult |
| 5-10 | Booking |
| 11-13 | Tildeling |

## Todo-liste

En **oppgave** er en oppfølging uten starttid. Det har vanligvis ikke varighet heller, men den har alltid en **tidsfrist** .
Oppgaver vanligvis brukes til ting du må huske å gjøre innen en viss tid.

Som standard finner du oppgaver i listen over todoer i dagboken, der de kan sjekkes av når de er utført.

## Samtaler

En **samtale** er en oppfølging som representerer en svært spesifikk handling - samtalen.

Det er også en slags hybrid mellom en avtale og en oppgave:

* Når du først planlegger en samtale, bor den i todolisten med en tidsfrist omtrent som en oppgave.
* Når du foretar samtalen, fikses den i tide og ligner nå på en avtale.
  * Starttidspunktet blir gjeldende klokkeslett og dagens dato.
  * Standard varighet er 15 minutter.

## Oppfølginger kontra andre enheter

Oppfølginger er en del av en bredere gruppe av  merkede **aktiviteter** :

* Oppfølging
  * Avtale
  * Oppgave
  * Kaller
* Dokumenter
  * [Dokumentet][11]
  * [Email][10]
* utsendelse og skjemainnsendinger
* [chatsesjoner][12]

Når du arbeider med oppfølginger, krysser ofte data sammen med følgende enheter:

* [Selskapet][1] (Persontabell)
* [Kontakt][2] (persontabell)
* [Prosjektet][4]
* [Salg][3]

## Se også

* [Gjentakende avtaler][6]
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
