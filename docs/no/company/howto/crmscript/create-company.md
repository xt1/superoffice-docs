---
title: Opprett og oppdater selskaper
description: Hvordan opprette og oppdatere selskaper med CRMScript.
uid: crmscript-create-company-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
keywords: CRMScript, company, organization, contact
so.topic: howto
---

# Opprette og oppdatere selskaper

## Void setValue(String-kolonne; Strengverdi)

Setter et navngitt felt til den angitte verdien. Slå opp navn i [referanse delen ned nedenfor][3], eller sjekk ut [klasse referanse][1].

> [!NOTE]Begge parametrene er strenger! Husk å bruke anførselstegn selv for ID-er.
> >
> Du må ringe `save()` etter at du har angitt alle gjeldende verdier for å faktisk opprette eller oppdatere firmaet.

```crmscript
Company c;
c.setValue("name", "SuperOffice");
c.save();
```

## Heltallslagring()

Lagrer et nytt eller oppdatert selskap og returnerer ID-en.

```crmscript
Company c;
c.setValue("name", "SuperOffice");
c.setValue("domain", "superoffice.com");
printLine(c.save().toString());
```

## Referanse

### Ofte brukte verdier

| Parameter | Database-feltet | Beskrivelse |
|:---|:---|:---|
| navn | navn | Navnet på selskapet |
| Telefon | Telefon | Selskapets telefonnummer |
| domene | company_domain | En visningsversjon av selskapets domene |
| prioritet | ticket_priority | ID-en for standardprioriteten for dette firmaet. <br>NULL eller -1 hvis ikke angitt. |
| Språk | cust_lang | ID-en til standard kundespråk for dette firmaet. <br>NULL eller -1 hvis ikke angitt. |

### Tilknyttede personer

| Parameter | Database-feltet | Beskrivelse |
|:---|:---|:---|
| vår Kontakt | associate_id | ID-en (`ejuser.id`) til den interne ansatte som håndterer salg til dette selskapet |
| supportAssociateId | supportAssociateId | ID (`ejuser.id`) eller brukernavn for den interne ansatte som håndterer støtte til dette selskapet |
| primContact | supportPerson | ID-en (`customer.id`) til primærkontakten i dette selskapet<br>er motparten til supportAssociateId |

Hvis du vil ha en fullstendig liste over felt, kan du se [database referanse][2].

<!-- Referenced links -->
[1]: <xref:CRMScript.Native.Company.setValue(String,String)>
[2]:../../../database/tabeller/contact.md
[3]: #reference
