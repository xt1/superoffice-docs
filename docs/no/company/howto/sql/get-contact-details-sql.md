---
title: Få kontaktinformasjon
description: Hvordan få kontaktinformasjon fra SuperOffice-databasen ved hjelp av rå SQL.
uid: get_contact_details-no
author: Bergfrid Skaara Dias
so.date: 11.04.2021
keywords: contact, company, SQL, API, phone
so.topic: howto
---

# Få kontaktinformasjon

På det mest grunnleggende søker vi bare i kontakttabellen:

```SQL
SELECT * FROM contact WHERE name = 'Client System AS'
```

Som gir oss navn, kode og nummer, og en haug med listeelement-ID-er.

| contact_id | navn | departement | nummer 1 | Nummer 2 | associate_id | country_id | business_idx |
|---|---|---|---|---|---|---|---|
| 15184 | Klientsystem AS | | 120832 | 1011044987 | 287 | 578 | 301 | 317 |

## Listeelementer: kategori og virksomhet

Dette er enkle indre sammenføyninger mot de tilsvarende listeelementtabellene.

```SQL
SELECT * FROM contact, category, business 
WHERE name = 'Client System AS'
AND contact.category_idx = category.category_id
AND contact.business_idx = business.business_id
```

Nå får vi kategorinavn og beskrivelse, samt kategorinavnet.

| contact_id | navn | departement |> Kategori_id| navn | rang | >business_idx | navn | rang |
|---|---|---|---|---|---|---|---|---|
| 15184 | Klientsystem AS | | 317 | Tidligere kunde | 13 | 301 | IT og telekom | 12 |

## Telefonnumre

Det kan være flere telefonnumre på en kontakt. Vi vil plukke ut den første.

```SQL
SELECT * FROM contact, category, business, phone 
WHERE name = 'Client System AS'
AND contact.category_idx = category.category_id
AND contact.business_idx = business.business_id
AND contact.contact_id = phone.owner_id
AND phone.ptype_idx = 1
AND phone.rank = 1
```

Telefoner kommer inn [Flere forskjellige typer][1]. Type 1 = direkte telefon.

Denne indre sammenføyningen forutsetter at kontakten har minst ett telefonnummer.

Hvis vi ønsker å håndtere kontakter som ikke har telefonnumre, må vi bruke en ytre sammenføyning:

```SQL
SELECT c.name, cat.name, bus.name, p.* FROM CRM.contact c
LEFT OUTER JOIN CRM.phone p ON c.contact_id = p.owner_id
INNER JOIN CRM.category cat ON c.category_idx = cat.category_id
INNER JOIN CRM.business bus ON c.business_idx = bus.business_id
WHERE c.name = 'Client System AS'
AND p.ptype_idx = 1
AND p.rank = 1
```

| navn | navn | navn | phone_id | owner_id | ptype_id | search_phone | Telefon | rang | beskrivelse |
|---|---|---|---|---|---|---|---|---|---|
| Klientsystem AS | Tidligere kunde | IT og telekom | 21537 | 15184 | 1 | 667763900 | 66 77 636 90 | 1 | Telefon |

## Adresse: gate eller post

Det finnes bare én adresseoppføring for hver type per kontakt. Men hvis ingen adresse er angitt, vil det ikke være en adressepost, så vi må bruke en ytre sammenføyning igjen.

Vi kan bruke en indre sammenføyning for å få land-ID. Listeelementet skal alltid angis.

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

[Type adresse][2]: 2 = gateadresse

| navn | navn | navn | Telefon | navn | address_id | owner_id | atype_idx | ... |
|---|---|---|---|---|---|---|---|---|
| Klientsystem AS | Tidligere kunde | IT og telekom | 66 77 63 90 | Norge | 15834 | 15184 | 2 | |

<!-- Referenced links -->
[1]: ../../../database/tables/phone.md
[2]: ../../../database/tables/address.md

<!-- Referenced images -->
