
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/20/2018 12:47:30
-- Generated from EDMX file: C:\Projects\Analyzer\trunk\Analyzer\Analyzer.Data\CSQL\EntityFramework\AnalyzerDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AnalyzerDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'T_Price'
CREATE TABLE [dbo].[T_Price] (
    [OId] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Quarter] int  NOT NULL,
    [COCR] nvarchar(max)  NOT NULL,
    [PARQ] nvarchar(max)  NOT NULL,
    [LALU] nvarchar(max)  NOT NULL,
    [REXP] nvarchar(max)  NOT NULL,
    [CCS] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'T_EPS'
CREATE TABLE [dbo].[T_EPS] (
    [OId] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Quarter] int  NOT NULL,
    [COCR] nvarchar(max)  NOT NULL,
    [PARQ] nvarchar(max)  NOT NULL,
    [LALU] nvarchar(max)  NOT NULL,
    [REXP] nvarchar(max)  NOT NULL,
    [CCS] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'T_EPS_Audited'
CREATE TABLE [dbo].[T_EPS_Audited] (
    [OId] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Quarter] int  NOT NULL,
    [COCR] nvarchar(max)  NOT NULL,
    [PARQ] nvarchar(max)  NOT NULL,
    [LALU] nvarchar(max)  NOT NULL,
    [REXP] nvarchar(max)  NOT NULL,
    [CCS] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OId] in table 'T_Price'
ALTER TABLE [dbo].[T_Price]
ADD CONSTRAINT [PK_T_Price]
    PRIMARY KEY CLUSTERED ([OId] ASC);
GO

-- Creating primary key on [OId] in table 'T_EPS'
ALTER TABLE [dbo].[T_EPS]
ADD CONSTRAINT [PK_T_EPS]
    PRIMARY KEY CLUSTERED ([OId] ASC);
GO

-- Creating primary key on [OId] in table 'T_EPS_Audited'
ALTER TABLE [dbo].[T_EPS_Audited]
ADD CONSTRAINT [PK_T_EPS_Audited]
    PRIMARY KEY CLUSTERED ([OId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------