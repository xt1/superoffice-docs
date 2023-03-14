---
title: Lag gjentatte oppfølginger
description: Hvordan lage gjentatte oppfølginger med CRMScript
uid: crmscript-crate-recurrence-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
keywords: CRMScript, calendar, diary, appointments, follow-up, recurrence
so.topic: howto
---

# Opprett gjentatte oppfølginger

1. Opprett avtalen, samtalen, møtet eller oppgaven som vanlig.
2. Angi informasjon om regelmessighet.
3. Lagre oppfølgingen.

```crmscript
NSAppointmentAgent appointmentAgent;
NSAppointmentEntity newAppointment = appointmentAgent.CreateDefaultAppointmentEntityByTypeAndAssociate(7, 1);

newAppointment.SetDescription("Morning coffee");

NSRecurrenceInfo r = appointmentAgent.CreateDefaultRecurrence();
newAppointment.SetRecurrence(r);

newAppointment = appointmentAgent.SaveAppointmentEntity(newAppointment);
```

## NSRecurrenceInfo CreateDefaultRecurrence()

```crmscript!
NSAppointmentAgent appointmentAgent;
NSRecurrenceInfo r = appointmentAgent.CreateDefaultRecurrence();

printLine("Start: " + r.GetStartDate().toString());
printLine("Pattern: " + r.GetPattern().toString());
```

> [!TIP]
> Alternativt kan du bruke `CreateDefaultRecurrenceByDate()` til datoen da det gjentakende mønsteret skal starte.

## Gjenta med standardintervall

For å gjenta med et standardintervall (daglig, ukentlig, månedlig, årlig), ring med `SetPattern()` verdi \[1-4\]. Se referansedelen for mer informasjon.

Dette eksemplet skaper en 10-minutters daglig kaffepause klokken 14:00 fra 1. august.

```crmscript
DateTime start = String("2020-08-01 14:00").toDateTime();
DateTime end = start;
end.addMin(10);
DateTime stop = start;
stop.moveToYearEnd();

NSAppointmentAgent appointmentAgent;
NSAppointmentEntity newAppointment = appointmentAgent.CreateDefaultAppointmentEntityByTypeAndAssociate(7, 1);

newAppointment.SetStartDate(start);
newAppointment.SetEndDate(end);
newAppointment.SetDescription("coffee break");

NSRecurrenceInfo r = appointmentAgent.CreateDefaultRecurrence();
r.SetPattern(1);
r.SetIsRecurrence(true);
r.SetRecurrenceEndType(1);
r.SetStartDate(start);
r.SetEndDate(stop);

NSRecurrenceDayPattern p;
p.SetPattern(1);
r.SetDayPattern(p);

newAppointment.SetRecurrence(r);
newAppointment = appointmentAgent.SaveAppointmentEntity(newAppointment);
```

## Gjenta med brukerdefinert intervall

Eksempel: timepåminnelser gjennom hele arbeidsdagen

```crmscript
NSRecurrenceInfo r;
r.SetPattern(5);

DateTime now;
NSRecurrenceDate[] dates;
for (Integer i =  0; i < 8; +++) {
  NSRecurrenceDate d;
  d.SetDate(now);
  d.SetDescription("Stretch and have some water");
  dates.pushBack(d);
  d.addHour(1);
}

r.SetDates(dates);
```

## Gjenta på merkede datoer

Du kan også manuelt opprette en liste over valgte datoer som ikke følger et mønster.

```crmscript
NSRecurrenceInfo r;
r.SetPattern(5);

DateTime[] selectedDates;
selectedDates.pushBack(String("2020-08-17").toDateTime());
selectedDates.pushBack(String("2020-09-21").toDateTime());
selectedDates.pushBack(String("2020-11-16").toDateTime());
selectedDates.pushBack(String("2021-01-04").toDateTime());

NSRecurrenceDate[] dates;
for (Integer i =  0; i < selectedDates.length(); +++) {
  NSRecurrenceDate d;
  d.SetDate(selectedDates[i]);
  d.SetDescription("Planning - daycare closed");
  dates.pushBack(d);
}

r.SetDates(dates);
```

## Gjenta til

Du kan velge å stoppe etter et bestemt antall ganger eller etter en bestemt dato.

**Gjenta 10 ganger:**

```crmscript
NSRecurrenceInfo r;
r.SetRecurrenceEndType(2);
r.SetRecurrenceCounter(10);
```

**Gjenta til slutten av neste måned:**

```crmscript
DateTime d;
d.moveToMonthEnd();
d.addMonth(1);
NSRecurrenceInfo r;
r.SetRecurrenceEndType(1);
r.SetEndDate(d);
```

## Beslektede emner

* [Regelmessige avtaler og mønstre][4]
* [NSAppointmentAgent][1]
* [NSAppointmentEntity][2]
* [NSRecurrenceInfo][3]

### NSRecurrenceInfo

| Felt             | Type             | Beskrivelse                         |
|:------------------|:-----------------|:------------------------------------|
| IsRecurrence      | Bool             | om det er en gjentatt oppfølging |
| Gjentakelses-ID      | Heltall          | unik ID for regelen               |
| TilbakefallEndType | Heltall          | 0 = ukjent 1 = slutt etter dato <br>2 = slutt etter n repetisjoner <br>|
| GjentakelseCounter | Heltall          | antall repetisjoner<br>som bare brukes når slutten beregnes ut fra en telling |
| StartDate         | DateTime         | Når repetisjonen starter              |
| EndDate           | DateTime         |når  repetisjonen avsluttes<br>brukes bare når slutten beregnes fra en dato |
| Datoer             | NSRecurrenceDate[] | Liste over alle datoer oppfølgingen skjer<br>bryter en DateTime |
| Mønster           | Heltall          | Hovedmønsteret for gjentakelse      |

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
[2]:<xref:CRMScript.NetServer.NSAppointmentEntity>
[3]:<xref:CRMScript.NetServer.NSRecurrenceInfo>
[4]:../../recurring-appointments.md
