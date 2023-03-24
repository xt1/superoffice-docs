---
title: Slik oppdaterer du avtaler
description: Slik oppdaterer, flytter og sletter du avtaler. markere en avtale som fullført
keywords: CRMScript, kalender, dagbok, avtaler, oppfølging
uid: crmscript-update-appointment-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
---

# Oppdatere avtale

## NSAppointment UpdateAppointment(Heltall p0, DateTime p1, DateTime p2, Heltall p3, Heltall p4, Heltall-medarbeiderId)

Endre for eksempel beskrivelsen for å legge til en agenda:

```crmscript
NSAppointmentAgent appointmentAgent;
NSAppointmentEntity appointment = appointmentAgent.GetAppointmentEntity(146);

appointment.SetDescription("Agenda: 1. Welcome 2. Annual report 3. Election 4. Misc");
appointmentAgent.SaveAppointmentEntity(appointment);
```

## Flytte avtale

Utsette en eksisterende avtale innen 1 uke (tidsplanlegg på nytt):

```crmscript
NSAppointmentAgent appointmentAgent;

NSAppointmentEntity a = appointmentAgent.GetAppointmentEntity(146);

DateTime start = a.GetStartDate();
a.SetStartDate(start.addDay(7));

DateTime end = a.GetEndDate();
a.SetEndDate(end.addDay(7));

a = appointmentAgent.SaveAppointmentEntity(a);
```

## Merke som fullført

*Utført* betyr at statusen er **3** .

### Void SetCompleted(Heltall utført)

```crmscript
NSAppointmentAgent appointmentAgent;

NSAppointmentEntity a = appointmentAgent.GetAppointmentEntity(77);
a.SetCompleted(3);
appointmentAgent.SaveAppointmentEntity(a);
```

### Heltall GetCompleted()

Du kan ikke redigere utførte oppfølginger før du har deaktivert Utført-statusen.

Bruk `GetCompleted()` for å kontrollere statusen. Bytt den til **0** for å gjøre endringene, og bytt den deretter tilbake hvis det er aktuelt.

```crmscript
NSAppointmentAgent appointmentAgent;

NSAppointmentEntity e = appointmentAgent.GetAppointmentEntity(77);

if (e.GetCompleted() == 3) {
  e.SetCompleted(0);
  appointmentAgent.SaveAppointmentEntity(e);
}
```

## Slette avtale

### Void DeleteAppointmentEntity(HeltallsavtaleEntityId)

```crmscript
NSAppointmentAgent appointmentAgent;
appointmentAgent.DeleteAppointmentEntity(142);
```

<!-- Referenced links -->
