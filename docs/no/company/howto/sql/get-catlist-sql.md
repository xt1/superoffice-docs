---
title: Få liste over kategorier
description: Slik får du alle kategorier med rå SQL.
keywords: kategori, KategoriGruppeKobling, person
uid: get-catlist-sql-no
author: Bergfrid Dias
so.date: 02.21.2022
so.topic: howto
---

# Få alle kategorier

```SQL
SELECT l.category_id, l.name, l.tooltip FROM Category l WHERE l.deleted = 0 ORDER BY l.rank
```

Resultatet er en liste over kategorier, bestilt etter rangering i listen.

De slettede forekomstene inkluderes ikke, men elementer som bør skjules for brukeren på grunn av MDO-filtrering, inkluderes.

| category_id | navn | Verktøytips |
|---|---|---|
| 754 |Kunde A| Stor fisk |
| 755 |Kunde B| Fisk i middagsstørrelse |
| 756 |Kunde F| Liten fisk |
| 318 | Partnerkunde | |
| 732 | Internasjonal kunde | |
| 317 | Tidligere kunde | Har lisens, men ingen vedlikeholdsavtale |

## Filtrere uten overskrift

Filtrering betyr at forekomster som er skjult for brukeren, ikke skal vises.

Filtrering gjøres gjennom brukerens gruppemedlemskap.

Noen forekomster er skjult for enkelte grupper.

```SQL
SELECT l.category_id, l.name, l.rank FROM Category l, CategoryGroupLink gl, UserGroupLink ugl
  WHERE l.deleted = 0
  AND l.category_id = gl.category_id
  AND gl.group_id = ugl.usergroup_id
  AND ugl.assoc_id = <my assoc_id>;
  ORDER BY l.rank
```

Resultatet er et sett med listenavn, filtrert via brukerens gruppemedlemskap. Forekomster som brukeren ikke har lov til å se, blir ikke returnert.

> [!NOTE]
> Fordi en bruker kan være medlem av flere enn én brukergruppe, må vi stå sammen mot tabellen [UserGroupLink][1] .
>
> Forekomster som er synlige for mer enn én gruppe, returneres to ganger. Bruk SELECT DISTINCT til å filtrere duplikatene ut.

| category_id | navn | Rangering |
|---|---|---|
| 754 |Kunde A| 1 |
| 755 |Kunde B| 2 |
| 756 |Kunde F| 3 |
| 732 | Internasjonal kunde | 10|
| 317 | Tidligere kunde | 13 |
| 104 | Partner | 14 |
| 416 |Bransje partner| 16 |
| 455 | Partner under sertifisering | 17 |

## Hente alle forekomster med overskrifter, ingen filtrering

```SQL
SELECT h.rank, h.name, l.name, l.category_id, l.rank FROM Heading h, Category l, CategoryHeadingLink hl
  WHERE l.deleted = 0
  AND h.heading_id = hl.heading_id
  AND l.category_id = hl.category_id
  ORDER BY h.rank, l.rank
```

Resultatet er et sett med overskriftsnavn par, bestilt av overskrift og deretter ønsket rekkefølge innenfor hver overskrift.

> [!NOTE]En forekomst kan vises under flere overskrifter - dette er tillatt av listeadministrasjonsverktøyet.
> 
| Rangering | navn | navn | category_id | Rangering |
|---|---|---|---|---|
| 1 | Andre | Praktikant  | 392 | 99 |
| 1 | Andre | Ansatt | 13 | 100 |
| 1 | Andre | Leverandør | 4 | 101|
| 1 | Andre | Konkurrent | 588 | 105 |
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

Dette gir riktig filtrert navnesett fra listen, bestilt av overskrifter og rangering.

Vis forekomster som er skjult for brukeren, blir fjernet fra resultatet av databasen ved hjelp av `UserGroupLink` sammenføyning.

<!-- Referenced links -->
[1]: ../../../database/tables/usergrouplink.md

<!-- Referenced images -->
