---
title: Opprett invitasjon
description: Hvordan lage en invitasjon til en avtale ved hjelp av rå SQL.
uid: create_invitation_sql-no
author: Bergfrid Skaara Dias
so.date: 03.02.2022
keywords: diary, calendar, appointment, API, invitation
so.topic: howto
---

# Opprett invitasjon

Invitere en kollega, en ekstern person til et møte i et møterom.

Her oppretter vi fire avtaleoppføringer, én for den som inviterer, én for kollegaen, én for den eksterne personen og én for ressursen.

> [!NOTE]Både den eksterne personen (Frantz) og møterommet (ResourceItem 1) har automatisk godtatt invitasjonen – siden de ikke har SuperOffice pålogging.
> 
Kollegaen (Ingrid Istad) vil få en invitasjonsdialog neste gang hun logger inn - og hun kan da takke ja til invitasjonen.

I dette eksemplet er følgende `associate_id`s nyttige å vite:

| `associate_id` | Associate Type | `person_id` | `contact_id` | navn |
|---|---|---|---|---|
| 7  | 0 | 15 | 2 | Frode Freestad       |
| 10 | 0 | 18 | 2 | Ingrid Istad         |
| 41 | 1 | 0  | 0 | Ressurspost 1      |
| -  | - | 42 | 13| Frantz Feinschmecker |

De neste avsnittene beskriver hva som skjer når LAGRE-knappen **** klikkes.

## Opprett invitasjonsavtale for Ingrid Istad

* Avtalen peker til hovedavtalen ved hjelp av `mother_id` feltet.
* Feltet `invitedPersonId` er satt til medarbeiderens `person_id`.

<!-- markdownlint-disable MD013 -->
```SQL
INSERT INTO CRM."appointment" ("appointment_id", "contact_id", "person_id", "**associate_id**", "group_idx", "registered", "registered_associate_id", "done", "do_by", "leadtime", "task_idx", "priority_idx", "type", "status", "private", "alarm", "text_id", "project_id", "**mother_id**", "document_id", "color_index", "opportunity_id", "**invitedPersonId**", "activeDate", "endDate", "lagTime", "source", "userdef_id", "userdef2_id", "updated", "updated_associate_id", "updatedCount", "activeLinks", "recurrenceRuleId", "location", "alldayEvent", "freeBusy", "rejectCounter", "emailId", "rejectReason", "hasAlarm", "assignedBy") VALUES (740, 13, 42, **10**, 5, 1164896595, 7, 0, 1164888900, 0, 8, 0, 6, 5, 0, 0, 389, 0, **739**, 0, 0, 0, **18**, 1164888900, 1164894300, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', 0, 0, 0, 0, '', 0, 0)

INSERT INTO CRM."traveltransactionlog" ("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") VALUES (110444, 1164900195, 0, 4352, 7, 9, 740)

INSERT INTO CRM."visiblefor" ("VisibleFor_id", "tableId", "recordId", "forAll", "forGroupId", "forAssocId", "encryptedCheck", "registered", "registered_associate_id", "updated", "updated_associate_id", "updatedCount") VALUES (915, 9, 740, 1, 0, 0, 'TU6UOTaVZLKiFhgQyTEIuYatA57qbFEo', 1164896595, 7, 0, 0, 0)

INSERT INTO CRM."traveltransactionlog" ("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") VALUES (110445, 1164900195, 0, 4352, 7, 196, 915)
```

## Opprette invitasjonsavtale for Frantz Feinsmecher

* `associate_id` = 0 siden Frantz ikke er en bruker, men `invited_person_id` = Frantz

```SQL
INSERT INTO CRM."appointment" ("appointment_id", "contact_id", "person_id", "**associate_id**", "group_idx", "registered", "registered_associate_id", "done", "do_by", "leadtime", "task_idx", "priority_idx", "type", "status", "private", "alarm", "text_id", "project_id", "**mother_id**", "document_id", "color_index", "opportunity_id", "**invitedPersonId**", "activeDate", "endDate", "lagTime", "source", "userdef_id", "userdef2_id", "updated", "updated_associate_id", "updatedCount", "activeLinks", "recurrenceRuleId", "location", "alldayEvent", "freeBusy", "rejectCounter", "emailId", "rejectReason", "hasAlarm", "assignedBy") VALUES (741, 13, 42, **0**, 0, 1164896595, 7, 0, 1164888900, 0, 8, 0, 1, 1, 0, 0, 389, 0, **739**, 0, 0, 0, **42**, 1164888900, 1164894300, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', 0, 0, 0, 0, '', 0, 0)

INSERT INTO CRM."traveltransactionlog" ("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") VALUES (110446, 1164900195, 0, 4352, 7, 9, 741)

INSERT INTO CRM."visiblefor" ("VisibleFor_id", "tableId", "recordId", "forAll", "forGroupId", "forAssocId", "encryptedCheck", "registered", "registered_associate_id", "updated", "updated_associate_id", "updatedCount") VALUES (916, 9, 741, 1, 0, 0, 'xt5SMR9bL92iFhgQyTEIuYatA57qbFEo', 1164896595, 7, 0, 0, 0)

INSERT INTO CRM."traveltransactionlog" ("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") VALUES (110447, 1164900195, 0, 4352, 7, 196, 916)
```

