---
title: Opprette et nytt firma
description: Slik oppretter du et nytt firma ved hjelp av REST
keywords: person, firma, tjenester, API, hvile, JavaScript
uid: create_company_rest-no
author: {github-id}
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Opprette et nytt firma

Hent tomt firma, endre det og poster det tilbake for å opprette et nytt firma.

```javascript
company = Get("api/v1/Contact/default")
company.Name = "New company"
company.Category.Id = 2
company = Post("api/v1/Contact", company)
```
