---
title: Spore svar
description: Slik sporer du svar på en invitasjon med CRMScript
keywords: CRMScript, kalender, dagbok, avtaler, oppfølging, invitasjon
uid: crmscript-track-invitation-response-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
so.topic: howto
---

# Spore svar

Før du kan spore svar, må du hente hovedavtalen og alle etterkommerne i den. Deretter kan du utforske invitasjonsstatusen for  **hver**  avtale.

I dette eksempelet merker og skriver vi ut svaret for hver deltaker ved hjelp av en `String` matrise. Du kan slå opp statuskoder på [invitasjoner side][1].

```crmscript!
String[15] state;
state[1] = "accepted";
state[5] = "not seen";
state[7] = "seen, but not declined or accepted";
state[9] = "declined";

Integer aId = 242;
NSAppointmentAgent appointmentAgent;

NSAppointmentEntity appointment = appointmentAgent.GetAppointmentEntity(aId);
NSAppointment[] invites = appointmentAgent.GetAppointmentRecords(aId, 0);

Integer rejects = appointment.GetRejectCounter();

if (rejects == 0) {
  printLine("There are currently no rejects.\n");
}
else {
  printLine("There are " + rejects.toString() + " rejects.\n");
}

for (Integer i = 0; i < invites.length(); i++) {
  NSAppointment a = invites[i];

  if (a.GetAppointmentId() == aId) {
    continue;
  }

  Integer s = a.GetInvitationStatus();
  if (s == 1 || s == 5 || s == 7 || s == 9) {
    printLine(a.GetAssociateFullName() + " with ID=" + a.GetAssociateId().toString() + " has " + state[s] + " the invitation.");
    if (s == 9) {
      printLine("Reason: " + a.GetRejectReason());
    }
  }
}
```

<!-- Referenced links -->
[1]: ../../invitations.md