## Opprette invitasjonsavtale for ressurselement 1

* Ressursen er en medarbeider uten person, så her = `associate_id` 41, men = `invitedPerson_id` 0

```SQL
INSERT INTO CRM."appointment" ("appointment_id", "contact_id", "person_id", "**associate_id**", "group_idx", "registered", "registered_associate_id", "done", "do_by", "leadtime", "task_idx", "priority_idx", "type", "status", "private", "alarm", "text_id", "project_id", "**mother_id**", "document_id", "color_index", "opportunity_id", "**invitedPersonId**", "activeDate", "endDate", "lagTime", "source", "userdef_id", "userdef2_id", "updated", "updated_associate_id", "updatedCount", "activeLinks", "recurrenceRuleId", "location", "alldayEvent", "freeBusy", "rejectCounter", "emailId", "rejectReason", "hasAlarm", "assignedBy") VALUES (742, 13, 42, **41**, 4, 1164896595, 7, 0, 1164888900, 0, 8, 0, 1, 1, 0, 0, 389, 0, **739**, 0, 0, 0, **0**, 1164888900, 1164894300, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', 0, 0, 0, 0, '', 0, 0)

INSERT INTO CRM."traveltransactionlog" ("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") VALUES (110448, 1164900195, 0, 4352, 7, 9, 742)

INSERT INTO CRM."visiblefor" ("VisibleFor_id", "tableId", "recordId", "forAll", "forGroupId", "forAssocId", "encryptedCheck", "registered", "registered_associate_id", "updated", "updated_associate_id", "updatedCount") VALUES (917, 9, 742, 1, 0, 0, '0/BOOig87Y+iFhgQyTEIuYatA57qbFEo', 1164896595, 7, 0, 0, 0)

INSERT INTO CRM."traveltransactionlog" ("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") VALUES (110449, 1164900195, 0, 4352, 7, 196, 917)
```

## Opprette masteravtale for Frode Freestad

* Hovedavtalen er gjenkjennelig med `appointment_id` = `mother_id`

```SQL
INSERT INTO CRM."appointment" ("appointment_id", "contact_id", "person_id", "associate_id", "group_idx", "registered", "registered_associate_id", "done", "do_by", "leadtime", "task_idx", "priority_idx", "type", "status", "private", "alarm", "text_id", "project_id", "mother_id", "document_id", "color_index", "opportunity_id", "invitedPersonId", "activeDate", "endDate", "lagTime", "source", "userdef_id", "userdef2_id", "updated", "updated_associate_id", "updatedCount", "activeLinks", "recurrenceRuleId", "location", "alldayEvent", "freeBusy", "rejectCounter", "emailId", "rejectReason", "hasAlarm", "assignedBy") VALUES (739, 13, 42, 7, 4, 1164896595, 7, 0, 1164888900, 0, 8, 0, 1, 1, 0, 0, 389, 0, 739, 0, 0, 0, 15, 1164888900, 1164894300, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', 0, 0, 0, 0, '', 0, 0)

INSERT INTO CRM."traveltransactionlog" ("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") VALUES (110450, 1164900195, 0, 4352, 7, 9, 739)

INSERT INTO CRM."visiblefor" ("VisibleFor_id", "tableId", "recordId", "forAll", "forGroupId", "forAssocId", "encryptedCheck", "registered", "registered_associate_id", "updated", "updated_associate_id", "updatedCount") VALUES (918, 9, 739, 1, 0, 0, 'BDTWlNDVe6qiFhgQyTEIuYatA57qbFEo', 1164896596, 7, 0, 0, 0)

INSERT INTO CRM."traveltransactionlog" ("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") VALUES (110452, 1164900196, 0, 4352, 7, 196, 918)
```

> [!NOTE]Den samme tekstoppføringen deles mellom alle avtalene.
> 
```SQL
INSERT INTO CRM."text" ("text_id", "type", "owner_id", "registered", "registered_associate_id", "updated", "updated_associate_id", "updatedCount", "text", "lcid", "seqno") VALUES (389, 4, 739, 1164896596, 7, 0, 0, 0, 'Lunch meeting', 1044, 0)

INSERT INTO CRM."traveltransactionlog" ("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") VALUES (110451, 1164900196, 0, 4352, 7, 18, 389)
```

