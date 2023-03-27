---
title: Firma (klasse)
description: Slik arbeider du med firmaer i CRMScript.
keywords: CRMScript, firma, organisasjon, person
uid: crmscript_class_company-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
so.topic: howto
---

# Arbeide med firmaer i CRMScript

## Firma (klasse)

Her [Firma CRMScript-klasse][1] vises følgende elementer:

* Virkelige liv: et firma eller en organisasjon
* SuperOffice Brukergrensesnitt: firma
* Databasetabell: [Kontakt][4]

Tabellen **for** firmadatabasen er ikke relatert til Firma  **CRMScript-klassen** . Tabellen bør bare ha én rad, som inneholder informasjon om lisenser og eieren av SuperOffice databasen.

[!include[ Ikke endre firmatabell](../../../includes/warn-company-table.md)]

## Analysere variabler

Kalling `toParser()` laster inn følgende felt og gjør dem tilgjengelige for [Maler][2]:

* company.id
* company.name
* firma.note
* company.domain
* firma.telefon
* firma.faks
* firma.adr
* firma.ourKontakt
* company.primaryContact.id
* company.primaryContact.email

Se [tilknyttede personer][5] tabellen for å få en beskrivelse av `ourContact` og `primaryContact`.

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

* [Opprett firma][6]
* [Hent firma][7]
* [Hent aktiviteter][8]

<!-- Referenced links -->
[1]: <xref:CRMScript.Native.Company>
[2]:../../../automation/crmscript/parser-and-templates/reply-template.md
[3]: ../../../globalization-and-localization/address/index.md
[4]: ../../../database/tables/contact.md
[5]: create-company.md#connected-persons
[6]: create-company.md
[7]: get-company.md
[8]: get-activities.md
