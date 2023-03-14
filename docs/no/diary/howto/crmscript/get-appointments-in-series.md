---
title: Få oppfølging i serie
description: Hvordan få oppfølging som tilhører en serie med CRMScript
uid: crmscript-get-apt-in-series-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
keywords: CRMScript, calendar, diary, appointments, follow-up, recurrence
so.topic: howto
---

# Få oppfølging som tilhører en serie

## NSAppointment[] GetAppointmentRecords(Heltall motherId, heltall tilbakefallRuleId)

```crmscript!
Integer recurrenceId = 1;
NSAppointmentAgent appointmentAgent;
NSAppointment[] appointmentList = appointmentAgent.GetAppointmentRecords(0,recurrenceId);

for(Integer i = 0; i < appointmentList.length(); i++) {
  printLine("ID: " + appointmentList[i].GetAppointmentId().toString() + "\t At: " + appointmentList[i].GetStartDate().toString());
}
```

> [!TIP]
> Sett `motherId` til **0** med  mindre du arbeider med [Møteinvitasjoner][1].

<!-- Referenced links -->
[1]: book-resource.md
