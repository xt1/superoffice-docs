---
title: Telefoninnstillinger
description: Telefoninnstillinger
uid: help-no-phone-preferences
author: SuperOffice RnD
so.date: 06.29.2022
keywords: CRM
so.topic: help
language: no
---

# Telefoninnstillinger

Du kan ringe ut fra SuperOffice CRM på en av følgende måter:

* Klikk på et telefonnummer i **** Firma-skjermbildet
* Klikk ![ikon][img1] i en dialogboks.
* Høyreklikk en person i en inndelingsfane, og velg ** *navnet ***Ring.
* [Ringe kontakter][1].

Telefoninnstillinger håndteres på en annen måte i Windows- og webklientene. Finn ut mer om telefoninnstillinger for Windows og Internett nedenfor.

## Tekniske krav

For å bruke telefonfunksjonene i SuperOffice må du kanskje installere TAPI-programvare.

### Foreslåtte leverandører

* Standard Windows-oppringingsprogramvare
* Panasonic TSP
* PBX-hjul

## Innstillinger

Hvis IP-telefon, Skype eller FaceTime er installert, kan du ringe fra SuperOffice CRM. **Innstillingen for Telefonkoblingsformat** må være riktig angitt, enten  i Innstillinger ** > **Standardverdier eller i **SuperOffice Innstillinger** og vedlikehold. I SuperOffice Innstillinger og vedlikehold kan telefoninnstillingene angis for individuelle brukere, brukergrupper eller hele systemet.

### Tilgjengelige parametere

**IP-telefon**: tel:% p (standardverdi)
**Skype**: callto:% p
**FaceTime**: facetime:%p

[Mal variabler][2] kan også brukes i telefonparametrene.

<!-- Referenced links -->
[1]: dial.md
[2]: ../../../document/learn/template-variables.md

<!-- Referenced images -->
[img1]: ../../../../../common/icons/phone.png
