CREATE DATABASE RentCar
USE RentCar

CREATE TABLE [Brands]
(
	[BrandId] SMALLINT IDENTITY(-32768,1),
	[BrandName] NVARCHAR(100) NOT NULL
	CONSTRAINT [PK_Brands] PRIMARY KEY ([BrandId])
);

CREATE TABLE [ModelTypes]
(
	[TypeId] TINYINT IDENTITY(1,1),
	[TypeName] NVARCHAR(25) NOT NULL,
	CONSTRAINT [PK_ModelTypes] PRIMARY KEY ([TypeId])
);

CREATE TABLE [Models]
(
	[ModelId] SMALLINT IDENTITY(-32768,1) PRIMARY KEY,
	[ModelName] NVARCHAR(50),
	[BrandId] SMALLINT NOT NULL,
	[TypeId] TINYINT NOT NULL,
	CONSTRAINT [FK_Model_VehicleTypes] FOREIGN KEY([TypeId]) REFERENCES [ModelTypes]([TypeId]),
	CONSTRAINT [FK_Models_Brands] FOREIGN KEY([BrandId]) REFERENCES [Brands]([BrandId])
);

CREATE TABLE [Colors]
(
	[ColorId] TINYINT IDENTITY(1,1),
	[ColorName] NVARCHAR(50) NOT NULL
	CONSTRAINT [PK_Colors] PRIMARY KEY ([ColorId] ASC)
);

CREATE TABLE [Vehicles]
(
	[VehicleId] SMALLINT IDENTITY(-32768,1),
	[LicensePlate] NVARCHAR(25) NOT NULL,
	[PricePerHr] SMALLMONEY NOT NULL,
	[OfferPercent] DECIMAL(5,2) CONSTRAINT [DF_Vehicles_OfferPercent] DEFAULT(1),
	[Description] NVARCHAR CONSTRAINT [DF_Vehicles_Description] DEFAULT(''),
	[Location] NVARCHAR(255) NOT NULL,
	[ModelId] SMALLINT NOT NULL,
	[ColorId] TINYINT NOT NULL,
	CONSTRAINT [PK_Vehicles] PRIMARY KEY ([VehicleId] ASC),
	CONSTRAINT [UK_Vehicles] UNIQUE ([LicensePlate]),
	CONSTRAINT [FK_Vehicles_Models] FOREIGN KEY([ModelId]) REFERENCES [Models]([ModelId]),
	CONSTRAINT [FK_Vehicles_Colors] FOREIGN KEY([ColorId]) REFERENCES [Colors]([ColorId]),
	CONSTRAINT [CK_OfferPercent] CHECK ([OfferPercent] BETWEEN 0 AND 1)
);

CREATE TABLE Customers
(
	[CustomerId] INT IDENTITY(-2147483648,1),
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Gender] CHAR(1) CONSTRAINT [DF_Vehicles_Gender] DEFAULT 'u', -- f(Female), m(male), u(unknown)
	[NationalityId] NVARCHAR(13) NOT NULL,
	[PhoneNumber] NVARCHAR(22) NOT NULL,
	[EmailAdress] NVARCHAR(255) NOT NULL,
	[BirthDate] DATE NOT NULL, 
	CONSTRAINT [PK_Customers] PRIMARY KEY([CustomerId], [NationalityId]),
	CONSTRAINT [CK_Birthdate] CHECK ([BirthDate] < getdate())
)

CREATE TABLE [Reservations]
(
	[ReservationId] INT IDENTITY(-2147483648, 1),
	[PickupDate] DATETIME CONSTRAINT [DF_Reservations_PickupDate] DEFAULT CURRENT_TIMESTAMP,
	[ReturnDate] DATETIME NULL,
	[VehicleId] SMALLINT NOT NULL,
	[CustomerId] INT NOT NULL,
	CONSTRAINT [PK_Reservations] PRIMARY KEY([ReservationId])
);

INSERT INTO [Customers]([FirstName], [LastName], [Gender], [NationalityId], [PhoneNumber], [EmailAdress], [BirthDate]) 
	VALUES 
	('Yunus Emre', 'Kalaycý', 'M', '21332226678', '+90(544)433824', 'yekelektronik@gmail.com', '1999/05/11'),
	('Fatih', 'Karaca', 'M', '22466227708', '+90(531)5894834', 'fatih123@gmail.com', '1994/01/06'),
	('Ayla', 'Demir', 'F', '41332226678', '+90(522)5513834', 'ayla_ayla@gmail.com', '2000/12/30'),
	('Esra', 'Gamsýz', 'F', '72132926978', '+90(550)5126833', 'hagi33@gmail.com', '1999/08/03'),
	('Deniz', 'Akarsu', 'U', '95302026783', '+90(526)3320836', 'denizak@gmail.com', '1985/11/23')


INSERT INTO [ModelTypes]([TypeName]) VALUES
	('Otomobil'), ('Kamyon'), ('Kamyonet')

INSERT INTO [Brands]([BrandName]) VALUES
	('Mercedes'), ('Bmw'), ('Porsche'), ('Fiat'), ('Renault'), ('Alfa Romeo'),
	('Daihatsu'), ('Delta')

INSERT INTO [Models]([ModelName], [BrandId], [TypeId]) VALUES 
	('Benz C 200 Kompressor Avantgarde', -32768, 1),
	('Benz CLA 180 D AMG', -32768, 1),
	('BMW 3 Series 320i ED Techno Plus', -32767, 1),
	('BMW 3 Series 320i ED Techno Plus', -32767, 1),
	('Egea 1.6 Multijet Comfort', -32765, 1)

INSERT INTO [Colors]([ColorName]) VALUES
	('BLACK'), ('WHITE'), ('RED'), ('GREEN'), ('BLUE')    

INSERT INTO [Vehicles] ([ColorId], [ModelId], [LicensePlate], [Description], [Location], [PricePerHr], [OfferPercent])
	VALUES
		(2, -32768, '34-BR-7243','','adres 1', 200, 1),
		(1, -32767, '22-AZ-4951','','adres 2', 140, 1),
		(4, -32765, '11-YEK-999','','adres 3', 50, 1),
		(5, -32768, '05-AC-1259','','adres 4', 50, 1)

SELECT * FROM [Models]
SELECT * FROM [Brands]
SELECT * FROM [Colors]
SELECT * FROM [ModelTypes]
SELECT * FROM [Customers]
SELECT * FROM [Vehicles]
