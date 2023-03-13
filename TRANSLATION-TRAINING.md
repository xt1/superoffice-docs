# Training a Custom Translator

Setting up the Custom Translation


## Open the Custom translator portal

[Open the portal](hhttps://portal.customtranslator.azure.ai/workspaces)
Log in with you superoffice account

## Create a project in the portal

This will hold the training documents and glossary info.

Specify from and to languages, and a domain - we want the technical domain. All the others use the 'general' model.

You will need one project per language, so naming the project after the language is not a bad idea.

## Create the Training Documents and Glossaries

Install `pandoc` on your PC using winget.

* `winget install pandoc`
* Make sure pandoc is in the path

Build the tools in training solution.

Run `tools\training\CopyLang.bat en` to copy the english files over.
Run `tools\training\CopyLang.bat no` to copy the norwegian files over, etc.

>Note: we use `no` for norwegian, but the translation tool wants `nb` for Norsk bokmål.

This will generate the glossary and all-resource files for you as well.

Processing the help files:
1. Pandoc converts the HTML files into plain text.
    admin/about.htm --> admin/about.txt
2. The help files are renamed to suit the translator tool's rules:
    admin/about.txt  --> admin/about_en.txt
3. The files are cleaned up and moved into a flattened folder.
    admin/about_en.txt  --> text/about_en.txt
4. The files are squished together based on the initial letter in the filename
    text/about_en.txt --> text/a_en.txt
5. All the single letter files are zipped together with the target language
   text/a_en.txt  --> en-xx.zip

Outputs:

* en-no.zip
* allresources-nb1_en.align
* allresources-nb1_nb.align
* glossary-en-nb.tmx

## Upload en-no.zip

* Add Document set > Training Set > Upload multiple sets with ZIP
* Browse to en-no.zup
* Upload

This will chew for a bit and then create a document for each letter in the alphabet, based on the first letter in the filenames from the help files.

## Upload all resources

* Add Document set > Training Set > Upload Parallel documents
* Browse to `allresources-nb1_en.align` and `allresources-nb1_nb.align`
* Upload

## Upload the glossary

* Add Document set > Dictionary Set > Phrase dictionary > Translation Memory file
* Browse to `glossary-en-nb.tmx`
* Upload

# Create a model

Train a new model (name = "nor" for example.

* Full training
* Select all documents, including the phrase dictionary.

The system will pick a random set of training phrases for testing and train the model. This will take a couple of hours.

At the end of the training you will get a BLEU score indicating how good the model is - anything 75% or better is nice.

Each model costs around 40 EUR to train.

# Publish the model

Publish the model to Western Europe.

This will also take a few minutes.

Once published, we get a category id we can use to access the model later.

   `   Category ID: 33dd6d37-9373-4c60-9d65-ee520602568d-TECH`

This is a language-specific ID that identifies this trained model.

We use this when translating the help documents later.
