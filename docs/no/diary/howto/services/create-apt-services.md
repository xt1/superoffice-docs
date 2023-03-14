---
title: Opprett en avtale ved hjelp av tjenester
description: Opprette en avtale ved hjelp av NetServer-tjenester
uid: create_appointment_services-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: diary, calendar, appointment, API, web services
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en avtale ved hjelp av tjenester

Dette eksemplet viser deg hvordan du oppretter en avtale ved hjelp av [NetServer-tjenester][1]. Den nye avtalen vil bli lagt til i dagboken til tilknyttet 103 av den innloggede brukeren er SAL0.

## Kode

[!code-csharp[CS]](includes/create-apt-services.cs)

## Gjennomgang

I eksemplet lager vi en `Appointment` ved hjelp av [CreateDefaultAppointmentEntityByTypeAndAssociate][2] metoden eksponert gjennom agenten. Metoden krever 2 parametere:

* typen av den forespurte oppgaven
* den `AssociateID` - ID-en som avtalen skal opprettes for

<!-- Referenced links -->
[1]: ../../../api/web-services/index.md
[2]: ../../../api/reference/restful/agent/Appointment_Agent/v1AppointmentAgent_CreateDefaultAppointmentEntityByTypeAndAssociate.md
