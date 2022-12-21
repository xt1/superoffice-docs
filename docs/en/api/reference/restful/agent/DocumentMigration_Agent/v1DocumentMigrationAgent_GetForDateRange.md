---
title: POST Agents/DocumentMigration/GetForDateRange
uid: v1DocumentMigrationAgent_GetForDateRange
---

# POST Agents/DocumentMigration/GetForDateRange

```http
POST /api/v1/Agents/DocumentMigration/GetForDateRange
```

Gets a migration summary for documents in the provided date-rage




## Online Restricted: ## The DocumentMigration agent is not available in Online by default. Access must be requested specifically when app is registered. Intended for SuperOffice-internal apps.






## Query String Parameters

| Parameter Name | Type |  Description |
|----------------|------|--------------|
| $select | string |  Optional comma separated list of properties to include in the result. Other fields are then nulled out to reduce payload size: "Name,department,category". Default = show all fields. |

```http
POST /api/v1/Agents/DocumentMigration/GetForDateRange?$select=name,department,category/id
```


## Request Headers

| Parameter Name | Description |
|----------------|-------------|
| Authorization  | Supports 'Basic', 'SoTicket' and 'Bearer' schemes, depending on installation type. |
| X-XSRF-TOKEN   | If not using Authorization header, you must provide XSRF value from cookie or hidden input field |
| Content-Type | Content-type of the request body: `application/json`, `text/json`, `application/xml`, `text/xml`, `application/x-www-form-urlencoded`, `application/json-patch+json`, `application/merge-patch+json` |
| Accept         | Content-type(s) you would like the response in: `application/json`, `text/json`, `application/xml`, `text/xml`, `application/json-patch+json`, `application/merge-patch+json` |
| Accept-Language | Convert string references and multi-language values into a specified language (iso2) code. |
| SO-Language | Convert string references and multi-language values into a specified language (iso2) code. Overrides Accept-Language value. |
| SO-Culture | Number, date formatting in a specified culture (iso2 language) code. Partially overrides SO-Language/Accept-Language value. Ignored if no Language set. |
| SO-TimeZone | Specify the timezone code that you would like date/time responses converted to. |
| SO-AppToken | The application token that identifies the partner app. Used when calling Online WebAPI from a server. |

## Request Body: request  

DocumentPluginId, MinDate, MaxDate, IncludeEmails 

| Property Name | Type |  Description |
|----------------|------|--------------|
| DocumentPluginId | int32 |  |
| MinDate | date-time |  |
| MaxDate | date-time |  |
| IncludeEmails | bool |  |


## Response: 

OK

| Response | Description |
|----------------|-------------|
| 200 | OK |

Response body: 

| Property Name | Type |  Description |
|----------------|------|--------------|
| NumDocumentsOmitted | int32 | Total amount of documents within the selection criteria, which has been omitted from the migration. |
| NumDocumentsAlreadyMigrated | int32 | Documents already migrated to the requested documentplugin. |
| Documents | array | List of documents to be migrated. |
| Associates | array | List of associates whose documents will be migrated. |

## Sample request

```http!
POST /api/v1/Agents/DocumentMigration/GetForDateRange
Authorization: Basic dGplMDpUamUw
Accept: application/json; charset=utf-8
Accept-Language: fr,de,ru,zh
Content-Type: application/json; charset=utf-8

{
  "DocumentPluginId": 788,
  "MinDate": "2020-12-15T02:49:44.3566372+01:00",
  "MaxDate": "2007-05-25T02:49:44.3566372+02:00",
  "IncludeEmails": true
}
```

## Sample response

```http_
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8

{
  "NumDocumentsOmitted": 266,
  "NumDocumentsAlreadyMigrated": 606,
  "Documents": [
    {
      "DocumentId": 988,
      "ContactId": 257,
      "PersonId": 668,
      "SaleId": 788,
      "ProjectId": 285,
      "DocTmplId": 401,
      "AssociateId": 400,
      "UserGroupId": 738,
      "VisibleForId": 198
    }
  ],
  "Associates": [
    {
      "AssociateId": 437,
      "EmailAddress": "isai@kovacek.com"
    },
    {
      "AssociateId": 437,
      "EmailAddress": "isai@kovacek.com"
    }
  ]
}
```