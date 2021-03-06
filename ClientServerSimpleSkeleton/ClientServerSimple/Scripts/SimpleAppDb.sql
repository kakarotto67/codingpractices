USE [master]
GO
/****** Object:  Database [SimpleAppDb]    Script Date: 07/11/2013 11:13:30 ******/
CREATE DATABASE [SimpleAppDb] ON  PRIMARY 
( NAME = N'SimpleAppDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\SimpleAppDb.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SimpleAppDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\SimpleAppDb.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SimpleAppDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimpleAppDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SimpleAppDb] SET ANSI_NULL_DEFAULT ON
GO
ALTER DATABASE [SimpleAppDb] SET ANSI_NULLS ON
GO
ALTER DATABASE [SimpleAppDb] SET ANSI_PADDING ON
GO
ALTER DATABASE [SimpleAppDb] SET ANSI_WARNINGS ON
GO
ALTER DATABASE [SimpleAppDb] SET ARITHABORT ON
GO
ALTER DATABASE [SimpleAppDb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SimpleAppDb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SimpleAppDb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SimpleAppDb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SimpleAppDb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SimpleAppDb] SET CURSOR_DEFAULT  LOCAL
GO
ALTER DATABASE [SimpleAppDb] SET CONCAT_NULL_YIELDS_NULL ON
GO
ALTER DATABASE [SimpleAppDb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SimpleAppDb] SET QUOTED_IDENTIFIER ON
GO
ALTER DATABASE [SimpleAppDb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SimpleAppDb] SET  DISABLE_BROKER
GO
ALTER DATABASE [SimpleAppDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SimpleAppDb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SimpleAppDb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SimpleAppDb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SimpleAppDb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SimpleAppDb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SimpleAppDb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SimpleAppDb] SET  READ_WRITE
GO
ALTER DATABASE [SimpleAppDb] SET RECOVERY FULL
GO
ALTER DATABASE [SimpleAppDb] SET  MULTI_USER
GO
ALTER DATABASE [SimpleAppDb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SimpleAppDb] SET DB_CHAINING OFF
GO
USE [SimpleAppDb]
GO
/****** Object:  Table [dbo].[Apple]    Script Date: 07/11/2013 11:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Apple](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SortName] [varchar](50) NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[Size] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
SET IDENTITY_INSERT [dbo].[Apple] ON
INSERT [dbo].[Apple] ([Id], [SortName], [Color], [Size]) VALUES (1, N'Antonovka', N'Green', N'Medium')
INSERT [dbo].[Apple] ([Id], [SortName], [Color], [Size]) VALUES (2, N'Elstar', N'YellowRed', N'Medium')
INSERT [dbo].[Apple] ([Id], [SortName], [Color], [Size]) VALUES (3, N'Ginger Gold', N'LightGreen', N'Big')
INSERT [dbo].[Apple] ([Id], [SortName], [Color], [Size]) VALUES (4, N'Foxwhelp', N'DarkRed', N'Medium')
INSERT [dbo].[Apple] ([Id], [SortName], [Color], [Size]) VALUES (5, N'Braeburn', N'Red', N'Medium')
SET IDENTITY_INSERT [dbo].[Apple] OFF
