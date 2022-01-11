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

