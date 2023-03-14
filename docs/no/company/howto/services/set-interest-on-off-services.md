---
title: Hvordan sette en interesse på eller av
description: Hvordan sette en interesse på eller av for en kontakt ved hjelp av tjenester
uid: toggle_contact_interest_ws-no
author: {github-id}
so.date: 11.04.2021
keywords: contact, company, services, API, interest, ContactAgent, electableMDOListItem
so.topic: howto
# so.envir:
# so.client:
---

# Hvordan sette en interesse på eller av for en kontakt (tjenester)

Du kan bruke webtjenester til å endre den valgte statusen for en [rente][1] bestemt kontakt.

## Kode

[!code-csharp[CS]](includes/toggle-interest-services.cs)

## Gjennomgang

Vi har først hentet en `Contact` enhet ved hjelp av `ContactAgent`. Og brukte deretter `Interests` eiendommen til å hente kontaktens interesser i en `SelectableMDOListItem` matrise.

Deretter itererer vi på matrisen og endrer den boolske `Selected` eiendomsstatusen. Ved å bruke `SaveContactEntity` metoden som er  tilgjengelig i `Contact` agenten, lagrer vi endringene som er gjort i enheten.

<!-- Referenced links -->
[1]: ../../interests.md

<!-- Referenced images -->
