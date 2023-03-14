---
title: Få en kategoriliste gjennom maskinskrevne listeleverandører
description: Få en kategoriliste gjennom maskinskrevne listeleverandører
uid: get_category_list_typed_provider-no
author: {github-id}
so.date: 05.11.2016
keywords: category, list provider, CategoryList
so.topic: howto
# so.envir:
# so.client:
---

# Få en kategoriliste gjennom maskinskrevne listeleverandører

I `SoList` klassen er det spesifikke metoder for å lage forskjellige typer listeleverandører. Derfor er det en metode spesialisert på å skape `CategoryList` leverandører også.

Følgende eksempel viser hvordan du får en [Kategori Liste][2] bruker [Leverandører av maskinskrevne lister][1].

[!code-csharp[CS]](includes/get-catlist-typed.cs)

Ved å bruke metoden som `CategoryList` er definert i klassen, `SoList` kan du få en `CategoryList` leverandør.

Det er 3 forskjellige elementer til stede i `CategoryList` leverandøren: HeadingItems, HistoryItems og RootItems. Hvert av disse elementene inneholder sine egne egenskaper, og i dette eksemplet har vi bare brukt og `Id` egenskapene `Name` .

De `HistoryItems` er definert i [historie tabell][1] med sitt `table_Id` felt som refererer til den konseptuelle tabell-ID-en til [Kategori-tabell][4]. Med mindre MDO-modusen for `Contact` listen er aktivert, blir ingen post lagt til i `history` tabellen.

De `RootItems` er  definert av postene i `category` tabellen bare hvis MDO-modus er satt til usann. Hvis MDO-modus er satt til sann, inneholder den `RootItems` bare elementene som ikke er tilordnet noen overskrift. Normalt er alle HeadingItems hentet direkte fra[overskrift tabell][5].

**Utgang av eksemplet:**

![01 -skjermbilde][img1]

<!-- Referenced links -->
[1]: ../../../api/lists/entity/typed-list.md
[2]: ../../category-list.md
[4]: ../../../database/tables/category.md
[5]: ../../../database/tables/heading.md

<!-- Referenced images -->
[img1]: media/image002.jpg
