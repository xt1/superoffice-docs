---
title: POST List/{id}/Headings
uid: v1ListItemEntity_SaveHeadingFromListDefinition
---

# POST List/{id}/Headings

```http
POST /api/v1/List/{id}/Headings
```

Save new heading for list resolved by the provided id.






| Path Part | Type | Description |
|-----------|------|-------------|
| id | int32 | The id of the list to look up. **Required** |



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

## Request Body: entity  

The new heading to save 

| Property Name | Type |  Description |
|----------------|------|--------------|
| HeadingId | int32 | Primary key |
| Name | string | The visible heading |
| Tooltip | string | Tooltip or other description |
| Deleted | bool | True if the heading is marked as deleted |
| Rank | int32 | Rank order |
| UdListDefinitionId | int32 | The id of the list which this heading belongs to |


## Response: 

OK

| Response | Description |
|----------------|-------------|
| 200 | OK |
| 400 | Bad request. Entity to save is not in request body. |

Response body: 

| Property Name | Type |  Description |
|----------------|------|--------------|
| HeadingId | int32 | Primary key |
| Name | string | The visible heading |
| Tooltip | string | Tooltip or other description |
| Deleted | bool | True if the heading is marked as deleted |
| Rank | int32 | Rank order |
| UdListDefinitionId | int32 | The id of the list which this heading belongs to |
| TableRight |  |  |
| FieldProperties | object |  |

## Sample request

```http!
POST /api/v1/List/{id}/Headings
Authorization: Basic dGplMDpUamUw
Accept: application/json; charset=utf-8
Accept-Language: sv
Content-Type: application/json; charset=utf-8

{
  "HeadingId": 680,
  "Name": "Berge, Wisozk and Smitham",
  "Tooltip": "quos",
  "Deleted": false,
  "Rank": 821,
  "UdListDefinitionId": 800
}
```

## Sample response

```http_
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8

{
  "HeadingId": 763,
  "Name": "Friesen, Eichmann and Koepp",
  "Tooltip": "ex",
  "Deleted": true,
  "Rank": 588,
  "UdListDefinitionId": 196,
  "TableRight": null,
  "FieldProperties": {
    "fieldName": {
      "FieldRight": null,
      "FieldType": "System.Int32",
      "FieldLength": 940
    }
  }
}
```