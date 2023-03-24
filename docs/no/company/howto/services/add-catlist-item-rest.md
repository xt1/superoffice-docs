---
title: Legge til en kategoriliste ved hjelp av REST
description: Legge til en kategoriliste
keywords: kategori,person,hvile
uid: add_catlist_item_rest-no
author: {github-id}
so.topic: howto
so.date:
# so.envir:
# so.client:
---

# Legge til en kategoriliste ved hjelp av REST

```javascript
var item = {}
item.Name = "Created by unit test";
item.Tooltip = "Unit Tests FTW";
item = Post("api/v1/List/Category/items", item)
```

Listeelementet blir lagt til - vi kan få hele listen her:

```javascript
item = Get("api/v1/List/Category/items", item)
```
