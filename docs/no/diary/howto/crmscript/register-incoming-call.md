---
title: Registrere en innkommende samtale
description: Slik registrerer du en innkommende samtale med CRMScript
keywords: CRMScript, kalender, dagbok, samtale, oppfølging
uid: crmscript-call-incoming-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
so.topic: howto
---

# Registrere en innkommende samtale

 **Aktivitetstypen** for samtaler er 5. Som standard er retningen *innkommende*.

Denne eksempelkoden registrerer en innkommende samtale med en beskrivelse som starter nå og varer i 10 minutter.

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

## Aktuelle emner

* [NSAppointmentAgent][1]
* [NSAppointmentEntity][2]
* [Om samtaler][3]

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
[2]:<xref:CRMScript.NetServer.NSAppointmentEntity>
[3]:../../overview.md#samtaler
