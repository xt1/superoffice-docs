---
title: POST Agents/BLOB/DeleteBlobEntity
id: v1BLOBAgent_DeleteBlobEntity
---

# POST Agents/BLOB/DeleteBlobEntity

```http
POST /api/v1/Agents/BLOB/DeleteBlobEntity
```

Deletes the BlobEntity







## Query String Parameters

| Parameter Name | Type |  Description |
|----------------|------|--------------|
| BlobEntityId | int32 | **Required** The id of the BlobEntity to be deleted. |

```http
POST /api/v1/Agents/BLOB/DeleteBlobEntity?BlobEntityId=894
```


## Request Headers

| Parameter Name | Description |
|----------------|-------------|
| Authorization  | Supports 'Basic', 'SoTicket' and 'Bearer' schemes, depending on installation type. |
| X-XSRF-TOKEN   | If not using Authorization header, you must provide XSRF value from cookie or hidden input field |
| SO-AppToken | The application token that identifies the partner app. Used when calling Online WebAPI from a server. |


## Response


| Response | Description |
|----------------|-------------|
| 204 | No Content |