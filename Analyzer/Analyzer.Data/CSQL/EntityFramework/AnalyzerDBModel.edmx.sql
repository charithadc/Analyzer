
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/20/2018 16:47:30
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

IF OBJECT_ID(N'[dbo].[T_Price]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_Price];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'T_Price'
CREATE TABLE [dbo].[T_Price] (
    [OId] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Quarter] int  NOT NULL,
    [COCR] float  NULL,
    [PARQ] float  NULL,
    [LALU] float  NULL,
    [REXP] float  NULL,
    [CCS] float  NULL,
    [KDL] float  NULL,
    [SOY] float  NULL,
    [HHL] float  NULL,
    [SEYB] float  NULL,
    [CDB] float  NULL,
    [LFIN] float  NULL,
    [LWL] float  NULL,
    [CIND] float  NULL,
    [DIPD] float  NULL,
    [LOLC] float  NULL,
    [NDB] float  NULL,
    [ACL] float  NULL,
    [SAMP] float  NULL,
    [TPL] float  NULL,
    [CFIN] float  NULL,
    [RCL] float  NULL,
    [DIMO] float  NULL,
    [BLI] float  NULL,
    [REG] float  NULL,
    [ALUF] float  NULL,
    [ARPI] float  NULL,
    [HDFC] float  NULL,
    [COLO] float  NULL,
    [VFIN] float  NULL,
    [PMB] float  NULL,
    [CRL] float  NULL,
    [TJL] float  NULL,
    [GRAN] float  NULL,
    [TAFL] float  NULL,
    [UML] float  NULL,
    [HAYL] float  NULL,
    [AAIC] float  NULL,
    [HNB] float  NULL,
    [BRWN] float  NULL,
    [CIC] float  NULL,
    [DIST] float  NULL,
    [LION] float  NULL,
    [LGL] float  NULL,
    [NTB] float  NULL,
    [DFCC] float  NULL,
    [SUN] float  NULL,
    [LLUB] float  NULL,
    [TYRE] float  NULL,
    [ASIR] float  NULL,
    [CARG] float  NULL,
    [LHCL] float  NULL,
    [BFL] float  NULL,
    [NEST] float  NULL,
    [GUAR] float  NULL,
    [CTC] float  NULL,
    [KAPI] float  NULL,
    [JKH] float  NULL,
    [LIOC] float  NULL,
    [CLND] float  NULL,
    [AHUN] float  NULL,
    [TKYO] float  NULL,
    [SPEN] float  NULL,
    [COMB] float  NULL,
    [MELS] float  NULL,
    [SLTL] float  NULL,
    [CTHR] float  NULL,
    [CARS] float  NULL,
    [CINS] float  NULL,
    [AEL] float  NULL,
    [BUKI] float  NULL,
    [AHPL] float  NULL,
    [SINS] float  NULL
);
GO

