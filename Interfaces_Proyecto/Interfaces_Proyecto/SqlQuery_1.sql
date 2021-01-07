CREATE DATABASE LOGIN
USE LOGIN

CREATE TABLE [dbo].[Usuarios]
(
 [Id_Usuario] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
 [Nombre] VARCHAR (50) NULL,
 [Usuario] VARCHAR (50) NULL,
 [Password] VARCHAR (50) NULL,
 [Tipo_Usuario] VARCHAR (50) NULL
)

SELECT * FROM Usuarios

INSERT INTO Usuarios VALUES ('Abril Zayas', 'Abril12', '1234', 'Admin');
INSERT INTO Usuarios VALUES ('Victor Joel', 'Joel', '4321', 'Usuario');

