---
title: Slå sammen selskaper
description: Slå sammen selskaper
uid: help-no-company-merge
author: SuperOffice RnD
so.date: 06.29.2022
keywords: company
so.topic: help
language: no
---

# Slå sammen selskaper

[!include[ Krav](../../learn/includes/note-req-manage-entities.md)]

Du kan flette like databaseposter for firmaer. Personer og aktiviteter flyttes til målselskapet, og kildeselskapet slettes.

**Trinn:**

[!include [Gå til selskapet](../../learn/includes/goto-company.md)]

1. Velg **Administrer selskaper ** fra ![ikon][img3] **** Oppgave-knappen, og klikk Slå **sammen selskaper**.
    Dialogboksen **Slå sammen selskaper** åpnes. Kildeselskapet er spesifisert under **Fra**.

1. Under **Til selskap** velger du firmaet du vil oppdatere med informasjon fra kildeselskapet. Begynn å skrive i feltet til [Søk etter et selskap][1].

    > [!TIP]
    > Hvis du vil bytte **Fra** og **Til** selskaper, klikker du på ![ikon][img1] knappen.

1. Under **Personer og firmadetaljer **kan du velge mellom:

    * Slå sammen identiske kontakter. Hvis dette alternativet er valgt, slås kontakter med identiske navn sammen.

        > [!NOTE]Navnene må være NØYAKTIG de samme, fornavn, mellomnavn og etternavn, for å bli slått sammen.
        > 
    * **Erstatt tomme felt i \[målfirma\] med verdier fra \[kildefirma\]**. Hvis dette alternativet er valgt, oppdateres tomme datafelt i **Til-firmaet**** med data  fra ** fra-selskapet.

    [!include [Forhåndsvis resultater](../../learn/includes/note-preview-results.md)]

1. Klikk Slå **sammen**. Følgende skjer da:

    * Selskapene slås sammen.
    * Personer flyttes eller slås sammen.
    * Alle aktiviteter flyttes.
    * Prosjekt medlemskap og medlemskap i statiske utvalg følger selskapet.
    * Alle detaljer slås sammen hvis du valgte **Erstatt tomme felt i <målfirma> med verdier fra <kildefirma> **.
    * Kildeselskapet slettes.

![Slå sammen selskaper dialog -skjermbilde][img4]

> [!TIP]Du kan også slå sammen selskaper i dynamiske og statiske valg.
> 
## Beslektede emner

* [Slå sammen kontakter][2]

<!-- Referenced links -->
[1]: ../../search-options/learn/using-fastsearcher.md
[2]: ../../contact/learn/merge-contacts.md

<!-- Referenced images -->
[img1]: ../../../../common/icons/info-ball.png
[img3]: ../../../media/icons/btn-menu.png
[img4]: media/merge-companies.bmp
