# 6. Projekt: Restaurant-Tischreservierung - Daniel Hofmann dh060296 ; Maximilian Trenz ChibyKito ; Tim Glaser tglaser1

Zur Benutzung des Programms ist die Datenbank RESTAURANT_TISCHRESERVIERUNG nötig. In der vorhandenen .sql-Datei sind ein Skript zum erstellen der Datenbank und fiktive Beispieldaten vorhanden. Um sich die Reservierungen anzeigen zu lassen und die Filterfunktion zu benutzen, sollte man ein Entity-Framework einbinden.

# Kurzbeschreibung zur Nutzung des Programms:

Das Programm startet im Tab "Innenbereich"
![grafik](https://user-images.githubusercontent.com/95036785/151723201-08b2ec62-34ed-4924-b057-29706366ed71.png)

Nachdem man ein Datum ausgewählt hat, an dem man gerne einene Tisch reservieren möchte, werden einem freie Tische grün eingefärbt. Reservierte Tische für diesen Zeitraum werden ausgegraut und mit roter Schrift angezeigt - Selbes gilt für den Tab "Außenbereich".
![grafik](https://user-images.githubusercontent.com/95036785/151723297-37bcd657-3b33-4952-aaa6-d670e6e6dd08.png)


Wenn man sich dann für einen Tisch entschieden hat, wählt man diesen per Mausklick aus und wird zum Reservierungstab weitergeleitet.
![grafik](https://user-images.githubusercontent.com/95036785/151723335-6715493a-98ff-44e9-adc5-52863e020150.png)

Durch vorheriges überprüfen, ob ein Tisch am gewünschten Datum frei ist, werden Datum und Tischnummer automatisch eingetragen. Der Nutzer muss lediglich seinen Namen und seine Telefonnummer eingeben.
Nachdem man seine Daten eingegeben hat, klickt man auf den Button "Eingaben prüfen" um sicher zu stellen, dass man die Daten in korrekter Form eingegeben hat.
Sind alle Daten korrekt eingegeben, schaltet sich der Button "Reservierung eintragen" frei und der Nutzer bekommt nach Klick auf den Button die Bestätigung, dass seine Reservierung eingetragen ist. 
![grafik](https://user-images.githubusercontent.com/95036785/151723468-db12c204-4161-4f6f-9fdc-fdc52177c7b9.png)
![grafik](https://user-images.githubusercontent.com/95036785/151723476-1bc54f7f-d96b-4c8c-bcda-52bfa0794bb8.png)

Nach Bestätigen der Meldung wird der Benutzer wieder in den Tab "Innenbereich" weitergeleitet.
Man kann sich alle Reservierungen im Tab "Reservierungen Anzeigen" anschauen und nach Namen filtern lassen.
![grafik](https://user-images.githubusercontent.com/95036785/151723544-37dea114-ade2-47b4-b5b7-e0bd8ec062a6.png)

