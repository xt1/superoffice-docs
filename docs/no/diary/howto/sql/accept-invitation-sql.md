---
title: Godta invitasjon
description: Hvordan godta en invitasjon til en avtale ved hjelp av rå SQL.
uid: accept_invitation_sql-no
author: Bergfrid Skaara Dias
so.date: 03.02.2022
keywords: diary, calendar, appointment, API, invitation
so.topic: howto
---

# Godta invitasjon

Å godta en invitasjon innebærer å endre typen avtale.

Her er Ingrid Istad i ferd med å takke ja til en invitasjon til time fra Frode Freestad.

En invitasjon har type = 6 (bestilling i dagbok) og status = 6 eller 7 (ikkeSett og sett).

Her er hva som skjer når  du klikker på **GODTA-knappen**:

<!-- markdownlint-disable MD013 -->
## Oppdatere invitasjonsavtale

```SQL
UPDATE CRM."appointment" SET "appointment_id" = 740, "contact_id" = 13, "person_id" = 42, "associate_id" = 10, "group_idx" = 5, 
"registered" = 1164896595, "registered_associate_id" = 7, "done" = 0, "do_by" = 1164888900, "leadtime" = 0, "task_idx" = 8, 
"priority_idx" = 0, **"type" = 1, "status" = 1,** 
"private" = 0, "alarm" = 0, "text_id" = 389, "project_id" = 0, "mother_id" = 739, "document_id" = 0, 
"color_index" = 0, "opportunity_id" = 0, "invitedPersonId" = 18, "activeDate" = 1164888900, "endDate" = 1164894300, 
"lagTime" = 0, "source" = 0, "userdef_id" = 0, "userdef2_id" = 0, "updated" = 1164904435, "updated_associate_id" = 10, 
"updatedCount" = 2, "activeLinks" = 0, "recurrenceRuleId" = 0, "location" = '', "alldayEvent" = 0, 
"freeBusy" = 0, "rejectCounter" = 0, "emailId" = 0, "rejectReason" = '', "hasAlarm" = 0, "assignedBy" = 0 
WHERE "appointment_id" = 740

INSERT INTO CRM."traveltransactionlog" 
("traveltransactionlog_id", "ttime", "prev_record_id", "type", "associate_id", "tablenumber", "record_id") 
VALUES (110522, 1164908036, 0, 4608, 10, 9, 740)
```

## Oppdater SAINT tellere for kontakten

```SQL
UPDATE CRM."countervalue" SET "CounterValue_id" = 16402, "contact_id" = 13, "person_id" = 0, "project_id" = 0, 
"extra1_id" = 0, "extra2_id" = 0, "record_type" = 1, "direction" = 3, "intent_id" = 0, "sale_status" = 0, "amountClassId" = 0, 
"totalReg" = 1, "totalRegInPeriod" = 1, "notCompleted" = 1, "notCompletedInPeriod" = 1, "lastRegistered" = 1164888900, "lastCompleted" = 0, "lastDoBy" = 1164888900, 
"extra1_count" = 0, "extra2_count" = 0, "extra3_count" = 0, "extra4_count" = 0, 
"registered" = 0, "registered_associate_id" = 0, "updated" = 1164904436, "updated_associate_id" = 10, "updatedCount" = 0 WHERE "CounterValue_id" = 16402

UPDATE CRM."countervalue" SET "CounterValue_id" = 16406, "contact_id" = 13, "person_id" = 0, "project_id" = 0, "extra1_id" = 0, "extra2_id" = 0, "record_type" = 1, "direction" = 3, "intent_id" = 5, "sale_status" = 0, "amountClassId" = 0, "totalReg" = 1, "totalRegInPeriod" = 1, "notCompleted" = 1, "notCompletedInPeriod" = 1, "lastRegistered" = 1164888900, "lastCompleted" = 0, "lastDoBy" = 1164888900, "extra1_count" = 0, "extra2_count" = 0, "extra3_count" = 0, "extra4_count" = 0, "registered" = 0, "registered_associate_id" = 0, "updated" = 1164904436, "updated_associate_id" = 10, "updatedCount" = 0 WHERE "CounterValue_id" = 16406

UPDATE CRM."countervalue" SET "CounterValue_id" = 16591, "contact_id" = 13, "person_id" = 0, "project_id" = 0, "extra1_id" = 0, "extra2_id" = 0, "record_type" = 10, "direction" = 3, "intent_id" = 0, "sale_status" = 0, "amountClassId" = 0, "totalReg" = 1, "totalRegInPeriod" = 1, "notCompleted" = 1, "notCompletedInPeriod" = 1, "lastRegistered" = 1164888900, "lastCompleted" = 0, "lastDoBy" = 1164888900, "extra1_count" = 0, "extra2_count" = 0, "extra3_count" = 0, "extra4_count" = 0, "registered" = 0, "registered_associate_id" = 0, "updated" = 1164904436, "updated_associate_id" = 10, "updatedCount" = 0 WHERE "CounterValue_id" = 16591

UPDATE CRM."countervalue" SET "CounterValue_id" = 16595, "contact_id" = 13, "person_id" = 0, "project_id" = 0, "extra1_id" = 0, "extra2_id" = 0, "record_type" = 10, "direction" = 3, "intent_id" = 5, "sale_status" = 0, "amountClassId" = 0, "totalReg" = 1, "totalRegInPeriod" = 1, "notCompleted" = 1, "notCompletedInPeriod" = 1, "lastRegistered" = 1164888900, "lastCompleted" = 0, "lastDoBy" = 1164888900, "extra1_count" = 0, "extra2_count" = 0, "extra3_count" = 0, "extra4_count" = 0, "registered" = 0, "registered_associate_id" = 0, "updated" = 1164904436, "updated_associate_id" = 10, "updatedCount" = 0 WHERE "CounterValue_id" = 16595
```

## Les også

* [Avtale tabell][1]
* [Invitasjoner][2]

<!-- Referenced links -->
[1]: ../../../database/tables/appointment.md
[2]: ../../invitations.md

<!-- Referenced images -->
