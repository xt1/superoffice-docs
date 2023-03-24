---
title: Opprett og oppdater firmaer
description: Slik oppretter og oppdaterer du firmaer med CRMScript.
keywords: CRMScript, firma, organisasjon, person
uid: crmscript-create-company-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
so.topic: howto
---

# Opprette og oppdatere firmaer

## Annuller setValue(Streng-kolonne, Strengverdi)

Setter et navngitt felt til den angitte verdien. Slå opp navn i [referansedelen nedenfor][3], eller sjekk ut [klassereferanse][1].

> [!NOTE]Begge parameterne er strenger! Husk å bruke tilbud selv for ID-er.
> >
> Du må ringe `save()` etter å ha angitt alle aktuelle verdier for å faktisk opprette eller oppdatere firmaet.

```crmscript
Company c;
c.setValue("name", "SuperOffice");
c.save();
```

## Heltallssparing()

Lagrer et nytt eller oppdatert firma, og returnerer IDen.

```crmscript
Company c;
c.setValue("name", "SuperOffice");
c.setValue("domain", "superoffice.com");
printLine(c.save().toString());
```

## Referanse

### Ofte brukte verdier

| Parameteren | Databasefelt | Beskrivelse |
|:---|:---|:---|
| navn | navn | Navnet på firmaet |
| Telefon | Telefon | Firmaets telefonnummer |
| Domene | company_domain | En visningsversjon av firmaets domene |
| Prioritet | ticket_priority | IDen til standardprioriteten for dette firmaet. <br>NULL eller -1 hvis ikke angitt. |
| Språk | cust_lang | IDen til standard kundespråk for dette firmaet. <br>NULL eller -1 hvis ikke angitt. |

### Tilknyttede personer

| Parameteren | Databasefelt | Beskrivelse |
|:---|:---|:---|
| vårKontakt | associate_id | IDen (`ejuser.id`) til det interne medarbeidersalget til dette firmaet |
| supportAssociateId | supportAssociateId | IDen (`ejuser.id`) eller brukernavnet til den interne brukerbehandlingsstøtten til dette firmaet |
| primKontakt | supportPerson | IDen (`customer.id`) til primærkontakten hos dette firmaet<br>, motparten av supportAssociateId |

Hvis du vil ha en fullstendig liste over felt, kan du se [databasereferanse][2].

<!-- Referenced links -->
[1]: <xref:CRMScript.Native.Company.setValue(String,String)>
[2]:../../../database/tabeller/person.md
[3]: #reference
