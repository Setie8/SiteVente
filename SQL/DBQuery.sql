CREATE DATABASE ClubTaekwondoCapital
go

use ClubTaekwondoCapital

CREATE TABLE [dbo].[Competitions](
	[Id] [uniqueidentifier] NOT NULL primary key,
	[IsDeleted] [bit] NOT NULL default 0, 
	[CreatedDate] DateTime not null default Getdate(),
	[CompName] [nvarchar](50) NOT NULL,
	[CompDate] [datetime] NOT NULL,
	[Result] [nchar](10) NULL,
	[Classement] [nchar](10) NOT NULL
) ON [PRIMARY]


CREATE TABLE [dbo].[Cours](
	[Id] [uniqueidentifier] NOT NULL primary key,
	[IsDeleted] [bit] NOT NULL default 0,
	[CreatedDate] Datetime NOT NULL  default Getdate(),
	[Category] [nvarchar](50) NOT NULL,
	[Price] [decimal](6, 2) NOT NULL,
	[Age] [nvarchar](100) NULL,
	[Horaire] [nvarchar](100) NULL,
	[Image] [nvarchar](100) NULL)
 ON [PRIMARY]


 CREATE TABLE [dbo].Secteur(
	[Id] [uniqueidentifier] NOT NULL primary key,
	[IsDeleted] [bit] NOT NULL default 0,
	[CreatedDate] [datetime] NOT NULL default Getdate(),
	[Name] [nvarchar](50) NOT NULL	)
ON [PRIMARY]

 CREATE TABLE [dbo].Equipement(
	[Id] [uniqueidentifier] NOT NULL primary key,
	[SecteurId] [uniqueidentifier] foreign Key References Secteur([Id]) NOT NULL,
	[IsDeleted] [bit] NOT NULL default 0,
	[CreatedDate] [datetime] NOT NULL default Getdate(),
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](6, 2) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Image] [nvarchar](100) NULL	)
ON [PRIMARY]

 CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL primary key,
	[IsDeleted] [bit] NOT NULL default 0,
	[CreatedDate] [datetime] NOT NULL default Getdate(),
	[Admin] bit NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar] (50) NOT NULL)
ON [PRIMARY]


insert into [dbo].[User] (Id, Admin, UserName, Password)
values ('235bc728-520a-426b-993f-1aba0ca1cff0', 1, 'Stanley', 'Admin'),
		('1192a108-87b7-4a93-a74a-bbc60a728144', 0, 'Trump', 'Wall'),
		('065d9d00-d226-4b2f-9945-a0839156204d', 1, 'Admin', 'Admin'),
		('b796bcd7-fa9c-46bc-943f-63821736e796', 0, 'qwerty', 'qwerty')




insert into dbo.[secteur] (Id, [Name])
values ('2b722664-5e66-45a6-8a52-19c018935092', 'Accessoires' ),
		('0b761b6b-1638-45af-a14a-10477363d776', 'Gants'),
		('32540443-3a7d-4965-a811-b32f9c7ee809', 'Ceinture'),
		('b7111318-f4f8-4927-84f0-e08ebda0dd3a', 'Chaussure'),
		('22f9a964-5876-4b92-9041-b76732f7eb86', 'Entrainement'),
		('967e0dd8-7568-4d7d-8980-3d3aa3cdd044', 'Uniforme')


