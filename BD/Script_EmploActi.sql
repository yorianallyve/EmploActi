USE [master]
GO
/****** Object:  Database [EmploActi]    Script Date: 3/29/2019 9:38:21 PM ******/
CREATE DATABASE [EmploActi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmploActi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmploActi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmploActi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmploActi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EmploActi] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmploActi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmploActi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmploActi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmploActi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmploActi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmploActi] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmploActi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmploActi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmploActi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmploActi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmploActi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmploActi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmploActi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmploActi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmploActi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmploActi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmploActi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmploActi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmploActi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmploActi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmploActi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmploActi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmploActi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmploActi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmploActi] SET  MULTI_USER 
GO
ALTER DATABASE [EmploActi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmploActi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmploActi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmploActi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmploActi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmploActi] SET QUERY_STORE = OFF
GO
USE [EmploActi]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 3/29/2019 9:38:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[ActivitiesCode] [int] IDENTITY(1,1) NOT NULL,
	[NameActivities] [nvarchar](250) NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[ActivitiesCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeActivity]    Script Date: 3/29/2019 9:38:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeActivity](
	[CodeTimeActivity] [int] IDENTITY(1,1) NOT NULL,
	[ActivitiesCode] [int] NOT NULL,
	[DateActivity] [date] NOT NULL,
	[Hours] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_TimeActivity] PRIMARY KEY CLUSTERED 
(
	[CodeTimeActivity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/29/2019 9:38:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[NameUser] [nvarchar](80) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Activities] ON 

INSERT [dbo].[Activities] ([ActivitiesCode], [NameActivities], [IdUser]) VALUES (1, N'Análisis del requerimiento 1', 1)
INSERT [dbo].[Activities] ([ActivitiesCode], [NameActivities], [IdUser]) VALUES (2, N'Desarrollo de calendario1', 1)
INSERT [dbo].[Activities] ([ActivitiesCode], [NameActivities], [IdUser]) VALUES (3, N'Desarrollo de calendario', 2)
INSERT [dbo].[Activities] ([ActivitiesCode], [NameActivities], [IdUser]) VALUES (11, N'Resolución de bugs', 1)
SET IDENTITY_INSERT [dbo].[Activities] OFF
SET IDENTITY_INSERT [dbo].[TimeActivity] ON 

INSERT [dbo].[TimeActivity] ([CodeTimeActivity], [ActivitiesCode], [DateActivity], [Hours], [IdUser]) VALUES (1, 3, CAST(N'2019-03-28' AS Date), 6, 2)
INSERT [dbo].[TimeActivity] ([CodeTimeActivity], [ActivitiesCode], [DateActivity], [Hours], [IdUser]) VALUES (2, 2, CAST(N'2019-03-29' AS Date), 2, 1)
INSERT [dbo].[TimeActivity] ([CodeTimeActivity], [ActivitiesCode], [DateActivity], [Hours], [IdUser]) VALUES (7, 1, CAST(N'2019-03-02' AS Date), 8, 1)
INSERT [dbo].[TimeActivity] ([CodeTimeActivity], [ActivitiesCode], [DateActivity], [Hours], [IdUser]) VALUES (8, 2, CAST(N'2019-03-21' AS Date), 3, 1)
INSERT [dbo].[TimeActivity] ([CodeTimeActivity], [ActivitiesCode], [DateActivity], [Hours], [IdUser]) VALUES (11, 1, CAST(N'2019-03-22' AS Date), 1, 1)
INSERT [dbo].[TimeActivity] ([CodeTimeActivity], [ActivitiesCode], [DateActivity], [Hours], [IdUser]) VALUES (12, 2, CAST(N'2019-03-14' AS Date), 1, 1)
INSERT [dbo].[TimeActivity] ([CodeTimeActivity], [ActivitiesCode], [DateActivity], [Hours], [IdUser]) VALUES (13, 11, CAST(N'2019-03-13' AS Date), 1, 1)
INSERT [dbo].[TimeActivity] ([CodeTimeActivity], [ActivitiesCode], [DateActivity], [Hours], [IdUser]) VALUES (14, 11, CAST(N'2019-03-13' AS Date), 1, 1)
INSERT [dbo].[TimeActivity] ([CodeTimeActivity], [ActivitiesCode], [DateActivity], [Hours], [IdUser]) VALUES (15, 11, CAST(N'2019-03-13' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[TimeActivity] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [NameUser], [Password]) VALUES (1, N'Dante', N'123')
INSERT [dbo].[User] ([IdUser], [NameUser], [Password]) VALUES (2, N'Venus', N'987')
INSERT [dbo].[User] ([IdUser], [NameUser], [Password]) VALUES (3, N'Juan', N'10293877')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_User]
GO
ALTER TABLE [dbo].[TimeActivity]  WITH CHECK ADD  CONSTRAINT [FK_TimeActivity_Activities] FOREIGN KEY([ActivitiesCode])
REFERENCES [dbo].[Activities] ([ActivitiesCode])
GO
ALTER TABLE [dbo].[TimeActivity] CHECK CONSTRAINT [FK_TimeActivity_Activities]
GO
ALTER TABLE [dbo].[TimeActivity]  WITH CHECK ADD  CONSTRAINT [FK_TimeActivity_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[TimeActivity] CHECK CONSTRAINT [FK_TimeActivity_User]
GO
USE [master]
GO
ALTER DATABASE [EmploActi] SET  READ_WRITE 
GO
