---
title: Telefonpreferanser
description: Telefonpreferanser
keywords: CRM
uid: help-no-phone-preferences
author: SuperOffice RnD
so.date: 06.29.2022
so.topic: help
language: no
---

# Telefonpreferanser

Du kan ringe ut fra SuperOffice CRM på en av følgende måter:

* Klikk på et telefonnummer i  **Firma-bildet** 
* Klikk ![Ikonet][img1] i en dialogboks.
* Høyreklikk på en person på et detaljkort, og velg **Ring *navn***.
* [Ringe til personer][1].

Telefonpreferanser håndteres ulikt i Windows- og Web-klientene. Du kan lære mer om telefonpreferanser for Windows og Web nedenfor.

## Tekniske krav

Hvis du vil bruke telefonfunksjonene i SuperOffice må du kanskje installere programvaren TAPI.

### Foreslåtte leverandører

* Standard telefonprogramvare fra Windows
* Panasonic TSP
* PBX-oppringing

## Innstillinger

Hvis IP-telefon, Skype eller FaceTime er installert, kan du ringe fra SuperOffice CRM. Preferansen **for telefonkoblingsformat** må angis riktig, enten i **Preferanser** > **Standardverdier** eller i SuperOffice Innstillinger og vedlikehold. I SuperOffice Innstillinger og vedlikehold kan telefonpreferansene angis for enkeltbrukere, brukergrupper eller hele systemet.

### Tilgjengelige parametere

 **IP-telefon** : tel:%p (standardverdi)
 **Skype** : callto:%p
 **FaceTime** : facetime:%p

[Malvariabler][2] kan også brukes i telefonparameterne.

<!-- Referenced links -->
[1]: dial.md
[2]: ../../../document/learn/template-variables.md

<!-- Referenced images -->
[img1]: ../../../../../common/icons/phone.png
