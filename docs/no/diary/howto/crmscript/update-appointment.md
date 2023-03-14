---
title: Slik oppdaterer du avtaler
description: Hvordan oppdatere, flytte og slette avtaler; Merke en avtale som fullført
uid: crmscript-update-appointment-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: CRMScript, calendar, diary, appointments, follow-up
so.topic: howto
---

# Oppdatere avtale

## NSAppointment UpdateAppointment(Heltall p0, DateTime p1, DateTime p2, Heltall p3, Heltall p4, Heltall associateId)

Endre beskrivelsen, for eksempel for å legge til en agenda:

```crmscript
NSAppointmentAgent appointmentAgent;
NSAppointmentEntity appointment = appointmentAgent.GetAppointmentEntity(146);

appointment.SetDescription("Agenda: 1. Welcome 2. Annual report 3. Election 4. Misc");
appointmentAgent.SaveAppointmentEntity(appointment);
```

## Flytte avtale

Utsett en eksisterende avtale med 1 uke (omberamme):

```crmscript
NSAppointmentAgent appointmentAgent;

NSAppointmentEntity a = appointmentAgent.GetAppointmentEntity(146);

DateTime start = a.GetStartDate();
a.SetStartDate(start.addDay(7));

DateTime end = a.GetEndDate();
a.SetEndDate(end.addDay(7));

a = appointmentAgent.SaveAppointmentEntity(a);
```

## Merk som fullført

*Fullført* betyr at statusen er **3**.

### Void SetCompleted(Heltall fullført)

```crmscript
NSAppointmentAgent appointmentAgent;

NSAppointmentEntity a = appointmentAgent.GetAppointmentEntity(77);
a.SetCompleted(3);
appointmentAgent.SaveAppointmentEntity(a);
```

### Heltall GetCompleted()

Du kan ikke redigere fullførte oppfølginger før du har angret statusen Fullført!

Brukes `GetCompleted()` til å kontrollere statusen. Bytt den til **0** for å gjøre endringene dine, og bytt den deretter tilbake hvis det er aktuelt.

```crmscript
NSAppointmentAgent appointmentAgent;

NSAppointmentEntity e = appointmentAgent.GetAppointmentEntity(77);

if (e.GetCompleted() == 3) {
  e.SetCompleted(0);
  appointmentAgent.SaveAppointmentEntity(e);
}
```

## Slett avtale

### Ugyldig DeleteAppointmentEntity(heltallsavtaleEntityId)

```crmscript
NSAppointmentAgent appointmentAgent;
appointmentAgent.DeleteAppointmentEntity(142);
```

<!-- Referenced links -->