insert into dbo.Equipement (Id, SecteurId, Name, Price, Image)
values	('c72b4287-4d09-411e-840c-a129af0290f2', '2b722664-5e66-45a6-8a52-19c018935092', 'Desinfectant', 19.99, 'Desinfectant.jpg'),
		('924085f7-8145-4fac-9dcb-654730632613', '0b761b6b-1638-45af-a14a-10477363d776', 'Gant TKD Adidas', 54.99, 'GantAdidas.jpg'),
		('efed0c70-1f16-497f-b751-ed589dac18ff', '0b761b6b-1638-45af-a14a-10477363d776', 'Gant de Competition WTF', 39.99, 'GantCompetition.jpg'),
		('94e309aa-0410-4d02-9197-2b8aea7a9dd9', '32540443-3a7d-4965-a811-b32f9c7ee809', 'Ceinture Noire Adidas', 24.99, 'NoireAdidas.jpg'),
		('576a8278-b5bc-4dd1-ab5e-bc730bef5004', '32540443-3a7d-4965-a811-b32f9c7ee809', 'Ceinture de Couleur TKD', 11.99, 'CouleurTKD.jpg'),
		('60973fe4-6e46-4085-8d14-a9b22104a605', '32540443-3a7d-4965-a811-b32f9c7ee809', 'Ceinture Bicolore Jukado', 11.99, 'BicoloreJukado.jpg'),
		('8043e3a2-aeb7-49fb-b16c-1512341448db', 'b7111318-f4f8-4927-84f0-e08ebda0dd3a', 'Soulier Sport', 67.99, 'SoulierSport.jpg'),
		('65915f36-cf5a-4b5d-8128-e0a59db5eec7', 'b7111318-f4f8-4927-84f0-e08ebda0dd3a', 'Soulier Sport Adiluxe', 119.99, 'SoulierSportAdiluxe.jpg'),
		('ad669b77-c53b-433c-a721-14a3d27234dc', '22f9a964-5876-4b92-9041-b76732f7eb86', 'Bouclier de Frappe', 64.99, 'BouclierFrappe.jpg'),
		('e3131f44-d2ea-4e4f-bbb1-a2da5a601a07', '22f9a964-5876-4b92-9041-b76732f7eb86', 'Sac Entrainement sur Base', 150.99, 'SacEntrainement.jpg'),
		('3794b7b8-7ad5-4ff5-b398-cea37b8b1141', '22f9a964-5876-4b92-9041-b76732f7eb86', 'Cible de Frappe', 29.99, 'CibleFrappe.jpg'),
		('b0a08ada-d52d-471d-8702-09dbfeb79c65', '967e0dd8-7568-4d7d-8980-3d3aa3cdd044', 'Adidas Grand Master', 179.99, 'AdidasGrandMaster.jpg'),
		('bc71c202-2c4b-4d8f-809d-4ac326102cfc', '967e0dd8-7568-4d7d-8980-3d3aa3cdd044', 'Dobuk Poly/Coton', 44.99, 'Dobuk.jpg'),
		('39901ba9-17e5-4fae-9d92-b9bcd724743e', '967e0dd8-7568-4d7d-8980-3d3aa3cdd044', 'Taekwondo Adidas', 49.99, 'TaekwondoAdidas.jpg'),
		('4f04cfdf-1f61-4635-bc22-ac4836510a5c', '967e0dd8-7568-4d7d-8980-3d3aa3cdd044', 'TKD Adidas Etudiant', 49.99, 'TkdEtudiant.jpg')




Insert into dbo.[Cours] (Id, Category, Price, Age, Horaire, Image)
values ('80e38325-210e-4e49-bc41-e95d39d41a95', 'Débutant', 75.00, '6- 12 ans','Samedi 9h00 - 10h00', 'debutant6a12ans.jpg'),
       ('bc0689a7-6d7d-4936-8834-a0583dcd87d5', 'Blanches 1 et 2', 85.00, '6 - 12 ans', 'Samedi 9h00 - 10h15', 'blanche12.jpg'),
	   ('a505323e-4ee6-42f0-925d-0a01a00f3487', 'Jaune et plus', 110.00, '6 - 12 ans', 'Samedi 10h15 - 11h30', 'jaune+.jpg'),
	   ('57a5ec05-b783-43c6-8176-7b3ebd5afae1', 'Débutant', 130.00, '13 ans et plus', 'Mardi et Jeudi 19h30 à 20h45', 'debutant13+.jpg'),
	   ('e9a34f13-5957-45cf-ac9d-ee1c9fdf2b08', 'Jaune 1 et 2', 140.00, '13 ans et plus', 'Mardi et Jeudi 19h30 à 20h45', 'jaune12.jpg'),
	   ('8cf82208-86d6-4688-a039-0e3408543acd', 'Verte et plus', 140.00, '13 ans et plus', 'Lundi et Mercredi 19h30 à 20h45', 'verte+.jpg')


GO




