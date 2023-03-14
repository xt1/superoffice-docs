---
title: Opprett et nytt selskap
description: Hvordan lage en ny Firma ved hjelp av webapi kontakt agent.
uid: create_company_webapi_agents-no
author: Bergfrid Dias
so.date: 11.18.2021
keywords: contact, company, services, API, WebAPI, agents, CreateDefaultContactEntity, JavaScript
so.topic: howto
# so.envir:
# so.client:
---

# Opprett et nytt selskap

Få et tomt selskap, endre det og legg det tilbake for å opprette et nytt selskap.

```javascript
company = Post("api/v1/Agents/Contact/CreateDefaultContactEntity")
company.Name = "New company"
company.Category.Id = 2
company.Business.Id = 3
company.NoMailing = true
company = Post("api/v1/Agents/Contact/SaveContactEntity", company)
```

[!include [Pseudokode](../../../api/includes/note-javascripty.md)]
