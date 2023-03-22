@echo off

if "%2" == "" echo TranslateDocs langCode categoryId
if "%2" == "" exit /b

if x%AZCON% == x echo Missing environment variable AZCON - "DefaultEndpointsProtocol=https;AccountName=sohelpdocstraining;AccountKey=p0n/Dx12+prt9ucaQm96OvMXuNcx+hnGhegP==;EndpointSuffix=core.windows.net" - Blob Storage Connection string 
if x%AZCON% == x exit /b

if x%AZKEY% == x echo Missing environment variable AZKEY - 1234abcd53d944489bec6e00f6a82c6f for translator Keys and Endpoint
if x%AZKEY% == x exit /b

set LANG=%1
set CATEGORYID=%2

if "%LANG%" == "nb" set LANG=no
if "%LANG%" == "ge" set LANG=de
if "%LANG%" == "se" set LANG=sv

set LANGCODE=%LANG%
if "%LANGCODE%" == "no" set LANGCODE=nb
if "%LANGCODE%" == "se" set LANGCODE=sv

if not exist glossary-en-%LANGCODE%.tsv ..\training\GenGlossary\GenGlossary.exe glossary.tsv ..\training\gloss-md.tsv

if exist "docs\en" rmdir docs\en /s /q
if exist "docs\%LANG%" rmdir docs\%LANG% /s /q

echo Get fresh copy from GIT folder
Robocopy ..\..\docs\en        docs\en  /njh /njs /np >NUL:
Robocopy ..\..\docs\en\diary docs\en\diary /s /njh /njs /np >NUL:
Robocopy ..\..\docs\en\company docs\en\company /s /njh /njs /np >NUL:
Robocopy ..\..\docs\en\includes docs\en\includes /s /njh /njs /np >NUL:

echo Cloning en to %LANG%
Robocopy docs\en docs\%LANG% /s /njh /njs /np >NUL:

FixMetadata\FixMetadata.exe save %LANG% docs\%LANG%

echo Prep for translation - just copy the markdown files to tmp
if exist "tmp" rmdir tmp /s /q
if exist "tmp.%LANG%" rmdir tmp.%LANG% /s /q
Robocopy docs\%LANG% tmp *.md /s /njh /njs /np >NUL:

echo Configure Translate to %LANG%/%LANGCODE%
set DOCTR=".\Document Translation\doctr.exe"
set TRANSFOLDER=".\TranslateFolder\TranslateFolder.exe"

%DOCTR% config set --region westeurope
%DOCTR% config set --category %CATEGORYID% 
%DOCTR% config set --endpoint https://helptrans.cognitiveservices.azure.com/ 
%DOCTR% config set --storage %AZCON%
%DOCTR% config set --key %AZKEY%

%DOCTR% config test

echo Start Translation to %LANGCODE%
%TRANSFOLDER% tmp tmp.%LANG% %LANGCODE% %CATEGORYID% glossary-en-%LANGCODE%.tsv

echo Move translated docs back
Robocopy tmp.%LANG% docs\%LANG% *.md /s /njh /njs /np >NUL:

FixMetadata\FixMetadata.exe load %LANG% docs\%LANG%

rem Exclude PNGs, since those have been translated
Robocopy docs\%LANG% ..\..\docs\%LANG% /s /njh /njs /np /xf *.png >NUL:
