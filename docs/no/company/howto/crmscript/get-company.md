---
title: Få firmainformasjon
description: Slik henter du firmainformasjon med CRMScript.
keywords: CRMScript, firma, organisasjon, person
uid: crmscript-get-company-no
author: Bergfrid Skaara Dias
so.date: 02.21.2022
so.topic: howto
---

# Hente firmainformasjon

Du kan få tilgang til et firma på tre måter. Hver av dem returnerer **usann** hvis firmaet er ukjent.

## Boollast(Heltall-id)

Henter firmaet med den angitte IDen. Dette er alltid det første trinnet når du vil gjøre noe med et eksisterende firma.

```crmscript
Company c;
c.load(2);
```

## Bool loadFromAgentAndKey(Heltallsagent, Strengnøkkel)

Henter opp firmaet som eies av agenten, og samsvarer med den eksterne nøkkelen.

> [!CAUTION]
> `loadFromAgentAndKey()` kan overskrive eksisterende verdier!

## Bool findFromDomain(Strengdomene)

Henter firmaet basert på domenet.

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
