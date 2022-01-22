USE master;
GO

IF DB_ID('RESTAURANT_TISCHRESERVIERUNG') IS NULL
    CREATE DATABASE RESTAURANT_TISCHRESERVIERUNG;
GO

USE RESTAURANT_TISCHRESERVIERUNG;
GO

IF OBJECT_ID('Reservierung') IS NOT NULL
    DROP TABLE Reservierung;
GO

IF OBJECT_ID('Kunde') IS NOT NULL
    DROP TABLE Kunde;
GO

IF OBJECT_ID('Tisch') IS NOT NULL
    DROP TABLE Tisch;
GO

CREATE TABLE Kunde (
  Kundennummer INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
  Name NVARCHAR(100) NOT NULL,
  Telefonnummer BIGINT NOT NULL
);

CREATE TABLE Tisch (
  Tischnummer INT PRIMARY KEY
);

CREATE TABLE Reservierung (
  Reservierungsnummer INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  Datum Datetime,
  Reservierungsdatum Datetime,
  Kundennummer INT,
  Tischnummer INT,
  CONSTRAINT fk_kunde FOREIGN KEY (Kundennummer)
	REFERENCES Kunde(Kundennummer),
  CONSTRAINT fk_tisch FOREIGN KEY (Tischnummer)
	REFERENCES Tisch(Tischnummer)
);

