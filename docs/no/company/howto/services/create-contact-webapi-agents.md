---
title: Opprette et nytt firma
description: Hvordan opprette et nytt Firma ved hjelp av webapi kontaktagent.
keywords: person, firma, tjenester, API, WebAPI, agenter, CreateDefaultContactEntity, JavaScript
uid: create_company_webapi_agents-no
author: Bergfrid Dias
so.date: 11.18.2021
so.topic: howto
# so.envir:
# so.client:
---

# Opprette et nytt firma

Hent tomt firma, endre det og poster det tilbake for å opprette et nytt firma.

```javascript
company = Post("api/v1/Agents/Contact/CreateDefaultContactEntity")
company.Name = "New company"
company.Category.Id = 2
company.Business.Id = 3
company.NoMailing = true
company = Post("api/v1/Agents/Contact/SaveContactEntity", company)
```

[!include [Pseudocode](../../../api/includes/note-javascripty.md)]
