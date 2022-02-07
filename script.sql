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
    [ValorDeducaoDependente] numeric(8,2) NULL,
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
    [ValorAliquota] numeric(8,2) NOT NULL,
    [ValorDeducao] numeric(8,2) NULL,
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
(2, NULL, 'IRRF');
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabela', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Descricao', N'IdTabelaTipo', N'ValorDeducaoDependente') AND [object_id] = OBJECT_ID(N'[APITabela]'))
    SET IDENTITY_INSERT [APITabela] ON;
INSERT INTO [APITabela] ([IdTabela], [DataHoraAlteracao], [DataVigenciaInicial], [Descricao], [IdTabelaTipo], [ValorDeducaoDependente])
VALUES (52, NULL, '1994-09-01', 'Tabela de IRRF de 09/1994 a 09/1994', 2, 62.07),
(51, NULL, '1994-08-01', 'Tabela de IRRF de 08/1994 a 08/1994', 2, 23.64),
(50, NULL, '1994-07-01', 'Tabela de IRRF de 07/1994 a 07/1994', 2, 22.47),
(49, NULL, '2022-01-01', 'INSS a partir de 01/2022', 1, NULL),
(48, NULL, '2021-01-01', 'INSS a partir de 01/2021', 1, NULL),
(47, NULL, '2020-03-01', 'INSS a partir de 03/2020', 1, NULL),
(46, NULL, '2020-01-01', 'INSS a partir de 01/2020', 1, NULL),
(44, NULL, '2018-01-01', 'INSS a partir de 01/2018', 1, NULL),
(53, NULL, '1994-10-01', 'Tabela de IRRF de 10/1994 a 10/1994', 2, 63.08),
(43, NULL, '2017-01-01', 'INSS a partir de 01/2017', 1, NULL),
(42, NULL, '2016-01-01', 'INSS a partir de 01/2016', 1, NULL),
(41, NULL, '2015-01-01', 'INSS a partir de 01/2015', 1, NULL),
(40, NULL, '2014-01-01', 'INSS a partir de 01/2014', 1, NULL),
(39, NULL, '2013-01-01', 'INSS a partir de 01/2013', 1, NULL),
(45, NULL, '2019-01-01', 'INSS a partir de 01/2019', 1, NULL),
(54, NULL, '1994-11-01', 'Tabela de IRRF de 11/1994 a 11/1994', 2, 64.28),
(57, NULL, '1995-04-01', 'Tabela de IRRF de 04/1995 a 06/1995', 2, 70.61),
(56, NULL, '1995-01-01', 'Tabela de IRRF de 01/1995 a 03/1995', 2, 67.67),
(71, NULL, '2013-01-01', 'Tabela de IRRF de 01/2013 a 12/2013', 2, 171.97),
(70, NULL, '2012-01-01', 'Tabela de IRRF de 01/2012 a 12/2012', 2, 164.56),
(69, NULL, '2011-04-01', 'Tabela de IRRF de 04/2011 a 12/2011', 2, 157.47),
(68, NULL, '2010-01-01', 'Tabela de IRRF de 01/2010 a 03/2011', 2, 150.69),
(67, NULL, '2009-01-01', 'Tabela de IRRF de 01/2009 a 12/2009', 2, 144.2),
(66, NULL, '2008-01-01', 'Tabela de IRRF de 01/2008 a 12/2008', 2, 137.99),
(65, NULL, '2007-01-01', 'Tabela de IRRF de 01/2007 a 12/2007', 2, 132.05),
(64, NULL, '2006-02-01', 'Tabela de IRRF de 02/2006 a 12/2006', 2, 126.36),
(63, NULL, '2005-01-01', 'Tabela de IRRF de 01/2005 a 01/2006', 2, 117.0),
(62, NULL, '2002-01-01', 'Tabela de IRRF de 01/2002 a 12/2004', 2, 106.0),
(61, NULL, '1998-01-01', 'Tabela de IRRF de 01/1998 a 12/2001', 2, 90.0),
(60, NULL, '1996-01-01', 'Tabela de IRRF de 01/1996 a 12/1997', 2, 90.0),
(59, NULL, '1995-10-01', 'Tabela de IRRF de 10/1995 a 12/1995', 2, 79.52),
(58, NULL, '1995-07-01', 'Tabela de IRRF de 07/1995 a 09/1995', 2, 75.64),
(38, NULL, '2012-01-01', 'INSS a partir de 01/2012', 1, NULL),
(55, NULL, '1994-12-01', 'Tabela de IRRF de 12/1994 a 12/1994', 2, 66.18),
(37, NULL, '2011-07-01', 'INSS a partir de 07/2011', 1, NULL),
(34, NULL, '2010-01-01', 'INSS a partir de 01/2010', 1, NULL),
(35, NULL, '2010-06-01', 'INSS a partir de 06/2010', 1, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabela', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Descricao', N'IdTabelaTipo', N'ValorDeducaoDependente') AND [object_id] = OBJECT_ID(N'[APITabela]'))
    SET IDENTITY_INSERT [APITabela] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabela', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Descricao', N'IdTabelaTipo', N'ValorDeducaoDependente') AND [object_id] = OBJECT_ID(N'[APITabela]'))
    SET IDENTITY_INSERT [APITabela] ON;
