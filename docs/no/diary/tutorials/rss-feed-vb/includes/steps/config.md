<!-- markdownlint-disable-file MD041 -->
### Konfigurer feeden i Outlook

RSS-feeder kan abonneres via Microsoft Office Outlook 2007. RSS-abonnementene beholdes i en egen mappe sammen med e-postmappene i Outlook 2007. Når du abonnerer, kan RSS-feeder leses på samme måte som e-postmeldinger leses. Når du klikker på en bestemt feed, vises alle innleggene i samme format som vanlig e-post i e-postleserruten.

Slik abonnerer du på RSS i Outlook 2007:

1. Gå til Verktøy og deretter Kontoinnstillinger.
2. Klikk kategorien RSS-feeder, og klikk Ny **** for å legge til en ny RSS-feed.
3. Skriv inn URL-adressen til feeden som vist nedenfor.

Nå kan du se en mappe under *hovedmappen for RSS-feeder* med navnet på feeden.

![RSS-feeder mappe -skjermbilde][img1]

### Generelle innstillinger

For at programmet skal kjøre, kreves det noen endringer i webkonfigurasjonsfilen. Følgende avsnitt illustrerer endringene som kreves i godkjenningsdelen og databasedelen av konfigurasjonsfilen.

[!code-xml[XML]](../rss-webconfig.xml)

Godkjenningsmodusen er satt til Skjemaer **for å aktivere egendefinert brukergodkjenning. Her peker på `loginUrl` applikasjonens tilpassede påloggingsside.

Videre må databaseinformasjonen endres.

### Legge til referanser

For å kjøre eksempelkoden, etter at vi har oppdatert *web.config-filen* , må vi legge til følgende referanser:

* SOCore.dll
* SODataBase.dll
* SuperOffice. Ettermæle.dll
* SuperOffice. Tjenester.dll
* SuperOffice. Services.Impl.dll

<!-- Referenced links -->

<!-- Referenced images -->
[img1]: ../../media/image035.jpg
