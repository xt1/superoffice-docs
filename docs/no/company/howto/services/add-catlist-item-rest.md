---
title: Legg til et kategorilisteelement ved hjelp av REST
description: Legge til et kategorilisteelement
uid: add_catlist_item_rest-no
author: {github-id}
keywords: category,contact,rest
so.topic: howto
so.date:
# so.envir:
# so.client:
---

# Legge til et kategorilisteelement ved hjelp av REST

```javascript
var item = {}
item.Name = "Created by unit test";
item.Tooltip = "Unit Tests FTW";
item = Post("api/v1/List/Category/items", item)
```

Listeelementet vil bli lagt til - vi kan få hele listen her:

```javascript
item = Get("api/v1/List/Category/items", item)
```
