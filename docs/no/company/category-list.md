---
title: Kategoriliste
description: Kategori liste
keywords: kategori
uid: category_list-no
author: {github-id}
so.date: 02.21.2022
so.topic: concept
---

# KategoriListe

Kategorilisten brukes til å klassifisere en person. Refererer `Contact.Category_id` til en forekomst på denne listen.

Det finnes flere metoder for å få en kategoriliste:

* [Rå SQL][7]
* [Typeerte listeleverandører][1]
* [Generiske listeleverandører][2]
* [SoDataReader][3]
* [KategoriRows-objekt][4]
* [ListAgent][5]
* [MDOAgent][6]

> [!NOTE]Alle forekomster i API for NetServer-tjenester har et felles grensesnitt. De kan nås eller endres ved hjelp av en ListAgent eller en MDOAgent. MDO-agenten tilbyr en generisk mekanisme for leselister. Listeagenten har en API som er enklere å programmere med.
> 
Utforsk alternativene og velg den mest hensiktsmessige metoden for applikasjonen. Vurder å bruke [KategoriCache][8].

<!-- Referenced links -->
[1]: howto/entity/get-catlist-typed-provider.md
[2]: howto/entity/get-catlist-generic-provider.md
[3]: howto/osql/get-catlist-sodatareader.md
[4]: howto/row/get-catlist-categoryrows.md
[5]: howto/services/get-catlist-listagent.md
[6]: howto/services/get-catlist-mdoagent.md
[7]: howto/sql/get-catlist-sql.md
[8]: ../api/caching/category-cache.md
