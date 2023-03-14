---
title: Få en kategoriliste gjennom generiske listeleverandører
description: Få en kategoriliste gjennom generiske listeleverandører
uid: get_category_list_generic_provider-no
author: {github-id}
so.date: 05.11.2016
keywords: category, list provider, CategoryList
so.topic: howto
# so.envir:
# so.client:
---

# Få en kategoriliste gjennom generiske listeleverandører

[!code-csharp[CS]](includes/get-catlist-generic.cs)

Ved å sende de riktige parametrene til `Create` metoden `SoListProviderFactory`for , kan du opprette en `CategoryList`.  `Create()` har 7 overbelastninger som gir et skrevet, tilpasset grensesnitt for hver liste.

I eksemplet ovenfor har vi passert navnet på listen som trengs (kategori). Måten hvordan `RootItems`  , `HeadingItems`, og `HistoryItems` er  definert er konsistent for alle[generiske lister][1].

Alle `RootItems` er tatt for det tilsvarende bordet, i dette tilfellet [Kategori-tabell][3]. Hvis MDO-modusen for er [Kategoriliste][2] slått på, kan det hende at noen poster finnes i den [historie tabell][4] tilsvarende kategorilisten, slik at historikklisten kan være ikke-tømmelig. På samme måte, hvis inneholder [overskrift tabell][5] poster som tilsvarer  kategorilisten, `HeadingItems` vil kategorilisten også være ikke-tom.

<!-- Referenced links -->
[1]: ../../../api/lists/entity/generic-list.md
[2]: ../../category-list.md
[3]: ../../../database/tables/category.md
[4]: ../../../database/tables/history.md
[5]: ../../../database/tables/heading.md
