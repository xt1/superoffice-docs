---
title: POST Agents/UserDefinedFieldInfo/SetListTableIdAndUDListDefinitionIdFromSelectedListId
id: v1UserDefinedFieldInfoAgent_SetListTableIdAndUDListDefinitionIdFromSelectedListId
---

# POST Agents/UserDefinedFieldInfo/SetListTableIdAndUDListDefinitionIdFromSelectedListId

```http
POST /api/v1/Agents/UserDefinedFieldInfo/SetListTableIdAndUDListDefinitionIdFromSelectedListId
```

Make stuff similar to what happens in the win client







## Query String Parameters

| Parameter Name | Type |  Description |
|----------------|------|--------------|
| $select | string |  Optional comma separated list of properties to include in the result. Other fields are then nulled out to reduce payload size: "Name,department,category". Default = show all fields. |

```http
POST /api/v1/Agents/UserDefinedFieldInfo/SetListTableIdAndUDListDefinitionIdFromSelectedListId?$select=name,department,category/id
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

Info, SelectedListId 

| Property Name | Type |  Description |
|----------------|------|--------------|
| Info |  | Return information about the user defined fields. The information can be used to mirror the layout of the user-defined fields in the user interface. <para /> Carrier object for UserDefinedFieldInfo. Services for the UserDefinedFieldInfo Carrier is available from the <see cref="T:SuperOffice.CRM.Services.IUserDefinedFieldInfoAgent">UserDefinedFieldInfo Agent</see>. |
| SelectedListId | int32 |  |


## Response: object

Return information about the user defined fields. The information can be used to mirror the layout of the user-defined fields in the user interface.



Carrier object for UserDefinedFieldInfo.
Services for the UserDefinedFieldInfo Carrier is available from the <see cref="T:SuperOffice.CRM.Services.IUserDefinedFieldInfoAgent">UserDefinedFieldInfo Agent</see>.

| Response | Description |
|----------------|-------------|
| 200 | OK |

Response body: object

| Property Name | Type |  Description |
|----------------|------|--------------|
| UDefFieldId | int32 | Primary key |
| ColumnId | int32 | The ID of the database column this field corresponds to |
| FieldDefault | string | Optional default value for String fields |
| FieldHeight | int32 | field height in pixels, 0 = 'enough' (from font) |
| FieldLabel | string | The label (lead text) |
| FieldLeft | int32 | X pixel coordinate of field |
| FieldTop | int32 | Y pixel coordinate of field |
| FieldType | string | Field type: 0 = leadtext only, 1 = Edit, 2 = CheckBox, 3 = dropdown, 4 = listbox |
| FieldWidth | int32 | field width in pixels, 0 = 'enough' (from font) |
| FormatMask | string | Formatting mask, can be whatever the controls understand (currently nothing :-)) |
| HideLabel | bool | Hide the label if 1 |
| IsIndexed | bool | Is this field indexed? 0 if no, index no. if yes |
| LabelHeight | int32 | label height in pixels, 0 = 'enough' (from font) |
| LabelLeft | int32 | X pixel coordinate of label |
| LabelTop | int32 | Y pixel coordinate of label |
| LabelWidth | int32 | label width in pixels, 0 = 'enough' (from font) |
| LastVersionId | int32 | UDefFieldId this field had in the previous version, 0 = field is new in this version |
| ListTableId | int32 | The table ID of the source table for lists: kTableAssoc, kTableContInt or whatever |
| IsMandatory | bool | 0 = no, 1 = yes (field must be filled out) |
| Type | string | ID of owning table (contact, person, project) - this is not the actual tableNumber, rather it's an enum |
| Page1LineNo | int32 | Line no on View Page 1, used if MDO flags are OFF. 0 = this field is not visible on page 1 |
| ProgId | string | Programmatic ID, for use by software that needs to find a particular field. Carried over like udefIdentity across generations. Use a Company.Product.Field format to avoid naming conflicts; the Company name SuperOffice is reserved. |
| IsReadOnly | bool | 0 = read/write, 1 = readonly (don't combine with mandatory  8-) ) |
| ShortLabel | string | Short name to be used in Archive headings and on page 1. If blank, the fieldLabel will be used everywhere. |
| TabOrder | int32 | Tab order value, sets the field processing sequence |
| TextLength | int32 | Length (in characters) of a text field, 0 for other types |
| Tooltip | string | Optional tooltip text for this field |
| UdefIdentity | int32 | Unique number used to track field identity across layout changes |
| UDListDefinitionId | int32 | List to use for populating dropdown or listbox |
| Justification | string | Justification - 0 = default, left, right, center |
| Version | int32 | Definition version number; ALL fields get new version whenever layout is updated. |
| TemplateVariableName | string | Template variable name |
| HasBeenPublished | bool | Has the udef field been published? |
| MdoListName | string | MDO list name used to populate this list. Derived from UDListDefinitionId and ListTableId. (Read-only) |
| TableRight |  |  |
| FieldProperties | object |  |

## Sample Request

```http!
POST /api/v1/Agents/UserDefinedFieldInfo/SetListTableIdAndUDListDefinitionIdFromSelectedListId
Authorization: Basic dGplMDpUamUw
Accept: application/json; charset=utf-8
Accept-Language: sv
Content-Type: application/json; charset=utf-8

