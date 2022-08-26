---
title: POST Agents/CustomerService/GetPreviewReplyTemplate
uid: v1CustomerServiceAgent_GetPreviewReplyTemplate
---

# POST Agents/CustomerService/GetPreviewReplyTemplate

```http
POST /api/v1/Agents/CustomerService/GetPreviewReplyTemplate
```

Get a reply template from its reply template id







## Query String Parameters

| Parameter Name | Type |  Description |
|----------------|------|--------------|
| $select | string |  Optional comma separated list of properties to include in the result. Other fields are then nulled out to reduce payload size: "Name,department,category". Default = show all fields. |

```http
POST /api/v1/Agents/CustomerService/GetPreviewReplyTemplate?$select=name,department,category/id
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

ReplyTemplateId 

| Property Name | Type |  Description |
|----------------|------|--------------|
| ReplyTemplateId | int32 |  |


## Response: 

OK

| Response | Description |
|----------------|-------------|
| 200 | OK |

Response body: 

| Property Name | Type |  Description |
|----------------|------|--------------|
| Name | string | The name for this reply template. |
| Description | string | The description for this reply template. |
| OwnedByFullName | string | Full name of the associate that owns this reply template |
| Updated | date-time | Date/time this reply template was last updated. |
| Body | string | Reply template body in the best available format. |
| IsHtml | bool | If true, body is HTML. |
| TableRight |  |  |
| FieldProperties | object |  |

## Sample request

```http!
POST /api/v1/Agents/CustomerService/GetPreviewReplyTemplate
Authorization: Basic dGplMDpUamUw
Accept: application/json; charset=utf-8
Accept-Language: en
Content-Type: application/json; charset=utf-8

{
  "ReplyTemplateId": 801
}
```

## Sample response

```http_
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8

{
  "Name": "Bosco, Gottlieb and Dibbert",
  "Description": "Multi-tiered responsive throughput",
  "OwnedByFullName": "Arvilla D'Amore",
  "Updated": "2008-10-23T11:10:26.4034227+02:00",
  "Body": "eius",
  "IsHtml": false,
  "TableRight": null,
  "FieldProperties": {
    "fieldName": {
      "FieldRight": null,
      "FieldType": "System.Int32",
      "FieldLength": 892
    }
  }
}
```