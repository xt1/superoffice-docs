---
title: Slik legger du til en ny kontaktinteresse
description: Slik legger du til en ny kontaktinteresse med rader.
uid: create_contact_interest-no
author: {github-id}
so.date: 05.11.2016
keywords: company, contact, interest, API, row, ContIntRow, ContactInterestRow, ContIntGroupLinkRow, ContIntHeadingLinkRow
so.topic: howto
# so.envir:
# so.client:
---

# Slik legger du til en ny kontaktinteresse

Når du legger til en ny[Kontakt interesse][1], bør nye rader legges til i flere tabeller, for eksempel `ContInt` , , `ContactInterest` `ConIntGroupLink`og tabellen `ContIntHeadingLink` . Her bruker vi `SuperOffice.CRM.Rows` navnerommet.

> [!NOTE]Dette er ikke det samme som å sette en eksisterende interesse på.
> 
## Kode

Kodesegmentet nedenfor viser oss hvordan du legger til en interesse i en eksisterende liste.

[!code-csharp[CS]](includes/add-interest.cs)

## Gjennomgang

Ovenfor oppretter vi først `ContIntRow` ved hjelp av `CreateNew` metoden og tilordner verdier til egenskapene. Deretter lagrer vi den ved hjelp av `Save` metoden som er tilgjengelig i `ContIntRow` klassen.

Deretter oppretter vi  en `ContactInterestRow` og tilordner ID-en til den tidligere opprettede `ContIntRow` til `ContactInterestRow`'s `CinterestIdx`. Vi tilordner også `ContactId` eiendommen til kontakt-ID.

### ContIntGroupLinkRow

Deretter må vi lage en `ContIntGroupLinkRow`. Her tilordner vi gruppe-ID-en til den nåværende innloggede medarbeideren. Men hvis du ønsker å legge til flere grupper som kontaktinteressen vil være synlig for, kan følgende kodesegment være nyttig.

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

Til slutt må vi lage en `ContIntHeadingLinkRow`. Dette er nødvendig fordi det er `ContInt` definert som et underelement, må vi lage en overskrift som den skal falle under.

Dette gjøres ved å ringe `CreateNew()`i `ContIntHeadingLinkRow` klassen og tilordne verdier til egenskapene.

## Resultat

Når eksempelkoden er utført, blir følgende rader lagt til i tabellene som vist nedenfor.

**ContInt-tabell:**

| ContInt_id | navn | rang | verktøytips | Slettet | registrert | ...|
|---|---|---|---|---|---|---|
| 1 | Referanse cust. | 1 | Referansekunde | 0 | 0 | |
| 2 | Prestige cust. | 2 | Prestisjekunde | 0 | 0 | |
| 3 | Stor kunde | 3 | Storkunde | 0 | 0 | |
| 4 | Sams interesse | 0 | Sams interesser | 0 | 1214207393 | |

**ContactInterest tabell:**

| contactinterest_id | contact_id | cinterest_idx | startDate | endDate | Flagg | registrert |
|---|---|---|---|---|---|---|
| 6 | 1 | 4 | 0 | 31.12.2021 02:13:49 | 0 | 28.10.2021 13.14:59 |
| 1 | 1 | 1 | 0 | 31.12.2021 02:13:49 | 0 | 28.10.2021 13.14:59 |
| 2 | 4 | 2 | 0 | 31.12.2021 02:13:49| 0 | 28.10.2021 13.14:59 |
| 3 | 9 | 3 | 0 | 31.12.2021 02:13:49| 0 | 28.10.2021 13.14:59 |

**ConIntGroupLink-tabell:**

| contintgrouplink | contint_id | group_id | registrert | registered_associate | ... |
|---|---|---|---|---|---|
| 1 | 4 | 1 | 1214207393 | 103 | |

**ContIntHeadingLink-tabell:**

| contintheadinglink | contint_id | heading_id | registrert | registerred_ass | ... |
|---|---|---|---|---|---|
| 1 | 4 | 24 | 1214207393 | 103 | |

<!-- Originally written for NetServer 3.0 -->

<!-- Referenced links -->
[1]: ../../interests.md

<!-- Referenced images -->
