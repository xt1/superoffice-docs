---
title: Opprett et nytt selskap
description: Hvordan opprette et nytt selskap ved hjelp av REST
uid: create_company_rest-no
author: {github-id}
so.date: 11.04.2021
keywords: contact, company, services, API, rest, JavaScript
so.topic: howto
# so.envir:
# so.client:
---

# Opprett et nytt selskap

Få et tomt selskap, endre det og legg det tilbake for å opprette et nytt selskap.

```javascript
company = Get("api/v1/Contact/default")
company.Name = "New company"
company.Category.Id = 2
company = Post("api/v1/Contact", company)
```
