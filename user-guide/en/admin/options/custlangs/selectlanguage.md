---
uid: help-en-admin-listcustlangs-selectlanguage
title: admin listCustLangs selectlanguage
description: admin listCustLangs selectlanguage
author: SuperOffice RnD
so.date: 06.29.2022
keywords: Settings and maintenance
so.topic: help
language: en
---

# How SuperOffice Service selects the customer language for new contacts

When a new customer sends in a request, SuperOffice Service tries to decide which customer language should be shown for the customer. We have described below various scenarios to show how this works.

## Scenario 1

1. John, a new contact, registers a new request in the customer centre cs.liberty.com with the e-mail address john@coca-cola.se.
2. The new request is sent to the system, where John's e-mail domain (coca-cola.se) is checked. coca-cola.se is registered as domain for the company Coca-Cola.
3. John is added as a new contact for Coca-Cola, instead of being added as a new contact without a company.
4. SuperOffice Service then checks whether the e-mail domain .se is linked to one of the registered customer languages. .se is registered as domain for the customer language Swedish.
5. The customer language for contact John is therefore set as Swedish.
6. SuperOffice Service sends a Swedish reply template (if this has been created) to John, informing him that the request has been received and registered.
7. John receives a user name and password from SuperOffice Service, and can log on to cs.liberty.com and access the Swedish version of SuperOffice Customer Centre. John will also have access to Swedish FAQs if this has been set up in SuperOffice Service.

## Scenario 2

1. Maria, a new contact, registers a new request in the customer centre cs.liberty.com with the e-mail address maria@coca-cola.nl.
2. SuperOffice Service checks the e-mail domain and this is registered to the company Coca-Cola.
3. Maria is added as a new contact for Coca-Cola.
4. SuperOffice Service then checks whether the e-mail domain .nl is linked to one of the registered customer languages. The e-mail domain .nl is *not* linked to a customer language and no customer language can therefore be decided for Maria.
5. Maria receives a reply template in the default language for the company she is linked to. SuperOffice Customer Centre and FAQs are also shown in the default language.

## Scenario 3

1. Dutch is added as a new customer language in SuperOffice Service and linked to the domain .nl.
2. Maria does not automatically get Dutch as customer language. This must be done manually for the contact. Only new contacts will be checked against new customer languages.