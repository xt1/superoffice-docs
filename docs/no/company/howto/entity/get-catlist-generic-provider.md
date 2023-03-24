---
title: Få en kategoriliste gjennom generiske listeleverandører
description: Få en kategoriliste gjennom generiske listeleverandører
keywords: kategori, listeleverandør, Kategoriliste
uid: get_category_list_generic_provider-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Få en kategoriliste gjennom generiske listeleverandører

[!code-csharp[CS](includes/get-catlist-generic.cs)]

Ved å sende de riktige parameterne til `Create` metoden  for `SoListProviderFactory`, kan du opprette en `CategoryList`.  `Create()` har 7 overlaster som gir et skrevet, tilpasset grensesnitt for hver liste.

I eksempelet ovenfor har vi passert ønsket navn på listen (kategori). Måten `RootItems`, `HeadingItems`og `HistoryItems` defineres på, er helhetlig for alle [generiske lister][1].

Alle `RootItems` hentes for den tilsvarende tabellen, og dermed brukes  [kategoritabell][3]. Hvis MDO-modusen for den [KategoriListe][2] er slått på, kan det hende at enkelte oppføringer finnes i [historikktabell][4] den tilsvarende kategorilisten, slik at historikklisten kan være utydig. Tilsvarende, hvis inneholder [overskriftstabell][5] oppføringer som tilsvarer kategorilisten, `HeadingItems` vil også kategorilisten være utydlig.

<!-- Referenced links -->
[1]: ../../../api/lists/entity/generic-list.md
[2]: ../../category-list.md
[3]: ../../../database/tables/category.md
[4]: ../../../database/tables/history.md
[5]: ../../../database/tables/heading.md
