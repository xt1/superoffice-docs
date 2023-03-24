---
title: Arbeide med firmaer
description: Firmakortet bruker persontabellen og tilhørende tabeller. Det finnes flere personoppføringer for enhver person.
keywords: firma, person, person
uid: company-overview-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
so.topic: concept
---

# Firma

![Firmakort -skjermbilde][img2]

[!include [komprimert vs. person](../includes/terminology-company.md)]

## Firma kontra andre enheter

Firmakortet bruker [Kontakt][2] tabellen og tilhørende tabeller:

![diagram over Firma tabeller][img1]

Det finnes flere `person` oppføringer for eventuelle `contact`. Et klassisk forhold mellom mange og én.

* En **person** kan bare tilhøre én **person** .
* En **person** kan ha null eller flere **personer** .

Det er denne relasjonen som driver de første feltene i dialogboksene avtale, salg og dokument. Hver gang du velger et nytt firma, må personlisten under det fylles ut igjen.

* [Kontakt][10] (persontabell)
* [Dokumenter][11]
* [Oppfølging][12] (Avtaletabell)
* [Prosjekter][13]
* [Salg][14]

## API-hvordan-tos

* [CRMScript][4]
* [Webtjenester][5]
* [Enheter][6]
* [Rader][7]
* [Objektisert SQL][8]
* [Rå SQL][9]

## Mer

* [Interesser][1]
* [Kategorier][15]
* [Adresser][3]
* [Medarbeidere][16]

<!-- Referenced links -->
[1]: interests.md
[2]: ../database/tables/contact.md
[3]: ../globalization-and-localization/address/index.md
[4]: howto/crmscript/index.md
[5]: howto/services/index.md
[6]: howto/entity/index.md
[7]: howto/row/index.md
[8]: howto/osql/index.md
[9]: howto/sql/index.md
[10]: ../contact/index.yml
[11]: ../document/index.yml
[12]: ../diary/index.yml
[13]: ../project/index.yml
[14]: ../sale/index.yml
[15]: category-list.md
[16]: ../contact/associate.md

<!-- Referenced images -->
[img1]: media/so-contact.gif
[img2]: media/company-card.png
