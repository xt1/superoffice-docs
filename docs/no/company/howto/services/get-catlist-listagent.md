---
title: Få en KategoriListe ved hjelp av ListAgent
description: Få en kategoriliste gjennom ListAgent
uid: get_category_list_listagent-no
author: {github-id}
so.date: 02.21.2022
keywords: category, list agent
so.topic: howto
# so.envir:
# so.client:
---

# Få en KategoriListe ved hjelp av ListAgent

[!code-csharp[CS]](includes/get-catlist-listagent.cs)

Her har vi brukt ListAgent til å hente kategorilisten.  `ListAgent` tilbyr spesifikke metoder for å hente listene som har blitt eksponert av NetServer. Den returnerer en matrise med Kategori objekter i stedet for generelle MDOListItems. De Kategori objektene har imidlertid ingen måte å gruppere elementene i overskrifter. Det er alltid bare en enkel liste over elementer.
