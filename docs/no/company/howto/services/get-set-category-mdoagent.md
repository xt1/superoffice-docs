---
title: Slik får du kategorilisten og angir kategori for en person
description: Slik får du kategorilisten og setter Person.Kategori fra kombinasjonsboks
keywords: MDOAgent
uid: get_set_category_mdoagent-no
author: Bergfrid Dias
so.date: 02.22.2022
so.topic: howto
so.category: list
so.area: api-services
# so.envir:
# so.client:
---

# Slik får du tak i kategorilisten og angi kategori på en person

Her har vi brukt to arrangementer for å få jobben gjort. Vi har brukt ett arrangement til å fylle kontrollen med kategorier fra listen vi har hentet, og den andre for å angi kategorien for personen og lagre enheten.

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
