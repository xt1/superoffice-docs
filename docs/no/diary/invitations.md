---
title: Invitasjoner
description: Innkalle til møter eller andre arrangementer med flere deltakere.
keywords: dagbok, kalender, avtale, invitasjon, møte, medarbeider, deltaker
uid: invitations-intro-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
so.topic: concept
---

# Invitasjoner

Når to avtaler har en delt tekstoppføring og ulike statusverdier, kan det kalles en **invitasjon** .

Invitasjoner **opprettes** når du kaller møter eller andre ordninger mellom ulike medlemmer av et firma. Møter har flere **deltakere** : Du inviterer flere medarbeidere eller ressurser til å delta.

Mens avtaler med eieren pluss én ressurs teknisk sett er bestillinger, definerer vi her et **møte** som:

* 2 eller flere personer
* eventuelt en ressurs

Når vi lagrer avtalen, legges det også til en invitasjon til personen vi inviterte, og den vises i dagboken til personen på ønsket dato og klokkeslett.  **Dette skjer bare hvis den inviterte personen også er medarbeider.**  Du kan invitere personer som tilhører andre personer også, disse vil ikke ha en dagbok der avtalen vises, men den vil i stedet vises i aktivitetsarkivet til personen.

> [!NOTE]Ressurser og ikke-brukerpersoner mottar ikke invitasjoner – avtalen opprettes akkurat som en vanlig avtale for disse deltakerne.
> 
Når en invitasjon **godtas** , vises den i brukerens dagbok.

## Relevante statuser

| Status | Beskrivelse |
|:-:|----|
| 5  | Invitasjon (innledende status for bestilling) |
| 6  | Møtet er flyttet, be om nytt svar |
| 7  | Brukeren har sett, men ikke avslått eller godtatt invitasjonen |
| 8  | Møtet er flyttet. Brukeren har sett, men ikke svart på invitasjonen |
| 9  | Brukeren har avslått møtet |
| 10 | Møtet avlyses |

## Tilgjengelige how-tos

### Opprette

* [Opprett invitasjon - CRMScript][8]
* [Opprette invitasjon – webtjenester][5]
* [Opprette invitasjon – enhet][3]
* [Opprette invitasjon – rå SQL][1]

### Få

* [Hent invitasjoner - webtjenester][6]

### Godta

* [Godta invitasjon - CRMScript][9]
* [Godta invitasjon – webtjenester][7]
* [Godta invitasjon – enhet][4]
* [Godta invitasjon – rå SQL][2]

<!-- Referenced links -->
[1]: howto/sql/create-invitation-sql.md
[2]: howto/sql/accept-invitation-sql.md
[3]: howto/entity/create-invitation-entity.md
[4]: howto/entity/accept-invitation-entity.md
[5]: howto/services/create-invitation-services.md
[6]: howto/services/get-invitations-services.md
[7]: howto/services/accept-invitation-services.md
[8]: howto/crmscript/create-invitation.md
[9]: howto/crmscript/accept-invitation.md
