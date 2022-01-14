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

BEGIN TRANSACTION;
GO

CREATE TABLE [APIParametroTipoDado] (
    [IdParametroTipoDado] int NOT NULL IDENTITY,
    [Descricao] varchar(30) NOT NULL,
    [TamanhoMin] int NOT NULL,
    [TamanhoMax] int NOT NULL,
    [Formato] varchar(30) NULL,
    [IntervaloMin] numeric(8,2) NULL,
    [IntervaloMax] numeric(8,2) NULL,
    [DataHoraInclusao] datetime NOT NULL DEFAULT (getdate()),
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APIParametroTipoDado] PRIMARY KEY ([IdParametroTipoDado])
);
GO

CREATE TABLE [APITabelaTipo] (
    [IdTabelaTipo] int NOT NULL IDENTITY,
    [Descricao] varchar(30) NOT NULL,
    [DataHoraInclusao] datetime NOT NULL DEFAULT (getdate()),
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APITabelaTipo] PRIMARY KEY ([IdTabelaTipo])
);
GO

CREATE TABLE [APIParametro] (
    [IdParametro] int NOT NULL IDENTITY,
    [Descricao] varchar(100) NOT NULL,
    [DescricaoDetalhada] varchar(300) NOT NULL,
    [IdParametroTipoDado] int NOT NULL,
    [DataHoraInclusao] datetime NOT NULL DEFAULT (getdate()),
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APIParametro] PRIMARY KEY ([IdParametro]),
    CONSTRAINT [FK_APIParametro_APIParametroTipoDado_IdParametroTipoDado] FOREIGN KEY ([IdParametroTipoDado]) REFERENCES [APIParametroTipoDado] ([IdParametroTipoDado])
);
GO

CREATE TABLE [APITabela] (
    [IdTabela] int NOT NULL IDENTITY,
    [IdTabelaTipo] int NOT NULL,
    [DataVigenciaInicial] date NOT NULL,
    [Descricao] varchar(100) NOT NULL,
    [DataHoraInclusao] datetime NOT NULL DEFAULT (getdate()),
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APITabela] PRIMARY KEY ([IdTabela]),
    CONSTRAINT [FK_APITabela_APITabelaTipo_IdTabelaTipo] FOREIGN KEY ([IdTabelaTipo]) REFERENCES [APITabelaTipo] ([IdTabelaTipo])
);
GO

CREATE TABLE [APIParametroUsuario] (
    [IdParametroUsuario] int NOT NULL IDENTITY,
    [IdParametro] int NOT NULL,
    [IdUsuario] int NOT NULL,
    [DataVigenciaInicial] date NOT NULL,
    [Valor] varchar(30) NOT NULL,
    [DataHoraInclusao] datetime NOT NULL DEFAULT (getdate()),
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APIParametroUsuario] PRIMARY KEY ([IdParametroUsuario]),
    CONSTRAINT [FK_APIParametroUsuario_APIParametro_IdParametro] FOREIGN KEY ([IdParametro]) REFERENCES [APIParametro] ([IdParametro]),
    CONSTRAINT [FK_APIParametroUsuario_APIUsuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [APIUsuario] ([IdUsuario])
);
GO

CREATE TABLE [APITabelaItem] (
    [IdTabelaItem] int NOT NULL IDENTITY,
    [IdTabela] int NOT NULL,
    [IntervaloInicial] numeric(8,2) NOT NULL,
    [IntervaloFinal] numeric(8,2) NOT NULL,
    [Valor] numeric(8,2) NOT NULL,
    [DataHoraInclusao] datetime NOT NULL DEFAULT (getdate()),
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APITabelaItem] PRIMARY KEY ([IdTabelaItem]),
    CONSTRAINT [FK_APITabelaItem_APITabela_IdTabela] FOREIGN KEY ([IdTabela]) REFERENCES [APITabela] ([IdTabela])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametroTipoDado', N'DataHoraAlteracao', N'Descricao', N'Formato', N'IntervaloMax', N'IntervaloMin', N'TamanhoMax', N'TamanhoMin') AND [object_id] = OBJECT_ID(N'[APIParametroTipoDado]'))
    SET IDENTITY_INSERT [APIParametroTipoDado] ON;
INSERT INTO [APIParametroTipoDado] ([IdParametroTipoDado], [DataHoraAlteracao], [Descricao], [Formato], [IntervaloMax], [IntervaloMin], [TamanhoMax], [TamanhoMin])
VALUES (1, NULL, 'Monetário', '', NULL, NULL, 9, 1),
(2, NULL, 'Percentual', '', 100.0, 0.0, 6, 1),
(3, NULL, 'Data', 'dd/MM/yyyy', NULL, NULL, 10, 10),
(4, NULL, 'Hora', 'hh:mm', NULL, NULL, 5, 5);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametroTipoDado', N'DataHoraAlteracao', N'Descricao', N'Formato', N'IntervaloMax', N'IntervaloMin', N'TamanhoMax', N'TamanhoMin') AND [object_id] = OBJECT_ID(N'[APIParametroTipoDado]'))
    SET IDENTITY_INSERT [APIParametroTipoDado] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaTipo', N'DataHoraAlteracao', N'Descricao') AND [object_id] = OBJECT_ID(N'[APITabelaTipo]'))
    SET IDENTITY_INSERT [APITabelaTipo] ON;
INSERT INTO [APITabelaTipo] ([IdTabelaTipo], [DataHoraAlteracao], [Descricao])
VALUES (1, NULL, 'INSS'),
(2, NULL, 'IRPF');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaTipo', N'DataHoraAlteracao', N'Descricao') AND [object_id] = OBJECT_ID(N'[APITabelaTipo]'))
    SET IDENTITY_INSERT [APITabelaTipo] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametro', N'DataHoraAlteracao', N'Descricao', N'DescricaoDetalhada', N'IdParametroTipoDado') AND [object_id] = OBJECT_ID(N'[APIParametro]'))
    SET IDENTITY_INSERT [APIParametro] ON;
INSERT INTO [APIParametro] ([IdParametro], [DataHoraAlteracao], [Descricao], [DescricaoDetalhada], [IdParametroTipoDado])
VALUES (1, NULL, 'Horário de Entrada', 'Horário de Entrada do Usuário', 4),
(2, NULL, 'Horário de Saída', 'Horário de Saída do Usuário', 4),
(3, NULL, 'Intervalo Diário', 'Intervalo Diário do Usuário entre períodos de trabalho', 4),
(4, NULL, 'Tolerância Diária', 'Tolerância Diária (em hh:mm) para desconsiderar cálculos de Hora Extra ou Desconto', 4),
(5, NULL, 'Limite para Banco de Horas Diário', 'Limite (em hh:mm) para considerar o que fica em Banco de Horas; o excedente será considerado para pagamento em folha mensal', 4);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametro', N'DataHoraAlteracao', N'Descricao', N'DescricaoDetalhada', N'IdParametroTipoDado') AND [object_id] = OBJECT_ID(N'[APIParametro]'))
    SET IDENTITY_INSERT [APIParametro] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabela', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Descricao', N'IdTabelaTipo') AND [object_id] = OBJECT_ID(N'[APITabela]'))
    SET IDENTITY_INSERT [APITabela] ON;
