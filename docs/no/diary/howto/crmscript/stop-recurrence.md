---
title: Slutt å gjenta oppfølginger
description: Hvordan stoppe en gjentatt oppfølging med CRMScript
uid: crmscript-stop-recurrence-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
keywords: CRMScript, calendar, diary, appointments, follow-up, recurrence
so.topic: howto
---


# Slutte å gjenta oppfølginger

Når du stopper a [gjentakelse][1], slettes alle gjentakelser av oppfølgingen **etter forekomsten du redigerer** .

Hvis du avbryter gjentakelsen av 1. i en serie, slettes mønsteret og oppfølgingen blir en enkelt avtale/samtale/oppgave.

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
