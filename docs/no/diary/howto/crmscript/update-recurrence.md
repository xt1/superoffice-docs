---
title: Redigere repeterende oppfølginger
description: Slik oppdaterer du en repeterende oppfølging med CRMScript
keywords: CRMScript, kalender, dagbok, avtaler, oppfølging, gjentalse
uid: crmscript-update-recurrence-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
so.topic: howto
---

# Redigere repeterende oppfølginger

Du kan endre enten én eller alle fremtidige repetisjoner av en [gjentakende oppfølging][1].

## Endre én repetisjon

Endre bare denne forekomsten, endringen vil ikke påvirke andre tidspunkter.

Utsettelse av gjeldende oppfølging med 2 timer:

```crmscript
Integer aId = 234;

NSAppointmentAgent appointmentAgent;
NSAppointmentEntity a = appointmentAgent.GetAppointmentEntity(aId);

NSRecurrenceInfo r = a.GetRecurrence();

if (r.GetIsRecurrence()) {
  r.SetStartDate(r.GetStartDate().addHour(2));
  newAppointment.SetRecurrence(r);
  newAppointment = appointmentAgent.SaveAppointmentEntity(newAppointment);
}
```

## Endre alle fremtidige repetisjoner

Endre alle fremtidige forekomster, inkludert denne , endringen vil gjelde for denne oppfølgingen også i fremtiden.

```crmscript
Integer aId = 234;
DateTime now;

NSAppointmentAgent appointmentAgent;
NSAppointmentEntity a = appointmentAgent.GetAppointmentEntity(aId);

NSRecurrenceInfo r = a.GetRecurrence();

if (r.GetIsRecurrence()) {
  NSAppointment[] appointmentList = appointmentAgent.GetAppointmentRecords(0,r.GetRecurrenceId());

  for(Integer i = 0; i < appointmentList.length(); i++) {
    if (appointmentList[i].GetStartDate().diff(now) > 0) {
      NSAppointmentEntity futureAppointment = appointmentAgent.GetAppointmentEntity(appointmentList[i].GetAppointmentId());
      // set changes here
      futureAppointment = appointmentAgent.SaveAppointmentEntity(futureAppointment);
    }
  }
}
```

<!-- Referenced links -->
[1]: ../../recurring-appointments.md
