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

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211221162312_01CreateDb', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [APIPonto] (
    [IdPonto] int NOT NULL IDENTITY,
    [IdUsuario] int NOT NULL,
    [DataPonto] date NOT NULL,
    [HoraPonto] time NOT NULL,
    [DataHoraInclusao] datetime NOT NULL,
    [DataHoraAlteracao] datetime NOT NULL,
    CONSTRAINT [PK_APIPonto] PRIMARY KEY ([IdPonto]),
    CONSTRAINT [FK_APIPonto_APIUsuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [APIUsuario] ([IdUsuario])
);
GO

CREATE INDEX [IX_APIPonto_IdUsuario] ON [APIPonto] ([IdUsuario]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211222020027_02Ponto', N'5.0.13');
GO

COMMIT;
GO

