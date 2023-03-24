---
title: Arbeide med firmaer
description: Firmakortet bruker persontabellen og tilhørende tabeller. Det finnes flere personoppføringer for enhver person.
keywords: firma, person, person
author: Bergfrid Skaara Dias
so.date: 11.02.2021
so.topic: concept
---

# Person

[!include[ Ikke endre firmatabell](../../includes/warn-company-table.md)]

## E-post og URL

Slik setter du sammen en liste over URL-adressene og e-postmeldingene som tilhører denne personen:

```SQL
SELECT * FROM url WHERE contact_id = 123 ORDER BY rank

SELECT * FROM email WHERE contact_id = 123 ORDER BY rank
```

Det kan være flere URL-adresser som alle refererer til det samme `project_id`. Dette er OK. URL-adressene vil bli presentert i rangeringsrekkefølge. Den første rangeringen vil alltid være 1.

Dette er enklere relasjoner enn eier-ID + typerelasjoner som brukes på telefon og adresse.

## Personliste

Slik får du frem listen over personer under en person:

```SQL
SELECT * FROM person WHERE contact_id = 123 ORDER BY rank
```

## Rader og enheter

En `ContactRow` refererer til en rad i `contact` databasetabellen. Den består derfor av grunnleggende datatyper som støttes av SQL.

Typen `Rows` består av en samling av rader som `ContactRows` type består av en samling av `ContactRow` typer.

Det `ContactEntity` representerer et forretningsobjekt. Den inneholder et sett med egenskaper som er samlet som én enhet som representerer et bestemt forretningsobjekt. Enheter inneholder egenskaper for ulike datatyper, for eksempel egenskaper for grunnleggende datatyper som int, streng, boolsk, enheter, enhetsmatriser, EntityElement og LocalizedField.

> [!NOTE]
>  `Person` Egenskapen til er `ContactEntity` en *skrivebeskyttet* `Person` forekomst og ikke en `PersonEntity`.

## Opprette personer

Du kan opprette en person på flere nivåer i NetServer:

* [Opprette en person med rå SQL][9]
* [Opprette en personenhet][1]
* [Opprette en personenhet via en enhet][2]
* [Opprette en personenhet via en enhetssamling][3]
* [Opprette en personrad][4]
* [Opprette en person via radsamling (Rader)][5]
* [Opprette en person via OSQL][6]

## Hente personenhet

Du kan hente en `Contact` enhet enten ved å bruke klassene som er angitt i enheter-laget eller ved å bruke agentene i tjenestelaget.

* [Få en person gjennom Ettitetslag][7]
* [Få en person gjennom Services-laget][8]

## Mer

* [Adresse og telefon: eier-ID og type][10]

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
