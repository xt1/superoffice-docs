---
title: Legge til deltakere i oppfølginger
description: Legge til deltakere i oppfølginger
keywords: CRM
uid: help-no-invitation-add-participant
author: SuperOffice RnD
so.date: 06.29.2022
so.topic: help
language: no
---

# Legge til deltakere og ressurser i oppfølginger

Når du oppretter en oppfølging som omfatter andre personer, kan du legge dem til som deltakere i oppfølgingen. Du kan også reservere møterom og utstyr i organisasjonen. Hvem som er tilgjengelige som deltakere, defineres i SuperOffice Innstillinger og vedlikehold.

1. Åpne **dialogboksen Avtale** , **Oppgave** eller **Samtale** og [angi ønsket informasjon][2].

2. Åpne fanen **Deltakere,** og klikk  på **Legg til** nederst til venstre i vinduet. Dialogboksen **Invitasjon** vises.

    > [!NOTE]
    > Hvis du har andre brukeres eller ressursers oversikter åpne, legges de automatisk inn som deltakere i fanen **Deltakere** .

3. I feltet **Velg fra** velger du hvor du vil hente deltakerne fra. Velg mellom **Medarbeidere** , **Firma/person** , **Prosjekt** , **Utvalg** og **Ressurs** .

4. I listeboksen like under  feltet **Velg fra** velger du brukergruppen, firmaet, personen, prosjektet, utvalget eller ressursen du vil hente deltakerne fra. Innholdet i denne listeboksen varierer avhengig av hva du valgte ovenfor.
    * Hvis du valgte **Medarbeidere** eller **Ressurs** i trinn 3, kan du velge **Alle** i listeboksen for å vise medarbeiderne eller ressursene i alle gruppene.
    * Hvis du valgte **Firma/person** , **Prosjekt** eller **Utvalg** i trinn 3, kan du søke etter ønsket firma, person, prosjekt eller utvalg fra dette feltet.

5. Når du har valgt ønsket kilde, vises en liste over alle tilgjengelige oppføringer for denne kilden. Merk brukerne eller ressursene du vil inkludere i oppfølgingen, og klikk på pilknappen til høyre for listen ( ![Ikonet][img2] ). De vises da på høyre side av vinduet. Du kan også velge brukere og ressurser enkeltvis ved å dobbeltklikke på dem.

    > [!NOTE]Hvis noen av personene er opptatt på det tidspunktet du har angitt, vises navnet deres med rødt, slik at du enkelt ser om du bør finne et annet tidspunkt for oppfølgingen. Du kan likevel invitere dem til den nye avtalen, og oppføringen deres vil da vises med rødt og ordet "KONFLIKT" i dialogboksen for oppfølginger.
    > 
6. Klikk på  knappen **E-postinvitasjon** for å aktivere e-postinvitasjoner for alle deltakerne i listen (unntatt deg selv). Ikonet ![Ikonet][img1] til venstre for deltakernavnet betyr at en e-postinvitasjon til oppfølgingen vil bli sendt til denne deltakeren. Klikk på ikonet ved ![Ikonet][img1] siden av navnet på en deltaker for å deaktivere e-postinvitasjon for denne deltakeren. Ikonet ![Ikonet][img1] endres til inaktivt ( ![Ikonet][img3] ), og deltakeren vil ikke motta invitasjon via e-post.

7. Klikk  på **OK** for å lukke  dialogboksen **Invitasjon** . De valgte deltakerne og ressursene vil nå være synlige i fanen **Deltakere** . Du kan klikke på knappen **E-postinvitasjon** og ikonet ![Ikonet][img1] for å aktivere/deaktivere e-postinvitasjoner, på samme måte som i forrige trinn.
    Hvis noen av personene du valgte, ikke har en gyldig e-postadresse registrert i SuperOffice CRM, ![Ikonet][img1] endres ikonet til inaktivt ( ![Ikonet][img3] ) i fanen **Deltakere** .

    > [!NOTE]
    > Hvis du valgte brukere eller ressurser ved en feiltakelse, fjerner du dem ved å merke dem i listen til høyre og klikke på **** Slett-knappen.

8. Når du har valgt deltakere og ressurser, klikker du på **Lagre** for å lagre utvalgene dine eller **Avbryt** for å gå ut av dialogboksen uten å lagre.

## Feilsøking

### Hvorfor skjer ingenting når jeg klikker på E-postinvitasjon?

Hvis personen du valgte, ikke har en gyldig e-postadresse registrert i SuperOffice CRM, skjer det ingenting når du klikker **på E-postinvitasjon** .

### Hvorfor er knappen E-postinvitasjon deaktivert?

Bruke SuperOffice Innboks: Hvis du ikke har registrert nødvendig informasjon i  bildet **Logg på** , som vises første gang du klikker **på** Innboks-knappen i SuperOffice CRM, **er knappen E-postinvitasjon** deaktivert.

### Hvordan angir jeg at en ekstern person har godtatt eller avslått invitasjonen?

Eksterne deltakere blir varslet via e-post (hvis du valgte dette alternativet i dialogboksen invitasjon). Invitasjons-e-postmeldinger som sendes til eksterne personer, inneholder en iCal-fil (.ics) med invitasjonsdataene. Når de svarer på invitasjonen din, [Status][1] oppdateres den automatisk i SuperOffice.

Hvis du vil godta eller avslå en invitasjon på vegne av noen, merker du navnet i listen og klikker på Bytt **** status-knappen for å sette inn en grønn hake som viser at invitasjonen ble godtatt, eller klikk to ganger for å sette inn et rødt kryss for en avslått invitasjon.

<!-- Referenced links -->
[1]: index.md#status
[2]: ../screen/dialog-for-followups.md

<!-- Referenced images -->
[img1]: ../../../../../common/icons/pref-email.png
[img2]: ../../../../media/icons/arrow-right.png
[img3]: ../../../../media/icons/email-inactive.bmp
