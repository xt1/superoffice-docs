---
title: Legg til deltakere i oppfølginger
description: Legg til deltakere i oppfølginger
uid: help-no-invitation-add-participant
author: SuperOffice RnD
so.date: 06.29.2022
keywords: CRM
so.topic: help
language: no
---

# Legge til deltakere og ressurser i oppfølginger

Når du oppretter en oppfølging som angår andre personer, kan du legge dem til som deltakere i oppfølgingen. Du kan også bestille organisasjonens konferanserom og utstyr. Personer som er tilgjengelige som deltakere, defineres i SuperOffice Innstillinger og vedlikehold.

1. Åpne dialogboksen **Avtale**, **Oppgave** eller **Samtale** og [Skriv inn den nødvendige informasjonen][2].

2. **Åpne **** Deltakere-fanen og klikk på ** Legg til  nederst til venstre i vinduet. **Dialogboksen Invitasjon** åpnes.

    > [!NOTE]
    > Hvis du har oversiktene over andre brukere eller ressurser åpne, angis de automatisk som deltakere i Deltakere-fanen**. Ellers ** velger du dem manuelt som beskrevet nedenfor.

3. I **** Velg fra-feltet velger du hvor du vil hente deltakerne fra. Velg mellom **Medarbeidere**, Firma/kontakt**, **Prosjekt**, **Utvalg** og **Ressurs**.** 

4. I listen rett under **** Velg fra-feltet velger du brukergruppen, firmaet, kontakten, prosjektet, utvalget eller ressursen du vil hente deltakerne fra. Innholdet i denne listen vil variere avhengig av hva du valgte ovenfor.
    * Hvis du valgte **Medarbeidere** eller Ressurs** i  trinn 3, kan du velge **Alle i ** listen for å vise tilknyttede personer eller ressurser i alle grupper.** 
    * Hvis du valgte **Firma/kontakt, **Prosjekt**  eller **Utvalg** i trinn 3, kan du søke etter ønsket firma, kontakt, prosjekt eller utvalg fra dette feltet.** 

5. Når du har valgt ønsket kilde, vises en liste over alle tilgjengelige oppføringer for denne kilden. Velg brukerne eller ressursene som skal inkluderes i oppfølgingen, og klikk pilknappen til høyre for listen ( ![ikon][img2] ). De vises deretter på høyre side av vinduet. Du kan også velge brukere og ressurser enkeltvis ved å dobbeltklikke på dem.

    > [!NOTE]Hvis noen av personene er opptatt på det tidspunktet du spesifiserte, vises navnet deres i rødt, slik at du enkelt kan se om du bør finne et annet tidspunkt for oppfølgingen. Du kan fortsatt invitere dem til denne nye avtalen, og oppføringen deres vil da vises i rødt med ordet "KONFLIKT" i dialogboksen for oppfølging.
    > 
6. Klikk knappen ** Send e-postinvitasjon for å aktivere e-postinvitasjoner** for alle deltakerne i listen (unntatt deg selv). Ikonet  til ![ikon][img1] venstre for deltakerens navn betyr at en e-postinvitasjon til oppfølgingen vil bli sendt til denne deltakeren. Klikk  på ![ikon][img1] ikonet ved siden av navnet på en deltaker for å deaktivere e-postinvitasjonen for denne deltakeren. Ikonet ![ikon][img1] endres til inaktiv ( ![ikon][img3] ) og deltakeren vil da ikke motta en invitasjon via e-post.

7. Klikk **OK** for å lukke **dialogboksen Invitasjon**. De valgte deltakerne og ressursene vil nå være synlige i Deltakere-fanen **** . Du kan klikke på**E-postinvitasjon-knappen** og ![ikon][img1] ikonet for å aktivere/deaktivere e-postinvitasjoner, på samme måte som forrige trinn.
    Hvis noen av kontaktene du valgte, ikke har en gyldig e-postadresse registrert i SuperOffice CRM, ![ikon][img1] endres ikonet til inaktiv ( ![ikon][img3] ) i **kategorien Deltakere**.

    > [!NOTE]
    > Hvis du valgte brukere eller ressurser ved en feiltakelse, fjerner du dem ved å velge dem i listen til høyre og klikke **Slett-knappen** .

8. Når du har valgt deltakere og ressurser, klikker du på **Lagre** for å  lagre valgene eller **Avbryt** for å gå ut av dialogboksen uten å lagre.

## Feilsøking

### Hvorfor skjer det ingenting når jeg klikker på E-postinvitasjon?

Hvis kontakten du valgte, ikke har en gyldig e-postadresse registrert i SuperOffice CRM, vil ingenting skje når du klikker på **E-postinvitasjon**.

### Hvorfor er knappen E-postinvitasjon deaktivert?

Bruke SuperOffice Innboks: Hvis du ikke har angitt den nødvendige informasjonen  i ** påloggingsskjermen, som vises første gang du klikker på **Innboks-knappen** i SuperOffice CRM, ** deaktiveres **knappen E-postinvitasjon**.

### Hvordan angir jeg at en ekstern kontakt har godtatt eller avslått invitasjonen?

Eksterne deltakere blir varslet via e-post (hvis du valgte dette alternativet i invitasjonsdialogen). E-postinvitasjoner som sendes til eksterne kontakter, inneholder en iCal-fil (.ics) med invitasjonsdataene. Når de svarer på invitasjonen din, blir den [status][1] automatisk oppdatert i SuperOffice.

Hvis du vil godta eller avslå en invitasjon manuelt på vegne av noen, velger du navnet i listen og klikker knappen **Veksle status** én gang for å sette inn en  grønn hake for å vise at invitasjonen ble godtatt, eller klikk to ganger for å sette inn et rødt kryss for en avslått invitasjon.

<!-- Referenced links -->
[1]: index.md#status
[2]: ../screen/dialog-for-followups.md

<!-- Referenced images -->
[img1]: ../../../../../common/icons/pref-email.png
[img2]: ../../../../media/icons/arrow-right.png
[img3]: ../../../../media/icons/email-inactive.bmp
