---
title: Slik setter du en interesse på eller av
description: Slik setter du interesse for en person ved hjelp av tjenester
keywords: person, firma, tjenester, API, interesse, ContactAgent, valgbarMDOListItem
uid: toggle_contact_interest_ws-no
author: {github-id}
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Slik setter du en interesse av eller på for en person (tjenester)

Du kan bruke webtjenester til å endre valgt status for en [Interesse][1] bestemt person.

## Koden

[!code-csharp[CS](includes/toggle-interest-services.cs)]

## Gjennomgang

Vi har først hentet en enhet `Contact` ved hjelp av `ContactAgent`. Og deretter brukte `Interests` egenskapen sin til å hente personens interesser inn i en `SelectableMDOListItem` matrise.

Deretter iterer vi på matrisen og endrer den boolske egenskapsstatusen `Selected` . Ved å bruke `SaveContactEntity` metoden som er tilgjengelig i agenten `Contact` , lagrer vi modifikasjonene som er gjort i enheten.

<!-- Referenced links -->
[1]: ../../interests.md

<!-- Referenced images -->
