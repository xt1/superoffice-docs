---
title: Arbeide med todo-lister
description: Hvordan lage og fullføre gjøremål med CRMScript
uid: crmscript-create-task-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: CRMScript, calendar, diary, todo, task, follow-up
so.topic: howto
---

# Todo-liste

## Lag et gjøremål

Følgende kodeeksempel oppretter et gjøremål (oppgave-ID = 6) som forfaller på slutten av gjeldende dag. Det gjelder tilknytning til ID 1.

```crmscript
Integer owner = 1; // associate.associate_id

NSContact myCompany;
myCompany.SetContactId(2); // contact.contact_id

DateTime deadline;
deadline.moveToDayEnd();

NSAppointmentAgent appointmentAgent;
NSAppointmentEntity newTask = appointmentAgent.CreateDefaultAppointmentEntityByTypeAndAssociate(6, owner);

newTask.SetDescription("Remember to turn off the lights when you leave the office.");
newTask.SetContact(myCompany);
newTask.SetAssignmentStatus(11);
newTask.SetEndDate(deadline);

newTask = appointmentAgent.SaveAppointmentEntity(newTask);
```

> [!NOTE]Selv om aktiviteten teknisk sett ikke har starttidspunkt, angis dette feltet med en standardverdi. For eksempel midt på dagen den nåværende dagen. Ikke anta at starttiden er tom.
> 
## Fullfør et gjøremål

Å merke en oppgave som fullført er egentlig bare å sette **statusen** til 3.

Dette eksemplet fullfører oppgaven med ID 88, med sluttid = nå og starttid = 5 minutter siden.

```crmscript
DateTime start;
DateTime end;
NSAppointmentAgent appointmentAgent;
appointmentAgent.UpdateAppointment(88, start.addMin(-5), end, 3, 2, 5);
```

## Liste forfalte gjøremål

```crmscript
DateTime now;
SearchEngine se;
se.addFields("appointment", "appointment_id,task_idx,status,endDate");
se.addCriteria("appointment.task_idx.record_type", "OperatorEquals", "6","OperatorAnd", 0);
se.addCriteria("appointment.status", "OperatorEquals", "1","OperatorAnd", 0);
se.addCriteria("appointment.endDate", "OperatorLt", now.toString(), "OperatorAnd", 0);
printLine(se.executeTextTable());
```

Dette eksemplet viser alle oppgaver av type 6 som ikke er startet, og en tidsfrist tidligere.

## Beslektede emner

* [NSAppointmentAgent][1]
* [NSAppointmentEntity][2]
* [Arbeide med CRMScript SearchEngine][3]
* [Opprette avtale][4]
* [Om todo lister][5]

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
[2]:<xref:CRMScript.NetServer.NSAppointmentEntity>
[3]:../../../automatisering/crmscript/searchengine/index.md
[4]: create-appointment.md
[5]: ../../overview.md#todo-list
