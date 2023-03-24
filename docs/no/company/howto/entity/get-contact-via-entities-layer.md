---
title: Få en person gjennom et lag med enheter
description: Hvordan få en Person gjennom Entities layer.
keywords: person, firma, enhet, API, GetFromIdxContactId
uid: get_contact_entity_layer-no
author: {github-id}
so.date: 05.11.2016
so.topic: howto
# so.envir:
# so.client:
---

# Få en person gjennom et lag med enheter

Det er ganske enkelt å få en person gjennom **et lag med enheter** . Du må importere `SuperOffice.CRM.Entities` navneområdet.

Eksemplet nedenfor viser hvordan det gjøres.

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

Når du henter en `Contact` enhet via en Idx-klasse, må du bestå enhetens ID. Da blir alle egenskapene hentet fra databasen og oppbevart i minnet. På denne måten får du tilgang til egenskapene.

Du kan eventuelt [bruke tjenestelaget][1].

<!-- Referenced links -->
[1]: ../services/get-contact-via-services-layer.md
