Puppeteer / Playwright to take screenshots of elements
Annotate images using C# imageMagick
Yaml file to describe images and annotations
One file per image.

Automate login to Online tenant
Login and switch languages automatically

Sample image description file:

```
- url: "default.aspx?contact.main.activityarchive.minimonth?contact_id=3&diaryowner_id=316&tzlocation_id=261"
  windowSize: 1280x800
  filename: "foobar.png"
  element: ".SOMainPane"
  clip: 0,0-400,200
  before: 
    - click: "#edit"
    - type:
        element: "#edit"
        text: "bla bla bla"
    - type: 
        element: "bla bla bla"
        text: "bla bla bla"
    - click: "#tab2"
  after:
    - click: "#cancel"
  annotate:
    - rect: 
        over: "#edit"
    - text:
       - over: "#edit"
         text: ../includes/some-text.md
```

generates files en/foobar.png, no/foobar.png sv/foobar.png etc, one per language

Run script with base URL:
`gen-screenshots  https://sod.superoffice.com/Cust1234/  ./screenshots`

Text to type or annotate could be references to text snippets so we can use translated text in the screenshots.


# Many shot files 

Place images next to the shot files:

# Single shot file that describes many shots

`webshooter.exe -u https://sod.superoffice.com/Cust1234/ .\many.yml -o docs\en ` 