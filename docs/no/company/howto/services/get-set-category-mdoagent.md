---
title: Hvordan få kategorilisten og sette kategori på en kontakt
description: Hvordan få kategorilisten og sette Person.Kategori fra kombinasjonsboksen
uid: get_set_category_mdoagent-no
author: Bergfrid Dias
so.date: 02.22.2022
keywords: MDOAgent
so.topic: howto
so.category: list
so.area: api-services
# so.envir:
# so.client:
---

# Hvordan få kategorilisten og angi kategori på en kontakt

Her har vi brukt 2 arrangementer for å få jobben gjort. Vi har brukt én hendelse til å fylle kontrollen med kategorier fra listen vi har hentet, og den andre til å angi kontaktkategorien og lagre enheten.

```csharp
using SuperOffice.CRM.Services;
using SuperOffice;

private void button3_Click(object sender, EventArgs e)
{
  using (SoSession mySession = SoSession.Authenticate("SAL0", ""))
  {
    //Get the MDO agent
    using(MDOAgent mdoAgent = new MDOAgent())
    {
      SelectableMDOListItem[] categoryList =
       mdoAgent.GetSelectableList("category", false  , "", false);

      //Set the datasource of the control
      cmbCategory.DataSource = categoryList;

      //Set the display member
      cmbCategory.DisplayMember = "Name";

      //Set the value member
      cmbCategory.ValueMember = "Id";
    }
  }
}

private void button4_Click(object sender, EventArgs e)
{
  using (SoSession mySession = SoSession.Authenticate("SAL0", ""))
  {
    //Retrieve a contact agent
    using(ContactAgent contactAgent = new ContactAgent())
    {
      //Retrieve the contact entity you want through the contact agent
      ContactEntity myContact = contactAgent.GetContactEntity(4);

      //Set the category ID of the contact using selected value of the combo box control
      myContact.Category.Id = System.Convert.ToInt32(cmbCategory.SelectedValue);

      //Finally save contact entity
      contactAgent.SaveContactEntity(myContact);
    }
  }
}
```

Nedenfor er et skjermbilde av applikasjonen vi har utviklet.

![01 -skjermbilde][img1]

<!-- Referenced images -->
[img1]: media/image001.jpg
