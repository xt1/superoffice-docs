---
uid: help-en-customers-viewcompany-listinvoicescontact
title: customers viewCompany listInvoicesContact
description: customers viewCompany listInvoicesContact
author: SuperOffice RnD
so.date: 06.29.2022
keywords: Service
so.topic: help
language: en
---

# View invoice data for companies

When processing requests, you have the option of registering invoice data as you proceed (see [Invoice information](ticket.newTicket.md#InvoiceInformation)). When the request is closed, the customer can be invoiced for the work performed.

> [!NOTE]
> The invoice feature is only available if you have registered invoice types and have the required feature toggle. See [Invoice types](admin.listInvoiceTypes.md).

To view invoice information that has been registered for a specific company, do as follows:

1. Open the **Company** screen as described under [View companies](customers.viewCompany.md).
2. Click the ![icon](../media/btn-Menu.png)**Actions** button and select **Invoices**. The **Invoices for ...** screen appears. This contains both requests that include messages with invoiceable hours, and registered invoice items, in chronological order. Note in particular these columns:
    * **Credit**: Shows the total amount for invoicing.
    * **Debit** Shows the total amount invoiced.
    * **Balance**: Shows the running balance, i.e. the difference between **Credit** and **Debit**.
3. If you are sending an invoice out to the company, it is easier to keep an overview in SuperOffice Service if you add an invoice item at the same time. <!-- Fix reuse ID=a1 -->
    1. Click the **Invoice** button. This takes you to the **Invoice properties** screen.
    2. In the **Description** field, enter the object of the invoice.
    3. Enter the amount in the **Amount** field.
    4. Click **OK**.

    When you return to the invoice data, you will see that a new row has been added with the amount you just entered in the **Debit** column and that the **Balance** column has also been updated.
4. Click **Return to company** to go back to the **View company** screen.