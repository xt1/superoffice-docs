---
title: Opprette repeterende oppfølginger
description: Slik oppretter du repeterende oppfølginger med CRMScript
keywords: CRMScript, kalender, dagbok, avtaler, oppfølging, gjentalse
uid: crmscript-crate-recurrence-no
author: Bergfrid Skaara Dias
so.date: 03.21.2022
so.topic: howto
---

# Opprette repeterende oppfølginger

1. Opprett avtale, samtale, møte eller oppgave som vanlig.
2. Angi gjentakelsesinformasjon.
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
> Du kan eventuelt bruke `CreateDefaultRecurrenceByDate()` den datoen det gjentakende mønsteret skal starte.

## Gjenta ved standardintervall

Hvis du vil gjenta med standardintervall (daglig, ukentlig, månedlig, årlig), kaller du `SetPattern()` med verdi \[1-4\]. Se referansedelen hvis du ønsker mer informasjon.

Dette eksemplet oppretter en 10-minutters daglig kaffepause kl. 14.00 fra 1.

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

Eksempel: Timepåminnelser hele arbeidsdagen

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

## Gjenta på valgte datoer

Du kan også opprette en liste over valgte datoer som ikke følger et mønster manuelt.

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

Du kan velge å stoppe etter et bestemt antall ganger eller etter en angitt dato.

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

## Aktuelle emner

* [Gjentakende avtaler og mønstre][4]
* [NSAppointmentAgent][1]
* [NSAppointmentEntity][2]
* [NSRecurrenceInfo][3]

### NSRecurrenceInfo

| Feltet             | Type             | Beskrivelse                         |
|:------------------|:-----------------|:------------------------------------|
| IsRecurrence      | Bool             | om det er en repeterende oppfølging |
| Gjentakende ID      | Heltall          | unik ID for regelen               |
| GjentakendeEndType | Heltall          | 0 = ukjent<br>1 = sluttdato<br>2 = slutt etter n repetisjoner |
| GjentagelseStelling | Heltall          | antall repetisjoner<br>som bare brukes når slutten beregnes ut fra antall |
| StartDato         | Datetime         | når repetisjonen starter              |
| Sluttdato           | Datetime         | når repetisjonen slutter<br>brukt bare når slutten beregnes fra en dato |
| Datoer             | NSRecurrenceDate[] | Oversikt over alle datoer som oppfølgingen inntreffer<br>, brytes en DateTime |
| Mønster           | Heltall          | hovedmønstret for tilbakefall      |

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
[2]:<xref:CRMScript.NetServer.NSAppointmentEntity>
[3]:<xref:CRMScript.NetServer.NSRecurrenceInfo>
[4]:../../recurring-appointments.md
