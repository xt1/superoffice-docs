---
title: Få en person gjennom tjenestelaget
description: Slik får du en Person gjennom Services-laget.
keywords: person, firma, tjenester, API, api-tjenester, ContactAgent
uid: get_contact_services_layer-no
author: {github-id}
so.date: 11.04.2021
so.topic: howto
# so.envir:
# so.client:
---

# Få en person gjennom tjenestelaget

Dette er et alternativ til å hente en `Contact` enhet [gjennom enheter-laget][1].

Eksemplet nedenfor viser hvordan det gjøres.

## Koden

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

Først må du opprette en `ContactAgent`. Deretter kan vi hente en `Contact` enhetsbærer ved `Contact_id` å `GetContact` sende  til metoden. For øyeblikket vil alle egenskapene til denne personen sendes til minne fra databasen. Nå kan du få tilgang til alle egenskapene til denne personen via denne nyopprettede `Contact` transportøren.

<!-- Referenced links -->
[1]: ../entity/get-contact-via-entities-layer.md
