---
title: Services88.DashAgent.DuplicateDashboard SOAP
generated: 1
uid: Services88-Dash-DuplicateDashboard
---

# Services88 Dash DuplicateDashboard

SOAP request and response examples **Remote/Services88/Dash.svc**
Implemented by the <see cref="M:SuperOffice.Services88.IDashAgent.DuplicateDashboard">SuperOffice.Services88.IDashAgent.DuplicateDashboard</see> method.

## DuplicateDashboard

Duplicate for the dashboard and all the sub elements

* **dashboardId:** The id of the dashboard to add the tile to
* **name:** The name of the new dashboard

**Returns:** New dashboard

[WSDL file for Services88/Dash](../Services88-Dash.md)

Obtain a ticket from the [Services88/SoPrincipal.svc](../SoPrincipal/index.md)

Application tokens must be specified if calling an Online installation. ApplicationTokens are not checked for on-site installations.

## DuplicateDashboard Request

```xml
<?xml version="1.0" encoding="UTF-8"?>
<SOAP-ENV:Envelope
 xmlns:SOAP-ENV="http://www.w3.org/2003/05/soap-envelope"
 xmlns:SOAP-ENC="http://www.w3.org/2003/05/soap-encoding"
 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
 xmlns:xsd="http://www.w3.org/2001/XMLSchema"
 xmlns:NetServerServices882="http://schemas.microsoft.com/2003/10/Serialization/Arrays"
 xmlns:NetServerServices881="http://schemas.microsoft.com/2003/10/Serialization/"
 xmlns:Dash="http://www.superoffice.net/ws/crm/NetServer/Services88">
  <Dash:ApplicationToken>1234567-1234-9876</Dash:ApplicationToken>
  <Dash:Credentials>
    <Dash:Ticket>7T:1234abcxyzExample==</Dash:Ticket>
  </Dash:Credentials>
 <SOAP-ENV:Body>
   <Dash:DuplicateDashboard>
    <Dash:DashboardId xsi:type="xsd:int">0</Dash:DashboardId>
    <Dash:Name xsi:type="xsd:string"></Dash:Name>
   </Dash:DuplicateDashboard>

 </SOAP-ENV:Body>
</SOAP-ENV:Envelope>

```

## DuplicateDashboard Response

```xml
<?xml version="1.0" encoding="UTF-8"?>
<SOAP-ENV:Envelope
 xmlns:SOAP-ENV="http://www.w3.org/2003/05/soap-envelope"
 xmlns:SOAP-ENC="http://www.w3.org/2003/05/soap-encoding"
 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
 xmlns:xsd="http://www.w3.org/2001/XMLSchema"
 xmlns:NetServerServices882="http://schemas.microsoft.com/2003/10/Serialization/Arrays"
 xmlns:NetServerServices881="http://schemas.microsoft.com/2003/10/Serialization/"
 xmlns:Dash="http://www.superoffice.net/ws/crm/NetServer/Services88">
 <SOAP-ENV:Body>
  <Dash:DuplicateDashboardResponse>
   <Dash:Response xsi:type="Dash:Dash">
    <Dash:DashboardId xsi:type="xsd:int">0</Dash:DashboardId>
    <Dash:UniqueId xsi:type="xsd:string"></Dash:UniqueId>
    <Dash:Name xsi:type="xsd:string"></Dash:Name>
    <Dash:Description xsi:type="xsd:string"></Dash:Description>
    <Dash:AssociateId xsi:type="xsd:int">0</Dash:AssociateId>
    <Dash:Columns xsi:type="xsd:int">0</Dash:Columns>
    <Dash:Theme xsi:type="Dash:DashTheme">
     <Dash:DashboardThemeId xsi:type="xsd:int">0</Dash:DashboardThemeId>
     <Dash:Name xsi:type="xsd:string"></Dash:Name>
     <Dash:Config xsi:type="xsd:string"></Dash:Config>
     <Dash:Rank xsi:type="xsd:short">0</Dash:Rank>
     <Dash:Client xsi:type="xsd:string"></Dash:Client>
     <Dash:Style xsi:type="xsd:string"></Dash:Style>
    </Dash:Theme>
    <Dash:VisibleForAll xsi:type="xsd:short">0</Dash:VisibleForAll>
    <Dash:VisibleForAssociates xsi:type="NetServerServices882:ArrayOfint">
     <NetServerServices882:int xsi:type="xsd:int">0</NetServerServices882:int>
    </Dash:VisibleForAssociates>
    <Dash:VisibleForGroups xsi:type="NetServerServices882:ArrayOfint">
     <NetServerServices882:int xsi:type="xsd:int">0</NetServerServices882:int>
    </Dash:VisibleForGroups>
    <Dash:PinForAll xsi:type="xsd:short">0</Dash:PinForAll>
    <Dash:PinForAssociates xsi:type="NetServerServices882:ArrayOfint">
     <NetServerServices882:int xsi:type="xsd:int">0</NetServerServices882:int>
    </Dash:PinForAssociates>
    <Dash:PinForGroups xsi:type="NetServerServices882:ArrayOfint">
     <NetServerServices882:int xsi:type="xsd:int">0</NetServerServices882:int>
    </Dash:PinForGroups>
   </Dash:Response>
  </Dash:DuplicateDashboardResponse>
 </SOAP-ENV:Body>
</SOAP-ENV:Envelope>

```