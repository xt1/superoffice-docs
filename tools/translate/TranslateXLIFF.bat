@echo off

if exist "xliff.out\" rmdir xliff.out\ /s /q
if exist "xliff.in\" rmdir xliff.in\ /s /q
mkdir xliff.out
mkdir xliff.in
mkdir xliff.in\no
mkdir xliff.in\sv
mkdir xliff.in\da
mkdir xliff.in\de
mkdir xliff.in\nl

for %%f in (*-no.xlf) do copy %%f xliff.in\no
for %%f in (*-sv.xlf) do copy %%f xliff.in\sv
for %%f in (*-da.xlf) do copy %%f xliff.in\da
for %%f in (*-de.xlf) do copy %%f xliff.in\de
for %%f in (*-nl.xlf) do copy %%f xliff.in\nl

powershell .\TranslateXLIFF.ps1 no nb xliff.in\no

echo Configure Translate
set DOCTR=".\Document Translation\doctr.exe"
set CUSTOM_TRANS=9a9d30a9-d171-4b83-bee8-ae8cc6008bb7-TECH

%DOCTR% config set --region westeurope 
%DOCTR% config set --category %CUSTOM_TRANS% 
%DOCTR% config set --endpoint https://helptrans.cognitiveservices.azure.com/ 
%DOCTR% config set --storage %AZCON%
%DOCTR% config set --key 3bddbff653d944489bec6e00f6a82c6f

%DOCTR% config test


echo Start Translation

%DOCTR% translate xliff.in\no\ xliff.out --from:en --to nb --category %CUSTOM_TRANS% --glossary glossary-en-nb.tsv
%DOCTR% translate xliff.in\sv\ xliff.out --from:en --to sv --category %CUSTOM_TRANS% --glossary glossary-en-sv.tsv
%DOCTR% translate xliff.in\da\ xliff.out --from:en --to da --category %CUSTOM_TRANS% --glossary glossary-en-da.tsv
%DOCTR% translate xliff.in\de\ xliff.out --from:en --to de --category %CUSTOM_TRANS% --glossary glossary-en-de.tsv
%DOCTR% translate xliff.in\nl\ xliff.out --from:en --to nl --category %CUSTOM_TRANS% --glossary glossary-en-nl.tsv


echo Move translated docs back
powershell .\TranslateXLIFF.ps1 nb no xliff.out
