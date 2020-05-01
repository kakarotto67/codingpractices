
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/03/2016 18:13:07
-- Generated from EDMX file: D:\GIT_TFS\TL_Security_Project\GlobalCommercialBankLimited\GCBL.DataAccess\GcblPrincipalDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GcblPrincipalDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAccounts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserAccounts'
CREATE TABLE [dbo].[UserAccounts] (
    [UserId] bigint IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [Password] nvarchar(1024)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'UserAccounts'
ALTER TABLE [dbo].[UserAccounts]
ADD CONSTRAINT [PK_UserAccounts]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------