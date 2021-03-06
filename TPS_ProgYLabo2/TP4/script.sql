USE [master]
GO
/****** Object:  Database [tp4_ bbdd]    Script Date: 22/11/2020 21:18:30 ******/
CREATE DATABASE [tp4_ bbdd]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tp4_ bbdd', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tp4_ bbdd.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'tp4_ bbdd_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tp4_ bbdd_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [tp4_ bbdd] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tp4_ bbdd].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tp4_ bbdd] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET ARITHABORT OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tp4_ bbdd] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tp4_ bbdd] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tp4_ bbdd] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tp4_ bbdd] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tp4_ bbdd] SET  MULTI_USER 
GO
ALTER DATABASE [tp4_ bbdd] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tp4_ bbdd] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tp4_ bbdd] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tp4_ bbdd] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [tp4_ bbdd] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [tp4_ bbdd] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [tp4_ bbdd] SET QUERY_STORE = OFF
GO
USE [tp4_ bbdd]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 22/11/2020 21:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Precio] [float] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[productos] ON 

INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (1, N'Teclado', N'BlackWidow Chroma V2', N'Razer', 15230)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (2, N'Teclado', N'G Pro Gaming', N'Logitech', 10200)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (3, N'Mouse', N'Pulsefire Haste', N'HyperX', 5400)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (4, N'Mouse', N'Aivia Krypton', N'Gigabyte', 6800)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (5, N'Mouse', N'PruebaMouse', N'Gigabyte', 123)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (6, N'Teclado', N'teclprueba', N'Razer', 456)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (7, N'Teclado', N'eqweqw', N'Razer', 4568)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (8, N'Mouse', N'lalala', N'Gigabyte', 4567)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (15, N'Teclado', N'pruebasetter', N'Razer', 0)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (20, N'Mouse', N'pruebamapping', N'Gigabyte', 458)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (23, N'Mouse', N'pruebahiloload', N'Razer', 5688)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (24, N'Teclado', N'pruebahiloload', N'Razer', 4566)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (25, N'Mouse', N'pruebahiloloadagain', N'Razer', 75)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (26, N'Mouse', N'pruebadow', N'HyperX', 456)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (27, N'Mouse', N'PRUEBAABORT', N'Gigabyte', 4568)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (29, N'Mouse', N'pruebafin', N'Gigabyte', 785)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (30, N'Mouse', N'jfkldsd', N'Gigabyte', 1235)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (9, N'Mouse', N'Mouse Prueba', N'HyperX', 789)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (14, N'Mouse', N'pruebaxmlser', N'Razer', 4567)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (10, N'Teclado', N'lalala', N'Razer', 456)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (11, N'Mouse', N'pepe', N'Gigabyte', 4568)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (12, N'Mouse', N'pruebahilo', N'Gigabyte', 4567)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (13, N'Teclado', N'pruebahilo2', N'Razer', 458)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (16, N'Teclado', N'pruebathread', N'Gigabyte', 7845)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (17, N'Mouse', N'pruethr2', N'Razer', 5846)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (18, N'Mouse', N'PRUEBAPOSTOP', N'Razer', 458)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (19, N'Mouse', N'cambioproyprueba', N'Gigabyte', 754)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (22, N'Mouse', N'cambio nombre hilo', N'Razer', 7351)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (28, N'Mouse', N'Catch de abort', N'Razer', 4568)
INSERT [dbo].[productos] ([Id], [Tipo], [Nombre], [Marca], [Precio]) VALUES (21, N'Mouse', N'pruebaload', N'Gigabyte', 1254)
SET IDENTITY_INSERT [dbo].[productos] OFF
GO
USE [master]
GO
ALTER DATABASE [tp4_ bbdd] SET  READ_WRITE 
GO
