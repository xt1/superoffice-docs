---
title: Services84.ArchiveAgent.GetGroupAssociateIds SOAP
generated: 1
uid: Services84-Archive-GetGroupAssociateIds
---

# Services84 Archive GetGroupAssociateIds

SOAP request and response examples **Remote/Services84/Archive.svc**
Implemented by the <see cref="M:SuperOffice.Services84.IArchiveAgent.GetGroupAssociateIds">SuperOffice.Services84.IArchiveAgent.GetGroupAssociateIds</see> method.

## GetGroupAssociateIds

Returns the  associate ids that belongs to the given groups

* **groupIds:** Array of group ids

**Returns:** Array of associate ids

[WSDL file for Services84/Archive](../Services84-Archive.md)

Obtain a ticket from the [Services84/SoPrincipal.svc](../SoPrincipal/index.md)

Application tokens must be specified if calling an Online installation. ApplicationTokens are not checked for on-site installations.

## GetGroupAssociateIds Request

```xml
<?xml version="1.0" encoding="UTF-8"?>
<SOAP-ENV:Envelope
 xmlns:SOAP-ENV="http://www.w3.org/2003/05/soap-envelope"
 xmlns:SOAP-ENC="http://www.w3.org/2003/05/soap-encoding"
 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
 xmlns:xsd="http://www.w3.org/2001/XMLSchema"
 xmlns:NetServerServices842="http://schemas.microsoft.com/2003/10/Serialization/Arrays"
 xmlns:NetServerServices841="http://schemas.microsoft.com/2003/10/Serialization/"
 xmlns:Archive="http://www.superoffice.net/ws/crm/NetServer/Services84">
  <Archive:ApplicationToken>1234567-1234-9876</Archive:ApplicationToken>
  <Archive:Credentials>
    <Archive:Ticket>7T:1234abcxyzExample==</Archive:Ticket>
  </Archive:Credentials>
 <SOAP-ENV:Body>
   <Archive:GetGroupAssociateIds>
    <Archive:GroupIds xsi:type="NetServerServices842:ArrayOfint">
     <NetServerServices842:int xsi:type="xsd:int">0</NetServerServices842:int>
    </Archive:GroupIds>
   </Archive:GetGroupAssociateIds>

 </SOAP-ENV:Body>
</SOAP-ENV:Envelope>

```

## GetGroupAssociateIds Response

```xml
<?xml version="1.0" encoding="UTF-8"?>
<SOAP-ENV:Envelope
 xmlns:SOAP-ENV="http://www.w3.org/2003/05/soap-envelope"
 xmlns:SOAP-ENC="http://www.w3.org/2003/05/soap-encoding"
 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
 xmlns:xsd="http://www.w3.org/2001/XMLSchema"
 xmlns:NetServerServices842="http://schemas.microsoft.com/2003/10/Serialization/Arrays"
 xmlns:NetServerServices841="http://schemas.microsoft.com/2003/10/Serialization/"
 xmlns:Archive="http://www.superoffice.net/ws/crm/NetServer/Services84">
 <SOAP-ENV:Body>
  <Archive:GetGroupAssociateIdsResponse>
   <Archive:Response xsi:type="NetServerServices842:ArrayOfint">
    <NetServerServices842:int xsi:type="xsd:int">0</NetServerServices842:int>
   </Archive:Response>
  </Archive:GetGroupAssociateIdsResponse>
 </SOAP-ENV:Body>
</SOAP-ENV:Envelope>

```