USE RESTAURANT_TISCHRESERVIERUNG
GO

DELETE FROM Reservierung;
DELETE FROM Kunde;
DELETE FROM Tisch;


INSERT INTO Kunde(Name,Telefonnummer) VALUES ('Müller', 975389257123),('Schmidt', 578356947326),('Mayer', 819256483950),('Mustermann', 132857189401),
											 ('Schneider', 0183271582421),('Fischer', 745743810492),('Weber', 173471502817),('Dali', 766404367413);

INSERT INTO Tisch VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10),(11),(12),(13),(14),(15),(101),(102),(103),(104),(105),(106),(107),(108),(109),(110),(111),(112),(113),(114),(115);

INSERT INTO Reservierung(Datum,Reservierungsdatum,Kundennummer,Tischnummer) VALUES (GETDATE(), '12-02-2022 12:30',1,5),(GETDATE(), '09-02-2022 12:00',2,1),
																	  (GETDATE(), '10-02-2022 18:15',3,5),(GETDATE(), '12-02-2022 12:30',4,7),
																	  (GETDATE(), '03-02-2022 17:45',5,2),(GETDATE(), '07-04-2022 12:30',6,3),
																	  (GETDATE(), '04-02-2022 11:30',7,4),(GETDATE(), '24-04-2022 12:45',8,4)


