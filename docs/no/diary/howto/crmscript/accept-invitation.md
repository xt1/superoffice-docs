---
title: Opprette invitasjon
description: Slik godtar du møteinvitasjoner med CRMScript
keywords: CRMScript, kalender, dagbok, avtaler, oppfølging, invitasjon
uid: crmscript-accept-invitation-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
so.topic: howto
---

# Slik godtar du en invitasjon

## Vise oppfølginger du er invitert til

[GetMyAppointments()][2] henter avtaler for den påloggete brukeren. Hvis du vil hente etter medarbeider-ID, bruker du [GetPersonDiary()][3] i stedet.

```crmscript!
DateTime start;
DateTime end = start;
end.moveToQuarterEnd();

NSAppointmentAgent appointmentAgent;
NSAppointment[] appointmentList = appointmentAgent.GetMyAppointments(start, end, -1);

for (Integer i = 0; i < appointmentList.length(); i++) {
  NSAppointment a = appointmentList[i];
  Integer s = a.GetInvitationStatus();
  if (s >= 5 && s <= 10) {
    printLine(a.GetAppointmentId().toString() + "\t at " + a.GetStartDate().toString() + " - " + a.GetEndDate().toString());
  }
}
```

## Godta()

Å ringe `Accept()` er alt som trengs for å bli til [en invitasjon][4] en avtale i dagboken din. I det virkelige liv anbefales det å se etter 1.

Det første argumentet er avtale-IDen. Den andre brukes med gjentakende møter, og vi lar den stå på 0 for nå.

```crmscript
NSAppointmentAgent appointmentAgent;
appointmentAgent.Accept(242,0);
```

## Gjøre endringer

Deltakerne kan bare endre prioritets-, alarm- og utførte felt. Resten er møtearrangørens ansvar. Oppdateringer dekkes [Avtaler][1] generelt.

<!-- Referenced links -->
[1]: update-appointment.md
[2]: <xref:CRMScript.NetServer.NSAppointmentAgent.GetMyAppointments(Integer)>
[3]: <xref:CRMScript.NetServer.NSAppointmentAgent.GetPersonDiary(Integer,Integer)>
[4].. /.. /invitations.md
