---
title: Registrer et innkommende anrop
description: Hvordan registrere et innkommende anrop med CRMScript
uid: crmscript-call-incoming-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
keywords: CRMScript, calendar, diary, call, follow-up
so.topic: howto
---

# Registrer et innkommende anrop

Aktivitetstypen **** for telefonsamtaler er 5. Som standard er retningen *innkommende*.

Denne eksempelkoden registrerer et innkommende anrop med en beskrivelse, som starter nå og varer i 10 minutter.

```crmscript
DateTime start;
DateTime end;
end.addMin(10);

NSAppointmentAgent appointmentAgent;
NSAppointmentEntity incomingCall = appointmentAgent.CreateDefaultAppointmentEntityByTypeAndAssociate(5, 1);

incomingCall.SetActiveDate(start);
incomingCall.SetStartDate(start);
incomingCall.SetEndDate(end);
incomingCall.SetDescription("My favorite customer calling re migration.");

incomingCall = appointmentAgent.SaveAppointmentEntity(incomingCall);
```

## Beslektede emner

* [NSAppointmentAgent][1]
* [NSAppointmentEntity][2]
* [Om telefonsamtaler][3]

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
[2]:<xref:CRMScript.NetServer.NSAppointmentEntity>
[3]:../../oversikt.md#telefonsamtaler
