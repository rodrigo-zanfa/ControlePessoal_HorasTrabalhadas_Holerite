IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [APIUsuario] (
    [IdUsuario] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    CONSTRAINT [PK_APIUsuario] PRIMARY KEY ([IdUsuario])
);
GO

CREATE TABLE [APIPonto] (
    [IdPonto] int NOT NULL IDENTITY,
    [IdUsuario] int NOT NULL,
    [DataPonto] date NOT NULL,
    [HoraPonto] time NOT NULL,
    [DataHoraInclusao] datetime NOT NULL,
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APIPonto] PRIMARY KEY ([IdPonto]),
    CONSTRAINT [FK_APIPonto_APIUsuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [APIUsuario] ([IdUsuario])
);
GO

CREATE INDEX [IX_APIPonto_IdUsuario] ON [APIPonto] ([IdUsuario]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211222025204_01CreateDb', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [APIAusencia] (
    [IdAusencia] int NOT NULL IDENTITY,
    [IdUsuario] int NOT NULL,
    [DataAusencia] date NOT NULL,
    [HoraInicialAusencia] time NOT NULL,
    [HoraFinalAusencia] time NOT NULL,
    [DataHoraInclusao] datetime NOT NULL,
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APIAusencia] PRIMARY KEY ([IdAusencia]),
    CONSTRAINT [FK_APIAusencia_APIUsuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [APIUsuario] ([IdUsuario])
);
GO

CREATE INDEX [IX_APIAusencia_IdUsuario] ON [APIAusencia] ([IdUsuario]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211223020231_02Ausencia', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [APIUsuario] ADD [DataHoraAlteracao] datetime NULL;
GO

ALTER TABLE [APIUsuario] ADD [DataHoraInclusao] datetime NOT NULL DEFAULT '0001-01-01T00:00:00.000';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220106235713_03Usuario', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [APISalario] (
    [IdSalario] int NOT NULL IDENTITY,
    [IdUsuario] int NOT NULL,
    [DataVigenciaInicial] date NOT NULL,
    [Valor] numeric(8,2) NOT NULL,
    [DataHoraInclusao] datetime NOT NULL,
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APISalario] PRIMARY KEY ([IdSalario]),
    CONSTRAINT [FK_APISalario_APIUsuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [APIUsuario] ([IdUsuario])
);
GO

CREATE INDEX [IX_APISalario_IdUsuario] ON [APISalario] ([IdUsuario]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220111001442_04Salario', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [APISalarioMinimo] (
    [IdSalarioMinimo] int NOT NULL IDENTITY,
    [DataVigenciaInicial] date NOT NULL,
    [Valor] numeric(8,2) NOT NULL,
    [DataHoraInclusao] datetime NOT NULL DEFAULT (getdate()),
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APISalarioMinimo] PRIMARY KEY ([IdSalarioMinimo])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSalarioMinimo', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APISalarioMinimo]'))
    SET IDENTITY_INSERT [APISalarioMinimo] ON;
INSERT INTO [APISalarioMinimo] ([IdSalarioMinimo], [DataHoraAlteracao], [DataVigenciaInicial], [Valor])
VALUES (1, NULL, '1994-07-01', 64.79),
(30, NULL, '2020-02-01', 1045.0),
(29, NULL, '2020-01-01', 1039.0),
(28, NULL, '2019-01-01', 998.0),
(27, NULL, '2018-01-01', 954.0),
(26, NULL, '2017-01-01', 937.0),
(25, NULL, '2016-01-01', 880.0),
(24, NULL, '2015-01-01', 788.0),
(23, NULL, '2014-01-01', 724.0),
(22, NULL, '2013-01-01', 678.0),
(21, NULL, '2012-01-01', 622.0),
(20, NULL, '2011-03-01', 545.0),
(19, NULL, '2011-01-01', 540.0),
(18, NULL, '2010-01-01', 510.0),
(17, NULL, '2009-02-01', 465.0),
(16, NULL, '2008-03-01', 415.0),
(15, NULL, '2007-04-01', 380.0),
(14, NULL, '2006-04-01', 350.0),
(13, NULL, '2005-05-01', 300.0),
(12, NULL, '2004-05-01', 260.0),
(11, NULL, '2003-04-01', 240.0),
(10, NULL, '2002-04-01', 200.0),
(9, NULL, '2001-04-01', 180.0),
(8, NULL, '2000-04-03', 151.0),
(7, NULL, '1999-05-01', 136.0),
(6, NULL, '1998-05-01', 130.0),
(5, NULL, '1997-05-01', 120.0),
(4, NULL, '1996-05-01', 112.0),
(3, NULL, '1995-05-01', 100.0),
(2, NULL, '1994-09-01', 70.0),
(31, NULL, '2021-01-01', 1100.0),
(32, NULL, '2022-01-01', 1212.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSalarioMinimo', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APISalarioMinimo]'))
    SET IDENTITY_INSERT [APISalarioMinimo] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220112024938_05SalarioMinimo', N'5.0.13');
GO

COMMIT;
GO

