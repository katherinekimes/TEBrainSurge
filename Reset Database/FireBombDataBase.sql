Use master;
GO

DROP DATABASE IF EXISTS TEFlashCards;
GO

CREATE DATABASE TEFlashCards;
GO


USE TEFlashCards;
GO



CREATE TABLE Users (
	UserId     int NOT NULL IDENTITY(1,1),
	Email      nvarchar(50) NOT NULL,
	Password   nvarchar(50) NOT NULL,
	UserRole   nvarchar(50) NOT NULL,
	UserName   nvarchar(50) NOT NULL,
	constraint PK_Users PRIMARY KEY (UserId)
);

CREATE TABLE Deck (
	DeckId     int NOT NULL IDENTITY(1,1),
	UserId     int NOT NULL,
	DeckName   nvarchar(50) NOT NULL,
	constraint PK_Deck PRIMARY KEY (DeckId), 
	constraint FK_Deck_Users FOREIGN KEY (UserId) REFERENCES Users(UserId),

);

CREATE TABLE Card (
	CardId    int NOT NULL IDENTITY(1,1),
	DeckId    int, 
	UserId    int NOT NULL,
	FrontText nvarchar(255) NOT NULL,
	BackText  nvarchar(255) NOT NULL,
	Tags      nvarchar(50),
	constraint PK_Card PRIMARY KEY (CardId),
	constraint FK_Card_Deck FOREIGN KEY (DeckId) REFERENCES Deck(DeckId),
	constraint FK_Card_User FOREIGN KEY (UserId) REFERENCES Users(UserId)
);


INSERT INTO Users (Email, Password, UserRole, UserName)
VALUES ('kbk15@case.edu', 'katherine1313', 'Logged In User', 'katherinekimes')

SELECT * FROM Card

INSERT INTO Deck (UserId, DeckName)
VALUES (1, 'Module 1')

INSERT INTO Card (DeckId, UserId, FrontText, BackText, Tags)
VALUES (1, 1, 'What are the 4 principles of OOP?', 'Encapsulation, Inheritance, Polymorphism, Abstraction', 'OOP'), 
(1, 1, 'What are the 4 components of a method signature?', 'Access Modifier, Return Type, Method Name, Parameter List', 'Methods'),
(1, 1, 'What are 3 ways to break a loop?', 'Break, Continue, Return', 'Loops')
