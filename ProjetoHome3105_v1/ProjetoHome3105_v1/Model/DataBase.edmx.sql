
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/31/2017 19:03:35
-- Generated from EDMX file: D:\FERRAMENTAS DE DESENVOLVIMENTO\ASPNET\Etapa CIC\Projetos\AspNet_CIC\ProjetoHome3105_v1\ProjetoHome3105_v1\Model\DataBase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CategoriasLivros]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Livros] DROP CONSTRAINT [FK_CategoriasLivros];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Livros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Livros];
GO
IF OBJECT_ID(N'[dbo].[CategoriasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriasSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Livros'
CREATE TABLE [dbo].[Livros] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Categoria] nvarchar(max)  NOT NULL,
    [CategoriasId] int  NOT NULL,
    [Autor] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategoriasSet'
CREATE TABLE [dbo].[CategoriasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Livros'
ALTER TABLE [dbo].[Livros]
ADD CONSTRAINT [PK_Livros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriasSet'
ALTER TABLE [dbo].[CategoriasSet]
ADD CONSTRAINT [PK_CategoriasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoriasId] in table 'Livros'
ALTER TABLE [dbo].[Livros]
ADD CONSTRAINT [FK_CategoriasLivros]
    FOREIGN KEY ([CategoriasId])
    REFERENCES [dbo].[CategoriasSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriasLivros'
CREATE INDEX [IX_FK_CategoriasLivros]
ON [dbo].[Livros]
    ([CategoriasId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------