--FIRST STEP

CREATE TABLE TabUser (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserName VARCHAR(50),
	[Password] NVARCHAR(MAX),
	IsAdmin BIT
)

CREATE TABLE TabRoute (
	Id INT PRIMARY KEY IDENTITY(1,1),
	DeparturePoint VARCHAR(50),
	ArrivingPoint VARCHAR(50),
	Distance FLOAT
)

CREATE TABLE CatStatusBus (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Label] NVARCHAR(50)
)

CREATE TABLE TabBus (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Plates VARCHAR(10),
	Capacity INT,
	IdStatusBus INT
	FOREIGN KEY (IdStatusBus) REFERENCES CatStatusBus(Id)
)

CREATE TABLE TabBusSchedule (
	Id INT PRIMARY KEY IDENTITY(1,1),
	DepartureTime DATETIME,
	ArrivingTime DATETIME,
	IsAvailable BIT,
	IdBus INT,
	IdRoute INT
	FOREIGN KEY (IdRoute) REFERENCES TabRoute(Id)
)

CREATE TABLE TabTicket (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Price MONEY,
	IdUser INT,
	IdBusSchedule INT
	FOREIGN KEY (IdUser) REFERENCES TabUser(Id),
	FOREIGN KEY (IdBusSchedule) REFERENCES TabBusSchedule(Id)
)

CREATE TABLE TabSeat (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Seat CHAR(2),
	IdTicket INT
	FOREIGN KEY (IdTicket) REFERENCES TabTicket(Id),
)

--SECOND STEP

CREATE TABLE CatCategory (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Label] NVARCHAR(50)
)

ALTER TABLE TabBus ADD IdCategory INT,
					FOREIGN KEY (IdCategory) REFERENCES CatCategory(Id)

ALTER TABLE TabBus ADD UNIQUE (Plates)

ALTER TABLE TabUser ADD UNIQUE (UserName)