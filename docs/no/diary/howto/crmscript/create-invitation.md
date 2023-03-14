---
title: Opprett invitasjon
description: Hvordan lage møteinvitasjoner med CRMScript
uid: crmscript-create-invitation-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
keywords: CRMScript, calendar, diary, appointments, follow-up, invitation
so.topic: howto
---

# Opprett invitasjon

> [!TIP]Det er god praksis å alltid finne ut når personer vil være tilgjengelige, før du inviterer dem til et møte ved å koble dem til oppfølging.
> 
```crmscript
NSAppointmentAgent appointmentAgent;

// Schedule
DateTime start;
start.moveToHourStart();
start.addHour(1);
DateTime end = start;
end.addHour(1);

NSAppointmentEntity a = appointmentAgent.CreateDefaultAppointmentEntityByTypeAndAssociate(7, 1);
a.SetStartDate(start);
a.SetEndDate(end);
a.SetDescription("Sprint retrospective");

// Build list of available participants
NSParticipantInfo[] participants;
NSAssociateAgent associateAgent;

Integer[] teamMembers;
teamMembers.pushBack(8);
teamMembers.pushBack(27);

for(Integer i = 0; i < teamMembers.length(); i++) {

  NSAppointment[] appointmentList = appointmentAgent.GetAssociateDiary(teamMembers[i], start, end, -1);
  
  if (appointmentList.length() == 0) {
  
    NSParticipantInfo p;
    p.SetAssociateId(teamMembers[i] );
    participants.pushBack(p);
  }
  else {
    printLine(associateAgent.GetAssociate(teamMembers[i]).GetFullName() + " is unavailable at the given time.");
  }
}

// Add a room
NSParticipantInfo room;
room.SetAssociateId(37);
participants.pushBack(room);

// Finalize booking
a.SetParticipants(participants);
a = appointmentAgent.SaveAppointmentEntity(a);
```

## Les også

* [Invitasjoner][1]

<!-- Referenced links -->
[1]: ../../invitations.md
