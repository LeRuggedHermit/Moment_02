# Moment_02

Lösning till moment 2 DT191G webbutveckling med dotnet.
En applikation som använder MVC.
Har följande innehåll:
två controllers, 
två modeller,
tre views,
två JSON-filer,
gemensam layoutfil, 
header som en partial.

Titlar skrivs ut med viewdata.
Ett meddlenade skickas med ViewBag.

Formulär knutet till modeller skickar data via kontroller till JSON-filerna.
Från kontrollerna skrivs data ut i Views - förutom på gästboks-view: där data loopas ut i viewen med anledning av att modell-direktivet redan var åberopat.
Sidan bygger på egen html och css.
Routing har modifierats med egna namn.

formulären validerar om data är korrekt om inte visas felmeddelanden och data skickas inte till JSON.
