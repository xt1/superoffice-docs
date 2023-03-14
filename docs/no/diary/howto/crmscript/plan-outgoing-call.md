---
title: Planlegg en utgående samtale
description: Hvordan planlegge en utgående samtale med CRMScript
uid: crmscript-call-outgoing-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
keywords: CRMScript, calendar, diary, call, follow-up, direction
so.topic: howto
---

# Planlegge en utgående samtale

Typen er 5 for utgående samtaler (samme som innkommende). For å kontrollere retningen må du imidlertid bruke [Oppgave MDO-listetabell][5].

## Liste over tilgjengelige aktivitetstyper

```crmscript
SearchEngine se;
se.addFields("Task", "Task_id,name");
printLine(se.executeTextTable());
```

## Legge til kall i todo-listen

```crmscript
DateTime deadline;
deadline.addDay(2);

NSAppointmentAgent appointmentAgent;
NSAppointmentEntity newCall = appointmentAgent.CreateDefaultAppointmentEntityByTypeAndAssociate(5, 1);

newCall.SetDescription("Call to book rental car");
newCall.SetAssignmentStatus(11);
newCall.SetEndDate(deadline);

NSTaskListItem task;
task.SetTaskListItemId(3);
newCall.SetTask(task);

newCall = appointmentAgent.SaveAppointmentEntity(newCall);
```

## Oppdater når du foretar anropet

Parametere til [UpdateAppointment()][4]:

* appointment_id
* Starttid
* Sluttid
* status
* type
* eier (associate_id)

```crmscript
DateTime start;
DateTime end;
NSAppointmentAgent appointmentAgent;
appointmentAgent.UpdateAppointment(88, start, end.addMin(20), 0, 0, 5);
```

## Beslektede emner

* [NSAppointmentAgent][1]
* [NSAppointmentEntity][2]
* [NSTaskListItem][3]
* [Om telefonsamtaler][6]

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
[2]:<xref:CRMScript.NetServer.NSAppointmentEntity>
[3]:<xref:CRMScript.NetServer.NSTaskListItem>
[4]:<xref:CRMScript.NetServer.NSAppointmentAgent.UpdateAppointment(Integer,Integer,Integer,Integer)>
[5]:../../../database/tabeller/oppgave.md
[6]: ../../overview.md#phone-calls
