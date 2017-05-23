
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2017 17:37:33
-- Generated from EDMX file: C:\Users\joach\Source\Repos\VivesTGV2\Vives.Models\VivesTGVDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VivesTGV];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBestellijn_tblBesteling]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBestellijn] DROP CONSTRAINT [FK_tblBestellijn_tblBesteling];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBestellijn_tblProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBestellijn] DROP CONSTRAINT [FK_tblBestellijn_tblProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBestelling_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBestelling] DROP CONSTRAINT [FK_tblBestelling_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_tblHotel_tblStad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHotel] DROP CONSTRAINT [FK_tblHotel_tblStad];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProduct_tblHotel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProduct] DROP CONSTRAINT [FK_tblProduct_tblHotel];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProduct_tblTraject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProduct] DROP CONSTRAINT [FK_tblProduct_tblTraject];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTraject_tblStadAankomst]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTraject] DROP CONSTRAINT [FK_tblTraject_tblStadAankomst];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTraject_tblStadVertrek]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTraject] DROP CONSTRAINT [FK_tblTraject_tblStadVertrek];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTreinplaats_tblBestellijn]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTreinplaats] DROP CONSTRAINT [FK_tblTreinplaats_tblBestellijn];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTussenlocatie_tblTraject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTussenlocatie] DROP CONSTRAINT [FK_tblTussenlocatie_tblTraject];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWinkelmand_tblProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWinkelmandlijn] DROP CONSTRAINT [FK_tblWinkelmand_tblProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWinkelmandlijn_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWinkelmandlijn] DROP CONSTRAINT [FK_tblWinkelmandlijn_AspNetUsers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tblBestellijn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBestellijn];
GO
IF OBJECT_ID(N'[dbo].[tblBestelling]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBestelling];
GO
IF OBJECT_ID(N'[dbo].[tblGebruiker]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGebruiker];
GO
IF OBJECT_ID(N'[dbo].[tblHotel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblHotel];
GO
IF OBJECT_ID(N'[dbo].[tblProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProduct];
GO
IF OBJECT_ID(N'[dbo].[tblStad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStad];
GO
IF OBJECT_ID(N'[dbo].[tblTraject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTraject];
GO
IF OBJECT_ID(N'[dbo].[tblTreinplaats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTreinplaats];
GO
IF OBJECT_ID(N'[dbo].[tblTussenlocatie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTussenlocatie];
GO
IF OBJECT_ID(N'[dbo].[tblWinkelmandlijn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWinkelmandlijn];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Voornaam] nvarchar(max)  NULL,
    [Naam] nvarchar(max)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'tblBestellijn'
CREATE TABLE [dbo].[tblBestellijn] (
    [BestellijnID] int IDENTITY(1,1) NOT NULL,
    [BestellingID] int  NOT NULL,
    [ProductID] int  NOT NULL
);
GO

-- Creating table 'tblGebruiker'
CREATE TABLE [dbo].[tblGebruiker] (
    [GebruikersID] nvarchar(128)  NOT NULL,
    [Voornaam] nvarchar(50)  NOT NULL,
    [Naam] nvarchar(50)  NOT NULL,
    [Emailadres] nvarchar(250)  NOT NULL,
    [Wachtwoord] nvarchar(70)  NOT NULL
);
GO

-- Creating table 'tblHotel'
CREATE TABLE [dbo].[tblHotel] (
    [HotelID] int IDENTITY(1,1) NOT NULL,
    [StadID] int  NOT NULL,
    [PrijsPerOvernachting] float  NOT NULL,
    [Naam] nvarchar(100)  NOT NULL,
    [Adres] nvarchar(100)  NOT NULL,
    [HotelFoto] nvarchar(250)  NOT NULL
);
GO

-- Creating table 'tblProduct'
CREATE TABLE [dbo].[tblProduct] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [TrajectID] int  NULL,
    [HotelID] int  NULL,
    [Treinklasse] tinyint  NULL
);
GO

-- Creating table 'tblStad'
CREATE TABLE [dbo].[tblStad] (
    [StadID] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tblTraject'
CREATE TABLE [dbo].[tblTraject] (
    [TrajectID] int IDENTITY(1,1) NOT NULL,
    [Vertrek] int  NOT NULL,
    [Aankomst] int  NOT NULL,
    [Tijdsstip] time  NOT NULL,
    [Reistijd] time  NOT NULL,
    [BusinessPlaatsen] int  NOT NULL,
    [EconomicPlaatsen] int  NOT NULL,
    [BusinessPrijs] float  NOT NULL,
    [EconomicPrijs] float  NOT NULL
);
GO

-- Creating table 'tblTussenlocatie'
CREATE TABLE [dbo].[tblTussenlocatie] (
    [TrajectID] int  NOT NULL,
    [Volgnummer] int  NOT NULL,
    [Naam] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tblWinkelmandlijn'
CREATE TABLE [dbo].[tblWinkelmandlijn] (
    [WinkelmandlijnID] int IDENTITY(1,1) NOT NULL,
    [GebruikersID] nvarchar(128)  NOT NULL,
    [ProductID] int  NOT NULL,
    [Naam] nvarchar(50)  NOT NULL,
    [Datum] datetime  NOT NULL
);
GO

-- Creating table 'tblTreinplaats'
CREATE TABLE [dbo].[tblTreinplaats] (
    [TreinplaatsID] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(50)  NOT NULL,
    [BestellijnID] int  NOT NULL,
    [Plaatsnummer] int  NOT NULL,
    [Treinklasse] tinyint  NOT NULL
);
GO

-- Creating table 'tblBestelling'
CREATE TABLE [dbo].[tblBestelling] (
    [BestellingID] int IDENTITY(1,1) NOT NULL,
    [GebruikersID] nvarchar(128)  NOT NULL,
    [Vertrekdatum] datetime  NOT NULL,
    [Besteldatum] datetime  NOT NULL,
    [Geannuleerd] tinyint  NOT NULL
);
GO

-- Creating table 'sysdiagrams1Set'
CREATE TABLE [dbo].[sysdiagrams1Set] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [BestellijnID] in table 'tblBestellijn'
ALTER TABLE [dbo].[tblBestellijn]
ADD CONSTRAINT [PK_tblBestellijn]
    PRIMARY KEY CLUSTERED ([BestellijnID] ASC);
GO

-- Creating primary key on [GebruikersID] in table 'tblGebruiker'
ALTER TABLE [dbo].[tblGebruiker]
ADD CONSTRAINT [PK_tblGebruiker]
    PRIMARY KEY CLUSTERED ([GebruikersID] ASC);
GO

-- Creating primary key on [HotelID] in table 'tblHotel'
ALTER TABLE [dbo].[tblHotel]
ADD CONSTRAINT [PK_tblHotel]
    PRIMARY KEY CLUSTERED ([HotelID] ASC);
GO

-- Creating primary key on [ProductID] in table 'tblProduct'
ALTER TABLE [dbo].[tblProduct]
ADD CONSTRAINT [PK_tblProduct]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [StadID] in table 'tblStad'
ALTER TABLE [dbo].[tblStad]
ADD CONSTRAINT [PK_tblStad]
    PRIMARY KEY CLUSTERED ([StadID] ASC);
GO

-- Creating primary key on [TrajectID] in table 'tblTraject'
ALTER TABLE [dbo].[tblTraject]
ADD CONSTRAINT [PK_tblTraject]
    PRIMARY KEY CLUSTERED ([TrajectID] ASC);
GO

-- Creating primary key on [TrajectID], [Volgnummer] in table 'tblTussenlocatie'
ALTER TABLE [dbo].[tblTussenlocatie]
ADD CONSTRAINT [PK_tblTussenlocatie]
    PRIMARY KEY CLUSTERED ([TrajectID], [Volgnummer] ASC);
GO

-- Creating primary key on [WinkelmandlijnID] in table 'tblWinkelmandlijn'
ALTER TABLE [dbo].[tblWinkelmandlijn]
ADD CONSTRAINT [PK_tblWinkelmandlijn]
    PRIMARY KEY CLUSTERED ([WinkelmandlijnID] ASC);
GO

-- Creating primary key on [TreinplaatsID] in table 'tblTreinplaats'
ALTER TABLE [dbo].[tblTreinplaats]
ADD CONSTRAINT [PK_tblTreinplaats]
    PRIMARY KEY CLUSTERED ([TreinplaatsID] ASC);
GO

-- Creating primary key on [BestellingID] in table 'tblBestelling'
ALTER TABLE [dbo].[tblBestelling]
ADD CONSTRAINT [PK_tblBestelling]
    PRIMARY KEY CLUSTERED ([BestellingID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams1Set'
ALTER TABLE [dbo].[sysdiagrams1Set]
ADD CONSTRAINT [PK_sysdiagrams1Set]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [ProductID] in table 'tblBestellijn'
ALTER TABLE [dbo].[tblBestellijn]
ADD CONSTRAINT [FK_tblBestellijn_tblProduct]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[tblProduct]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBestellijn_tblProduct'
CREATE INDEX [IX_FK_tblBestellijn_tblProduct]
ON [dbo].[tblBestellijn]
    ([ProductID]);
GO

-- Creating foreign key on [StadID] in table 'tblHotel'
ALTER TABLE [dbo].[tblHotel]
ADD CONSTRAINT [FK_tblHotel_tblStad]
    FOREIGN KEY ([StadID])
    REFERENCES [dbo].[tblStad]
        ([StadID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblHotel_tblStad'
CREATE INDEX [IX_FK_tblHotel_tblStad]
ON [dbo].[tblHotel]
    ([StadID]);
GO

-- Creating foreign key on [HotelID] in table 'tblProduct'
ALTER TABLE [dbo].[tblProduct]
ADD CONSTRAINT [FK_tblProduct_tblHotel]
    FOREIGN KEY ([HotelID])
    REFERENCES [dbo].[tblHotel]
        ([HotelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblHotel'
CREATE INDEX [IX_FK_tblProduct_tblHotel]
ON [dbo].[tblProduct]
    ([HotelID]);
GO

-- Creating foreign key on [TrajectID] in table 'tblProduct'
ALTER TABLE [dbo].[tblProduct]
ADD CONSTRAINT [FK_tblProduct_tblTraject]
    FOREIGN KEY ([TrajectID])
    REFERENCES [dbo].[tblTraject]
        ([TrajectID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblTraject'
CREATE INDEX [IX_FK_tblProduct_tblTraject]
ON [dbo].[tblProduct]
    ([TrajectID]);
GO

-- Creating foreign key on [Aankomst] in table 'tblTraject'
ALTER TABLE [dbo].[tblTraject]
ADD CONSTRAINT [FK_tblTraject_tblStadAankomst]
    FOREIGN KEY ([Aankomst])
    REFERENCES [dbo].[tblStad]
        ([StadID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTraject_tblStadAankomst'
CREATE INDEX [IX_FK_tblTraject_tblStadAankomst]
ON [dbo].[tblTraject]
    ([Aankomst]);
GO

-- Creating foreign key on [Vertrek] in table 'tblTraject'
ALTER TABLE [dbo].[tblTraject]
ADD CONSTRAINT [FK_tblTraject_tblStadVertrek]
    FOREIGN KEY ([Vertrek])
    REFERENCES [dbo].[tblStad]
        ([StadID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTraject_tblStadVertrek'
CREATE INDEX [IX_FK_tblTraject_tblStadVertrek]
ON [dbo].[tblTraject]
    ([Vertrek]);
GO

-- Creating foreign key on [TrajectID] in table 'tblTussenlocatie'
ALTER TABLE [dbo].[tblTussenlocatie]
ADD CONSTRAINT [FK_tblTussenlocatie_tblTraject]
    FOREIGN KEY ([TrajectID])
    REFERENCES [dbo].[tblTraject]
        ([TrajectID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [GebruikersID] in table 'tblWinkelmandlijn'
ALTER TABLE [dbo].[tblWinkelmandlijn]
ADD CONSTRAINT [FK_tblWinkelmandlijn_AspNetUsers]
    FOREIGN KEY ([GebruikersID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWinkelmandlijn_AspNetUsers'
CREATE INDEX [IX_FK_tblWinkelmandlijn_AspNetUsers]
ON [dbo].[tblWinkelmandlijn]
    ([GebruikersID]);
GO

-- Creating foreign key on [ProductID] in table 'tblWinkelmandlijn'
ALTER TABLE [dbo].[tblWinkelmandlijn]
ADD CONSTRAINT [FK_tblWinkelmand_tblProduct]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[tblProduct]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWinkelmand_tblProduct'
CREATE INDEX [IX_FK_tblWinkelmand_tblProduct]
ON [dbo].[tblWinkelmandlijn]
    ([ProductID]);
GO

-- Creating foreign key on [BestellijnID] in table 'tblTreinplaats'
ALTER TABLE [dbo].[tblTreinplaats]
ADD CONSTRAINT [FK_tblTreinplaats_tblBestellijn]
    FOREIGN KEY ([BestellijnID])
    REFERENCES [dbo].[tblBestellijn]
        ([BestellijnID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTreinplaats_tblBestellijn'
CREATE INDEX [IX_FK_tblTreinplaats_tblBestellijn]
ON [dbo].[tblTreinplaats]
    ([BestellijnID]);
GO

-- Creating foreign key on [GebruikersID] in table 'tblBestelling'
ALTER TABLE [dbo].[tblBestelling]
ADD CONSTRAINT [FK_tblBestelling_AspNetUsers]
    FOREIGN KEY ([GebruikersID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBestelling_AspNetUsers'
CREATE INDEX [IX_FK_tblBestelling_AspNetUsers]
ON [dbo].[tblBestelling]
    ([GebruikersID]);
GO

-- Creating foreign key on [BestellingID] in table 'tblBestellijn'
ALTER TABLE [dbo].[tblBestellijn]
ADD CONSTRAINT [FK_tblBestellijn_tblBesteling]
    FOREIGN KEY ([BestellingID])
    REFERENCES [dbo].[tblBestelling]
        ([BestellingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBestellijn_tblBesteling'
CREATE INDEX [IX_FK_tblBestellijn_tblBesteling]
ON [dbo].[tblBestellijn]
    ([BestellingID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------