Nå legger vi til ordene i tekstposten til fritekstindeksen:

```SQL
DELETE FROM CRM."freetextindex" WHERE "table_id" = 18 AND "record_id" = 389

INSERT INTO CRM."freetextwords" ("freetextwords_id", "word") VALUES (2086811941, 'LUNCH')

INSERT INTO CRM."freetextwords" ("freetextwords_id", "word") VALUES (535965901, 'MEETING')

INSERT INTO CRM."freetextindex" ("freetextindex_id", "freetextwords_id", "table_id", "record_id", "ownertable_id", "ownerrecord_id", "infile") VALUES (790392919, 2086811941, 18, 389, 9, 739, 0)

INSERT INTO CRM."freetextindex" ("freetextindex_id", "freetextwords_id", "table_id", "record_id", "ownertable_id", "ownerrecord_id", "infile") VALUES (1431706010, 535965901, 18, 389, 9, 739, 0)
```

## Oppdater SAINT tellere for "Fritz & Frantz Import"

```SQL
UPDATE CRM."countervalue" SET "CounterValue_id" = 16402, "contact_id" = 13, "person_id" = 0, "project_id" = 0, "extra1_id" = 0, "extra2_id" = 0, "record_type" = 1, "direction" = 3, "intent_id" = 0, "sale_status" = 0, "amountClassId" = 0, "totalReg" = 1, "totalRegInPeriod" = 1, "notCompleted" = 1, "notCompletedInPeriod" = 1, "lastRegistered" = 1164888900, "lastCompleted" = 0, "lastDoBy" = 1164888900, "extra1_count" = 0, "extra2_count" = 0, "extra3_count" = 0, "extra4_count" = 0, "registered" = 0, "registered_associate_id" = 0, "updated" = 1164896596, "updated_associate_id" = 7, "updatedCount" = 0 WHERE "CounterValue_id" = 16402

UPDATE CRM."countervalue" SET "CounterValue_id" = 16406, "contact_id" = 13, "person_id" = 0, "project_id" = 0, "extra1_id" = 0, "extra2_id" = 0, "record_type" = 1, "direction" = 3, "intent_id" = 5, "sale_status" = 0, "amountClassId" = 0, "totalReg" = 1, "totalRegInPeriod" = 1, "notCompleted" = 1, "notCompletedInPeriod" = 1, "lastRegistered" = 1164888900, "lastCompleted" = 0, "lastDoBy" = 1164888900, "extra1_count" = 0, "extra2_count" = 0, "extra3_count" = 0, "extra4_count" = 0, "registered" = 0, "registered_associate_id" = 0, "updated" = 1164896596, "updated_associate_id" = 7, "updatedCount" = 0 WHERE "CounterValue_id" = 16406

UPDATE CRM."countervalue" SET "CounterValue_id" = 16591, "contact_id" = 13, "person_id" = 0, "project_id" = 0, "extra1_id" = 0, "extra2_id" = 0, "record_type" = 10, "direction" = 3, "intent_id" = 0, "sale_status" = 0, "amountClassId" = 0, "totalReg" = 1, "totalRegInPeriod" = 1, "notCompleted" = 1, "notCompletedInPeriod" = 1, "lastRegistered" = 1164888900, "lastCompleted" = 0, "lastDoBy" = 1164888900, "extra1_count" = 0, "extra2_count" = 0, "extra3_count" = 0, "extra4_count" = 0, "registered" = 0, "registered_associate_id" = 0, "updated" = 1164896596, "updated_associate_id" = 7, "updatedCount" = 0 WHERE "CounterValue_id" = 16591

UPDATE CRM."countervalue" SET "CounterValue_id" = 16595, "contact_id" = 13, "person_id" = 0, "project_id" = 0, "extra1_id" = 0, "extra2_id" = 0, "record_type" = 10, "direction" = 3, "intent_id" = 5, "sale_status" = 0, "amountClassId" = 0, "totalReg" = 1, "totalRegInPeriod" = 1, "notCompleted" = 1, "notCompletedInPeriod" = 1, "lastRegistered" = 1164888900, "lastCompleted" = 0, "lastDoBy" = 1164888900, "extra1_count" = 0, "extra2_count" = 0, "extra3_count" = 0, "extra4_count" = 0, "registered" = 0, "registered_associate_id" = 0, "updated" = 1164896596, "updated_associate_id" = 7, "updatedCount" = 0 WHERE "CounterValue_id" = 16595
```

## Les også

* [Avtale tabell][1]
* [Invitasjoner][2]

<!-- Referenced links -->
[1]: ../../../database/tables/appointment.md
[2]: ../../invitations.md

<!-- Referenced images -->
