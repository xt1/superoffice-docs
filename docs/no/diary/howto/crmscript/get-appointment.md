---
title: Få avtaler
description: Slik får du avtaler med CRMScript
keywords: CRMScript, kalender, dagbok, avtale, oppfølging, NSAppointment
uid: crmscript-get-appointment-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
---

# Få avtaler

> [!TIP]
> Du kan bare hente avtaler for personer som er SuperOffice brukere ([Associates][1]).
>
> Den påloggete brukeren må også ha tillatelse til å vise disse avtalene. Ellers kastes det et unntak.

## NSAppointment[] GetAppointmentList([] Heltall-IDer)

Henter en samling avtaler som tilsvarer en liste over IDer.

```crmscript!
Integer[] appointmentIDs;
appointmentIDs.pushFront(84);
appointmentIDs.pushFront(86);
appointmentIDs.pushFront(88);
NSAppointmentAgent appointmentAgent;
NSAppointment[] appointmentList = appointmentAgent.GetAppointmentList(appointmentIDs);

for(Integer i = 0; i < appointmentList.length(); i++) {
  print("ID: " + appointmentList[i].GetAppointmentId().toString());
  printLine("\t At: " + appointmentList[i].GetStartDate().toString() + " to " + appointmentList[i].GetEndDate().toString());
}
```

> [!TIP]
> Du kan også bruke [arkivagent][2] til å hente avtaler.

## NSAppointment[] GetPersonDiary(HeltallspersonId, DateTime startTid, DateTime endTime, Heltallsantall)

Henter et begrenset antall avtaler innen et tidsperiode for den angitte personen.  `GetPersonDiary()` ignorerer ikke avtaler som ikke vises i brukerens dagbok.

```crmscript!
NSAppointmentAgent appointmentAgent;
DateTime start;
DateTime end;

NSAppointment[] appointmentList = appointmentAgent.GetPersonDiary(5, start.addMonth(-6), end, 10);

for(Integer i = 0; i < appointmentList.length(); i++) {
  print("ID: " + appointmentList[i].GetAppointmentId().toString());
  printLine("\t At: " + appointmentList[i].GetStartDate().toString() + " to " + appointmentList[i].GetEndDate().toString());
}
```

> [!TIP]
> Sett `count` til -1 for ikke å begrense innsamlingen av avtaler som er hentet.

## NSAppointment[] GetPersonAppointments(HeltallspersonId, Bool inkludererProjectAppointments, DateTime startTime, DateTime endTime, Antall heltall)

Samme som `GetPersonDiary()`, men vil også omfatte alle avtaler i prosjekter som brukeren er medlem av, hvis det er satt til **sann** .

```crmscript!
NSAppointmentAgent appointmentAgent;
DateTime start;
DateTime end;

NSAppointment[] appointmentList = appointmentAgent.GetPersonAppointments(5, true, start.addMonth(-6), end, 5);

for(Integer i = 0; i < appointmentList.length(); i++) {
  printLine("ID: " + appointmentList[i].GetAppointmentId().toString());
}
```

<!-- Referenced links -->
[1]: ../../../contact/associate.md
[2]: ../../../automation/crmscript/netserver/crmscript-archiveagent.md
