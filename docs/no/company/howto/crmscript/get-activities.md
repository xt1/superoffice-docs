---
title: Aktiviteter
description: Slik arbeider du med aktiviteter i CRMScript.
keywords: CRMScript, firma, NSContactAgent
uid: crmscript-get-company-activities-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
so.topic: howto
---

# Aktiviteter

Du kan også bruke [NSContactAgent][4] til å sjekke hva som skjer.

## GetMyActiveContacts

Her får vi alle aktiviteter som skjedde den siste uken for firmaer knyttet til den påloggete brukeren.

Du kan filtrere etter kategori og handlingstype.

> [!TIP]Angi starttidspunktet til en fremtidig dato for å hente alle aktiviteter siden forrige pålogging.
> 
```crmscript!
NSContactAgent contactAgent;

DateTime start;
Integer[] categories; // ignore filter

NSContactActivity[] activities = contactAgent.GetMyActiveContacts(start.addDay(-7), categories, 63);

for (Integer i = 0; i < activities.length(); i++) {
  NSContactActivity a = activities[i];
  printLine("At " + a.GetActionTime().toString() + ", " + a.GetActivityPersonName() + " did something to " + a.GetName());
}
```

## NSContactSummary GetContactSummary(Heltallskontakt-ID, Heltallsgrense)

Få en oppsummering av firmaets nylige aktivitet.

```crmscript!
Integer contactId = 2;
NSContactAgent agent;

NSContactSummary summary = agent.GetContactSummary(contactId, -1);

NSActivitySummaryItem[] followups = summary.GetFollowups();

for (Integer i = 0; i < followups.length(); i++) {
  printLine(followups[i].GetDate().toString());
}
```

> [!TIP]Du kan også utforske andre samlinger i aktivitetssammendraget.
> 
## Handlingstyper

| Verdi | Beskrivelse |
|:---:|:---|
| 1  | Opprettet |
| 2  | Oppdatert |
| 4  | ny aktivitet |
| 8  | utført aktivitet |
| 16 | person lagt til |
| 32 | person oppdatert |

> [!TIP]
> Hvis du vil be om mer enn én handlingstype, oppsummerer du verdiene. **63** betyr at **inkluderer alle** .

<!-- Referenced links -->
[4]: ../../../automation/crmscript/netserver/ns-agents-and-carriers.md
