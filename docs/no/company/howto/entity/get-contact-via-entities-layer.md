---
title: Få en kontakt via enhetslag
description: Hvordan få en Person gjennom Enheter-laget.
uid: get_contact_entity_layer-no
author: {github-id}
so.date: 05.11.2016
keywords: contact, company, entity, API, GetFromIdxContactId
so.topic: howto
# so.envir:
# so.client:
---

# Få en kontakt via enhetslag

Å få en kontakt gjennom **enhetslaget** er ganske greit. Du må importere `SuperOffice.CRM.Entities` navneområdet.

Følgende eksempel viser hvordan det gjøres.

```csharp
using SuperOffice;
using SuperOffice.CRM.Entities;
using(SoSession mySession = SoSession.Authenticate("SAL0", ""))
{
  //Get a contact through Idx class
  Contact contactThroughIdx = Contact.GetFromIdxContactId(3);

  //Access the Name property
  string name = contactThroughIdx.Name;
}
```

Når du henter `Contact` en  enhet gjennom en Idx-klasse, må du sende ID-en til enheten. Da blir alle egenskapene hentet fra databasen og holdt i minnet. Dette gir deg tilgang til eiendommene.

Du kan alternativt [Bruk tjenestelaget][1].

<!-- Referenced links -->
[1]: ../services/get-contact-via-services-layer.md