INSERT INTO [APITabela] ([IdTabela], [DataHoraAlteracao], [DataVigenciaInicial], [Descricao], [IdTabelaTipo])
VALUES (27, NULL, '2005-05-01', 'INSS a partir de 05/2005', 1),
(28, NULL, '2006-04-01', 'INSS a partir de 04/2006', 1),
(29, NULL, '2006-08-01', 'INSS a partir de 08/2006', 1),
(30, NULL, '2007-04-01', 'INSS a partir de 04/2007', 1),
(31, NULL, '2008-01-01', 'INSS a partir de 01/2008', 1),
(32, NULL, '2008-03-01', 'INSS a partir de 03/2008', 1),
(33, NULL, '2009-02-01', 'INSS a partir de 02/2009', 1),
(34, NULL, '2010-01-01', 'INSS a partir de 01/2010', 1),
(35, NULL, '2010-06-01', 'INSS a partir de 06/2010', 1),
(36, NULL, '2011-01-01', 'INSS a partir de 01/2011', 1),
(39, NULL, '2013-01-01', 'INSS a partir de 01/2013', 1),
(38, NULL, '2012-01-01', 'INSS a partir de 01/2012', 1),
(26, NULL, '2004-05-01', 'INSS a partir de 05/2004', 1),
(40, NULL, '2014-01-01', 'INSS a partir de 01/2014', 1),
(41, NULL, '2015-01-01', 'INSS a partir de 01/2015', 1),
(42, NULL, '2016-01-01', 'INSS a partir de 01/2016', 1),
(43, NULL, '2017-01-01', 'INSS a partir de 01/2017', 1),
(44, NULL, '2018-01-01', 'INSS a partir de 01/2018', 1),
(45, NULL, '2019-01-01', 'INSS a partir de 01/2019', 1),
(46, NULL, '2020-01-01', 'INSS a partir de 01/2020', 1),
(47, NULL, '2020-03-01', 'INSS a partir de 03/2020', 1),
(37, NULL, '2011-07-01', 'INSS a partir de 07/2011', 1),
(25, NULL, '2004-01-01', 'INSS a partir de 01/2004', 1),
(22, NULL, '2002-06-01', 'INSS a partir de 06/2002', 1),
(23, NULL, '2003-04-01', 'INSS a partir de 04/2003', 1),
(1, NULL, '1995-01-01', 'INSS a partir de 01/1995', 1),
(2, NULL, '1995-05-01', 'INSS a partir de 05/1995', 1),
(3, NULL, '1995-08-01', 'INSS a partir de 08/1995', 1),
(4, NULL, '1996-05-01', 'INSS a partir de 05/1996', 1),
(5, NULL, '1997-01-01', 'INSS a partir de 01/1997', 1),
(6, NULL, '1997-05-01', 'INSS a partir de 05/1997', 1),
(7, NULL, '1997-06-01', 'INSS a partir de 06/1997', 1),
(8, NULL, '1998-05-01', 'INSS a partir de 05/1998', 1),
(9, NULL, '1998-06-01', 'INSS a partir de 06/1998', 1),
(10, NULL, '1998-12-01', 'INSS a partir de 12/1998', 1),
(24, NULL, '2003-06-01', 'INSS a partir de 06/2003', 1),
(11, NULL, '1999-01-01', 'INSS a partir de 01/1999', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabela', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Descricao', N'IdTabelaTipo') AND [object_id] = OBJECT_ID(N'[APITabela]'))
    SET IDENTITY_INSERT [APITabela] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabela', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Descricao', N'IdTabelaTipo') AND [object_id] = OBJECT_ID(N'[APITabela]'))
    SET IDENTITY_INSERT [APITabela] ON;
INSERT INTO [APITabela] ([IdTabela], [DataHoraAlteracao], [DataVigenciaInicial], [Descricao], [IdTabelaTipo])
VALUES (13, NULL, '1999-07-01', 'INSS a partir de 07/1999', 1),
(14, NULL, '2000-04-01', 'INSS a partir de 04/2000', 1),
(15, NULL, '2000-05-01', 'INSS a partir de 05/2000', 1),
(16, NULL, '2000-06-01', 'INSS a partir de 06/2000', 1),
(17, NULL, '2000-07-01', 'INSS a partir de 07/2000', 1),
(18, NULL, '2001-03-01', 'INSS a partir de 03/2001', 1),
(19, NULL, '2001-04-01', 'INSS a partir de 04/2001', 1),
(20, NULL, '2001-06-01', 'INSS a partir de 06/2001', 1),
(21, NULL, '2002-04-01', 'INSS a partir de 04/2002', 1),
(48, NULL, '2021-01-01', 'INSS a partir de 01/2021', 1),
(12, NULL, '1999-06-01', 'INSS a partir de 06/1999', 1),
(49, NULL, '2022-01-01', 'INSS a partir de 01/2022', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabela', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Descricao', N'IdTabelaTipo') AND [object_id] = OBJECT_ID(N'[APITabela]'))
    SET IDENTITY_INSERT [APITabela] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametroUsuario', N'DataHoraAlteracao', N'DataVigenciaInicial', N'IdParametro', N'IdUsuario', N'Valor') AND [object_id] = OBJECT_ID(N'[APIParametroUsuario]'))
    SET IDENTITY_INSERT [APIParametroUsuario] ON;
