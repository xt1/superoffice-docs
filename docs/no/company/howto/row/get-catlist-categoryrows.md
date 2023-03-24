---
title: Hent kategorilisten via KategoriRows-objektet
description: Hent kategorilisten via KategoriRows-objektet
keywords: kategori, rader
uid: get_category_list_categoryrows-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Hent categorylist via KategoriRows-objektet

`CategoryRows` defineres under `SuperOffice.CRM.Rows` navneområde. Du kan til og med få en kategoriliste via `CategoryRows` objektet.

## Koden

```csharp
using SuperOffice.CRM.Rows;
using SuperOffice.Data;
using SuperOffice;
using(SoSession mySession = SoSession.Authenticate("SAL0", ""))
{
CategoryRows.CustomSearch mySearch = newCategoryRows.CustomSearch();
  //Add a Search Restriction to make sure that only the rows with the Field Deleted = 0 will be returned
  mySearch.Restriction = mySearch.TableInfo.Deleted.Equal ( S.Parameter( 0 ) );

  //Retrieve CategoryRows through CustomSearch
  CategoryRows myResult = CategoryRows.GetFromCustomSearch( mySearch );

  //Display the CategoryID and the Name on the ListView
  foreach (CategoryRow row in myResult)
  {
    ListView.Items.Add(row.CategoryId + " " + row.Name);
  }
}
```

## Gjennomgang

Vi har først opprettet en forekomst av `CustomSearch` klassen. Gjennom dette prøver vi å hente ut alle kategoriradene som ikke slettes. I dette eksempelet henter vi bare en liste over kategorier. Du kan også gruppere disse kategoriene i henhold til overskriftene ved å legge til flere begrensninger i `CustomSearch` forekomsten.

Eksemplet ovenfor er en svært enkel demonstrasjon av hvordan en kategoriliste hentes via `CategoryRows` objekt. Du kan også forbedre det i henhold til dine krav.
