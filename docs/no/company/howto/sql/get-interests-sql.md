---
title: Hent interesser for person
description: Slik henter du interesser for en person fra SuperOffice database ved hjelp av rå SQL.
keywords: person, firma, interesse, SQL, API
uid: get_interests_sql-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Hent interesser for person

 **Slik får du merket av for en liste over interesser for en person:** 

```SQL
SELECT * FROM contactinterest WHERE contact_id = 123
```

 **Slik henter du navnene på de avsjekkede interessene for en person:** 

```SQL
SELECT * FROM contactinterest, contint
WHERE contactinterest.contact_id = 123
AND contactinterest.cinterest_idx = contint.contint_id
```

| contactinterest_id | contact_id | cinterest_idx | > | ContInt_id | navn | Rangering | Verktøytips | Slettet |
|---|---|---|---|---|---|---|---|---|
| 53459 | 123 | 594 | | 594 | SAP | 142 | | 0 |
| 53640 | 123 | 1569 | | 1569 | Utviklere | 195 | Dette firmaet har... | 0 |
