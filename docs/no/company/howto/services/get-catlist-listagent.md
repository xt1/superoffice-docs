---
title: Få en kategoriliste ved hjelp av ListAgent
description: Få en kategoriliste gjennom ListAgent
keywords: kategori, listeagent
uid: get_category_list_listagent-no
author: {github-id}
so.date: 02.21.2022
so.topic: howto
# so.envir:
# so.client:
---

# Hente en kategoriliste ved hjelp av ListAgent

[!code-csharp[CS](includes/get-catlist-listagent.cs)]

Her har vi brukt ListAgent til å hente kategorilisten.  `ListAgent` tilbyr bestemte metoder for å hente frem listene som NetServer har eksponert. Den returnerer en rekke Kategori objekter i stedet for generelle MDOListItems. De Kategori objektene har imidlertid ingen måte å gruppere forekomstene i overskrifter på. Det er alltid bare en enkel liste over elementer.
