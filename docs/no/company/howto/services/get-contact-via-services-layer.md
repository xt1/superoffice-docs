---
title: Få en kontakt gjennom tjenestelaget
description: Hvordan få en Person gjennom Tjenester lag.
uid: get_contact_services_layer-no
author: {github-id}
so.date: 11.04.2021
keywords: contact, company, services, API, api-services, ContactAgent
so.topic: howto
# so.envir:
# so.client:
---

# Få en kontakt gjennom tjenestelaget

Dette er et alternativ til å hente en `Contact` enhet [gjennom enhetslaget][1].

Følgende eksempel viser hvordan det gjøres.

## Kode

```csharp
using SuperOffice.CRM.Services;
using SuperOffice;
using(SoSession mySession = SoSession.Authenticate("SAL0", ""))
{
  //Create a Contact Agent
  ContactAgent myContactAgent = new ContactAgent();

  //Get a Contact Entity through the Contact Agent
  Contact myContact = myContactAgent.GetContact(4);

  //Retrieving the Name Property of the Contact
  string name = myContact.Name;
}
```

## Gjennomgang

Først må du opprette en `ContactAgent`. Deretter kan vi hente en `Contact` enhetsbærer ved å sende til `Contact_id` metoden `GetContact` . For øyeblikket vil alle egenskapene til denne kontakten bli sendt til minnet fra databasen. Nå kan du få tilgang til alle egenskapene til denne kontakten via denne nyopprettede transportøren `Contact` .

<!-- Referenced links -->
[1]: ../entity/get-contact-via-entities-layer.md
