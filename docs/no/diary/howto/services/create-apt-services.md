---
title: Opprette en avtale ved hjelp av tjenester
description: Opprette en avtale ved hjelp av NetServer-tjenester
keywords: dagbok, kalender, avtale, API, webtjenester
uid: create_appointment_services-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
# so.envir:
# so.client:
---

# Opprette en avtale ved hjelp av tjenester

I dette eksemplet vises hvordan du oppretter en avtale ved hjelp av [NetServer-tjenester][1]. Den nye avtalen blir lagt til i dagboken til medarbeider 103 av den påloggede brukeren er SAL0.

## Koden

[!code-csharp[CS](includes/create-apt-services.cs)]

## Gjennomgang

I eksempelet oppretter vi en `Appointment` metode [CreateDefaultAppointmentEntityByTypeAndAssociate][2] som  eksponeres gjennom agenten. Metoden krever to parametere:

* typen saksbehandlere
* - `AssociateID` IDen som avtalen skal opprettes for

<!-- Referenced links -->
[1]: ../../../api/web-services/index.md
[2]: ../../../api/reference/restful/agent/Appointment_Agent/v1AppointmentAgent_CreateDefaultAppointmentEntityByTypeAndAssociate.md
