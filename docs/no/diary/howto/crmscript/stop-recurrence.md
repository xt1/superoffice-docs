---
title: Stoppe repeterende oppfølginger
description: Slik stopper du en repeterende oppfølging med CRMScript
keywords: CRMScript, kalender, dagbok, avtaler, oppfølging, gjentalse
uid: crmscript-stop-recurrence-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
so.topic: howto
---


# Stoppe repeterende oppfølginger

Når du stopper en [Regelmessighet][1], slettes alle repetisjoner av oppfølgingen **etter forekomsten du redigerer** .

Hvis du avbryter gjentakelsen av den første i en serie, slettes mønsteret, og oppfølgingen blir én enkelt avtale/samtale/oppgave.

```crmscript
Integer aId = 234;
DateTime now;

NSAppointmentAgent appointmentAgent;
NSAppointmentEntity a = appointmentAgent.GetAppointmentEntity(aId);

NSRecurrenceInfo r = a.GetRecurrence();
if (r.GetIsRecurrence()) {
  r.SetIsRecurrence(false);
  r.SetPattern(0);
  a.SetRecurrence(r);
  a = appointmentAgent.SaveAppointmentEntity(a);
}
```

<!-- Referenced links -->
[1]: ../../recurring-appointments.md
