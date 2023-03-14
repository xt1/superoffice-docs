---
title: Få CategoryList gjennom SODataReader
description: Få CategoryList gjennom SODataReader
uid: get_category_list_sodatareader-no
author: Bergfrid Dias
so.date: 02.22.2022
keywords: category, CategoryHeadingLinkTableInfo, CategoryList
so.topic: howto
# so.envir:
# so.client:
---

# Få kategorilisten gjennom SODataReader

[SODataReader][1] gjør det også lettere for oss å skaffe kategorilister. Her må du spørre databasen for å hente `CategoryList`.

[!include [ALT](../../../api/includes/note-using-sodatareader.md)]

## Kode

Følgende eksempel viser hvordan det gjøres.

[!code-csharp[CS]](includes/get-catlist-osql.cs)

## Gjennomgang

Her gjør vi en spørring for å hente fra `CategoryList` [Kategori database tabell][2]. Hvis en kategori har en overskrift, vil det være en lenke i [categoryheadinglink tabell][3].

Vi har gruppert elementer i kategorilisten i henhold til overskriftene. Hvis en post i `category` tabellen ikke har en overskrift, returneres "0" som . `HeadingId` På samme måte kan du hente historikkelementene ved å spørre [historie tabell][4].

<!-- Referenced links -->
[1]: ../../../api/osql/so-data-reader.md
[2]: ../../../database/tables/category.md
[3]: ../../../database/tables/categoryheadinglink.md
[4]: ../../../database/tables/history.md
