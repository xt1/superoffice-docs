---
title: Opprett avtale
description: Hvordan lage avtaler med CRMScript
uid: crmscript-create-appointment-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: CRMScript, calendar, diary, appointments, follow-up
so.topic: howto
---

# Opprette avtale

Du må opprette [NSAppointmentAgent][1] og lagre en ny avtale. Bruk en av disse metodene som utgangspunkt, og slå opp flere alternativer i API-referansen.

* `CreateDefaultAppointmentEntity()`
* `CreateDefaultAppointmentEntityByType(Integer type)`
* `CreateDefaultAppointmentEntityByTypeAndAssociate(Integer type, Integer associateId)`

Eksempel: blokker ut 2 timer fra nå for en laglunsj.

```crmscript
DateTime start;
DateTime end;
end.addHour(2);

NSAppointmentAgent appointmentAgent;
NSAppointmentEntity newAppointment = appointmentAgent.CreateDefaultAppointmentEntityByTypeAndAssociate(7, 1);

newAppointment.SetActiveDate(start);
newAppointment.SetStartDate(start);
newAppointment.SetEndDate(end);
newAppointment.SetDescription("Team lunch");

newAppointment = appointmentAgent.SaveAppointmentEntity(newAppointment);
```

## Dager med røde bokstaver

Har du noen gang prøvd å sette opp en avtale rundt jul og lurt på om det er en dag med røde bokstaver eller ikke? Slik kontrollerer du det:

```crmscript!
NSAppointmentAgent appointmentAgent;

DateTime start = String("2020-12-22").toDateTime();
DateTime end = start;
end.addDay(10);

Integer associateId = 0;

NSRedLetterInformationListItem[] redLetterDays = appointmentAgent.GetRedLetterInformationListByDatesAndAssociate(start, end, associateId);

for (Integer i = 0; i < redLetterDays.length(); i++)
{
  print(start.toString() + " is holiday: " + redLetterDays[i].GetRedLetterInformation().GetIsOwnCountryHoliday().toString() + "\n");
  start.addDay(1);
}
```

## Delegasjon

Delegering er handlingen med å tildele en oppfølging **til noen andre**. Dette betyr at skaperen og eieren av avtalen er to forskjellige personer. Vanlige scenarier:

* En personlig assistent administrerer administrerende direktørs dagbok på deres vegne.
* HR tar i bruk en nyansatt og setter opp introduksjonsprogrammet for den ansatte på forhånd.
* En teamleder er ansvarlig for å ringe 20 kunder og delegerer 4 samtaler til hver av sine 5 direkte underordnede.
* En kollega er på ferie, men de må ringe en klient når de kommer tilbake.
* En konsulent har avtalt et møte med en klient, men har blitt syk og har behov for å sende noen andre.

**Slik delegerer du en avtale:**

1. Opprett eller oppdater oppfølgingen på vanlig måte.
2. Angi `owner` tilknytnings-ID-en du delegerer til.
3. Sett til `AssignedBy` forrige eier.
4. Lagre.

> [!NOTE]
> `AssignedBy` angis når du bytter eier, men ikke før.

### Relevante statuser

| Status | Beskrivelse |
|:-:|:---|
| 11 |Avtale er tilordnet til en bruker (innledende status)|
| 12 | Brukeren har sett, men ikke akseptert eller avslått avtalen |
| 13 | Brukeren har avslått den tilordnede avtalen |

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
