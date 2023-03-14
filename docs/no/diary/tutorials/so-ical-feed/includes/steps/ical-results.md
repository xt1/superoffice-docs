<!-- markdownlint-disable-file MD041 -->iCal-siden gjør den samme påloggingskontrollen som resultatsiden, men den leser brukerens avtaler og sender ut iCal. Søket begrenser antall avtaler til ca. 2 måneders avtaler, vektet mot fremtidige/planlagte avtaler.

[!code-csharp[CS]](../ical-write-results.cs?range=1-5)

For å sende ut avtalene må vi angi et par ting i overskriften:

[!code-csharp[CS]](../ical-write-results.cs?range=7-12)

Selve svaret har en overskrift og deretter en liste over avtaledetaljer.

### Topptekst for innhold

[!code-csharp[CS]](../ical-write-results.cs?range=14-21)

### Utdata per avtale

[!code-csharp[CS]](../ical-write-results.cs?range=23-68)

Google er kresen på tidssone-ID-en på DTSTART/DTEND – den må være til stede.

Denne siden resulterer i utdata som dette:

```text
BEGIN:VCALENDAR
PRODID:-//SuperOffice AS//SuperOffice Calendar 6//EN
VERSION:2.0
CALSCALE:GREGORIAN
METHOD:PUBLISH
X-WR-CALNAME:SO Christian
X-WR-CALDESC:Christian SuperOffice calendar
X-WR-TIMEZONE;VALUE=TEXT:Europe/Oslo
BEGIN:VEVENT
DTSTART;TZID=Europe/Oslo:20110209T123000
DTEND;TZID=Europe/Oslo:20110209T133000
DTSTAMP:20110209T083551Z
UID:appointmentid-3146920@localhost
CLASS:PUBLIC
CREATED:20110125T141334Z
LAST-MODIFIED:20110209T083551Z
SUMMARY:Meeting - IN: Discuss Expander Online Extensibility\n\n-Web...
CATEGORIES:Meeting - IN
DESCRIPTION:Meeting - IN / SuperOffice AS / Discuss Expander Online Extensibility\n\n- Web Services (currently limited availability)\n- NetServer Services Scripting\n- .merge/.config file modifications
SEQUENCE:0
STATUS:CONFIRMED
TRANSP:OPAQUE
END:VEVENT
BEGIN:VEVENT
DTSTART;TZID=Europe/Oslo:20110211T130000
DTEND;TZID=Europe/Oslo:20110211T140000
DTSTAMP:20110207T101132Z
UID:appointmentid-3154868@localhost
CLASS:PUBLIC
CREATED:20110203T110804Z
LAST-MODIFIED:20110207T101132Z
SUMMARY:Meeting - IN: (Almost) MAF-meeting – Configuration
...
END:VEVENT
END:VCALENDAR
```
