---
title: Legge til et kategorilisteelement
description: Legge til et kategorilisteelement ved hjelp av WebAPI-agenter
uid: add_catlist_item_listagent-no
author: Bergfrid Dias
so.date: 11.18.2021
keywords: category, contact, WebAPI, agents
so.topic: howto
# so.envir:
# so.client:
---

# Legge til et kategorilisteelement

```javascript
var item = {}
item.Id = 0;
item.Name = "Created by unit test";
item.Tooltip = "Unit Tests FTW";
item.UdListDefinitionId = -64 // Category list ID
item = Post("api/v1/Agents/List/SaveListItemEntity", item)
```

Listeelementet vil bli lagt til - vi kan få hele listen her:

```javascript
req = { UdListDefinitionName: "category", IncludeDeleted: true }
items = Post("api/v1/Agents/List/GetAllFromListName", req)
```

[!include [Pseudokode](../../../api/includes/note-javascripty.md)]
