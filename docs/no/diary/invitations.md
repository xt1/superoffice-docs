---
title: Invitasjoner
description: Innkalling til møter eller andre avtaler med flere deltakere.
uid: invitations-intro-no
author: Bergfrid Skaara Dias
so.date: 03.18.2022
keywords: diary, calendar, appointment, invitation, meeting, associate, participant
so.topic: concept
---

# Invitasjoner

Når to avtaler har en delt tekstpost og forskjellige statusverdier, kan det kalles en **invitasjon**.

Invitasjoner opprettes **** når du ringer til møter eller andre ordninger mellom ulike medlemmer av et selskap. Møter har  flere **deltakere**: Du inviterer flere medarbeidere eller ressurser til å bli med.

Mens avtaler med eieren pluss en ressurs teknisk sett er bestillinger, definerer vi her et **møte** som:

* 2 eller flere personer
* eventuelt en ressurs

Når vi lagrer avtalen, vil en invitasjon også bli lagt til personen vi inviterte og vil bli vist i dagboken til personen på riktig dato og klokkeslett.  **Dette skjer bare hvis den inviterte personen også er en medarbeider.**  Du kan invitere personer som tilhører andre kontakter også, disse vil ikke ha en dagbok der timen vises, men den vil bli vist i aktivitetsarkivet til kontakten deres i stedet.

> [!NOTE]Ressurser og ikke-brukerpersoner mottar ikke invitasjoner – avtalen opprettes bare som en vanlig avtale for disse deltakerne.
> 
Når en invitasjon er **akseptert**,  vil den vises i brukerens dagbok.

## Relevante statuser

| Status | Beskrivelse |
|:-:|----|
| 5  | Invitasjon (innledende status for en bestilling) |
| 6  | Møtet er flyttet, be om nytt svar |
| 7  | Brukeren har sett, men ikke avslått eller godtatt invitasjonen |
| 8  | Møtet er flyttet. Brukeren har sett, men ikke svart på invitasjonen |
| 9  | Brukeren har avslått møtet |
| 10 | Møtet avlyses |

## Tilgjengelige fremgangsmåter

### Skape

* [Opprette invitasjon – CRMScript][8]
* [Opprette invitasjon – nettjenester][5]
* [Opprette invitasjon – enhet][3]
* [Opprett invitasjon – rå SQL][1]

### Få

* [Få invitasjoner - webtjenester][6]

### Godta

* [Godta invitasjon - CRMScript][9]
* [Godta invitasjon - webtjenester][7]
* [Godta invitasjon – enhet][4]
* [Godta invitasjon - rå SQL][2]

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
