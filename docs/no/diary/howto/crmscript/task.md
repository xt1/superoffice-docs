---
title: Arbeide med todolister
description: Slik oppretter og fullfører du gjøremeldinger med CRMScript
keywords: CRMScript, kalender, dagbok, todo, oppgave, oppfølging
uid: crmscript-create-task-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
---

# Todo-liste

## Opprette et gjørebeskyttet område

Følgende kodeeksempel vil opprette et gjøremål (oppgave-ID = 6) som forfaller på slutten av gjeldende dag. Det gjelder medarbeider med ID 1.

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

> [!NOTE]Selv om oppgaven teknisk sett ikke har starttidsfelt, settes feltet med en standardverdi. For eksempel 12.00 gjeldende dag. Ikke anta at starttidslinjen er tom.
> 
## Fullføre et gjørebeskyttet arbeid

Å merke en oppgave som utført er i hovedsak bare for å sette statusen  **til**  3.

Dette eksemplet fullfører oppgaven med ID 88, med sluttid = nå og starttid = 5 minutter siden.

```crmscript
DateTime start;
DateTime end;
NSAppointmentAgent appointmentAgent;
appointmentAgent.UpdateAppointment(88, start.addMin(-5), end, 3, 2, 5);
```

## Vise forfalte gjøremål

```crmscript
DateTime now;
SearchEngine se;
se.addFields("appointment", "appointment_id,task_idx,status,endDate");
se.addCriteria("appointment.task_idx.record_type", "OperatorEquals", "6","OperatorAnd", 0);
se.addCriteria("appointment.status", "OperatorEquals", "1","OperatorAnd", 0);
se.addCriteria("appointment.endDate", "OperatorLt", now.toString(), "OperatorAnd", 0);
printLine(se.executeTextTable());
```

Dette utvalget viser alle oppgaver av type 6 som ikke er startet, og en tidsfrist tidligere.

## Aktuelle emner

* [NSAppointmentAgent][1]
* [NSAppointmentEntity][2]
* [Arbeide med CRMScript SearchEngine][3]
* [Opprett avtale][4]
* [Om todolister][5]

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
[2]:<xref:CRMScript.NetServer.NSAppointmentEntity>
[3]:../../../automatisering/crmscript/searchengine/index.md
[4]: create-appointment.md
[5]: ../../overview.md#todo-list
