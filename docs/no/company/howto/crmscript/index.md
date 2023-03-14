---
title: Firma (klasse)
description: Hvordan jobbe med selskaper i CRMScript.
uid: crmscript_class_company-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
keywords: CRMScript, company, organization, contact
so.topic: howto
---

# Arbeide med selskaper i CRMScript

## Firma (klasse)

Representerer [Firma CRMScript-klassen][1] følgende enheter:

* Real-life: et selskap eller en organisasjon
* SuperOffice brukergrensesnitt: selskap
* Database tabell: [kontakt][4]

 **Firmadatabasetabellen** er ikke relatert til **Firma** CRMScript-klassen. Tabellen skal bare ha én rad, som inneholder informasjon om lisenser og eieren av den SuperOffice databasen.

[!include[ Ikke endre firmatabell](../../../includes/warn-company-table.md)]

## Parser variabler

Anrop `toParser()` vil laste inn følgende felt og gjøre dem tilgjengelige for [Maler][2]:

* company.id
* company.name
* selskap.note
* firma.domene
* firma.telefon
* firma.faks
* selskap.adr
* selskap.ourKontakt
* company.primaryContact.id
* company.primaryContact.email

Se [Tilknyttede personer][5] tabellen for beskrivelse av `ourContact` og `primaryContact`.

```crmscript!
Parser p;
Company c;
c.load(2);
c.toParser(p);
printLine(p.getVariable("company.name", 0));
```

> [!TIP]
> Les mer om [lokaliserte adresser][3].

## How-to

* [Opprett selskap][6]
* [Få selskap][7]
* [Få aktiviteter][8]

<!-- Referenced links -->
[1]: <xref:CRMScript.Native.Company>
[2]:../../../automatisering/crmscript/parser-og-maler/svar-template.md
[3]: ../../../globalization-and-localization/address/index.md
[4]: ../../../database/tables/contact.md
[5]: create-company.md#connected-persons
[6]: create-company.md
[7]: get-company.md
[8]: get-activities.md
