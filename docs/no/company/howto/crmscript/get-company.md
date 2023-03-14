---
title: Få firmainformasjon
description: Slik får du bedriftsinformasjon med CRMScript.
uid: crmscript-get-company-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
keywords: CRMScript, company, organization, contact
so.topic: howto
---

# Få informasjon om bedriften

Du kan få tilgang til et selskap på tre måter. Hver vil returnere **falsk** hvis selskapet er ukjent.

## Bool-belastning(heltalls-id)

Bringer opp selskapet med den oppgitte ID. Dette er alltid 1. trinn når du vil gjøre noe med et eksisterende selskap.

```crmscript
Company c;
c.load(2);
```

## Bool loadFromAgentAndKey (heltallsagent, strengnøkkel)

Henter opp selskapet som eies av agenten og matcher den eksterne nøkkelen.

> [!CAUTION]
> `loadFromAgentAndKey()` kan overskrive eksisterende verdier!

## Bool findFromDomain (String domene)

Bringer opp selskapet basert på sitt domene.

```crmscript
Company c;
c.findFromDomain("superoffice.com");
```

## String getValue(String colName)

Henter verdien fra et navngitt felt.

```crmscript!
Company c;
c.load(2);
print(c.getValue("name"));
```

<!-- Referenced links -->