{
  "Info": {
    "UDefFieldId": 882,
    "ColumnId": 227,
    "FieldDefault": "maiores",
    "FieldHeight": 377,
    "FieldLabel": "et",
    "FieldLeft": 813,
    "FieldTop": 717,
    "FieldType": "Checkbox",
    "FieldWidth": 832,
    "FormatMask": "assumenda",
    "HideLabel": false,
    "IsIndexed": false,
    "LabelHeight": 473,
    "LabelLeft": 98,
    "LabelTop": 412,
    "LabelWidth": 430,
    "LastVersionId": 515,
    "ListTableId": 702,
    "IsMandatory": true,
    "Type": "Appointment",
    "Page1LineNo": 904,
    "ProgId": "aspernatur",
    "IsReadOnly": false,
    "ShortLabel": "et",
    "TabOrder": 69,
    "TextLength": 269,
    "Tooltip": "asperiores",
    "UdefIdentity": 818,
    "UDListDefinitionId": 957,
    "Justification": "Center",
    "Version": 414,
    "TemplateVariableName": "Crooks-Rolfson",
    "HasBeenPublished": true,
    "MdoListName": "Bergnaum Inc and Sons"
  },
  "SelectedListId": 784
}
```

```http_
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8

{
  "UDefFieldId": 323,
  "ColumnId": 419,
  "FieldDefault": "quasi",
  "FieldHeight": 836,
  "FieldLabel": "rerum",
  "FieldLeft": 401,
  "FieldTop": 389,
  "FieldType": "Checkbox",
  "FieldWidth": 697,
  "FormatMask": "qui",
  "HideLabel": false,
  "IsIndexed": true,
  "LabelHeight": 37,
  "LabelLeft": 228,
  "LabelTop": 56,
  "LabelWidth": 638,
  "LastVersionId": 732,
  "ListTableId": 654,
  "IsMandatory": true,
  "Type": "Appointment",
  "Page1LineNo": 295,
  "ProgId": "sit",
  "IsReadOnly": false,
  "ShortLabel": "et",
  "TabOrder": 994,
  "TextLength": 814,
  "Tooltip": "consequuntur",
  "UdefIdentity": 8,
  "UDListDefinitionId": 169,
  "Justification": "Center",
  "Version": 785,
  "TemplateVariableName": "Wilkinson Inc and Sons",
  "HasBeenPublished": false,
  "MdoListName": "Bogan LLC",
  "TableRight": {
    "Mask": "Delete",
    "Reason": ""
  },
  "FieldProperties": {
    "fieldName": {
      "FieldRight": {
        "Mask": "FULL",
        "Reason": ""
      },
      "FieldType": "System.Int32",
      "FieldLength": 922
    }
  }
}
```