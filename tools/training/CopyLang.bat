@echo off
if "%1" == "" echo Need language code: en, da, de, nl, no, se
if "%1" == "" exit /b
if "%1" neq "en" if not exist artifacts\en\text echo Need to install 'en' language first
if "%1" neq "en" if not exist artifacts\en\text exit /b

if not exist glossary-en-nb.tmx GenGlossary\GenGlossary.exe glossary.tmx gloss-md.tsv allresources.align

echo "Copying language %1"
set ARTIF=artifacts\%1
if exist %ARTIF% rmdir %ARTIF% /q /s
if not exist artifacts mkdir artifacts
if not exist %ARTIF% mkdir %ARTIF%
robocopy "\\norfilepub\RnD\Semantix Ink\Help\10.1\Azure-Update-10.1.8-20221114\%1\CRM\UserHelp" %ARTIF%\userhelp *.htm* /s /NP >NUL:
robocopy "\\norfilepub\RnD\Semantix Ink\Help\10.1\Azure-Update-10.1.8-20221114\%1\CRM\WebHelpAdmin" %ARTIF%\webhelpadmin *.htm* /s /NP >NUL:

set LANG=%1
if "%LANG%" =="no" set LANG=nb
if "%LANG%" =="se" set LANG=sv
if "%LANG%" =="ge" set LANG=de

cd %ARTIF%
del /s access_cook*
del /s index*

if exist text rmdir /s text
if not exist text mkdir text

powershell ..\..\make-text.ps1 %LANG%

if NOT EXIST text cd ..
if NOT EXIST text cd ..
if EXIST text cd ..
if NOT EXIST artifacts cd ..
if NOT EXIST artifacts cd ..

if "%LANG%" =="en" exit /b

SquishTextFiles\SquishTextFiles.exe all artifacts\en\text %ARTIF%\text en %LANG%

zip -rjD .\en-%1.zip artifacts\en\text\?_en.txt  %ARTIF%\text\?_%LANG%.txt

dir *-*.zip
