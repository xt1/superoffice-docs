---
title: Få en kategoriliste gjennom innskrevne listeleverandører
description: Få en kategoriliste gjennom innskrevne listeleverandører
keywords: kategori, listeleverandør, Kategoriliste
uid: get_category_list_typed_provider-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Få en kategoriliste gjennom innskrevne listeleverandører

I `SoList` klassen finnes det bestemte metoder for å opprette ulike typer listeleverandører. Derfor er det en metode spesialisert i å opprette `CategoryList` leverandører også.

I eksemplet nedenfor vises hvordan du bruker . [kategoriliste][2][typede listeleverandører][1]

[!code-csharp[CS](includes/get-catlist-typed.cs)]

Ved å bruke metoden `CategoryList` som er definert i `SoList` klassen, kan du skaffe deg en `CategoryList` leverandør.

Det finnes tre forskjellige forekomster i `CategoryList` tilbyderen: HeadingItems, HistoryItems og RootItems. Hver av disse forekomstene inneholder egne egenskaper, og i dette eksempelet har vi bare brukt egenskapene `Id` og `Name` .

I `HistoryItems` feltet defineres med [historikktabell][1] feltet  med `table_Id` henvisning til den konseptuelle tabell-IDen til [kategoritabell][4]. Med mindre MDO-modusen på `Contact` listen er slått på, legges det ikke til noen post i `history` tabellen.

Oppføringene `RootItems` defineres bare av postene i `category` tabellen hvis MDO-modusen er satt til usann. Hvis MDO-modusen er satt til sann, inneholder den `RootItems` bare forekomstene som ikke er tilordnet noen overskrift. Vanligvis hentes alle HeadingItems direkte fra [overskriftstabell][5].

 **Utdata fra eksempelet:** 

![01 -skjermbilde][img1]

<!-- Referenced links -->
[1]: ../../../api/lists/entity/typed-list.md
[2]: ../../category-list.md
[4]: ../../../database/tables/category.md
[5]: ../../../database/tables/heading.md

<!-- Referenced images -->
[img1]: media/image002.jpg
