---
title: Slå sammen firmaer
description: Slå sammen firmaer
keywords: firma
uid: help-no-company-merge
author: SuperOffice RnD
so.date: 06.29.2022
so.topic: help
language: no
---

# Slå sammen firmaer

[!include [Requirement](../../learn/includes/note-req-manage-entities.md)]

Du kan slå sammen duplikater av databaseposter for firmaer. Personer og aktiviteter flyttes til målfirmaet, og kildefirmaet blir slettet.

 **Trinn:** 

[!include[ Go til firma](../../learn/includes/goto-company.md)]

1. Velg **Administrer firmaer** fra ![Ikonet][img3]  **Oppgave-knappen** , og klikk på **Slå sammen firmaer** .
    Dialogboksen **Slå sammen firmaer** åpnes. Kildefirmaet er angitt under **Fra** .

1. Under **Til firma** velger du firmaet du vil oppdatere med informasjon fra kildefirmaet. Begynn å skrive i feltet til [søke etter et firma][1].

    > [!TIP]
    > Hvis du vil bytte om på **Fra** - og **Til-firma** , klikker du på ![Ikonet][img1] knappen.

1. Under **Personer- og firmadetaljer** kan du velge mellom følgende:

    * Slå sammen identiske personer. Hvis valgt, slås personer med identiske navn sammen.

        > [!NOTE]Navnene må være HELT identiske, fornavn, mellomnavn og etternavn for å bli slått sammen.
        > 
    * **Erstatt tomme felt i \[målfirma\] med verdier fra \[kildefirma\]** . Hvis det er valgt, oppdateres tomme datafelt i **Til-firmaet** med data fra **Fra-firmaet** .

    [!include [Forvise resultater](../../learn/includes/note-preview-results.md)]

1. Klikk på **Slå sammen** . Da skjer følgende:

    * Firmaene slås sammen.
    * Personer flyttes eller slås sammen.
    * Alle aktiviteter flyttes.
    * Prosjekt medlemskap og medlemskap i statiske utvalg følger firmaet.
    * Alle detaljer slås sammen hvis du har valgt **Erstatt tomme felt i <målfirma> med verdier fra <source company>** 10. I
    * Kildefirmaet slettes.

![Dialogboksen Slå sammen firmaer - skjermbilde][img4]

> [!TIP]Du kan også slå sammen firmaer i dynamiske og statiske utvalg.
> 
## Aktuelle emner

* [Slå sammen personer][2]

<!-- Referenced links -->
[1]: ../../search-options/learn/using-fastsearcher.md
[2]: ../../contact/learn/merge-contacts.md

<!-- Referenced images -->
[img1]: ../../../../common/icons/info-ball.png
[img3]: ../../../media/icons/btn-menu.png
[img4]: media/merge-companies.bmp
