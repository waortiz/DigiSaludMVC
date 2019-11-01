USE [master]
GO
/****** Object:  Database [DigiSalud]    Script Date: 31/10/2019 20:45:10 ******/
CREATE DATABASE [DigiSalud]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DigiSalud', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DigiSalud.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DigiSalud_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DigiSalud_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DigiSalud] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DigiSalud].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DigiSalud] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DigiSalud] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DigiSalud] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DigiSalud] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DigiSalud] SET ARITHABORT OFF 
GO
ALTER DATABASE [DigiSalud] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DigiSalud] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DigiSalud] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DigiSalud] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DigiSalud] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DigiSalud] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DigiSalud] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DigiSalud] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DigiSalud] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DigiSalud] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DigiSalud] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DigiSalud] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DigiSalud] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DigiSalud] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DigiSalud] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DigiSalud] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DigiSalud] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DigiSalud] SET RECOVERY FULL 
GO
ALTER DATABASE [DigiSalud] SET  MULTI_USER 
GO
ALTER DATABASE [DigiSalud] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DigiSalud] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DigiSalud] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DigiSalud] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DigiSalud] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DigiSalud', N'ON'
GO
ALTER DATABASE [DigiSalud] SET QUERY_STORE = OFF
GO
USE [DigiSalud]
GO
/****** Object:  Table [dbo].[Antecedentes]    Script Date: 31/10/2019 20:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antecedentes](
	[IdAntecedente] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Antecedentes] PRIMARY KEY CLUSTERED 
(
	[IdAntecedente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AntecedentesCliente]    Script Date: 31/10/2019 20:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AntecedentesCliente](
	[IdCliente] [int] NOT NULL,
	[IdAntecedente] [int] NOT NULL,
 CONSTRAINT [PK_AntecedentesCliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[IdAntecedente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 31/10/2019 20:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[PrimerNombre] [nvarchar](50) NOT NULL,
	[SegundoNombre] [nvarchar](50) NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[NumeroDocumento] [nvarchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[IdSexo] [int] NOT NULL,
	[Cotizante] [bit] NOT NULL,
	[Observaciones] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexo]    Script Date: 31/10/2019 20:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexo](
	[IdSexo] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sexo] PRIMARY KEY CLUSTERED 
(
	[IdSexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDocumento]    Script Date: 31/10/2019 20:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDocumento](
	[IdTipoDocumento] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TiposDocumento] PRIMARY KEY CLUSTERED 
(
	[IdTipoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Antecedentes] ([IdAntecedente], [Nombre]) VALUES (1, N'Hipertensión')
INSERT [dbo].[Antecedentes] ([IdAntecedente], [Nombre]) VALUES (2, N'Aneurisma')
INSERT [dbo].[Antecedentes] ([IdAntecedente], [Nombre]) VALUES (3, N'ACV')
INSERT [dbo].[AntecedentesCliente] ([IdCliente], [IdAntecedente]) VALUES (5, 1)
INSERT [dbo].[AntecedentesCliente] ([IdCliente], [IdAntecedente]) VALUES (5, 2)
INSERT [dbo].[AntecedentesCliente] ([IdCliente], [IdAntecedente]) VALUES (5, 3)
INSERT [dbo].[AntecedentesCliente] ([IdCliente], [IdAntecedente]) VALUES (6, 1)
INSERT [dbo].[AntecedentesCliente] ([IdCliente], [IdAntecedente]) VALUES (6, 2)
INSERT [dbo].[AntecedentesCliente] ([IdCliente], [IdAntecedente]) VALUES (6, 3)
INSERT [dbo].[AntecedentesCliente] ([IdCliente], [IdAntecedente]) VALUES (7, 1)
INSERT [dbo].[Sexo] ([IdSexo], [Nombre]) VALUES (1, N'Femenino')
INSERT [dbo].[Sexo] ([IdSexo], [Nombre]) VALUES (2, N'Masculino')
INSERT [dbo].[TiposDocumento] ([IdTipoDocumento], [Nombre]) VALUES (1, N'Cédula de Ciudadanía')
INSERT [dbo].[TiposDocumento] ([IdTipoDocumento], [Nombre]) VALUES (2, N'Tarjeta de Identidad')
INSERT [dbo].[TiposDocumento] ([IdTipoDocumento], [Nombre]) VALUES (3, N'Tarjeta de Extranjería')
/****** Object:  StoredProcedure [dbo].[IngresarAntecedente]    Script Date: 31/10/2019 20:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IngresarAntecedente]

		    @IdCliente bigint
		   ,@IdAntecedente int
AS
BEGIN

INSERT INTO [dbo].[AntecedentesCliente]
           ([IdCliente]
           ,[IdAntecedente])
     VALUES
           (@IdCliente
           ,@IdAntecedente)

END
GO
/****** Object:  StoredProcedure [dbo].[IngresarCliente]    Script Date: 31/10/2019 20:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IngresarCliente]

			@PrimerNombre nvarchar(50)
           ,@SegundoNombre nvarchar(50) = null
           ,@PrimerApellido nvarchar(50)
           ,@SegundoApellido nvarchar(50) = null
           ,@IdTipoDocumento int
           ,@NumeroDocumento nvarchar(50)
           ,@FechaNacimiento datetime
           ,@IdSexo int
           ,@Cotizante bit
		   ,@Observaciones nvarchar(max) = null
		   ,@IdCliente bigint OUTPUT 	
AS
BEGIN


INSERT INTO [dbo].[Clientes]
           (
            [PrimerNombre]
           ,[SegundoNombre]
           ,[PrimerApellido]
           ,[SegundoApellido]
           ,[IdTipoDocumento]
           ,[NumeroDocumento]
           ,[FechaNacimiento]
           ,[IdSexo]
           ,[Cotizante]
		   ,[Observaciones])
     VALUES
           (
            @PrimerNombre
           ,@SegundoNombre
           ,@PrimerApellido
           ,@SegundoApellido
           ,@IdTipoDocumento
           ,@NumeroDocumento
           ,@FechaNacimiento
           ,@IdSexo
           ,@Cotizante
		   ,@Observaciones)

    SET @IdCliente = @@IDENTITY

END
GO
USE [master]
GO
ALTER DATABASE [DigiSalud] SET  READ_WRITE 
GO