-- Creating table 'T_EPS'
CREATE TABLE [dbo].[T_EPS] (
    [OId] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Quarter] int  NOT NULL,
    [COCR] float  NULL,
    [PARQ] float  NULL,
    [LALU] float  NULL,
    [REXP] float  NULL,
    [CCS] float  NULL,
    [KDL] float  NULL,
    [SOY] float  NULL,
    [HHL] float  NULL,
    [SEYB] float  NULL,
    [CDB] float  NULL,
    [LFIN] float  NULL,
    [LWL] float  NULL,
    [CIND] float  NULL,
    [DIPD] float  NULL,
    [LOLC] float  NULL,
    [NDB] float  NULL,
    [ACL] float  NULL,
    [SAMP] float  NULL,
    [TPL] float  NULL,
    [CFIN] float  NULL,
    [RCL] float  NULL,
    [DIMO] float  NULL,
    [BLI] float  NULL,
    [REG] float  NULL,
    [ALUF] float  NULL,
    [ARPI] float  NULL,
    [HDFC] float  NULL,
    [COLO] float  NULL,
    [VFIN] float  NULL,
    [PMB] float  NULL,
    [CRL] float  NULL,
    [TJL] float  NULL,
    [GRAN] float  NULL,
    [TAFL] float  NULL,
    [UML] float  NULL,
    [HAYL] float  NULL,
    [AAIC] float  NULL,
    [HNB] float  NULL,
    [BRWN] float  NULL,
    [CIC] float  NULL,
    [DIST] float  NULL,
    [LION] float  NULL,
    [LGL] float  NULL,
    [NTB] float  NULL,
    [DFCC] float  NULL,
    [SUN] float  NULL,
    [LLUB] float  NULL,
    [TYRE] float  NULL,
    [ASIR] float  NULL,
    [CARG] float  NULL,
    [LHCL] float  NULL,
    [BFL] float  NULL,
    [NEST] float  NULL,
    [GUAR] float  NULL,
    [CTC] float  NULL,
    [KAPI] float  NULL,
    [JKH] float  NULL,
    [LIOC] float  NULL,
    [CLND] float  NULL,
    [AHUN] float  NULL,
    [TKYO] float  NULL,
    [SPEN] float  NULL,
    [COMB] float  NULL,
    [MELS] float  NULL,
    [SLTL] float  NULL,
    [CTHR] float  NULL,
    [CARS] float  NULL,
    [CINS] float  NULL,
    [AEL] float  NULL,
    [BUKI] float  NULL,
    [AHPL] float  NULL,
    [SINS] float  NULL
);
GO

-- Creating table 'T_EPS_Audited'
CREATE TABLE [dbo].[T_EPS_Audited] (
    [OId] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Quarter] int  NOT NULL,
    [COCR] float  NULL,
    [PARQ] float  NULL,
    [LALU] float  NULL,
    [REXP] float  NULL,
    [CCS] float  NULL,
    [KDL] float  NULL,
    [SOY] float  NULL,
    [HHL] float  NULL,
    [SEYB] float  NULL,
    [CDB] float  NULL,
    [LFIN] float  NULL,
    [LWL] float  NULL,
    [CIND] float  NULL,
    [DIPD] float  NULL,
    [LOLC] float  NULL,
    [NDB] float  NULL,
    [ACL] float  NULL,
    [SAMP] float  NULL,
    [TPL] float  NULL,
    [CFIN] float  NULL,
    [RCL] float  NULL,
    [DIMO] float  NULL,
    [BLI] float  NULL,
    [REG] float  NULL,
    [ALUF] float  NULL,
    [ARPI] float  NULL,
    [HDFC] float  NULL,
    [COLO] float  NULL,
    [VFIN] float  NULL,
    [PMB] float  NULL,
    [CRL] float  NULL,
    [TJL] float  NULL,
    [GRAN] float  NULL,
    [TAFL] float  NULL,
    [UML] float  NULL,
    [HAYL] float  NULL,
    [AAIC] float  NULL,
    [HNB] float  NULL,
    [BRWN] float  NULL,
    [CIC] float  NULL,
    [DIST] float  NULL,
    [LION] float  NULL,
    [LGL] float  NULL,
    [NTB] float  NULL,
    [DFCC] float  NULL,
    [SUN] float  NULL,
    [LLUB] float  NULL,
    [TYRE] float  NULL,
    [ASIR] float  NULL,
    [CARG] float  NULL,
    [LHCL] float  NULL,
    [BFL] float  NULL,
    [NEST] float  NULL,
    [GUAR] float  NULL,
    [CTC] float  NULL,
    [KAPI] float  NULL,
    [JKH] float  NULL,
    [LIOC] float  NULL,
    [CLND] float  NULL,
    [AHUN] float  NULL,
    [TKYO] float  NULL,
    [SPEN] float  NULL,
    [COMB] float  NULL,
    [MELS] float  NULL,
    [SLTL] float  NULL,
    [CTHR] float  NULL,
    [CARS] float  NULL,
    [CINS] float  NULL,
    [AEL] float  NULL,
    [BUKI] float  NULL,
    [AHPL] float  NULL,
    [SINS] float  NULL
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