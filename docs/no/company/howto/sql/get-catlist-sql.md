---
title: Få liste over kategorier
description: Hvordan få alle kategorier med rå SQL.
uid: get-catlist-sql-no
author: Bergfrid Dias
so.date: 02.21.2022
keywords: category, CategoryGroupLink, contact
so.topic: howto
---

# Få alle kategorier

```SQL
SELECT l.category_id, l.name, l.tooltip FROM Category l WHERE l.deleted = 0 ORDER BY l.rank
```

Resultatet er en liste over kategorier, sortert etter rangering i listen.

De slettede elementene er ikke inkludert, men elementer som skal skjules for brukeren på grunn av MDO-filtrering, er inkludert.

| category_id | navn | verktøytips |
|---|---|---|
| 754 |Kunde A| Stor fisk |
| 755 |Kunde B| Fisk i middagsstørrelse |
| 756 |Kunde C| Liten fisk |
| 318 | Partner kunde | |
| 732 | Internasjonal kunde | |
| 317 | Tidligere kunde | Har lisens, men ingen vedlikeholdsavtale |

## Filtrere uten overskrift

Filtrering betyr at elementer som er skjult for brukeren, ikke skal vises.

Filtrering gjøres gjennom brukerens gruppemedlemskap.

Noen elementer er skjult for noen grupper.

```SQL
SELECT l.category_id, l.name, l.rank FROM Category l, CategoryGroupLink gl, UserGroupLink ugl
  WHERE l.deleted = 0
  AND l.category_id = gl.category_id
  AND gl.group_id = ugl.usergroup_id
  AND ugl.assoc_id = <my assoc_id>;
  ORDER BY l.rank
```

Resultatet er et sett med listenavn, filtrert via brukerens gruppemedlemskap. Elementer som brukeren ikke har lov til å se, blir ikke returnert.

> [!NOTE]
> Fordi en bruker kan være medlem av mer enn én brukergruppe, må vi bli med mot bordet [UserGroupLink][1] .
>
> Elementer som er synlige for mer enn én gruppe, returneres to ganger. Bruk VELG DISTINKT for å filtrere duplikatene ut.

| category_id | navn | rang |
|---|---|---|
| 754 |Kunde A| 1 |
| 755 |Kunde B| 2 |
| 756 |Kunde C| 3 |
| 732 | Internasjonal kunde | 10|
| 317 | Tidligere kunde | 13 |
| 104 | Partner | 14 |
| 416 |Bransje partner| 16 |
| 455 | Partner under sertifisering | 17 |

## Få alle elementer med overskrifter, ingen filtrering

```SQL
SELECT h.rank, h.name, l.name, l.category_id, l.rank FROM Heading h, Category l, CategoryHeadingLink hl
  WHERE l.deleted = 0
  AND h.heading_id = hl.heading_id
  AND l.category_id = hl.category_id
  ORDER BY h.rank, l.rank
```

Resultatet er et sett med overskriftsnavnspar, sortert etter overskrift og deretter ønsket rekkefølge innenfor hver overskrift.

> [!NOTE]Et element kan vises under flere overskrifter - dette er tillatt av listeadministratorverktøyet.
> 
| rang | navn | navn | category_id | rang |
|---|---|---|---|---|
| 1 | Annen | Internere  | 392 | 99 |
| 1 | Annen | Arbeidstaker | 13 | 100 |
| 1 | Annen | Leverandør | 4 | 101|
| 1 | Annen | Konkurrent | 588 | 105 |
| 2 | Partner | Partner | 104 | 14
| 2 | Partner |Bransje partner| 416 | 16 |
| 2 | Partner | Partner under sertifisering | 455 | 17 |
| 2 | Partner | SAP-leverandør | 918 | 18 |
| 2 | Partner | Potensiell partner | 18 | 19 |

## Filtrere og gruppere under overskrifter

```SQL
SELECT DISTINCT h.rank, h.name, l.name, l.category_id, l.rank
  FROM Heading h, Category l, CategoryHeadingLink hl, CategoryGroupLink gl, UserGroupLink ugl
  WHERE l.deleted = 0
  AND selecth.heading_id = hl.heading_id
  AND l.category_id = hl.category_id
  AND l.category_id = gl.category_id
  AND gl.group_id = ugl.usergroup_id
  AND ugl.assoc_id = <my assoc_id>
  ORDER BY h.rank, l.rank
```

Dette vil gi riktig filtrert sett med navn fra listen, sortert etter overskrifter og rang.

Listeelementer som er skjult for brukeren, fjernes fra resultatet av databasen ved hjelp av `UserGroupLink` sammenføyningen.

<!-- Referenced links -->
[1]: ../../../database/tables/usergrouplink.md

<!-- Referenced images -->