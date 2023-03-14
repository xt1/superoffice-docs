---
title: Arbeide med selskaper
description: Firmakortet bruker kontakttabellen og de relaterte tabellene. Det finnes flere personoppføringer for alle kontakter.
author: Bergfrid Skaara Dias
so.date: 11.02.2021
so.topic: concept
keywords: company, person, contact
---

# Person

[!include[ Ikke endre firmatabell](../../includes/warn-company-table.md)]

## E-post og URL

Slik setter du sammen en liste over URL-adresser og e-postmeldinger som tilhører denne kontakten:

```SQL
SELECT * FROM url WHERE contact_id = 123 ORDER BY rank

SELECT * FROM email WHERE contact_id = 123 ORDER BY rank
```

Det kan være flere nettadresser som alle refererer til det samme `project_id`. Dette er OK. URL-ene vil bli presentert i rangrekkefølge. Den første rangeringen vil alltid være 1.

Dette er enklere relasjoner enn relasjonene for eier-ID + som brukes på telefon og adresse.

## Personliste

Slik får du listen over personer under en kontakt:

```SQL
SELECT * FROM person WHERE contact_id = 123 ORDER BY rank
```

## Rader og enheter

A `ContactRow` refererer til en rad i `contact` databasetabellen. Derfor består den av grunnleggende datatyper som støttes av SQL.

Typen `Rows` består av en samling  rader, for eksempel `ContactRows` type består av en samling typer `ContactRow` .

Den `ContactEntity` representerer et forretningsobjekt. Den inneholder et sett med egenskaper samlet som en enkelt enhet som representerer et bestemt forretningsobjekt. Enheter inneholder egenskaper for ulike datatyper, for eksempel egenskaper for grunnleggende datatyper som int, string, boolsk, enheter, enhetsmatriser, EntityElement og LocalizedField.

> [!NOTE]
>  `Person` Egenskapen til er `ContactEntity` et *skrivebeskyttet* `Person` element og ikke en `PersonEntity`.

## Opprette kontakter

Du kan opprette en kontakt på flere nivåer av NetServer:

* [Opprette en kontakt med rå SQL][9]
* [Opprette en kontaktenhet][1]
* [Opprette en kontaktenhet gjennom en enhet][2]
* [Opprette en kontaktenhet gjennom en enhetssamling][3]
* [Opprette en kontaktrad][4]
* [Opprette en kontakt via radsamling (rader)][5]
* [Opprett en kontakt gjennom OSQL][6]

## Få kontaktenhet

Du kan få en `Contact` enhet enten ved å bruke  klassene som er angitt i enhetslaget, eller ved å bruke agentene på tjenestelaget.

* [Få en kontakt via Enheter-laget][7]
* [Få en kontakt via Tjenester-laget][8]

## Mer

* [Adresse og telefon: eier-id og type][10]

<!-- Referenced links -->
[1]: entity/create-contact-entity.md
[2]: entity/create-contact-entity-in-entity.md
[3]: entity/create-contact-entity-in-collection.md
[4]: row/create-contact-row.md
[5]: row/create-contact-rows.md
[6]: osql/create-contact-osql.md
[7]: entity/get-contact-via-entities-layer.md
[8]: services/get-contact-via-services-layer.md
[9]: sql/create-contact-sql.md
[10]: ../../globalization-and-localization/address/index.md

<!-- Referenced images -->
