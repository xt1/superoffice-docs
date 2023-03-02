---
uid: AppointmentNotificationAggregator
title: AppointmentNotificationAggregator
description: Aggregates all subproviders, doing some work on linkhints.
keywords:
  - "archive"
  - "provider"
  - "archive provider"
  - "AppointmentNotificationAggregator"
so.generated: true
so.date: 02.15.2023
so.topic: reference
so.envir:
  - "onsite"
  - "online"
---

# "AppointmentNotificationAggregator"

This provider name is implemented by the class <see cref="T:SuperOffice.CRM.ArchiveLists.AppointmentNotificationAggregatorProvider">SuperOffice.CRM.ArchiveLists.AppointmentNotificationAggregatorProvider</see> inside NetServer's SODatabase assembly.

Aggregates all subproviders, doing some work on linkhints.

## Supported Entities
| Name | Description |
| ---- | ----- |
|"appointmentNew"|Appointment|
|"appointmentUpdated"|Appointment|
|"appointmentCancelled"|Appointment|
|"appointmentAccepted"|Appointment|
|"appointmentRejected"|Appointment|

## Supported Columns
| Name | Restriction | Description | OrderBy
| ---- | ----- | ------- | ------ |
|getAllRows|bool|GetAll: Get all rows of archive - use with care, you may be fetching the whole database|  |
|getNoRows|bool|GetNone: Do not get any rows from the archive|  |
|id| *None* |!!id| x |
|associateId|associate|Associate: SR\_SINGULAR\_ASSOCIATE\_TOOLTIP| x |
|originatorFullName|associate|!!originatorFullName - Full name: !!originatorFullName| x |
|receiverFullName|associate|!!receiverFullName - Full name: !!receiverFullName| x |
|notifyDateTime|datetime|!!notifyDateTime| x |
|title| *None* |!!title|  |
|updateType| *None* |!!updateType|  |
|startDateTime| *None* |!!startDateTime| x |
|endDateTime| *None* |!!endDateTime|  |
|location| *None* |!!location|  |
|isRecurring| *None* |!!isRecurring|  |
|isEmailInvitation| *None* |!!isEmailInvitation|  |
|isSeen| *None* |!!isSeen|  |
|recurringStartDateTime| *None* |!!recurringStartDate| x |
|recurringEndDateTime| *None* |!!recurringEndDate| x |

## Sample

```http!
GET /api/v1/archive/AppointmentNotificationAggregator?$select=receiverFullName,updateType
Authorization: Basic dGplMDpUamUw
Accept: application/json; charset=utf-8
Accept-Language: sv

```



See also: <see cref="T:SuperOffice.CRM.Services.IArchiveAgent">IArchiveAgent</see>.</p>
