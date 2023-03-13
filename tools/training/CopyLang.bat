@echo off
if "%1" == "" echo Need language code
if "%1" == "" exit /b
if not exist en\text echo Need to install 'en' language first
if not exist en\text exit /b

if not exist glossary-en-nb.tmx GenGlossary\GenGlossary.exe gloss-md.tsv allresources.align

echo "Copying language %1"
set ARTIF=artifacts\%1
if exist %ARTIF% rmdir %ARTIF% /q /s
if not exist artifacts mkdir artifacts
if not exist %ARTIF% mkdir %ARTIF%
robocopy "\\norfilepub\RnD\Semantix Ink\Help\10.1\Azure-Update-10.1.8-20221114\%1\CRM\UserHelp" %ARTIF%\userhelp *.htm* /s
robocopy "\\norfilepub\RnD\Semantix Ink\Help\10.1\Azure-Update-10.1.8-20221114\%1\CRM\WebHelpAdmin" %ARTIF%\webhelpadmin *.htm* /s

set LANG=%1
if "%LANG%" =="no" (
    set LANG=NB
)

cd %ARTIF%
del /s access_cook*
del /s index*

if exist text rmdir /s text
if not exist text mkdir text

powershell ..\make-text.ps1 %LANG%

if NOT EXIST text cd ..
if NOT EXIST text cd ..
if EXIST text cd ..
if EXIST artifacts cd ..

if "%LANG%" =="en" exit /b

SquishTextFiles\SquishTextFiles.exe all artifacts\en\text %ARTIF%\text en %LANG%

zip -rjD .\en-%1.zip artifacts\en\text\?_en.txt  %ARTIF%\text\?_%LANG%.txt

dir *-*.zip
