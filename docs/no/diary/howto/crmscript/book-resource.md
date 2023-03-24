---
title: Slik reserverer du en ressurs
description: Slik reserverer du en ressurs med CRMScript
keywords: CRMScript, kalender, dagbok, avtaler, oppfølging, ressurs, sted
uid: crmscript-book-resource-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
---

# Ressurser

Feltet `location` er enten en egendefinert streng eller informasjon fra en bestilt ressurs.

> [!TIP]
> Husk at en **ressurs er en medarbeider av type 1** , og at du bør se bort fra `person_id`.

Når du reserverer en ressurs, knyttes avtalen til personens avtale ved hjelp av feltet `mother_id` . Det vil være to forskjellige avtale-IDer: én for personen og én for ressursen!

## Vise ressurser

```crmscript!
SearchEngine se;
se.addFields("associate", "associate_id,name,isLocation");
se.addCriteria("associate.type", "OperatorEquals", "1","OperatorAnd", 0);
printLine(se.executeTextTable());
```

## Kontrollere om en ressurs er tilgjengelig

Det er god praksis å alltid sjekke tilgjengelighet før du bestiller en ressurs for å unngå dobbeltbestilling.

```crmscript!
NSAppointmentAgent appointmentAgent;
DateTime start;
DateTime end;
end.moveToDayEnd();

NSAppointment[] appointmentList = appointmentAgent.GetAssociateDiary(37, start, end, -1);

if (appointmentList.length() > 0) {

  printLine("The resource is booked at the following times:\n");

  for(Integer i = 0; i < appointmentList.length(); i++) {
    print("ID: " + appointmentList[i].GetAppointmentId().toString());
    printLine("\t At: " + appointmentList[i].GetStartDate().toString() + " to " + appointmentList[i].GetEndDate().toString());
  }
}
else {
  printLine("The resource is free for the rest of today.");
}
```

## Reservere en ressurs

Ved å ringe `SetParticipants()`kan du reservere ressursen uten at det er tid for kloning og kobling av avtaler. Slik gjør du:

1. Opprett en ny avtale for personen **, eller** hent en eksisterende avtale som ikke er utført.
2. Opprett en NSParticipantInfo-liste, og legg til den tilknyttede IDen til ressursen i den.
3. Ring `SetParticipants()`.
4. Lagre avtalen.

Følgende eksempel setter opp et gjennomgangsmøte kl. 14.15-15.00 på den siste dagen i inneværende måned, og reserverer møterommet med ID 37.

```crmscript
DateTime start;
start.moveToMonthEnd();
start.setTime(String("14:15:00").toTime());
DateTime end = start;
end.addMin(45);

NSAppointmentAgent appointmentAgent;
NSAppointmentEntity newAppointment = appointmentAgent.CreateDefaultAppointmentEntityByTypeAndAssociate(7, 1);

newAppointment.SetActiveDate(start);
newAppointment.SetStartDate(start);
newAppointment.SetEndDate(end);
newAppointment.SetDescription("End-of-month review");

NSParticipantInfo p;
p.SetAssociateId(37); // meeting room
NSParticipantInfo[] participants;
participants.pushBack(p);

newAppointment.SetParticipants(participants);

newAppointment = appointmentAgent.SaveAppointmentEntity(newAppointment);
```

> [!TIP]
> Du kan også [invitere personer til møtet][3]).

<!-- Referenced links -->
[3]: ../../invitations.md
