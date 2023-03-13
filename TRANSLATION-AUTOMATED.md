# Using a Custom Translator

Using the Custom Translator we used earlier, we can get better results than using the standard translator engine.

## Tools/Translate/TranslateDocs.bat

We need to pass in the language code we want to use and the translator's category id.

This copies the `superoffice-docs/docs/en` folder to a language-specific folder: `superoffice-docs/docs/no`

The language-specific folder is the processed:
`FixMetadata.exe` strips out the YAML header bits we don't want translated and also creates a MD file for any YAML files it finds. The meta data from `foo.md` is saved in `foo.meta`.

We are left with markdown files are can translate.
We copy the *.MD files from `docs/no` to TMP.

We use `TranslateFolder.exe` to translate each folder in the TMP folder tree recursively.
Translations are handled by the cloud using Microsoft's `Document Translation\doctr.exe`

The translations are dumped into a new folder: `tmp.out`

We can copy the *.MD files from `tmp.out` back to `superoffice-docs/docs/no`, overwriting the english files we copied earlier.

`FixMetadata.exe` sews the metadata we saved back into the markdown files, and makes the YML files readable again.

# Translating screenshots

Using the tool `Webshooter.exe` we can describe how to take screenshots, and where to place the outputs.

So after the text files are translated, we run the webshooter to generate new screenshots in the language we have
translated into.