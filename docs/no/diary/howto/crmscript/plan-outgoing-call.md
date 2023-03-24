---
title: Planlegge en utgående samtale
description: Slik planlegger du en utgående samtale med CRMScript
keywords: CRMScript, kalender, dagbok, samtale, oppfølging, retning
uid: crmscript-call-outgoing-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
so.topic: howto
---

# Planlegge en utgående samtale

Typen er 5 for utgående samtaler (samme som innkommende). Hvis du vil styre retningen, må du imidlertid bruke [Oppgave MDO-listetabell][5].

## Vise tilgjengelige oppgavetyper

```crmscript
SearchEngine se;
se.addFields("Task", "Task_id,name");
printLine(se.executeTextTable());
```

## Legge til samtale i todo-listen

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

## Oppdater når du foretar samtalen

Parametere til [UpdateAppointment()][4]:

* appointment_id
* starttid
* sluttidspunkt
* Status
* Type
* eier (associate_id)

```crmscript
DateTime start;
DateTime end;
NSAppointmentAgent appointmentAgent;
appointmentAgent.UpdateAppointment(88, start, end.addMin(20), 0, 0, 5);
```

## Aktuelle emner

* [NSAppointmentAgent][1]
* [NSAppointmentEntity][2]
* [NSTaskListItem][3]
* [Om samtaler][6]

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
[2]:<xref:CRMScript.NetServer.NSAppointmentEntity>
[3]:<xref:CRMScript.NetServer.NSTaskListItem>
[4]:<xref:CRMScript.NetServer.NSAppointmentAgent.UpdateAppointment(Integer,Integer,Integer,Integer)>
[5]:../../../database/tabeller/task.md
[6]: ../../overview.md#phone-calls
