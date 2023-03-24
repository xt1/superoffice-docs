---
title: Få oppfølginger i serien
description: Slik henter du oppfølginger som tilhører en serie med CRMScript
keywords: CRMScript, kalender, dagbok, avtaler, oppfølging, gjentalse
uid: crmscript-get-apt-in-series-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
so.topic: howto
---

# Få oppfølginger som tilhører en serie

## NSAppointment[] GetAppointmentRecords(Heltallsmor-ID, Tilbakefall av heltall)

```crmscript!
Integer recurrenceId = 1;
NSAppointmentAgent appointmentAgent;
NSAppointment[] appointmentList = appointmentAgent.GetAppointmentRecords(0,recurrenceId);

for(Integer i = 0; i < appointmentList.length(); i++) {
  printLine("ID: " + appointmentList[i].GetAppointmentId().toString() + "\t At: " + appointmentList[i].GetStartDate().toString());
}
```

> [!TIP]
> Sett `motherId` til **0** med mindre du jobber med [møteinvitasjoner][1].

<!-- Referenced links -->
[1]: book-resource.md
