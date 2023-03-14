---
title: interesser
description: Interesser lagres på kontakter og personer
uid: company-interests-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
keywords: interest, contact, company, person, contactinterest, ContInt
so.topic: concept
---

# Interesser

![Interesse-fanen på Personkort -screenshot][img1]

Interesser lagres på kontakter og personer - det er to separate sett med interesser og et eget sett med koblingstabeller.

![InterestLinkTable-diagram][img2]

Koblingstabellen ([kontaktinteresse][10]) gjør det mulig for en enkelt kontakt å ha null eller flere interesser krysset av.

Tabellen [ContInt][9] er en **MDO-tabell**, slik at interesser kan grupperes og organiseres under overskrifter. Stillingen under en overskrift spiller ingen rolle for koblingen til en kontakt.

```SQL
SELECT * FROM contint
```

| ContInt_id | navn | rang | verktøytips | Slettet | registrert | registered_associate_id |
|---|---|---|---|---|---|---|
| 854 | Hansa | 136 | Hansa | 0 | 28.10.2021 13.14:59 | 94 |
| 855 | IFS | 137 | IFS | 0 | 28.10.2021 13.18:17 | 94 |
| 856 | Agresso | 133 | Agresso | 0 | 28.10.2021 13.19:23 | 94 |
| 857 | AS400 | 134 | AS400 | 0 | 28.10.2021 13.20:22 | 94 |

```SQL
SELECT * FROM contactinterest
```

| contactinterest_id | contact_id | cinterest_idx | startDate | endDate | Flagg | registrert |
|---|---|---|---|---|---|---|
| 53459 | 1 | 594 | | 31.12.2021 02:13:49 | 0 | 28.10.2021 13.14:59 |
| 53640 | 1 | 1569 | | 31.12.2021 02:13:49 | 0 | 28.10.2021 13.14:59 |
| 45770 | 4 | 965 | | 31.12.2021 02:13:49| 0 | 28.10.2021 13.14:59 |
| 45259 | 9 | 965 | | 31.12.2021 02:13:49| 0 | 28.10.2021 13.14:59 |

Du kan utvide listen over interesser for en kontakt ved å opprette og legge til en ny interesse i listen.

## Person bufrede verdien

Tabellen `contact` har et tellerfelt som lagrer antall aktive interesser. Dette feltet brukes til å bufre antallet. Den oppdateres når brukeren redigerer selskapet. Feltet brukes til raskt å kontrollere om kategorien interesser må angi tilstedeværelsen av interesser eller ikke.

## Slik gjør du det

* [Få interesser - rå SQL][1]
* [Legge til en ny kontaktinteresse – rader][2]
* [Liste over alle valgte interesser - enheter][3]
* [Angi renter på/av – enheter][4]
* [Liste interesser - tjenester][6]
* [Sett renter på / av - tjenester][7]
* [ContInt MDO-leverandør][8]

<!-- Referenced links -->
[1]: howto/sql/get-interests-sql.md
[2]: howto/row/add-new-contact-interest.md
[3]: howto/entity/get-interests-for-contact-entity.md
[4]: howto/entity/set-interest-on-off-entity.md
[6]: howto/services/get-interests-for-contact-services.md
[7]: howto/services/set-interest-on-off-services.md
[8]: ../api/mdo-providers/reference/ContInt.md
[9]: ../database/tables/contint.md
[10]: ../database/tables/contactinterest.md

<!-- Referenced images -->
[img1]: media/contact-interests.png
[img2]: media/interestlink-table.png
