---
title: Arbeide med selskaper
description: Firmakortet bruker kontakttabellen og de relaterte tabellene. Det finnes flere personoppføringer for alle kontakter.
uid: company-overview-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
so.topic: concept
keywords: company, person, contact
---

# Firma

![Firmakort -skjermbilde][img2]

[!include [selskap vs. kontakt](../includes/terminology-company.md)]

## Firma kontra andre enheter

Firmakortet bruker [kontakt][2] tabellen og de relaterte tabellene:

![Firma tabelldiagram][img1]

Det er flere `person` poster for alle `contact`. En klassisk mange-til-én-relasjon.

* En **person** kan bare tilhøre én **kontakt**.
* En **kontakt** kan ha null eller flere **personer**.

Det er denne relasjonen som driver de første til feltene i avtale-, salgs- og dokumentdialogboksene. Hver gang du velger et nytt selskap, må personlisten under den fylles ut på nytt.

* [kontakt][10] (person tabell)
* [Dokumenter][11]
* [Oppfølging][12] (avtale tabell)
* [Prosjekter][13]
* [Salg][14]

## API-fremgangsmåter

* [CRMScript][4]
* [Web-tjenester][5]
* [Enheter][6]
* [Rader][7]
* [Objektivert SQL][8]
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
