---
title: GET Hierarchy/default
uid: v1HierarchyEntity_DefaultHierarchyEntity
---

# GET Hierarchy/default

```http
GET /api/v1/Hierarchy/default
```

Set default values into a new HierarchyEntity.


NetServer calculates default values on the entity, which is required when creating/storing a new instance Calls the List agent service CreateDefaultHierarchyEntity.







## Request Headers

| Parameter Name | Description |
|----------------|-------------|
| Authorization  | Supports 'Basic', 'SoTicket' and 'Bearer' schemes, depending on installation type. |
| X-XSRF-TOKEN   | If not using Authorization header, you must provide XSRF value from cookie or hidden input field |
| Accept         | Content-type(s) you would like the response in: `application/json`, `text/json`, `application/xml`, `text/xml`, `application/json-patch+json`, `application/merge-patch+json` |
| Accept-Language | Convert string references and multi-language values into a specified language (iso2) code. |
| SO-Language | Convert string references and multi-language values into a specified language (iso2) code. Overrides Accept-Language value. |
| SO-Culture | Number, date formatting in a specified culture (iso2 language) code. Partially overrides SO-Language/Accept-Language value. Ignored if no Language set. |
| SO-TimeZone | Specify the timezone code that you would like date/time responses converted to. |
| SO-AppToken | The application token that identifies the partner app. Used when calling Online WebAPI from a server. |


## Response: 

OK

| Response | Description |
|----------------|-------------|
| 200 | OK |

Response body: 

| Property Name | Type |  Description |
|----------------|------|--------------|
| HierarchyId | int32 | The primary key (auto-incremented) |
| Domain | string | Domain seperating the different hierarchy |
| Name | string | Name of this hierarchy folder. |
| Fullname | string | The full name of this category, i.e. Foo/bar/test. |
| ParentId | int32 | Parent table |
| Children | array | Sub-items, if any. |
| Registered | date-time | Registered when  in UTC. |
| RegisteredAssociateId | int32 | Registered by whom |
| Updated | date-time | Last updated when  in UTC. |
| UpdatedAssociateId | int32 | Last updated by whom |
| TableRight |  |  |
| FieldProperties | object |  |

## Sample request

```http!
GET /api/v1/Hierarchy/default
Authorization: Basic dGplMDpUamUw
Accept: application/json; charset=utf-8
Accept-Language: sv
```

## Sample response

```http_
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8

{
  "HierarchyId": 777,
  "Domain": "Dashboards",
  "Name": "Kiehn, Greenholt and Tillman",
  "Fullname": "laborum",
  "ParentId": 545,
  "Children": [
    {
      "HierarchyId": 14,
      "Domain": "Dashboards",
      "Name": "Hilpert, Barton and Walsh",
      "Fullname": "aut",
      "ParentId": 185,
      "Children": [
        {},
        {}
      ],
      "Registered": "2017-03-31T02:49:50.9952888+02:00",
      "RegisteredAssociateId": 224,
      "Updated": "2018-02-09T02:49:50.9952888+01:00",
      "UpdatedAssociateId": 730,
      "TableRight": null,
      "FieldProperties": {
        "fieldName": {
          "FieldRight": null,
          "FieldType": "System.String",
          "FieldLength": 997
        }
      }
    }
  ],
  "Registered": "2002-02-05T02:49:50.9952888+01:00",
  "RegisteredAssociateId": 650,
  "Updated": "2009-07-10T02:49:50.9952888+02:00",
  "UpdatedAssociateId": 541,
  "TableRight": null,
  "FieldProperties": {
    "fieldName": {
      "FieldRight": null,
      "FieldType": "System.String",
      "FieldLength": 844
    }
  }
}
```