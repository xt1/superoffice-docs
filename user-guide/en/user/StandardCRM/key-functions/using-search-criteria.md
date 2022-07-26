---
uid: help-en-using-search-criteria
title: Using search criteria
description: Using search criteria
author: SuperOffice RnD
so.date: 06.29.2022
keywords: CRM
so.topic: help
language: en
---

# Use search criteria

You use search criteria to define what you are looking for, e.g. "companies with an address in Denmark". Search criteria are used in a number of places in SuperOffice CRM, for instance in the **Find** screen and when creating selections. But, regardless of what you are using the criteria for, you work with them in the same way.

Everywhere you are able to enter search criteria, you will find a criteria list containing the selected search criteria.

## Add search criteria

1. Go to the criteria list.  
    <!-- Fix reuse ID=a1 -->
    The criteria list can be found in the following different locations, all depending on what you want to use the search criteria for:

    * Dynamic selection:  
        Go to the required selection and select the **Criteria** tab.
    * The **Find** screen:  
        Click **Find** in the top bar (see [Use the Find screen](Find-dialog.md)). The criteria list is in the **Criteria** tab.
2. Click the **Add** button.  
    A new line is added to the criteria list and a list of fields to choose from is displayed.
3. Select the field you want to search for information in. You can also enter the start of the name in the appropriate field (see [FastSearcher](Using-FastSearcher.md)). There are different types of fields. Click the field description for more information about the field type:
    * <!-- Fix reuse ID=a7 -->
        If the field you are searching in is a text field (e.g. a name field), the search is made on text or numbers you enter. A list with the following options is displayed:

        * Starts with
        * Contains
        * Ends with
        * Equals
        * Between
        * Does not begin with
        * Does not contain
        * Does not end with
        * Is not

        Select one of these options and then enter the search criteria in the text field on the right.
    * <!-- Fix reuse ID=a6 -->
        If the field you are searching in is a Yes/No field, e.g. the **No mailings** field in the **Company** screen, two radio buttons are displayed. You can choose between **Yes** and **No**.
    * <!-- Fix reuse ID=a3 -->
        If the field you are searching in is a date field, e.g. the **Date** field in the **Document** dialog, a list box is displayed containing the following options:

        * Before
        * Equals
        * After
        * Between
        * Before today
        * Today
        * After today
        * This...
        * This and next...
        * Next...
        * This and previous...
        * Previous...
        * This, previous and next...

        Select the required option. Depending on what you select, the field at the far right of the line is automatically filled with a date or date range, or you can enter the date you want. You can also select a date in the calendar which is displayed when you click the arrow button ( ![icon][img1] ).
    * <!-- Fix reuse ID=a4 -->
        If the field you are searching in contains a numerical value, e.g. the **Amount** field in the **Sale** screen, a list box is displayed containing the following options:

        | Option | Description |
        |---|---|
        | = | Equals |
        | &gt; | Greater than |
        | &lt; | Less than |
        | &gt;= | Greater than or equals |
        | &lt;= | Less than or equals |
        | &lt; &gt; | Does not equal |
        | Between | The value lies between specified figures |

        Select the required option and enter the required numerical value in the text field on the right.
    * <!-- Fix reuse ID=a5 -->
        If the field you are searching in is a field containing lists, e.g. the **Business** field in the **Company** screen, a list box appears with the options **Is one of** and **Is not one of**.

        Click the **Select items** field to display the list of values.

        If the list is long, you can type text in the **Search criteria** fields to search for values.

        Click outside the list to close it.
    * <!-- Fix reuse ID=a9 -->
        If the field you are searching in is a status field, you just need to select the required status.

        The statuses are created and maintained in SuperOffice Settings and maintenance.

        * Status fields are only relevant if you have purchased a licence for and have enabled status monitors.
    * <!-- Fix reuse ID=a10 -->
        Counters can be, for example, the number of sales in a period or the date of the last completed sale. <!-- Fix reuse ID=a2 -->.

        [!include[Examples](../../includes/status-examples.md)]

        Counter fields can be found under **Counters (SAINT)** in the list of criteria.

        The counters are created and maintained in SuperOffice Settings and maintenance.

        * Counter fields are only relevant if you have purchased a licence for and have enabled status monitors.

        To the right of the fields, you can click the links to specify additional criteria for the counters. The available options will depend on the type of record and counter you are working with.

        **SAINT type**: Here you choose the activity type you want to search for.
        **Status**: Here you choose the status of the record you want to search for.
        **Direction**: Here you can choose whether the activity is incoming or outgoing.
        **Amount class**: Here you choose the sale's amount class.
        **Intention**: Here you choose the intention of the activity.

        Depending on what you have selected above, a list box for a date field or a number field is displayed. These list boxes work as described above. Select the required option and enter the required numerical value or date in the text field.
4. Select values for the search criteria in the various fields on the line.
5. Click **Add** to add a new line, or click **Or** to add a new set of criteria. (See [Use the Find screen](Find-dialog.md).)

## Change search criteria

If you want to change a search criterion, click it and select a different one from the list that appears.

## Move search criteria

To move criteria (a line), click and drag ![icon](../media/criteria-move.png).

## Delete search criteria

To delete a search criterion, click ![icon](../media/criteria-remove.png).

## Activate or deactivate search criteria

When you open the **Find** screen, it contains default search criteria or the search criteria you specified the last time you used the dialog. If you want to use different search criteria than those shown, you have the following options:

* you can delete them by clicking ![icon](../media/criteria-remove.png)
* you can deactivate one or more search criteria by leaving the value field empty. A deactivated search criterion remains in the criteria list and can be simply reactivated when needed.
* you can deactivate all the search criteria by clicking **Clear all**.

## Move search criteria up or down

To move criteria, click and drag ![icon](../media/criteria-move.png). This has no practical effect on the search, but allows you to arrange the criteria in your preferred order. If some of the criteria are not being used, but you still want to keep them, you can move inactive criteria to the bottom if the list.

## Reset to default search criteria

The criteria lists contain a set of default criteria you can edit or remove as required. If you want to reset the criteria list to the default criteria, click **Reset to default**.

## What would you like to do now?

* [Use the Find screen](Find-dialog.md)

<!-- Referenced links -->
[1]:

<!-- Referenced images -->
[img1]: ../../../../media/icons/dialogboksknapper-pil-ned.bmp