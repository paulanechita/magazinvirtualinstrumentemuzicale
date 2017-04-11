CREATE DATABASE [MVIMDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MVIMDatabase', FILENAME = N'C:\Users\pauli\MVIMDatabase.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MVIMDatabase_log', FILENAME = N'C:\Users\pauli\MVIMDatabase_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [MagazinInstrumenteDb] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MagazinInstrumenteDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

USE [MVIMDatabase]
GO
/****** Object:  Table [dbo].[Adresa]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adresa](
	[IdAdresa] [int] IDENTITY(1,1) NOT NULL,
	[Strada] [nvarchar](250) NOT NULL,
	[Numar] [nvarchar](150) NOT NULL,
	[Oras] [nvarchar](250) NOT NULL,
	[Judet] [nvarchar](250) NOT NULL,
	[CodPostal] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Adresa] PRIMARY KEY CLUSTERED 
(
	[IdAdresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[IdCategorie] [int] IDENTITY(1,1) NOT NULL,
	[NumeCategorie] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[IdCategorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategorieProdus]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategorieProdus](
	[IdProdus] [int] NOT NULL,
	[IdCategorie] [int] NOT NULL,
	[IdCategorieProdus] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CategorieProdus] PRIMARY KEY CLUSTERED 
(
	[IdCategorieProdus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[Nume] [nvarchar](250) NOT NULL,
	[Prenume] [nvarchar](250) NOT NULL,
	[DataNasterii] [date] NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[NumarTelefon] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comanda]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda](
	[IdComanda] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdAdresa] [int] NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Data] [date] NOT NULL,
	[IdCodStatusComanda] [int] NOT NULL,
 CONSTRAINT [PK_Comanda] PRIMARY KEY CLUSTERED 
(
	[IdComanda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComandaProdus]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComandaProdus](
	[IdComandaProdus] [int] IDENTITY(1,1) NOT NULL,
	[IdComanda] [int] NOT NULL,
	[IdProdus] [int] NOT NULL,
	[NumeProdus] [nvarchar](250) NOT NULL,
	[PretProdus] [money] NOT NULL,
	[DescriereProdus] [nvarchar](max) NOT NULL,
	[Cantitate] [int] NOT NULL,
 CONSTRAINT [PK_ComandaProdus] PRIMARY KEY CLUSTERED 
(
	[IdComandaProdus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cos]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cos](
	[IdCos] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdCodStatusCos] [int] NOT NULL,
	[Data] [date] NOT NULL,
 CONSTRAINT [PK_Cos] PRIMARY KEY CLUSTERED 
(
	[IdCos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CosProdus]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CosProdus](
	[IdCos] [int] NOT NULL,
	[IdProdus] [int] NOT NULL,
	[Cantitate] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PozaProdus]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PozaProdus](
	[IdPozaProdus] [int] IDENTITY(1,1) NOT NULL,
	[IdProdus] [int] NOT NULL,
	[Poza] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_PozaProdus] PRIMARY KEY CLUSTERED 
(
	[IdPozaProdus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producator]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producator](
	[IdProducator] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Producator] PRIMARY KEY CLUSTERED 
(
	[IdProducator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Produs]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produs](
	[IdProdus] [int] IDENTITY(1,1) NOT NULL,
	[IdProducator] [int] NOT NULL,
	[NumeProdus] [nvarchar](250) NOT NULL,
	[PretProdus] [money] NOT NULL,
	[DescriereProdus] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Produs] PRIMARY KEY CLUSTERED 
(
	[IdProdus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusComanda]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusComanda](
	[IdCodStatusComanda] [int] IDENTITY(1,1) NOT NULL,
	[DescriereStatusComanda] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StatusComanda] PRIMARY KEY CLUSTERED 
(
	[IdCodStatusComanda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusCos]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusCos](
	[IdCodStatusCos] [int] IDENTITY(1,1) NOT NULL,
	[DescriereStatusCos] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StatusCos] PRIMARY KEY CLUSTERED 
(
	[IdCodStatusCos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 21.03.2017 20:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Parola] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CategorieProdus]  WITH CHECK ADD  CONSTRAINT [FK_CategorieProdus_Categorie] FOREIGN KEY([IdCategorie])
REFERENCES [dbo].[Categorie] ([IdCategorie])
GO
ALTER TABLE [dbo].[CategorieProdus] CHECK CONSTRAINT [FK_CategorieProdus_Categorie]
GO
ALTER TABLE [dbo].[CategorieProdus]  WITH CHECK ADD  CONSTRAINT [FK_CategorieProdus_Produs] FOREIGN KEY([IdProdus])
REFERENCES [dbo].[Produs] ([IdProdus])
GO
ALTER TABLE [dbo].[CategorieProdus] CHECK CONSTRAINT [FK_CategorieProdus_Produs]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO
ALTER TABLE [dbo].[Comanda]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Adresa] FOREIGN KEY([IdAdresa])
REFERENCES [dbo].[Adresa] ([IdAdresa])
GO
ALTER TABLE [dbo].[Comanda] CHECK CONSTRAINT [FK_Comanda_Adresa]
GO
ALTER TABLE [dbo].[Comanda]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Comanda] CHECK CONSTRAINT [FK_Comanda_Client]
GO
ALTER TABLE [dbo].[Comanda]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_StatusComanda] FOREIGN KEY([IdCodStatusComanda])
REFERENCES [dbo].[StatusComanda] ([IdCodStatusComanda])
GO
ALTER TABLE [dbo].[Comanda] CHECK CONSTRAINT [FK_Comanda_StatusComanda]
GO
ALTER TABLE [dbo].[ComandaProdus]  WITH CHECK ADD  CONSTRAINT [FK_ComandaProdus_Comanda] FOREIGN KEY([IdComanda])
REFERENCES [dbo].[Comanda] ([IdComanda])
GO
ALTER TABLE [dbo].[ComandaProdus] CHECK CONSTRAINT [FK_ComandaProdus_Comanda]
GO
ALTER TABLE [dbo].[ComandaProdus]  WITH CHECK ADD  CONSTRAINT [FK_ComandaProdus_Produs] FOREIGN KEY([IdProdus])
REFERENCES [dbo].[Produs] ([IdProdus])
GO
ALTER TABLE [dbo].[ComandaProdus] CHECK CONSTRAINT [FK_ComandaProdus_Produs]
GO
ALTER TABLE [dbo].[Cos]  WITH CHECK ADD  CONSTRAINT [FK_Cos_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Cos] CHECK CONSTRAINT [FK_Cos_Client]
GO
ALTER TABLE [dbo].[Cos]  WITH CHECK ADD  CONSTRAINT [FK_Cos_StatusCos] FOREIGN KEY([IdCodStatusCos])
REFERENCES [dbo].[StatusCos] ([IdCodStatusCos])
GO
ALTER TABLE [dbo].[Cos] CHECK CONSTRAINT [FK_Cos_StatusCos]
GO
ALTER TABLE [dbo].[CosProdus]  WITH CHECK ADD  CONSTRAINT [FK_CosProdus_Cos] FOREIGN KEY([IdCos])
REFERENCES [dbo].[Cos] ([IdCos])
GO
ALTER TABLE [dbo].[CosProdus] CHECK CONSTRAINT [FK_CosProdus_Cos]
GO
ALTER TABLE [dbo].[CosProdus]  WITH CHECK ADD  CONSTRAINT [FK_CosProdus_Produs] FOREIGN KEY([IdProdus])
REFERENCES [dbo].[Produs] ([IdProdus])
GO
ALTER TABLE [dbo].[CosProdus] CHECK CONSTRAINT [FK_CosProdus_Produs]
GO
ALTER TABLE [dbo].[PozaProdus]  WITH CHECK ADD  CONSTRAINT [FK_PozaProdus_Produs] FOREIGN KEY([IdProdus])
REFERENCES [dbo].[Produs] ([IdProdus])
GO
ALTER TABLE [dbo].[PozaProdus] CHECK CONSTRAINT [FK_PozaProdus_Produs]
GO
ALTER TABLE [dbo].[Produs]  WITH CHECK ADD  CONSTRAINT [FK_Produs_Producator] FOREIGN KEY([IdProducator])
REFERENCES [dbo].[Producator] ([IdProducator])
GO
ALTER TABLE [dbo].[Produs] CHECK CONSTRAINT [FK_Produs_Producator]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Rol]
GO

INSERT INTO [dbo].[Rol] (IdRol, Rol)
VALUES (1, 'Administrator')

INSERT INTO [dbo].[Rol] (IdRol, Rol)
VALUES (2, 'Client')
