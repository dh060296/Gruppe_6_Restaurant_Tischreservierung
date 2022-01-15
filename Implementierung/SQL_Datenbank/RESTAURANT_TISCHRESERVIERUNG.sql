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
  Kundennummer INT PRIMARY KEY, 
  Name NVARCHAR(100),
  Telefonnummer BIGINT
);

CREATE TABLE Tisch (
  Tischnummer INT PRIMARY KEY
);

CREATE TABLE Reservierung (
  Reservierungsnummer INT PRIMARY KEY,
  Datum NVARCHAR(100),
  Reservierungsdatum NVARCHAR(100),
  Kundennummer INT,
  Tischnummer INT,
  CONSTRAINT fk_kunde FOREIGN KEY (Kundennummer)
	REFERENCES Kunde(Kundennummer),
  CONSTRAINT fk_tisch FOREIGN KEY (Tischnummer)
	REFERENCES Tisch(Tischnummer)
);

