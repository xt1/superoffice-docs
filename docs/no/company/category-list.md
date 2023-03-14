---
title: Kategoriliste
description: Kategori liste
uid: category_list-no
author: {github-id}
so.date: 02.21.2022
keywords: category
so.topic: concept
---

# Kategoriliste

Kategorilisten brukes til å klassifisere en kontakt. Den `Contact.Category_id` refererer til et element på denne listen.

Det finnes flere metoder for å få en kategoriliste:

* [Rå SQL][7]
* [Leverandører av maskinskrevne lister][1]
* [Leverandører av generiske lister][2]
* [SoDataReader][3]
* [CategoryRows-objekt][4]
* [ListAgent][5]
* [MDOAgent][6]

> [!NOTE]Alle listeobjekter i NetServer Services API har et felles grensesnitt. De kan nås eller endres ved hjelp av en ListAgent eller en MDOAgent. MDO-agenten gir en generisk mekanisme for pensumlister. List-agenten inneholder et sterkt typer API som er enklere å programmere med.
> 
Utforsk alternativene og velg den mest passende metoden for applikasjonen din. Vurder å bruke [KategoriCache][8].

<!-- Referenced links -->
[1]: howto/entity/get-catlist-typed-provider.md
[2]: howto/entity/get-catlist-generic-provider.md
[3]: howto/osql/get-catlist-sodatareader.md
[4]: howto/row/get-catlist-categoryrows.md
[5]: howto/services/get-catlist-listagent.md
[6]: howto/services/get-catlist-mdoagent.md
[7]: howto/sql/get-catlist-sql.md
[8]: ../api/caching/category-cache.md
