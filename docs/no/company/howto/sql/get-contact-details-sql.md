---
title: Få opplysninger om personen
description: Slik henter du opplysninger om personen fra SuperOffice-databasen ved hjelp av rå SQL.
keywords: person, firma, SQL, API, telefon
uid: get_contact_details-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
so.topic: howto
---

# Få opplysninger om personen

På sitt mest grunnleggende søker vi bare i persontabellen:

```SQL
SELECT * FROM contact WHERE name = 'Client System AS'
```

Som gir oss navnet, koden og nummeret, og en haug med forekomst-IDer.

| contact_id | navn | Avdeling | nummer 1 | nummer2 | associate_id | country_id | business_idx |
|---|---|---|---|---|---|---|---|
| 15184 | Klientsystem AS | | 120832 | 1011044987 | 287 | 578 | 301 | 317 |

## Vise forekomster: kategori og bransje

Dette er enkle indre sammenføyninger mot de tilsvarende forekomsttabellene i listen.

```SQL
SELECT * FROM contact, category, business 
WHERE name = 'Client System AS'
AND contact.category_idx = category.category_id
AND contact.business_idx = business.business_id
```

Nå får vi kategoriens navn og beskrivelse samt kategorinavnet.

| contact_id | navn | Avdeling |> Kategori_id| navn | Rangering | >business_idx | navn | Rangering |
|---|---|---|---|---|---|---|---|---|
| 15184 | Klientsystem AS | | 317 | Tidligere kunde | 13 | 301 | IT og teletelekom | 12 |

## Telefonnumre

Det kan være flere telefonnumre på en person. Vi skal plukke ut den første.

```SQL
SELECT * FROM contact, category, business, phone 
WHERE name = 'Client System AS'
AND contact.category_idx = category.category_id
AND contact.business_idx = business.business_id
AND contact.contact_id = phone.owner_id
AND phone.ptype_idx = 1
AND phone.rank = 1
```

Telefoner kommer inn [flere ulike typer][1]. Type 1 = direkte telefon.

Denne indre sammenføyning forutsetter at personen har minst ett telefonnummer.

Hvis vi ønsker å håndtere personer som ikke har telefonnumre, må vi bruke en ytre sammenføyning:

```SQL
SELECT c.name, cat.name, bus.name, p.* FROM CRM.contact c
LEFT OUTER JOIN CRM.phone p ON c.contact_id = p.owner_id
INNER JOIN CRM.category cat ON c.category_idx = cat.category_id
INNER JOIN CRM.business bus ON c.business_idx = bus.business_id
WHERE c.name = 'Client System AS'
AND p.ptype_idx = 1
AND p.rank = 1
```

| navn | navn | navn | phone_id | owner_id | ptype_id | search_phone | Telefon | Rangering | Beskrivelse |
|---|---|---|---|---|---|---|---|---|---|
| Klientsystem AS | Tidligere kunde | IT og teletelekom | 21537 | 15184 | 1 | 667763900 | 66 77 636 90 | 1 | Telefon |

## Adresse: gate eller post

Det finnes bare én adresseoppføring av hver type per person. Men hvis det ikke er registrert noen adresse, vil det ikke være noen adresseoppføring, så vi må bruke en ytre sammenføyning på nytt.

Vi kan bruke en indre sammenføyning for å hente land-IDen. Forekomst av listen bør alltid angis.

```SQL
SELECT c.name, cat.name, bus.name, p.phone, cou.name, a.*
FROM CRM.contact c
LEFT OUTER JOIN CRM.address a ON c.contact_id = a.owner_id
LEFT OUTER JOIN CRM.phone p ON c.contact_id = p.owner_id
INNER JOIN CRM.category cat ON c.category_idx = cat.category_id
INNER JOIN CRM.business bus ON c.business_idx = bus.business_id
INNER JOIN CRM.country cou ON c.country_id = cou.country_id
WHERE c.name = 'Client System AS'
AND p.ptype_idx = 1
AND p.rank = 1
AND a.atype_idx = 2
```

[Adressetype][2]: 2 = gateadresse

| navn | navn | navn | Telefon | navn | address_id | owner_id | atype_idx | ... |
|---|---|---|---|---|---|---|---|---|
| Klientsystem AS | Tidligere kunde | IT og teletelekom | 66 77 63 90 | Norge | 15834 | 15184 | 2 | |

<!-- Referenced links -->
[1]: ../../../database/tables/phone.md
[2]: ../../../database/tables/address.md

<!-- Referenced images -->
