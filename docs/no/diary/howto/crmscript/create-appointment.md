---
title: Opprett avtale
description: Slik oppretter du avtaler med CRMScript
keywords: CRMScript, kalender, dagbok, avtaler, oppfølging
uid: crmscript-create-appointment-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: howto
---

# Opprett avtale

Du trenger en [NSAppointmentAgent][1] for å opprette, fylle ut og lagre en ny avtale. Bruk en av disse metodene som utgangspunkt, og slå opp flere alternativer i API-referansen.

* `CreateDefaultAppointmentEntity()`
* `CreateDefaultAppointmentEntityByType(Integer type)`
* `CreateDefaultAppointmentEntityByTypeAndAssociate(Integer type, Integer associateId)`

Eksempel: Blokker 2 timer fra og med nå for en teamlunsj.

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

## Røde dager

Har du noen gang forsøkt å sette opp en avtale rundt jul og lurt på om det er en rød dag eller ikke? Slik merker du av for:

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

Delegering handler om å tildele en oppfølging **til en annen** person. Det betyr at skaperen og eieren av avtalen er to ulike personer. Vanlige scenarioer:

* En personlig assistent administrerer konsernsjefens dagbok på deres vegne.
* HR er om bord i en ny ansettelse og setter opp introduksjonsprogrammet for den ansatte på forhånd.
* En teamleder belastes med å ringe 20 kunder og delegater 4 samtaler til hver av sine 5 direkterapporter.
* En kollega er på ferie, men de må ringe en klient når de kommer tilbake.
* En konsulent har avtalt et møte med en kunde, men har blitt syk og har behov for å sende noen andre.

 **Slik delegerer du en avtale:** 

1. Opprett eller oppdater oppfølgingen som vanlig.
2. Sett `owner` til medarbeider-IDen du delegerer til.
3. Sett `AssignedBy` til forrige eier.
4. Lagre.

> [!NOTE]
> `AssignedBy` angis når du bytter eier, men ikke før.

### Relevante statuser

| Status | Beskrivelse |
|:-:|:---|
| 11 |Avtale er tilordnet en bruker (innledende status)|
| 12 | Brukeren har sett, men ikke godtatt eller avslått avtalen |
| 13 | Brukeren har avslått den tildelte avtalen |

<!-- Referenced links -->
[1]: <xref:CRMScript.NetServer.NSAppointmentAgent>
