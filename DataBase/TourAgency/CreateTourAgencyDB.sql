CREATE DATABASE TravelAgency_DB;

USE TravelAgency_DB;

CREATE TABLE TourLocation(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
City NVARCHAR(30),
Country NVARCHAR(30)
);


CREATE TABLE Tour(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Name NVARCHAR(30) NOT NULL,
PriceUSD DECIMAL,
StartConnectionID INT FOREIGN KEY REFERENCES TourLocation(ID),
Description TEXT,
FoodType TEXT

);

CREATE TABLE Picture(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
TourID INT  FOREIGN KEY REFERENCES Tour(ID),
PicturePath TEXT
);

CREATE TABLE TourDate(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
TourID INT  FOREIGN KEY REFERENCES Tour(ID),
StartDate DATE,
Duration TIME,
);


CREATE TABLE Route_Connection(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
LocationID INT FOREIGN KEY REFERENCES TourLocation(ID),
NextLocation INT FOREIGN KEY REFERENCES TourLocation(ID),
TourID INT  FOREIGN KEY REFERENCES Tour(ID)
);
SELECT * FROM dbo.Tour;

CREATE TABLE Bus(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Name NVARCHAR(30) NOT NULL,
Brand  NVARCHAR(30) NOT NULL,
Color  NVARCHAR(30) NOT NULL,
Seats TEXT
);

CREATE TABLE PictureBus(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
BusID INT FOREIGN KEY REFERENCES Bus(ID),
PicturePath TEXT
);

CREATE TABLE Equipment(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Description TEXT
);
 
 CREATE TABLE BusEquipment(
 ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
 BusID INT FOREIGN KEY REFERENCES Bus(ID),
 EquipmentID INT FOREIGN KEY REFERENCES Equipment(ID)
 );
