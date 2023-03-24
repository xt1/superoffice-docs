---
title: Velg alle firmaer
description: Slik leser du alle firmaene i SuperOffice med REST Web API.
keywords: person, firma, tjenester, API, søk, hvile
uid: rest_api_search_contact-no
author: {github-id}
so.date: 11.04.2021
so.topic: howto
---

# Velg alle firmaer

Les alle firmaene i SuperOffice.

```http
GET /api/v1/contact?$select=name,associateId,contactAssociate/fullName HTTP/1.1
Authorization: Bearer 8A:
Content-Type: application/json
Accept: application/json
```

```javascript
companies = Get("api/v1/Contact?$select=name,category,number")
// companies.value = 
  [
   {
    "PrimaryKey": "3",
    "EntityName": "contact",
    "name": "Amadeus AS",
    "category": "Kunde",
    "number": "AA10011"
   },{
    "PrimaryKey": "4",
    "EntityName": "contact",
    "name": "Arne's Kebab",
    "category": "Kunde",
    "number": "AA10012"
   },{
    "PrimaryKey": "5",
    "EntityName": "contact",
    "name": "Bjørge AS",
    "category": "Kunde",
    "number": "BB10013"
   } ]
```
