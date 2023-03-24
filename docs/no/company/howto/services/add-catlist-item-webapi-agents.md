---
title: Legge til en kategoriliste
description: Legge til en kategoriliste ved hjelp av WebAPI-agenter
keywords: kategori, person, WebAPI, agenter
uid: add_catlist_item_listagent-no
author: Bergfrid Dias
so.date: 11.18.2021
so.topic: howto
# so.envir:
# so.client:
---

# Legge til en kategoriliste

```javascript
var item = {}
item.Id = 0;
item.Name = "Created by unit test";
item.Tooltip = "Unit Tests FTW";
item.UdListDefinitionId = -64 // Category list ID
item = Post("api/v1/Agents/List/SaveListItemEntity", item)
```

Listeelementet blir lagt til - vi kan få hele listen her:

```javascript
req = { UdListDefinitionName: "category", IncludeDeleted: true }
items = Post("api/v1/Agents/List/GetAllFromListName", req)
```

[!include [Pseudocode](../../../api/includes/note-javascripty.md)]
