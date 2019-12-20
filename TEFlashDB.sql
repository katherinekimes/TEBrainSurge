Use master;
GO

DROP DATABASE IF EXISTS TEFlashCards;
GO

CREATE DATABASE TEFlashCards;
GO


USE TEFlashCards;
GO

CREATE TABLE users
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);

CREATE TABLE Deck (
	DeckId     int NOT NULL IDENTITY(1,1),
	UserId     int NOT NULL,
	DeckName   nvarchar(50) NOT NULL,
	DeckDescription nvarchar(255) NOT NULL,
	constraint PK_Deck PRIMARY KEY (DeckId), 
	constraint FK_Deck_Users FOREIGN KEY (UserId) REFERENCES Users(id),

);

CREATE TABLE Card (
	CardId    int NOT NULL IDENTITY(1,1),
	UserId    int NOT NULL,
	FrontText nvarchar(255) NOT NULL,
	BackText  nvarchar(255) NOT NULL,
	Tags      nvarchar(50),
	constraint PK_Card PRIMARY KEY (CardId),
	constraint FK_Card_User FOREIGN KEY (UserId) REFERENCES Users(id)
);

CREATE TABLE card_deck (
	CardId int NOT NULL,
	DeckId int NOT NULL,
	CONSTRAINT PK_card_deck PRIMARY KEY (CardId, DeckId),
	CONSTRAINT FK_card_deck_card FOREIGN KEY (CardId) REFERENCES Card(CardId),
	CONSTRAINT FK_card_deck_deck FOREIGN KEY (DeckId) REFERENCES Deck(DeckId)
	);

	
