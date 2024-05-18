USE master;
GO

IF DB_ID(N'tvdb') IS NULL
  CREATE DATABASE tvdb;
GO

USE tvdb;
GO 

IF OBJECT_ID('Versicherungsantrag') IS NOT NULL
  DROP TABLE Versicherungsantrag;

IF OBJECT_ID('Tier') IS NOT NULL
  DROP TABLE Tier;
GO
GO
IF OBJECT_ID('Versicherungsvorschlaege') IS NOT NULL
  DROP TABLE Versicherungsvorschlaege;
GO


IF OBJECT_ID('TR') IS NOT NULL
  DROP TABLE TR;
GO
IF OBJECT_ID('Benutzter') IS NOT NULL
  DROP TABLE Benutzter;
GO
IF OBJECT_ID('TA') IS NOT NULL
  DROP TABLE TA;
GO
IF OBJECT_ID('Zahlungsweise') IS NOT NULL
  DROP TABLE Zahlungsweise;
GO
IF OBJECT_ID('Kunden') IS NOT NULL
  DROP TABLE Kunden;
GO


CREATE TABLE TA (
  TA_ID int NOT NULL IDENTITY PRIMARY KEY,
  Tierart nvarchar(50)
);
CREATE TABLE TR (
  TR_ID int NOT NULL IDENTITY PRIMARY KEY, 
  Rasse nvarchar(50),
  Lebenserwartung int,
  TA_ID int,
  CONSTRAINT fk_AT 
  FOREIGN KEY (TA_ID)
	REFERENCES TA(TA_ID)
);

CREATE TABLE Benutzter (
  B_ID int NOT NULL IDENTITY PRIMARY KEY, 
  Vorname nvarchar(50),
  Nachname nvarchar(50),
  Benutztername nvarchar(50),
  Rolle nvarchar(50),
  Password nvarchar(50),
  Email nvarchar(50),
  Adresse nvarchar(50),
  Erstelungsdatum datetime,
);
CREATE TABLE Zahlungsweise (
  Z_ID int NOT NULL IDENTITY PRIMARY KEY,
  Zahlungsweise nvarchar(50)
);

CREATE TABLE Versicherungsvorschlaege (
  V_ID int NOT NULL IDENTITY PRIMARY KEY,
  
  B_ID int,
  CONSTRAINT fk_B 
  FOREIGN KEY (B_ID)
	REFERENCES Benutzter(B_ID),
  Z_ID int,
  CONSTRAINT fk_Z 
  FOREIGN KEY (Z_ID)
	REFERENCES Zahlungsweise(Z_ID),
  Dauer int,
  Beginn datetime,

);
CREATE TABLE Tier (
  T_ID int NOT NULL IDENTITY PRIMARY KEY, 
  
  Chipnummer int,
  Name nvarchar(50),
  TR_ID int,
  CONSTRAINT fk_TR
  FOREIGN KEY (TR_ID)
	REFERENCES TR(TR_ID),
	
  V_ID int,
  CONSTRAINT fk_V1 
  FOREIGN KEY (V_ID)
	REFERENCES Versicherungsvorschlaege(V_ID),
);

CREATE TABLE Kunden (
  K_ID int NOT NULL IDENTITY PRIMARY KEY,
  Title nvarchar(50),
  Anrede nvarchar(50),
  Vorname nvarchar(50),
  Nachname nvarchar(50),
  Bankdaten nvarchar(50),
  Adresse nvarchar(50),
  Geburtsdatum datetime,
);

CREATE TABLE Versicherungsantrag (
  A_ID int NOT NULL IDENTITY PRIMARY KEY,
  B_ID int,
  CONSTRAINT fk_B1 
  FOREIGN KEY (B_ID)
	REFERENCES Benutzter(B_ID),
  V_ID int,
  CONSTRAINT fk_V 
  FOREIGN KEY (V_ID)
	REFERENCES Versicherungsvorschlaege(V_ID),
  K_ID int,
  CONSTRAINT fk_K 
  FOREIGN KEY (K_ID)
	REFERENCES Kunden(K_ID),
  Versicherungsbeiträge decimal,
  Antragsbeschreibung nvarchar(255)
);

  INSERT INTO TA(Tierart) VALUES ('Hund'),('Pferd');
  INSERT INTO TR(Rasse,TA_ID,Lebenserwartung) VALUES ('Sheltie',1,0),('Chihuahua',1,0),('Shetlandpony.',2,0),('Reitpony',2,0);
  INSERT INTO Benutzter(Benutztername,Password) VALUES ('B1','B1'),('B2','B2'),('a','a');
  INSERT INTO Zahlungsweise(Zahlungsweise) VALUES ('Monatlich'),('viertel Jährlich'),('halb Jährlich'),('Jährlich');
  