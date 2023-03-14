---
title: Få avtaler
description: Hvordan få avtaler med CRMScript
uid: crmscript-get-appointment-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: CRMScript, calendar, diary, appointment, follow-up, NSAppointment
so.topic: howto
---

# Få avtaler

> [!TIP]
> Du kan bare hente avtaler for personer som er SuperOffice brukere ([Associates][1]).
>
> Den påloggede brukeren må også ha tillatelse til å vise disse avtalene. Ellers kastes et unntak.

## NSAppointment[] GetAppointmentList([] Heltalls-IDer)

Henter en samling avtaler som tilsvarer en liste over ID-er.

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
> Du kan også bruke [arkiv agent][2] til å hente avtaler.

## NSAppointment[] GetPersonDiary(Heltall personId, DateTime startTime, DateTime endTime; Heltallstall)

Henter et begrenset antall avtaler innenfor et tidsintervall for den gitte personen. `GetPersonDiary()`  vil ignorere avtaler som ikke vises i brukerens dagbok.

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
> Sett til `count` -1 for ikke å begrense samlingen av avtaler som er hentet.

## NSAppointment[] GetPersonAppointments(Heltall personId, Bool includeProjectAppointments, DateTime startTime, DateTime endTime, Heltall)

Samme  som `GetPersonDiary()`, men vil også inkludere alle avtaler i prosjekter som brukeren er medlem av hvis satt til **sann**.

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
