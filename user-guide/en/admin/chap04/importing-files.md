---
uid: help-en-importing-files
title: Importing files
description: Importing files
author: SuperOffice RnD
so.date: 06.29.2022
keywords: Windows Client settings
so.topic: help
language: en
---

# Import files

When you have performed a backup of the database file, found the right data file and placed it in a folder where you can easily find it again (see [Import routines](Import-routines.md)), you can start the import itself.

> [!NOTE]
> Before you begin the import, you need to make sure that neither the import description file, nor the data file are open in any other program (such as Excel). This is because some programs "lock" files they open so that other programs cannot access them.

To import a data file into the SuperOffice database:

1. Open the **Import** screen.

    [!include[How to open import](../includes/open-import.md)]

2. Click ![icon](../media/Soek.bmp) next to the **Import description file** field and select an import description file (file type: **DSC**) in the dialog which opens. For more details, see [Import descriptions](Import-descriptions.md).

3. The import description file contains information about which data file is to be imported, and this file is then shown automatically in the **Import file** field. If no file is shown here, you can click ![icon](../media/Soek.bmp) next to the field and navigate to the required import file.

    > [!NOTE]
    > The import description and import file must contain the same number of columns. You cannot insert any file at will into the **Import file** field.

4. When you have chosen an import description and the import file has been found, the other fields are filled in automatically. If you want to edit any of the details in the import description, follow the procedure under [Edit import descriptions](Editing-import-descriptions.md).

5. It may be useful to check that the contents of the fields correctly match the fields you have selected. The **Field in file** column under **Field mapping** shows the contents of the first record in the data file you are importing, while the **Field in SuperOffice CRM** column shows the fields in the SuperOffice database the data will be imported to. Click the **Next** button a few times to check the contents of some of the following records as well.

    > [!NOTE]
    > If the fields do not display as required, you must either amend the field mapping (see [Field mapping](Field-mapping.md)) or make the necessary changes in the import file.

6. Click **Start** to start the import. A progress indicator is displayed at the bottom of the screen.

> [!NOTE]
> The time required to import the data from the import file into the SuperOffice database depends on the size of the database and the data connection (slow or fast connection to the database server). However, you can cancel the import at any time by clicking the **Stop** button on the right of the progress indicator.