INSERT INTO [APITabela] ([IdTabela], [DataHoraAlteracao], [DataVigenciaInicial], [Descricao], [IdTabelaTipo], [ValorDeducaoDependente])
VALUES (15, NULL, '2000-05-01', 'INSS a partir de 05/2000', 1, NULL),
(14, NULL, '2000-04-01', 'INSS a partir de 04/2000', 1, NULL),
(13, NULL, '1999-07-01', 'INSS a partir de 07/1999', 1, NULL),
(12, NULL, '1999-06-01', 'INSS a partir de 06/1999', 1, NULL),
(11, NULL, '1999-01-01', 'INSS a partir de 01/1999', 1, NULL),
(10, NULL, '1998-12-01', 'INSS a partir de 12/1998', 1, NULL),
(9, NULL, '1998-06-01', 'INSS a partir de 06/1998', 1, NULL),
(8, NULL, '1998-05-01', 'INSS a partir de 05/1998', 1, NULL),
(7, NULL, '1997-06-01', 'INSS a partir de 06/1997', 1, NULL),
(6, NULL, '1997-05-01', 'INSS a partir de 05/1997', 1, NULL),
(5, NULL, '1997-01-01', 'INSS a partir de 01/1997', 1, NULL),
(4, NULL, '1996-05-01', 'INSS a partir de 05/1996', 1, NULL),
(3, NULL, '1995-08-01', 'INSS a partir de 08/1995', 1, NULL),
(2, NULL, '1995-05-01', 'INSS a partir de 05/1995', 1, NULL),
(1, NULL, '1995-01-01', 'INSS a partir de 01/1995', 1, NULL),
(16, NULL, '2000-06-01', 'INSS a partir de 06/2000', 1, NULL),
(36, NULL, '2011-01-01', 'INSS a partir de 01/2011', 1, NULL),
(17, NULL, '2000-07-01', 'INSS a partir de 07/2000', 1, NULL),
(19, NULL, '2001-04-01', 'INSS a partir de 04/2001', 1, NULL),
(72, NULL, '2014-01-01', 'Tabela de IRRF de 01/2014 a 03/2015', 2, 179.71),
(33, NULL, '2009-02-01', 'INSS a partir de 02/2009', 1, NULL),
(32, NULL, '2008-03-01', 'INSS a partir de 03/2008', 1, NULL),
(31, NULL, '2008-01-01', 'INSS a partir de 01/2008', 1, NULL),
(30, NULL, '2007-04-01', 'INSS a partir de 04/2007', 1, NULL),
(29, NULL, '2006-08-01', 'INSS a partir de 08/2006', 1, NULL),
(28, NULL, '2006-04-01', 'INSS a partir de 04/2006', 1, NULL),
(27, NULL, '2005-05-01', 'INSS a partir de 05/2005', 1, NULL),
(26, NULL, '2004-05-01', 'INSS a partir de 05/2004', 1, NULL),
(25, NULL, '2004-01-01', 'INSS a partir de 01/2004', 1, NULL),
(24, NULL, '2003-06-01', 'INSS a partir de 06/2003', 1, NULL),
(23, NULL, '2003-04-01', 'INSS a partir de 04/2003', 1, NULL),
(22, NULL, '2002-06-01', 'INSS a partir de 06/2002', 1, NULL),
(21, NULL, '2002-04-01', 'INSS a partir de 04/2002', 1, NULL),
(20, NULL, '2001-06-01', 'INSS a partir de 06/2001', 1, NULL),
(18, NULL, '2001-03-01', 'INSS a partir de 03/2001', 1, NULL),
(73, NULL, '2015-04-01', 'Tabela de IRRF de 04/2015 a 01/2022', 2, 189.59);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabela', N'DataHoraAlteracao', N'DataVigenciaInicial', N'Descricao', N'IdTabelaTipo', N'ValorDeducaoDependente') AND [object_id] = OBJECT_ID(N'[APITabela]'))
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [ValorAliquota], [ValorDeducao])
VALUES (183, NULL, 52, 620.71, 0.0, 0.0, 0.0),
(182, NULL, 51, 999999.99, 10639.81, 35.0, 1116.14),
(181, NULL, 51, 10639.8, 1152.66, 26.6, 222.49),
(180, NULL, 51, 1152.65, 591.11, 15.0, 88.66),
(179, NULL, 51, 591.1, 0.0, 0.0, 0.0),
(178, NULL, 50, 999999.99, 10112.41, 35.0, 1060.82),
(175, NULL, 50, 561.8, 0.0, 0.0, 0.0),
(176, NULL, 50, 1095.51, 561.81, 15.0, 84.27),
(184, NULL, 52, 1210.36, 620.72, 15.0, 93.1),
(174, NULL, 49, 7088.5, 3641.7, 14.0, NULL),
(173, NULL, 49, 3641.69, 2427.8, 12.0, NULL),
(172, NULL, 49, 2427.79, 1212.01, 9.0, NULL),
(171, NULL, 49, 1212.0, 0.0, 7.5, NULL),
(177, NULL, 50, 10112.4, 1095.52, 26.6, 211.46),
(185, NULL, 52, 11172.6, 1210.37, 26.6, 233.63),
(187, NULL, 53, 630.8, 0.0, 0.0, 0.0),
(170, NULL, 48, 6433.57, 3305.23, 14.0, NULL),
(188, NULL, 53, 1230.06, 630.81, 15.0, 94.62),
(189, NULL, 53, 11354.4, 1230.07, 26.6, 237.43),
(190, NULL, 53, 999999.99, 11354.41, 35.0, 1191.11),
(191, NULL, 54, 642.8, 0.0, 0.0, 0.0),
(192, NULL, 54, 1253.47, 642.81, 15.0, 96.42),
(193, NULL, 54, 11570.4, 1253.48, 26.6, 241.94),
(194, NULL, 54, 999999.99, 11570.41, 35.0, 1213.77),
(195, NULL, 55, 661.8, 0.0, 0.0, 0.0),
(196, NULL, 55, 1290.51, 661.81, 15.0, 99.27),
(197, NULL, 55, 11912.4, 1290.52, 26.6, 249.09),
(198, NULL, 55, 999999.99, 11912.41, 35.0, 1249.64),
(199, NULL, 56, 676.7, 0.0, 0.0, 0.0),
(200, NULL, 56, 1319.57, 676.71, 15.0, 101.51),
(186, NULL, 52, 999999.99, 11172.61, 35.0, 1172.04),
(169, NULL, 48, 3305.22, 2203.49, 12.0, NULL),
(167, NULL, 48, 1100.0, 0.0, 7.5, NULL),
(201, NULL, 56, 12180.6, 1319.58, 26.6, 254.7),
(137, NULL, 38, 1958.1, 1174.87, 9.0, NULL),
(138, NULL, 38, 3916.2, 1958.11, 11.0, NULL),
(139, NULL, 39, 1247.7, 0.0, 8.0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [ValorAliquota], [ValorDeducao])
VALUES (140, NULL, 39, 2079.5, 1247.71, 9.0, NULL),
(141, NULL, 39, 4159.0, 2079.51, 11.0, NULL),
(142, NULL, 40, 1317.07, 0.0, 8.0, NULL),
(143, NULL, 40, 2195.12, 1317.08, 9.0, NULL),
(144, NULL, 40, 4390.24, 2195.13, 11.0, NULL),
(145, NULL, 41, 1399.12, 0.0, 8.0, NULL),
(146, NULL, 41, 2331.88, 1399.13, 9.0, NULL),
(147, NULL, 41, 4663.75, 2331.89, 11.0, NULL),
(148, NULL, 42, 1556.94, 0.0, 8.0, NULL),
(149, NULL, 42, 2594.92, 1556.95, 9.0, NULL),
(150, NULL, 42, 5189.82, 2594.93, 11.0, NULL),
(168, NULL, 48, 2203.48, 1100.01, 9.0, NULL),
(151, NULL, 43, 1659.38, 0.0, 8.0, NULL),
(153, NULL, 43, 5531.31, 2765.67, 11.0, NULL),
(154, NULL, 44, 1693.72, 0.0, 8.0, NULL),
(155, NULL, 44, 2822.9, 1693.73, 9.0, NULL),
(156, NULL, 44, 5645.8, 2822.91, 11.0, NULL),
(157, NULL, 45, 1751.81, 0.0, 8.0, NULL),
(158, NULL, 45, 2919.72, 1751.82, 9.0, NULL),
(159, NULL, 45, 5839.45, 2919.73, 11.0, NULL),
(160, NULL, 46, 1830.29, 0.0, 8.0, NULL),
(161, NULL, 46, 3050.52, 1830.3, 9.0, NULL),
(162, NULL, 46, 6101.06, 3050.53, 11.0, NULL),
(163, NULL, 47, 1045.0, 0.0, 7.5, NULL),
(164, NULL, 47, 2089.6, 1045.01, 9.0, NULL),
(165, NULL, 47, 3134.4, 2089.61, 12.0, NULL),
(166, NULL, 47, 6101.06, 3134.41, 14.0, NULL),
(152, NULL, 43, 2765.66, 1659.39, 9.0, NULL),
(202, NULL, 56, 999999.99, 12180.61, 35.0, 1277.78),
(204, NULL, 57, 1376.84, 706.11, 15.0, 105.91),
(136, NULL, 38, 1174.86, 0.0, 8.0, NULL),
(239, NULL, 67, 3582.0, 2866.71, 22.5, 483.84),
(240, NULL, 67, 999999.99, 3582.01, 27.5, 662.94),
(241, NULL, 68, 1499.15, 0.0, 0.0, 0.0),
(242, NULL, 68, 2246.75, 1499.16, 7.5, 112.43),
(243, NULL, 68, 2995.7, 2246.76, 15.0, 280.94),
(244, NULL, 68, 3743.19, 2995.71, 22.5, 505.62),
(245, NULL, 68, 999999.99, 3743.2, 27.5, 692.78),
(246, NULL, 69, 1566.61, 0.0, 0.0, 0.0),
(247, NULL, 69, 2347.85, 1566.62, 7.5, 117.49),
(248, NULL, 69, 3130.51, 2347.86, 15.0, 293.58),
(249, NULL, 69, 3911.63, 3130.52, 22.5, 528.37);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [ValorAliquota], [ValorDeducao])
VALUES (250, NULL, 69, 999999.99, 3911.64, 27.5, 723.95),
(251, NULL, 70, 1637.11, 0.0, 0.0, 0.0),
(252, NULL, 70, 2453.5, 1637.12, 7.5, 122.78),
(238, NULL, 67, 2866.7, 2150.01, 15.0, 268.84),
(253, NULL, 70, 3271.38, 2453.51, 15.0, 306.8),
(255, NULL, 70, 999999.99, 4087.66, 27.5, 756.53),
(256, NULL, 71, 1710.78, 0.0, 0.0, 0.0),
(257, NULL, 71, 2563.91, 1710.79, 7.5, 128.31),
(258, NULL, 71, 3418.59, 2563.92, 15.0, 320.6),
(259, NULL, 71, 4271.59, 3418.6, 22.5, 577.0),
(260, NULL, 71, 999999.99, 4271.6, 27.5, 790.58),
(261, NULL, 72, 1787.77, 0.0, 0.0, 0.0),
(262, NULL, 72, 2679.29, 1787.78, 7.5, 134.08),
(263, NULL, 72, 3572.43, 2679.3, 15.0, 335.03),
(264, NULL, 72, 4463.81, 3572.44, 22.5, 602.96),
(265, NULL, 72, 999999.99, 4463.82, 27.5, 826.15),
(266, NULL, 73, 1903.98, 0.0, 0.0, 0.0),
(267, NULL, 73, 2826.65, 1903.99, 7.5, 142.8),
(268, NULL, 73, 3751.05, 2826.66, 15.0, 354.8),
(254, NULL, 70, 4087.65, 3271.39, 22.5, 552.15),
(203, NULL, 57, 706.1, 0.0, 0.0, 0.0),
(237, NULL, 67, 2150.0, 1434.6, 7.5, 107.59),
(235, NULL, 66, 999999.99, 2743.26, 27.5, 548.82),
(205, NULL, 57, 12709.24, 1376.85, 26.6, 265.76),
(206, NULL, 57, 999999.99, 12709.25, 35.0, 1333.23),
(207, NULL, 58, 756.44, 0.0, 0.0, 0.0),
(208, NULL, 58, 1475.01, 756.45, 15.0, 103.47),
(209, NULL, 58, 13615.41, 1475.02, 26.6, 284.71),
(210, NULL, 58, 999999.99, 13615.42, 35.0, 1428.29),
(211, NULL, 59, 795.24, 0.0, 0.0, 0.0),
(212, NULL, 59, 1550.68, 795.25, 15.0, 119.29),
(213, NULL, 59, 14313.88, 1550.69, 26.6, 299.32),
(214, NULL, 59, 999999.99, 14313.89, 35.0, 1501.57),
(215, NULL, 60, 900.0, 0.0, 0.0, 0.0),
(216, NULL, 60, 1800.0, 900.01, 15.0, 135.0),
(217, NULL, 60, 999999.99, 1800.01, 25.0, 315.0),
(218, NULL, 61, 900.0, 0.0, 0.0, 0.0),
(236, NULL, 67, 1434.59, 0.0, 0.0, 0.0),
(219, NULL, 61, 1800.0, 900.01, 15.0, 135.0),
(221, NULL, 62, 1058.0, 0.0, 0.0, 0.0),
(222, NULL, 62, 2115.0, 1058.01, 15.0, 158.7),
(223, NULL, 62, 999999.99, 2115.01, 27.5, 423.08);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [ValorAliquota], [ValorDeducao])
VALUES (224, NULL, 63, 1164.0, 0.0, 0.0, 0.0),
(225, NULL, 63, 2326.0, 1164.01, 15.0, 174.6),
(226, NULL, 63, 999999.99, 2326.01, 27.5, 465.35),
(227, NULL, 64, 1257.12, 0.0, 0.0, 0.0),
(228, NULL, 64, 2512.08, 1257.13, 15.0, 188.57),
(229, NULL, 64, 999999.99, 2512.09, 27.5, 502.58),
(230, NULL, 65, 1313.69, 0.0, 0.0, 0.0),
(231, NULL, 65, 2625.12, 1313.7, 15.0, 197.05),
(232, NULL, 65, 999999.99, 2625.13, 27.5, 525.19),
(233, NULL, 66, 1372.81, 0.0, 0.0, 0.0),
(234, NULL, 66, 2743.25, 1372.82, 15.0, 205.92),
(220, NULL, 61, 999999.99, 1800.01, 27.5, 360.0),
(135, NULL, 37, 3691.74, 1845.88, 11.0, NULL),
(133, NULL, 37, 1107.52, 0.0, 8.0, NULL),
(269, NULL, 73, 4664.68, 3751.06, 22.5, 636.13),
(35, NULL, 10, 600.0, 390.01, 9.0, NULL),
(36, NULL, 10, 1200.0, 600.01, 11.0, NULL),
(37, NULL, 11, 360.0, 0.0, 8.0, NULL),
(38, NULL, 11, 600.0, 360.01, 9.0, NULL),
(39, NULL, 11, 1200.0, 600.01, 11.0, NULL),
(40, NULL, 12, 376.6, 0.0, 7.65, NULL),
(41, NULL, 12, 408.0, 376.61, 8.65, NULL),
(42, NULL, 12, 627.66, 408.01, 9.0, NULL),
(43, NULL, 12, 1255.32, 627.67, 11.0, NULL),
(44, NULL, 13, 376.6, 0.0, 7.65, NULL),
(45, NULL, 13, 408.0, 376.61, 8.65, NULL),
(46, NULL, 13, 627.66, 408.01, 9.0, NULL),
(47, NULL, 13, 1255.32, 627.67, 11.0, NULL),
(48, NULL, 14, 376.6, 0.0, 7.65, NULL),
(34, NULL, 10, 390.0, 360.01, 8.82, NULL),
(49, NULL, 14, 450.0, 376.61, 8.65, NULL),
(51, NULL, 14, 1255.32, 627.67, 11.0, NULL),
(52, NULL, 15, 376.6, 0.0, 7.65, NULL),
(53, NULL, 15, 453.0, 376.61, 8.65, NULL),
(54, NULL, 15, 627.66, 453.01, 9.0, NULL),
(55, NULL, 15, 1255.32, 627.67, 11.0, NULL),
(56, NULL, 16, 398.48, 0.0, 7.72, NULL),
(57, NULL, 16, 453.0, 398.49, 8.73, NULL),
(58, NULL, 16, 664.13, 453.01, 9.0, NULL),
(59, NULL, 16, 1328.25, 664.14, 11.0, NULL),
(60, NULL, 17, 398.48, 0.0, 7.72, NULL),
(61, NULL, 17, 453.0, 398.49, 8.73, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [ValorAliquota], [ValorDeducao])
VALUES (62, NULL, 17, 664.13, 453.01, 9.0, NULL),
(63, NULL, 17, 1328.25, 664.14, 11.0, NULL),
(64, NULL, 18, 398.48, 0.0, 7.65, NULL),
(50, NULL, 14, 627.66, 450.01, 9.0, NULL),
(65, NULL, 18, 453.0, 398.49, 8.65, NULL),
(33, NULL, 10, 360.0, 0.0, 7.82, NULL),
(31, NULL, 9, 540.75, 390.01, 9.0, NULL),
(1, NULL, 1, 174.86, 0.0, 8.0, NULL),
(2, NULL, 1, 291.43, 174.87, 9.0, NULL),
(3, NULL, 1, 582.86, 291.44, 10.0, NULL),
(4, NULL, 2, 249.8, 0.0, 8.0, NULL),
(5, NULL, 2, 416.33, 249.81, 9.0, NULL),
(6, NULL, 2, 832.66, 416.34, 10.0, NULL),
(7, NULL, 3, 249.8, 0.0, 8.0, NULL),
(8, NULL, 3, 416.33, 249.81, 9.0, NULL),
(9, NULL, 3, 832.66, 416.34, 11.0, NULL),
(10, NULL, 4, 287.27, 0.0, 8.0, NULL),
(11, NULL, 4, 478.78, 287.28, 9.0, NULL),
(12, NULL, 4, 957.56, 478.79, 11.0, NULL),
(13, NULL, 5, 287.27, 0.0, 7.82, NULL),
(14, NULL, 5, 336.0, 287.28, 8.82, NULL),
(32, NULL, 9, 1081.5, 540.76, 11.0, NULL),
(15, NULL, 5, 478.78, 336.01, 9.0, NULL),
(17, NULL, 6, 287.27, 0.0, 7.82, NULL),
(18, NULL, 6, 360.0, 287.28, 8.82, NULL),
(19, NULL, 6, 478.78, 360.01, 9.0, NULL),
(20, NULL, 6, 957.56, 478.79, 11.0, NULL),
(21, NULL, 7, 309.56, 0.0, 7.82, NULL),
(22, NULL, 7, 360.0, 309.57, 8.82, NULL),
(23, NULL, 7, 515.93, 360.01, 9.0, NULL),
(24, NULL, 7, 1031.87, 515.94, 11.0, NULL),
(25, NULL, 8, 309.56, 0.0, 7.82, NULL),
(26, NULL, 8, 390.0, 309.57, 8.82, NULL),
(27, NULL, 8, 515.93, 390.01, 9.0, NULL),
(28, NULL, 8, 1031.87, 515.94, 11.0, NULL),
(29, NULL, 9, 324.45, 0.0, 7.82, NULL),
(30, NULL, 9, 390.0, 324.46, 8.82, NULL),
(16, NULL, 5, 957.56, 478.79, 11.0, NULL),
(134, NULL, 37, 1845.87, 1107.53, 9.0, NULL),
(66, NULL, 18, 664.13, 453.01, 9.0, NULL),
(68, NULL, 19, 398.48, 0.0, 7.65, NULL),
(103, NULL, 28, 840.47, 0.0, 7.65, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [ValorAliquota], [ValorDeducao])
VALUES (104, NULL, 28, 1050.0, 840.48, 8.65, NULL),
(105, NULL, 28, 1400.77, 1050.01, 9.0, NULL),
(106, NULL, 28, 2801.56, 1400.78, 11.0, NULL),
(107, NULL, 29, 840.55, 0.0, 7.65, NULL),
(108, NULL, 29, 1050.0, 840.56, 8.65, NULL),
(109, NULL, 29, 1400.91, 1050.01, 9.0, NULL),
(110, NULL, 29, 2801.82, 1400.92, 11.0, NULL),
(111, NULL, 30, 868.29, 0.0, 7.65, NULL),
(112, NULL, 30, 1140.0, 868.3, 8.65, NULL),
(113, NULL, 30, 1447.14, 1140.01, 9.0, NULL),
(114, NULL, 30, 2894.28, 1447.15, 11.0, NULL),
(115, NULL, 31, 868.29, 0.0, 8.0, NULL),
(116, NULL, 31, 1447.14, 868.3, 9.0, NULL),
(102, NULL, 27, 2668.15, 1334.08, 11.0, NULL),
(117, NULL, 31, 2894.28, 1447.15, 11.0, NULL),
(119, NULL, 32, 1519.5, 911.71, 9.0, NULL),
(120, NULL, 32, 3038.99, 1519.51, 11.0, NULL),
(121, NULL, 33, 965.67, 0.0, 8.0, NULL),
(122, NULL, 33, 1609.45, 965.68, 9.0, NULL),
(123, NULL, 33, 3218.9, 1609.46, 11.0, NULL),
(124, NULL, 34, 1024.97, 0.0, 8.0, NULL),
(125, NULL, 34, 1708.27, 1024.98, 9.0, NULL),
(126, NULL, 34, 3416.24, 1708.28, 11.0, NULL),
(127, NULL, 35, 1040.22, 0.0, 8.0, NULL),
(128, NULL, 35, 1733.7, 1040.23, 9.0, NULL),
(129, NULL, 35, 3467.4, 1733.71, 11.0, NULL),
(130, NULL, 36, 1106.9, 0.0, 8.0, NULL),
(131, NULL, 36, 1844.83, 1106.91, 9.0, NULL),
(132, NULL, 36, 3689.66, 1844.84, 11.0, NULL),
(118, NULL, 32, 911.7, 0.0, 8.0, NULL),
(67, NULL, 18, 1328.25, 664.14, 11.0, NULL),
(101, NULL, 27, 1334.07, 900.01, 9.0, NULL),
(99, NULL, 27, 800.45, 0.0, 7.65, NULL),
(69, NULL, 19, 540.0, 398.49, 8.65, NULL),
(70, NULL, 19, 664.13, 540.01, 9.0, NULL),
(71, NULL, 19, 1328.25, 664.14, 11.0, NULL),
(72, NULL, 20, 429.0, 0.0, 7.65, NULL),
(73, NULL, 20, 540.0, 429.01, 8.65, NULL),
(74, NULL, 20, 715.0, 540.01, 9.0, NULL),
(75, NULL, 20, 1430.0, 715.01, 11.0, NULL),
(76, NULL, 21, 429.0, 0.0, 7.65, NULL),
(77, NULL, 21, 600.0, 429.01, 8.65, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
    SET IDENTITY_INSERT [APITabelaItem] ON;
INSERT INTO [APITabelaItem] ([IdTabelaItem], [DataHoraAlteracao], [IdTabela], [IntervaloFinal], [IntervaloInicial], [ValorAliquota], [ValorDeducao])
VALUES (78, NULL, 21, 715.0, 600.01, 9.0, NULL),
(79, NULL, 21, 1430.0, 715.01, 11.0, NULL),
(80, NULL, 22, 468.47, 0.0, 7.65, NULL),
(81, NULL, 22, 600.0, 468.48, 8.65, NULL),
(82, NULL, 22, 780.78, 600.01, 9.0, NULL),
(100, NULL, 27, 900.0, 800.46, 8.65, NULL),
(83, NULL, 22, 1561.56, 780.79, 11.0, NULL),
(85, NULL, 23, 720.0, 468.48, 8.65, NULL),
(86, NULL, 23, 780.78, 720.01, 9.0, NULL),
(87, NULL, 23, 1561.56, 780.79, 11.0, NULL),
(88, NULL, 24, 560.81, 0.0, 7.65, NULL),
(89, NULL, 24, 720.0, 560.82, 8.65, NULL),
(90, NULL, 24, 934.67, 720.01, 9.0, NULL),
(91, NULL, 24, 1869.34, 934.68, 11.0, NULL),
(92, NULL, 25, 720.0, 0.0, 7.65, NULL),
(93, NULL, 25, 1200.0, 720.01, 9.0, NULL),
(94, NULL, 25, 2400.0, 1200.01, 11.0, NULL),
(95, NULL, 26, 752.62, 0.0, 7.65, NULL),
(96, NULL, 26, 780.0, 752.63, 8.65, NULL),
(97, NULL, 26, 1254.36, 780.01, 9.0, NULL),
(98, NULL, 26, 2508.72, 1254.37, 11.0, NULL),
(84, NULL, 23, 468.47, 0.0, 7.65, NULL),
(270, NULL, 73, 999999.99, 4664.69, 27.5, 869.36);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTabelaItem', N'DataHoraAlteracao', N'IdTabela', N'IntervaloFinal', N'IntervaloInicial', N'ValorAliquota', N'ValorDeducao') AND [object_id] = OBJECT_ID(N'[APITabelaItem]'))
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
VALUES (N'20220114160112_06ParametrosTabelas', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [APIParametroTipoDado] SET [IntervaloMax] = 999999.99
WHERE [IdParametroTipoDado] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametroTipoDado', N'DataHoraAlteracao', N'Descricao', N'Formato', N'IntervaloMax', N'IntervaloMin', N'TamanhoMax', N'TamanhoMin') AND [object_id] = OBJECT_ID(N'[APIParametroTipoDado]'))
    SET IDENTITY_INSERT [APIParametroTipoDado] ON;
INSERT INTO [APIParametroTipoDado] ([IdParametroTipoDado], [DataHoraAlteracao], [Descricao], [Formato], [IntervaloMax], [IntervaloMin], [TamanhoMax], [TamanhoMin])
VALUES (5, NULL, 'Número Inteiro 2 Dígitos', '', 99.0, 0.0, 2, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametroTipoDado', N'DataHoraAlteracao', N'Descricao', N'Formato', N'IntervaloMax', N'IntervaloMin', N'TamanhoMax', N'TamanhoMin') AND [object_id] = OBJECT_ID(N'[APIParametroTipoDado]'))
    SET IDENTITY_INSERT [APIParametroTipoDado] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametro', N'DataHoraAlteracao', N'Descricao', N'DescricaoDetalhada', N'IdParametroTipoDado') AND [object_id] = OBJECT_ID(N'[APIParametro]'))
    SET IDENTITY_INSERT [APIParametro] ON;
INSERT INTO [APIParametro] ([IdParametro], [DataHoraAlteracao], [Descricao], [DescricaoDetalhada], [IdParametroTipoDado])
VALUES (6, NULL, 'Quantidade de Dependentes', 'Quantidade de Dependentes que o Usuário possui, para fins de desconto do cálculo de IRRF', 5);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametro', N'DataHoraAlteracao', N'Descricao', N'DescricaoDetalhada', N'IdParametroTipoDado') AND [object_id] = OBJECT_ID(N'[APIParametro]'))
    SET IDENTITY_INSERT [APIParametro] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametroUsuario', N'DataHoraAlteracao', N'DataVigenciaInicial', N'IdParametro', N'IdUsuario', N'Valor') AND [object_id] = OBJECT_ID(N'[APIParametroUsuario]'))
    SET IDENTITY_INSERT [APIParametroUsuario] ON;
INSERT INTO [APIParametroUsuario] ([IdParametroUsuario], [DataHoraAlteracao], [DataVigenciaInicial], [IdParametro], [IdUsuario], [Valor])
VALUES (6, NULL, '2021-01-01', 6, 1, '2');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParametroUsuario', N'DataHoraAlteracao', N'DataVigenciaInicial', N'IdParametro', N'IdUsuario', N'Valor') AND [object_id] = OBJECT_ID(N'[APIParametroUsuario]'))
    SET IDENTITY_INSERT [APIParametroUsuario] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220121181237_07Parametros', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [APIHolerite] (
    [IdHolerite] int NOT NULL IDENTITY,
    [IdUsuario] int NOT NULL,
    [Descricao] varchar(100) NOT NULL,
    [DataInicialPonto] date NOT NULL,
    [DataFinalPonto] date NOT NULL,
    [DataPagamentoAdiantamento] date NOT NULL,
    [DataPagamento] date NOT NULL,
    [DataInicialHoraExtraNormal] date NULL,
    [DataFinalHoraExtraNormal] date NULL,
    [DataInicialHoraExtraAdicional] date NULL,
    [DataFinalHoraExtraAdicional] date NULL,
    [DataHoraInclusao] datetime NOT NULL,
    [DataHoraAlteracao] datetime NULL,
    CONSTRAINT [PK_APIHolerite] PRIMARY KEY ([IdHolerite]),
    CONSTRAINT [FK_APIHolerite_APIUsuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [APIUsuario] ([IdUsuario])
);
GO

CREATE INDEX [IX_APIHolerite_IdUsuario] ON [APIHolerite] ([IdUsuario]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220205134300_08Holerite', N'5.0.13');
GO

COMMIT;
GO

