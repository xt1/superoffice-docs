---
title: Få kategorilisten gjennom SODataReader
description: Få kategorilisten gjennom SODataReader
keywords: kategori, KategoriOverskriftLinkTableInfo, Kategoriliste
uid: get_category_list_sodatareader-no
author: Bergfrid Dias
so.date: 02.22.2022
so.topic: howto
# so.envir:
# so.client:
---

# Få kategorilisten gjennom SODataReader

[SODataReader][1] Gjør det også enklere for oss å skaffe kategorilister. Her må du søke i databasen for å hente . `CategoryList`

[!include [ALT](../../../api/includes/note-using-sodatareader.md)]

## Koden

Eksemplet nedenfor viser hvordan det gjøres.

[!code-csharp[CS](includes/get-catlist-osql.cs)]

## Gjennomgang

Her lager vi en spørring for å hente `CategoryList` fra [kategoridatabasetabell][2]. Hvis en kategori har en overskrift, vil det finnes en kobling i [kategorioverskriftstabell][3].

Vi har grupperte forekomster i kategorilisten i henhold til overskriftene deres. Hvis en oppføring i `category` tabellen ikke har overskrift, returneres "0" som `HeadingId`. På tilsvarende måte kan du hente historikkelementene ved å søke etter [historikktabell][4].

<!-- Referenced links -->
[1]: ../../../api/osql/so-data-reader.md
[2]: ../../../database/tables/category.md
[3]: ../../../database/tables/categoryheadinglink.md
[4]: ../../../database/tables/history.md
