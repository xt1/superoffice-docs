---
title: interesser
description: Interesser lagres på personer og personer
keywords: interesse, person, firma, person, personinterest, ContInt
uid: company-interests-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
so.topic: concept
---

# Interesser

![Fanen Interesse på Personkort -skjermbilde][img1]

Interesser lagres på personer og personer - det er to separate sett med interesser og et eget sett med koblingstabeller.

![InterestLinkTable diagram][img2]

Koblingstabellen ([personinterest][10]) gjør det mulig for én person å ha null eller flere interesser.

Tabellen [ContInt][9] er en **MDO-tabell** , slik at interesser kan grupperes og organiseres under overskrifter. Stillingen under en overskrift spiller ingen rolle for tilknytningen til en person.

```SQL
SELECT * FROM contint
```

| ContInt_id | navn | Rangering | Verktøytips | Slettet | Registrert | registered_associate_id |
|---|---|---|---|---|---|---|
| 854 | Hansa | 136 | Hansa | 0 | 28.10.2021 13.14:59 | 94 |
| 855 | IFS | 137 | IFS | 0 | 28.10.2021 13.18:17 | 94 |
| 856 | Agresso | 133 | Agresso | 0 | 28.10.2021 13.19:23 | 94 |
| 857 | AS400 | 134 | AS400 | 0 | 28.10.2021 13.20:22 | 94 |

```SQL
SELECT * FROM contactinterest
```

| contactinterest_id | contact_id | cinterest_idx | startDato | sluttDato | Flagg | Registrert |
|---|---|---|---|---|---|---|
| 53459 | 1 | 594 | | 31.12.2021 02:13:49 | 0 | 28.10.2021 13.14:59 |
| 53640 | 1 | 1569 | | 31.12.2021 02:13:49 | 0 | 28.10.2021 13.14:59 |
| 45770 | 4 | 965 | | 31.12.2021 02:13:49| 0 | 28.10.2021 13.14:59 |
| 45259 | 9 | 965 | | 31.12.2021 02:13:49| 0 | 28.10.2021 13.14:59 |

Du kan utvide listen over interesser for en person ved å opprette og legge til en ny interesse i den aktuelle listen.

## Person hurtigbufrede verdien

Tabellen `contact` har et tellerfelt som lagrer antall aktive interesser. Dette feltet brukes til å hurtigbufre antallet. Den oppdateres når brukeren redigerer firmaet. I feltet kan du raskt kontrollere om fanen Interesser har behov for å angi om interessene finnes eller ikke.

## Howto

* [Hent interesser - rå SQL][1]
* [Legge til ny interesse for person – rader][2]
* [Vise alle valgte interesser - enheter][3]
* [Angi av/på-interesser - enheter][4]
* [Vise interesser - tjenester][6]
* [Angi av/på-interesser - tjenester][7]
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
