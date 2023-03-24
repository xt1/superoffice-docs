<!-- markdownlint-disable-file MD041 -->
### Konfigurere feeden i Outlook

RSS-feeder kan abonneres via Microsoft Office Outlook 2007. RSS-abonnementene lagres i en egen mappe sammen med e-postmappene i Outlook 2007. Når de er abonnert, kan RSS-feeder leses på samme måte som e-postmeldinger leses. Når du klikker på en bestemt feed, vises alle innleggene i samme format som vanlig e-post i e-postleservinduet.

Slik abonnerer du på RSS i Outlook 2007:

1. Gå til Verktøy og deretter Kontoinnstillinger.
2. Klikk på fanen RSS-feeder, og klikk **på Ny** for å legge til en ny RSS-feed.
3. Skriv inn URL-adressen til feeden som vist nedenfor.

Nå kan du se en mappe under  hovedmappen *RSS Feeds* med navnet på feeden.

![RSS feeds mappe -skjermbilde][img1]

### Generelle innstillinger

For at applikasjonen skal kunne kjøres, kreves det noen endringer i webkonfigurasjonsfilen. I delen nedenfor ser du hvilke endringer som kreves i autentiseringsdelen og databasedelen av konfigurasjonsfilen.

[!kode-xml[XML](../rss-webconfig.xml)]

Autentiseringsmodus settes til *Skjemaer*, for å aktivere egendefinert brukergodkjenning. Her peker `loginUrl` punktene til applikasjonens egendefinerte påloggingsside.

Videre må databaseinformasjonen endres.

### Legge til referanser

Når vi har oppdatert *web.config-filen*, må vi legge til følgende referanser etter at vi har oppdatert web.config-filen:

* SOCore.dll
* SODataBase.dll
* SuperOffice. Eldre.dll
* SuperOffice. Tjenester.dll
* SuperOffice. Services.Impl.dll

<!-- Referenced links -->

<!-- Referenced images -->
[img1]: ../../media/image035.jpg
