USE master
GO

IF DB_ID(N'movie.api') IS NOT NULL
DROP DATABASE [movie.api] 
GO

CREATE DATABASE [movie.api]
GO

USE [movie.api]
GO

DROP TABLE IF EXISTS USessions
GO
DROP TABLE IF EXISTS Users
GO

CREATE TABLE Users
(
	UserId varchar(50) PRIMARY KEY,
	UserName varchar(100),
	UserPasswordHash varchar(500),
)
GO

CREATE TABLE USessions
(
	SessionId varchar(50) PRIMARY KEY,
	UserId varchar(50) FOREIGN KEY REFERENCES Users(userid)
)

DROP TABLE IF EXISTS Movies
GO

CREATE TABLE Movies
(
	MovieId int PRIMARY KEY,
	MovieName varchar(100),
	MovieDate date,
	MovieTime time,
)

DROP TABLE IF EXISTS Registrations
GO

CREATE TABLE Registrations
(
	UserId varchar(50),
	MovieId int,
	SeatNumber int,
)

SELECT * FROM Users
GO

SELECT * FROM USessions
GO

SELECT * FROM Registrations
GO

INSERT INTO Movies VALUES 
(1,'Страх и ненависть в Самаре','24.01.2020','19:00'),
(2,'Призрачная красота','24.01.2020','21:00'),
(3,'Самурай Джек','25.01.2020','18:00')
GO

