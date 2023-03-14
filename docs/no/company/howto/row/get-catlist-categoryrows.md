---
title: Få CategoryList via CategoryRows objektet
description: Få CategoryList via CategoryRows-objektet
uid: get_category_list_categoryrows-no
author: {github-id}
so.date: 05.11.2016
keywords: category, rows
so.topic: howto
# so.envir:
# so.client:
---

# Få CategoryList via CategoryRows-objektet

`CategoryRows` er definert under `SuperOffice.CRM.Rows` navneområde. Du kan til og med få en kategoriliste via objektet `CategoryRows` .

## Kode

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

Vi har først opprettet en forekomst av `CustomSearch` klassen. Gjennom dette prøver vi å hente alle kategoriradene som ikke er slettet. I dette eksemplet henter vi ganske enkelt en liste over kategorier. Du kan til og med gruppere disse kategoriene i henhold til overskriftene deres ved å legge til flere begrensninger i forekomsten `CustomSearch` .

Eksemplet ovenfor er en veldig enkel demonstrasjon av hvordan en kategoriliste oppnås via `CategoryRows` objekt. Du kan til og med forbedre den i henhold til dine krav.