INSERT INTO [APIParametroUsuario] ([IdParametroUsuario], [DataHoraAlteracao], [DataVigenciaInicial], [IdParametro], [IdUsuario], [Valor])
VALUES (1, NULL, '2021-01-01', 1, 1, '09:00'),
(2, NULL, '2021-01-01', 2, 1, '18:00'),
(3, NULL, '2021-01-01', 3, 1, '01:00'),
(4, NULL, '2021-01-01', 4, 1, '00:10'),
(5, NULL, '2021-01-01', 5, 1, '02:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametroUsuario', N'DataHoraAlteracao', N'DataVigenciaInicial', N'IdParametro', N'IdUsuario', N'Valor') AND [object_id] = OBJECT_ID(N'[APIParametroUsuario]'))
    SET IDENTITY_INSERT [APIParametroUsuario] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [Valor])
VALUES (111, NULL, 30, 868.29, 0.0, 7.65),
(112, NULL, 30, 1140.0, 868.3, 8.65),
(113, NULL, 30, 1447.14, 1140.01, 9.0),
(114, NULL, 30, 2894.28, 1447.15, 11.0),
(115, NULL, 31, 868.29, 0.0, 8.0),
(116, NULL, 31, 1447.14, 868.3, 9.0),
(117, NULL, 31, 2894.28, 1447.15, 11.0),
(118, NULL, 32, 911.7, 0.0, 8.0),
(119, NULL, 32, 1519.5, 911.71, 9.0),
(121, NULL, 33, 965.67, 0.0, 8.0),
(110, NULL, 29, 2801.82, 1400.92, 11.0),
(122, NULL, 33, 1609.45, 965.68, 9.0),
(123, NULL, 33, 3218.9, 1609.46, 11.0),
(124, NULL, 34, 1024.97, 0.0, 8.0),
(125, NULL, 34, 1708.27, 1024.98, 9.0),
(126, NULL, 34, 3416.24, 1708.28, 11.0),
(127, NULL, 35, 1040.22, 0.0, 8.0),
(128, NULL, 35, 1733.7, 1040.23, 9.0),
(120, NULL, 32, 3038.99, 1519.51, 11.0),
(109, NULL, 29, 1400.91, 1050.01, 9.0),
(107, NULL, 29, 840.55, 0.0, 7.65),
(129, NULL, 35, 3467.4, 1733.71, 11.0),
(89, NULL, 24, 720.0, 560.82, 8.65),
(90, NULL, 24, 934.67, 720.01, 9.0),
(91, NULL, 24, 1869.34, 934.68, 11.0),
(92, NULL, 25, 720.0, 0.0, 7.65),
(93, NULL, 25, 1200.0, 720.01, 9.0),
(94, NULL, 25, 2400.0, 1200.01, 11.0),
(95, NULL, 26, 752.62, 0.0, 7.65),
(96, NULL, 26, 780.0, 752.63, 8.65),
(108, NULL, 29, 1050.0, 840.56, 8.65),
(97, NULL, 26, 1254.36, 780.01, 9.0),
(99, NULL, 27, 800.45, 0.0, 7.65),
(100, NULL, 27, 900.0, 800.46, 8.65),
(101, NULL, 27, 1334.07, 900.01, 9.0),
(102, NULL, 27, 2668.15, 1334.08, 11.0),
(103, NULL, 28, 840.47, 0.0, 7.65);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [Valor])
VALUES (104, NULL, 28, 1050.0, 840.48, 8.65),
(105, NULL, 28, 1400.77, 1050.01, 9.0),
(106, NULL, 28, 2801.56, 1400.78, 11.0),
(98, NULL, 26, 2508.72, 1254.37, 11.0),
(130, NULL, 36, 1106.9, 0.0, 8.0),
(132, NULL, 36, 3689.66, 1844.84, 11.0),
(88, NULL, 24, 560.81, 0.0, 7.65),
(155, NULL, 44, 2822.9, 1693.73, 9.0),
(156, NULL, 44, 5645.8, 2822.91, 11.0),
(157, NULL, 45, 1751.81, 0.0, 8.0),
(158, NULL, 45, 2919.72, 1751.82, 9.0),
(159, NULL, 45, 5839.45, 2919.73, 11.0),
(160, NULL, 46, 1830.29, 0.0, 8.0),
(161, NULL, 46, 3050.52, 1830.3, 9.0),
(162, NULL, 46, 6101.06, 3050.53, 11.0),
(154, NULL, 44, 1693.72, 0.0, 8.0),
(163, NULL, 47, 1045.0, 0.0, 7.5),
(165, NULL, 47, 3134.4, 2089.61, 12.0),
(166, NULL, 47, 6101.06, 3134.41, 14.0),
(167, NULL, 48, 1100.0, 0.0, 7.5),
(168, NULL, 48, 2203.48, 1100.01, 9.0),
(169, NULL, 48, 3305.22, 2203.49, 12.0),
(170, NULL, 48, 6433.57, 3305.23, 14.0),
(171, NULL, 49, 1212.0, 0.0, 7.5),
(172, NULL, 49, 2427.79, 1212.01, 9.0),
(164, NULL, 47, 2089.6, 1045.01, 9.0),
(131, NULL, 36, 1844.83, 1106.91, 9.0),
(153, NULL, 43, 5531.31, 2765.67, 11.0),
(151, NULL, 43, 1659.38, 0.0, 8.0),
(133, NULL, 37, 1107.52, 0.0, 8.0),
(134, NULL, 37, 1845.87, 1107.53, 9.0),
(135, NULL, 37, 3691.74, 1845.88, 11.0),
(136, NULL, 38, 1174.86, 0.0, 8.0),
(137, NULL, 38, 1958.1, 1174.87, 9.0),
(138, NULL, 38, 3916.2, 1958.11, 11.0),
(139, NULL, 39, 1247.7, 0.0, 8.0),
(140, NULL, 39, 2079.5, 1247.71, 9.0),
(152, NULL, 43, 2765.66, 1659.39, 9.0),
(141, NULL, 39, 4159.0, 2079.51, 11.0),
(143, NULL, 40, 2195.12, 1317.08, 9.0),
(144, NULL, 40, 4390.24, 2195.13, 11.0),
(145, NULL, 41, 1399.12, 0.0, 8.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [Valor])
VALUES (146, NULL, 41, 2331.88, 1399.13, 9.0),
(147, NULL, 41, 4663.75, 2331.89, 11.0),
(148, NULL, 42, 1556.94, 0.0, 8.0),
(149, NULL, 42, 2594.92, 1556.95, 9.0),
(150, NULL, 42, 5189.82, 2594.93, 11.0),
(142, NULL, 40, 1317.07, 0.0, 8.0),
(87, NULL, 23, 1561.56, 780.79, 11.0),
(85, NULL, 23, 720.0, 468.48, 8.65),
(173, NULL, 49, 3641.69, 2427.8, 12.0),
(23, NULL, 7, 515.93, 360.01, 9.0),
(24, NULL, 7, 1031.87, 515.94, 11.0),
(25, NULL, 8, 309.56, 0.0, 7.82),
(26, NULL, 8, 390.0, 309.57, 8.82),
(27, NULL, 8, 515.93, 390.01, 9.0),
(28, NULL, 8, 1031.87, 515.94, 11.0),
(29, NULL, 9, 324.45, 0.0, 7.82),
(30, NULL, 9, 390.0, 324.46, 8.82),
(22, NULL, 7, 360.0, 309.57, 8.82),
(31, NULL, 9, 540.75, 390.01, 9.0),
(33, NULL, 10, 360.0, 0.0, 7.82),
(34, NULL, 10, 390.0, 360.01, 8.82),
(35, NULL, 10, 600.0, 390.01, 9.0),
(36, NULL, 10, 1200.0, 600.01, 11.0),
(37, NULL, 11, 360.0, 0.0, 8.0),
(38, NULL, 11, 600.0, 360.01, 9.0),
(39, NULL, 11, 1200.0, 600.01, 11.0),
(40, NULL, 12, 376.6, 0.0, 7.65),
(32, NULL, 9, 1081.5, 540.76, 11.0),
(41, NULL, 12, 408.0, 376.61, 8.65),
(21, NULL, 7, 309.56, 0.0, 7.82),
(19, NULL, 6, 478.78, 360.01, 9.0),
(1, NULL, 1, 174.86, 0.0, 8.0),
(2, NULL, 1, 291.43, 174.87, 9.0),
(3, NULL, 1, 582.86, 291.44, 10.0),
(4, NULL, 2, 249.8, 0.0, 8.0),
(5, NULL, 2, 416.33, 249.81, 9.0),
(6, NULL, 2, 832.66, 416.34, 10.0),
(7, NULL, 3, 249.8, 0.0, 8.0),
(8, NULL, 3, 416.33, 249.81, 9.0),
(20, NULL, 6, 957.56, 478.79, 11.0),
(9, NULL, 3, 832.66, 416.34, 11.0),
(11, NULL, 4, 478.78, 287.28, 9.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [Valor])
VALUES (12, NULL, 4, 957.56, 478.79, 11.0),
(13, NULL, 5, 287.27, 0.0, 7.82),
(14, NULL, 5, 336.0, 287.28, 8.82),
(15, NULL, 5, 478.78, 336.01, 9.0),
(16, NULL, 5, 957.56, 478.79, 11.0),
(17, NULL, 6, 287.27, 0.0, 7.82),
(18, NULL, 6, 360.0, 287.28, 8.82),
(10, NULL, 4, 287.27, 0.0, 8.0),
(86, NULL, 23, 780.78, 720.01, 9.0),
(42, NULL, 12, 627.66, 408.01, 9.0),
(44, NULL, 13, 376.6, 0.0, 7.65),
(67, NULL, 18, 1328.25, 664.14, 11.0),
(68, NULL, 19, 398.48, 0.0, 7.65),
(69, NULL, 19, 540.0, 398.49, 8.65),
(70, NULL, 19, 664.13, 540.01, 9.0),
(71, NULL, 19, 1328.25, 664.14, 11.0),
(72, NULL, 20, 429.0, 0.0, 7.65),
(73, NULL, 20, 540.0, 429.01, 8.65),
(74, NULL, 20, 715.0, 540.01, 9.0),
(66, NULL, 18, 664.13, 453.01, 9.0),
(75, NULL, 20, 1430.0, 715.01, 11.0),
(77, NULL, 21, 600.0, 429.01, 8.65),
(78, NULL, 21, 715.0, 600.01, 9.0),
(79, NULL, 21, 1430.0, 715.01, 11.0),
(80, NULL, 22, 468.47, 0.0, 7.65),
(81, NULL, 22, 600.0, 468.48, 8.65),
(82, NULL, 22, 780.78, 600.01, 9.0),
(83, NULL, 22, 1561.56, 780.79, 11.0),
(84, NULL, 23, 468.47, 0.0, 7.65),
(76, NULL, 21, 429.0, 0.0, 7.65),
(43, NULL, 12, 1255.32, 627.67, 11.0),
(65, NULL, 18, 453.0, 398.49, 8.65),
(63, NULL, 17, 1328.25, 664.14, 11.0),
(45, NULL, 13, 408.0, 376.61, 8.65),
(46, NULL, 13, 627.66, 408.01, 9.0),
(47, NULL, 13, 1255.32, 627.67, 11.0),
(48, NULL, 14, 376.6, 0.0, 7.65),
(49, NULL, 14, 450.0, 376.61, 8.65),
(50, NULL, 14, 627.66, 450.01, 9.0),
(51, NULL, 14, 1255.32, 627.67, 11.0),
(52, NULL, 15, 376.6, 0.0, 7.65),
(64, NULL, 18, 398.48, 0.0, 7.65);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [Valor])
VALUES (53, NULL, 15, 453.0, 376.61, 8.65),
(55, NULL, 15, 1255.32, 627.67, 11.0),
(56, NULL, 16, 398.48, 0.0, 7.72),
(57, NULL, 16, 453.0, 398.49, 8.73),
(58, NULL, 16, 664.13, 453.01, 9.0),
(59, NULL, 16, 1328.25, 664.14, 11.0),
(60, NULL, 17, 398.48, 0.0, 7.72),
(61, NULL, 17, 453.0, 398.49, 8.73),
(62, NULL, 17, 664.13, 453.01, 9.0),
(54, NULL, 15, 627.66, 453.01, 9.0),
(174, NULL, 49, 7088.5, 3641.7, 14.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'Valor') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

CREATE INDEX [IX_APIParametro_IdParametroTipoDado] ON [APIParametro] ([IdParametroTipoDado]);
GO

CREATE INDEX [IX_APIParametroUsuario_IdParametro] ON [APIParametroUsuario] ([IdParametro]);
GO

CREATE INDEX [IX_APIParametroUsuario_IdUsuario] ON [APIParametroUsuario] ([IdUsuario]);
GO

CREATE INDEX [IX_APITabela_IdTabelaTipo] ON [APITabela] ([IdTabelaTipo]);
GO

CREATE INDEX [IX_APITabelaItem_IdTabela] ON [APITabelaItem] ([IdTabela]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220114043045_06ParametrosTabelas', N'5.0.13');
GO

COMMIT;
GO

