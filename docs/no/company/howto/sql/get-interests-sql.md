---
title: Få interesser for kontakt
description: Hvordan få interesser for en kontakt fra den SuperOffice databasen ved hjelp av rå SQL.
uid: get_interests_sql-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
keywords: contact, company, interest, SQL, API
so.topic: howto
# so.envir:
# so.client:
---

# Få interesser for kontakt

**Slik får du en liste over interesser krysset av for en kontakt:**

```SQL
SELECT * FROM contactinterest WHERE contact_id = 123
```

**Slik får du navnene på de avmerkede interessene for en kontakt:**

```SQL
SELECT * FROM contactinterest, contint
WHERE contactinterest.contact_id = 123
AND contactinterest.cinterest_idx = contint.contint_id
```

| contactinterest_id | contact_id | cinterest_idx | > | ContInt_id | navn | rang | verktøytips | Slettet |
|---|---|---|---|---|---|---|---|---|
| 53459 | 123 | 594 | | 594 | SAP | 142 | | 0 |
| 53640 | 123 | 1569 | | 1569 | Utviklere | 195 | Dette selskapet har... | 0 |
