---
title: Slik legger du til en ny personinteresse
description: Slik legger du til en ny personinteresse med rader.
keywords: firma, person, interesse, API, rad, ContIntRow, ContactInterestRow, ContIntGroupLinkRow, ContIntHeadingLinkRow
uid: create_contact_interest-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Slik legger du til en ny personinteresse

Når du legger til en ny [person interesse][1], legges det til nye rader i flere tabeller, for eksempel `ContInt`, `ContactInterest` `ConIntGroupLink`, og i `ContIntHeadingLink` tabellen. Her bruker vi `SuperOffice.CRM.Rows` navneområdet.

> [!NOTE]Dette er ikke det samme som å sette en eksisterende interesse på.
> 
## Koden

I kodesegmentet nedenfor vises vi hvordan vi legger til interesser i en eksisterende liste.

[!code-csharp[CS](includes/add-interest.cs)]

## Gjennomgang

Over oppretter vi først `ContIntRow` ved hjelp av `CreateNew` metoden og tilordner verdier til egenskapene. Deretter lagrer vi den ved hjelp av `Save` metoden som er tilgjengelig i `ContIntRow` klassen.

Deretter oppretter vi en `ContactInterestRow` og tilordner IDen til den tidligere registrerte `ContIntRow` " `ContactInterestRow`s" `CinterestIdx`. Vi tilordner også egenskapen `ContactId` til personens ID.

### ContIntGroupLinkRow

Deretter må vi opprette en `ContIntGroupLinkRow`. Her tilordner vi gruppe-IDen til den påloggede medarbeideren som for tiden er pålogget. Men hvis du vil legge til flere grupper som interessen for personen skal være synlig for, kan følgende kodesegment være nyttig.

```csharp
int[] groupIds = { 2, 3, 4, 5, 6 };
ContIntGroupLinkRows newContGrpLinkRows =
ContIntGroupLinkRows.GetFromIdxContIntId(newConInt.ContIntId);
foreach (int groupId in groupIds)
{
  ContIntGroupLinkRow newContGrpLinkRow = newContGrpLinkRows.AddNew();
  newContGrpLinkRow.SetDefaults();
  newContGrpLinkRow.GroupId = groupId;
  newContGrpLinkRow.Save();
}
```

### ContIntHeadingLinkRow

Til slutt må vi opprette en `ContIntHeadingLinkRow`. Dette er nødvendig fordi det `ContInt` er definert som en undervare, må vi opprette en overskrift som den skal falle under.

Dette gjøres ved å ringe `CreateNew()`inn `ContIntHeadingLinkRow` klassen og tildele verdier til egenskapene.

## Resultatet

Når eksempelkoden er utført, legges følgende rader til i tabellene som vist nedenfor.

 **ContInt-tabell:** 

| ContInt_id | navn | Rangering | Verktøytips | Slettet | Registrert | ...|
|---|---|---|---|---|---|---|
| 1 | Referanse-cust. | 1 | Referansekunde | 0 | 0 | |
| 2 | De er på 100 000 000. | 2 | Arnesen | 0 | 0 | |
| 3 | Stor kunde | 3 | Storkunde | 0 | 0 | |
| 4 | Sams interesse | 0 | Sams interesser | 0 | 1214207393 | |

 **Personinterest-tabell:** 

| contactinterest_id | contact_id | cinterest_idx | startDato | sluttDato | Flagg | Registrert |
|---|---|---|---|---|---|---|
| 6 | 1 | 4 | 0 | 31.12.2021 02:13:49 | 0 | 28.10.2021 13.14:59 |
| 1 | 1 | 1 | 0 | 31.12.2021 02:13:49 | 0 | 28.10.2021 13.14:59 |
| 2 | 4 | 2 | 0 | 31.12.2021 02:13:49| 0 | 28.10.2021 13.14:59 |
| 3 | 9 | 3 | 0 | 31.12.2021 02:13:49| 0 | 28.10.2021 13.14:59 |

 **ConIntGroupLink-tabell:** 

| contintgrouplink | contint_id | group_id | Registrert | registered_associate | ... |
|---|---|---|---|---|---|
| 1 | 4 | 1 | 1214207393 | 103 | |

 **ContIntHeadingLink-tabell:** 

| contintheadinglink | contint_id | heading_id | Registrert | registerred_ass | ... |
|---|---|---|---|---|---|
| 1 | 4 | 24 | 1214207393 | 103 | |

<!-- Originally written for NetServer 3.0 -->

<!-- Referenced links -->
[1]: ../../interests.md

<!-- Referenced images -->
