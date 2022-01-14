using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePessoal.Infrastructure.Migrations
{
    public partial class _06ParametrosTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIParametroTipoDado",
                columns: table => new
                {
                    IdParametroTipoDado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    TamanhoMin = table.Column<int>(type: "int", nullable: false),
                    TamanhoMax = table.Column<int>(type: "int", nullable: false),
                    Formato = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    IntervaloMin = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    IntervaloMax = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIParametroTipoDado", x => x.IdParametroTipoDado);
                });

            migrationBuilder.CreateTable(
                name: "APITabelaTipo",
                columns: table => new
                {
                    IdTabelaTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APITabelaTipo", x => x.IdTabelaTipo);
                });

            migrationBuilder.CreateTable(
                name: "APIParametro",
                columns: table => new
                {
                    IdParametro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DescricaoDetalhada = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    IdParametroTipoDado = table.Column<int>(type: "int", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIParametro", x => x.IdParametro);
                    table.ForeignKey(
                        name: "FK_APIParametro_APIParametroTipoDado_IdParametroTipoDado",
                        column: x => x.IdParametroTipoDado,
                        principalTable: "APIParametroTipoDado",
                        principalColumn: "IdParametroTipoDado");
                });

            migrationBuilder.CreateTable(
                name: "APITabela",
                columns: table => new
                {
                    IdTabela = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTabelaTipo = table.Column<int>(type: "int", nullable: false),
                    DataVigenciaInicial = table.Column<DateTime>(type: "date", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ValorDeducaoDependente = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APITabela", x => x.IdTabela);
                    table.ForeignKey(
                        name: "FK_APITabela_APITabelaTipo_IdTabelaTipo",
                        column: x => x.IdTabelaTipo,
                        principalTable: "APITabelaTipo",
                        principalColumn: "IdTabelaTipo");
                });

            migrationBuilder.CreateTable(
                name: "APIParametroUsuario",
                columns: table => new
                {
                    IdParametroUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdParametro = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    DataVigenciaInicial = table.Column<DateTime>(type: "date", nullable: false),
                    Valor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIParametroUsuario", x => x.IdParametroUsuario);
                    table.ForeignKey(
                        name: "FK_APIParametroUsuario_APIParametro_IdParametro",
                        column: x => x.IdParametro,
                        principalTable: "APIParametro",
                        principalColumn: "IdParametro");
                    table.ForeignKey(
                        name: "FK_APIParametroUsuario_APIUsuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "APIUsuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "APITabelaItem",
                columns: table => new
                {
                    IdTabelaItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTabela = table.Column<int>(type: "int", nullable: false),
                    IntervaloInicial = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    IntervaloFinal = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    ValorAliquota = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    ValorDeducao = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APITabelaItem", x => x.IdTabelaItem);
                    table.ForeignKey(
                        name: "FK_APITabelaItem_APITabela_IdTabela",
                        column: x => x.IdTabela,
                        principalTable: "APITabela",
                        principalColumn: "IdTabela");
                });

            migrationBuilder.InsertData(
                table: "APIParametroTipoDado",
                columns: new[] { "IdParametroTipoDado", "DataHoraAlteracao", "Descricao", "Formato", "IntervaloMax", "IntervaloMin", "TamanhoMax", "TamanhoMin" },
                values: new object[,]
                {
                    { 1, null, "Monetário", "", null, null, 9, 1 },
                    { 2, null, "Percentual", "", 100m, 0m, 6, 1 },
                    { 3, null, "Data", "dd/MM/yyyy", null, null, 10, 10 },
                    { 4, null, "Hora", "hh:mm", null, null, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "APITabelaTipo",
                columns: new[] { "IdTabelaTipo", "DataHoraAlteracao", "Descricao" },
                values: new object[,]
                {
                    { 1, null, "INSS" },
                    { 2, null, "IRRF" }
                });

            migrationBuilder.InsertData(
                table: "APIParametro",
                columns: new[] { "IdParametro", "DataHoraAlteracao", "Descricao", "DescricaoDetalhada", "IdParametroTipoDado" },
                values: new object[,]
                {
                    { 1, null, "Horário de Entrada", "Horário de Entrada do Usuário", 4 },
                    { 2, null, "Horário de Saída", "Horário de Saída do Usuário", 4 },
                    { 3, null, "Intervalo Diário", "Intervalo Diário do Usuário entre períodos de trabalho", 4 },
                    { 4, null, "Tolerância Diária", "Tolerância Diária (em hh:mm) para desconsiderar cálculos de Hora Extra ou Desconto", 4 },
                    { 5, null, "Limite para Banco de Horas Diário", "Limite (em hh:mm) para considerar o que fica em Banco de Horas; o excedente será considerado para pagamento em folha mensal", 4 }
                });

            migrationBuilder.InsertData(
                table: "APITabela",
                columns: new[] { "IdTabela", "DataHoraAlteracao", "DataVigenciaInicial", "Descricao", "IdTabelaTipo", "ValorDeducaoDependente" },
                values: new object[,]
                {
                    { 52, null, new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 09/1994 a 09/1994", 2, 62.07m },
                    { 51, null, new DateTime(1994, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 08/1994 a 08/1994", 2, 23.64m },
                    { 50, null, new DateTime(1994, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 07/1994 a 07/1994", 2, 22.47m },
                    { 49, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2022", 1, null },
                    { 48, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2021", 1, null },
                    { 47, null, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 03/2020", 1, null },
                    { 46, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2020", 1, null },
                    { 44, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2018", 1, null },
                    { 53, null, new DateTime(1994, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 10/1994 a 10/1994", 2, 63.08m },
                    { 43, null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2017", 1, null },
                    { 42, null, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2016", 1, null },
                    { 41, null, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2015", 1, null },
                    { 40, null, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2014", 1, null },
                    { 39, null, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2013", 1, null },
                    { 45, null, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2019", 1, null },
                    { 54, null, new DateTime(1994, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 11/1994 a 11/1994", 2, 64.28m },
                    { 57, null, new DateTime(1995, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 04/1995 a 06/1995", 2, 70.61m },
                    { 56, null, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/1995 a 03/1995", 2, 67.67m },
                    { 71, null, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/2013 a 12/2013", 2, 171.97m },
                    { 70, null, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/2012 a 12/2012", 2, 164.56m },
                    { 69, null, new DateTime(2011, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 04/2011 a 12/2011", 2, 157.47m },
                    { 68, null, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/2010 a 03/2011", 2, 150.69m },
                    { 67, null, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/2009 a 12/2009", 2, 144.2m },
                    { 66, null, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/2008 a 12/2008", 2, 137.99m },
                    { 65, null, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/2007 a 12/2007", 2, 132.05m },
                    { 64, null, new DateTime(2006, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 02/2006 a 12/2006", 2, 126.36m },
                    { 63, null, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/2005 a 01/2006", 2, 117m },
                    { 62, null, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/2002 a 12/2004", 2, 106m },
                    { 61, null, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/1998 a 12/2001", 2, 90m },
                    { 60, null, new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/1996 a 12/1997", 2, 90m },
                    { 59, null, new DateTime(1995, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 10/1995 a 12/1995", 2, 79.52m },
                    { 58, null, new DateTime(1995, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 07/1995 a 09/1995", 2, 75.64m },
                    { 38, null, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2012", 1, null },
                    { 55, null, new DateTime(1994, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 12/1994 a 12/1994", 2, 66.18m },
                    { 37, null, new DateTime(2011, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 07/2011", 1, null },
                    { 34, null, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2010", 1, null },
                    { 35, null, new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2010", 1, null }
                });

            migrationBuilder.InsertData(
                table: "APITabela",
                columns: new[] { "IdTabela", "DataHoraAlteracao", "DataVigenciaInicial", "Descricao", "IdTabelaTipo", "ValorDeducaoDependente" },
                values: new object[,]
                {
                    { 15, null, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/2000", 1, null },
                    { 14, null, new DateTime(2000, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2000", 1, null },
                    { 13, null, new DateTime(1999, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 07/1999", 1, null },
                    { 12, null, new DateTime(1999, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/1999", 1, null },
                    { 11, null, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/1999", 1, null },
                    { 10, null, new DateTime(1998, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 12/1998", 1, null },
                    { 9, null, new DateTime(1998, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/1998", 1, null },
                    { 8, null, new DateTime(1998, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/1998", 1, null },
                    { 7, null, new DateTime(1997, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/1997", 1, null },
                    { 6, null, new DateTime(1997, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/1997", 1, null },
                    { 5, null, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/1997", 1, null },
                    { 4, null, new DateTime(1996, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/1996", 1, null },
                    { 3, null, new DateTime(1995, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 08/1995", 1, null },
                    { 2, null, new DateTime(1995, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/1995", 1, null },
                    { 1, null, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/1995", 1, null },
                    { 16, null, new DateTime(2000, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2000", 1, null },
                    { 36, null, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2011", 1, null },
                    { 17, null, new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 07/2000", 1, null },
                    { 19, null, new DateTime(2001, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2001", 1, null },
                    { 72, null, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 01/2014 a 03/2015", 2, 179.71m },
                    { 33, null, new DateTime(2009, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 02/2009", 1, null },
                    { 32, null, new DateTime(2008, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 03/2008", 1, null },
                    { 31, null, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2008", 1, null },
                    { 30, null, new DateTime(2007, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2007", 1, null },
                    { 29, null, new DateTime(2006, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 08/2006", 1, null },
                    { 28, null, new DateTime(2006, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2006", 1, null },
                    { 27, null, new DateTime(2005, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/2005", 1, null },
                    { 26, null, new DateTime(2004, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/2004", 1, null },
                    { 25, null, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2004", 1, null },
                    { 24, null, new DateTime(2003, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2003", 1, null },
                    { 23, null, new DateTime(2003, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2003", 1, null },
                    { 22, null, new DateTime(2002, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2002", 1, null },
                    { 21, null, new DateTime(2002, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2002", 1, null },
                    { 20, null, new DateTime(2001, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2001", 1, null },
                    { 18, null, new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 03/2001", 1, null },
                    { 73, null, new DateTime(2015, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabela de IRRF de 04/2015 a 01/2022", 2, 189.59m }
                });

            migrationBuilder.InsertData(
                table: "APIParametroUsuario",
                columns: new[] { "IdParametroUsuario", "DataHoraAlteracao", "DataVigenciaInicial", "IdParametro", "IdUsuario", "Valor" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "09:00" },
                    { 2, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "18:00" },
                    { 3, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "01:00" },
                    { 4, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, "00:10" },
                    { 5, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, "02:00" }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "ValorAliquota", "ValorDeducao" },
                values: new object[,]
                {
                    { 183, null, 52, 620.71m, 0m, 0m, 0m },
                    { 182, null, 51, 999999.99m, 10639.81m, 35m, 1116.14m },
                    { 181, null, 51, 10639.8m, 1152.66m, 26.6m, 222.49m },
                    { 180, null, 51, 1152.65m, 591.11m, 15m, 88.66m },
                    { 179, null, 51, 591.1m, 0m, 0m, 0m },
                    { 178, null, 50, 999999.99m, 10112.41m, 35m, 1060.82m },
                    { 175, null, 50, 561.8m, 0m, 0m, 0m },
                    { 176, null, 50, 1095.51m, 561.81m, 15m, 84.27m },
                    { 184, null, 52, 1210.36m, 620.72m, 15m, 93.1m },
                    { 174, null, 49, 7088.5m, 3641.7m, 14m, null },
                    { 173, null, 49, 3641.69m, 2427.8m, 12m, null },
                    { 172, null, 49, 2427.79m, 1212.01m, 9m, null },
                    { 171, null, 49, 1212m, 0m, 7.5m, null },
                    { 177, null, 50, 10112.4m, 1095.52m, 26.6m, 211.46m },
                    { 185, null, 52, 11172.6m, 1210.37m, 26.6m, 233.63m },
                    { 187, null, 53, 630.8m, 0m, 0m, 0m },
                    { 170, null, 48, 6433.57m, 3305.23m, 14m, null },
                    { 188, null, 53, 1230.06m, 630.81m, 15m, 94.62m },
                    { 189, null, 53, 11354.4m, 1230.07m, 26.6m, 237.43m },
                    { 190, null, 53, 999999.99m, 11354.41m, 35m, 1191.11m },
                    { 191, null, 54, 642.8m, 0m, 0m, 0m },
                    { 192, null, 54, 1253.47m, 642.81m, 15m, 96.42m },
                    { 193, null, 54, 11570.4m, 1253.48m, 26.6m, 241.94m },
                    { 194, null, 54, 999999.99m, 11570.41m, 35m, 1213.77m },
                    { 195, null, 55, 661.8m, 0m, 0m, 0m },
                    { 196, null, 55, 1290.51m, 661.81m, 15m, 99.27m },
                    { 197, null, 55, 11912.4m, 1290.52m, 26.6m, 249.09m },
                    { 198, null, 55, 999999.99m, 11912.41m, 35m, 1249.64m },
                    { 199, null, 56, 676.7m, 0m, 0m, 0m },
                    { 200, null, 56, 1319.57m, 676.71m, 15m, 101.51m },
                    { 186, null, 52, 999999.99m, 11172.61m, 35m, 1172.04m },
                    { 169, null, 48, 3305.22m, 2203.49m, 12m, null },
                    { 167, null, 48, 1100m, 0m, 7.5m, null },
                    { 201, null, 56, 12180.6m, 1319.58m, 26.6m, 254.7m },
                    { 137, null, 38, 1958.1m, 1174.87m, 9m, null },
                    { 138, null, 38, 3916.2m, 1958.11m, 11m, null },
                    { 139, null, 39, 1247.7m, 0m, 8m, null }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "ValorAliquota", "ValorDeducao" },
                values: new object[,]
                {
                    { 140, null, 39, 2079.5m, 1247.71m, 9m, null },
                    { 141, null, 39, 4159m, 2079.51m, 11m, null },
                    { 142, null, 40, 1317.07m, 0m, 8m, null },
                    { 143, null, 40, 2195.12m, 1317.08m, 9m, null },
                    { 144, null, 40, 4390.24m, 2195.13m, 11m, null },
                    { 145, null, 41, 1399.12m, 0m, 8m, null },
                    { 146, null, 41, 2331.88m, 1399.13m, 9m, null },
                    { 147, null, 41, 4663.75m, 2331.89m, 11m, null },
                    { 148, null, 42, 1556.94m, 0m, 8m, null },
                    { 149, null, 42, 2594.92m, 1556.95m, 9m, null },
                    { 150, null, 42, 5189.82m, 2594.93m, 11m, null },
                    { 168, null, 48, 2203.48m, 1100.01m, 9m, null },
                    { 151, null, 43, 1659.38m, 0m, 8m, null },
                    { 153, null, 43, 5531.31m, 2765.67m, 11m, null },
                    { 154, null, 44, 1693.72m, 0m, 8m, null },
                    { 155, null, 44, 2822.9m, 1693.73m, 9m, null },
                    { 156, null, 44, 5645.8m, 2822.91m, 11m, null },
                    { 157, null, 45, 1751.81m, 0m, 8m, null },
                    { 158, null, 45, 2919.72m, 1751.82m, 9m, null },
                    { 159, null, 45, 5839.45m, 2919.73m, 11m, null },
                    { 160, null, 46, 1830.29m, 0m, 8m, null },
                    { 161, null, 46, 3050.52m, 1830.3m, 9m, null },
                    { 162, null, 46, 6101.06m, 3050.53m, 11m, null },
                    { 163, null, 47, 1045m, 0m, 7.5m, null },
                    { 164, null, 47, 2089.6m, 1045.01m, 9m, null },
                    { 165, null, 47, 3134.4m, 2089.61m, 12m, null },
                    { 166, null, 47, 6101.06m, 3134.41m, 14m, null },
                    { 152, null, 43, 2765.66m, 1659.39m, 9m, null },
                    { 202, null, 56, 999999.99m, 12180.61m, 35m, 1277.78m },
                    { 204, null, 57, 1376.84m, 706.11m, 15m, 105.91m },
                    { 136, null, 38, 1174.86m, 0m, 8m, null },
                    { 239, null, 67, 3582m, 2866.71m, 22.5m, 483.84m },
                    { 240, null, 67, 999999.99m, 3582.01m, 27.5m, 662.94m },
                    { 241, null, 68, 1499.15m, 0m, 0m, 0m },
                    { 242, null, 68, 2246.75m, 1499.16m, 7.5m, 112.43m },
                    { 243, null, 68, 2995.7m, 2246.76m, 15m, 280.94m },
                    { 244, null, 68, 3743.19m, 2995.71m, 22.5m, 505.62m },
                    { 245, null, 68, 999999.99m, 3743.2m, 27.5m, 692.78m },
                    { 246, null, 69, 1566.61m, 0m, 0m, 0m },
                    { 247, null, 69, 2347.85m, 1566.62m, 7.5m, 117.49m },
                    { 248, null, 69, 3130.51m, 2347.86m, 15m, 293.58m },
                    { 249, null, 69, 3911.63m, 3130.52m, 22.5m, 528.37m }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "ValorAliquota", "ValorDeducao" },
                values: new object[,]
                {
                    { 250, null, 69, 999999.99m, 3911.64m, 27.5m, 723.95m },
                    { 251, null, 70, 1637.11m, 0m, 0m, 0m },
                    { 252, null, 70, 2453.5m, 1637.12m, 7.5m, 122.78m },
                    { 238, null, 67, 2866.7m, 2150.01m, 15m, 268.84m },
                    { 253, null, 70, 3271.38m, 2453.51m, 15m, 306.8m },
                    { 255, null, 70, 999999.99m, 4087.66m, 27.5m, 756.53m },
                    { 256, null, 71, 1710.78m, 0m, 0m, 0m },
                    { 257, null, 71, 2563.91m, 1710.79m, 7.5m, 128.31m },
                    { 258, null, 71, 3418.59m, 2563.92m, 15m, 320.6m },
                    { 259, null, 71, 4271.59m, 3418.6m, 22.5m, 577m },
                    { 260, null, 71, 999999.99m, 4271.6m, 27.5m, 790.58m },
                    { 261, null, 72, 1787.77m, 0m, 0m, 0m },
                    { 262, null, 72, 2679.29m, 1787.78m, 7.5m, 134.08m },
                    { 263, null, 72, 3572.43m, 2679.3m, 15m, 335.03m },
                    { 264, null, 72, 4463.81m, 3572.44m, 22.5m, 602.96m },
                    { 265, null, 72, 999999.99m, 4463.82m, 27.5m, 826.15m },
                    { 266, null, 73, 1903.98m, 0m, 0m, 0m },
                    { 267, null, 73, 2826.65m, 1903.99m, 7.5m, 142.8m },
                    { 268, null, 73, 3751.05m, 2826.66m, 15m, 354.8m },
                    { 254, null, 70, 4087.65m, 3271.39m, 22.5m, 552.15m },
                    { 203, null, 57, 706.1m, 0m, 0m, 0m },
                    { 237, null, 67, 2150m, 1434.6m, 7.5m, 107.59m },
                    { 235, null, 66, 999999.99m, 2743.26m, 27.5m, 548.82m },
                    { 205, null, 57, 12709.24m, 1376.85m, 26.6m, 265.76m },
                    { 206, null, 57, 999999.99m, 12709.25m, 35m, 1333.23m },
                    { 207, null, 58, 756.44m, 0m, 0m, 0m },
                    { 208, null, 58, 1475.01m, 756.45m, 15m, 103.47m },
                    { 209, null, 58, 13615.41m, 1475.02m, 26.6m, 284.71m },
                    { 210, null, 58, 999999.99m, 13615.42m, 35m, 1428.29m },
                    { 211, null, 59, 795.24m, 0m, 0m, 0m },
                    { 212, null, 59, 1550.68m, 795.25m, 15m, 119.29m },
                    { 213, null, 59, 14313.88m, 1550.69m, 26.6m, 299.32m },
                    { 214, null, 59, 999999.99m, 14313.89m, 35m, 1501.57m },
                    { 215, null, 60, 900m, 0m, 0m, 0m },
                    { 216, null, 60, 1800m, 900.01m, 15m, 135m },
                    { 217, null, 60, 999999.99m, 1800.01m, 25m, 315m },
                    { 218, null, 61, 900m, 0m, 0m, 0m },
                    { 236, null, 67, 1434.59m, 0m, 0m, 0m },
                    { 219, null, 61, 1800m, 900.01m, 15m, 135m },
                    { 221, null, 62, 1058m, 0m, 0m, 0m },
                    { 222, null, 62, 2115m, 1058.01m, 15m, 158.7m },
                    { 223, null, 62, 999999.99m, 2115.01m, 27.5m, 423.08m }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "ValorAliquota", "ValorDeducao" },
                values: new object[,]
                {
                    { 224, null, 63, 1164m, 0m, 0m, 0m },
                    { 225, null, 63, 2326m, 1164.01m, 15m, 174.6m },
                    { 226, null, 63, 999999.99m, 2326.01m, 27.5m, 465.35m },
                    { 227, null, 64, 1257.12m, 0m, 0m, 0m },
                    { 228, null, 64, 2512.08m, 1257.13m, 15m, 188.57m },
                    { 229, null, 64, 999999.99m, 2512.09m, 27.5m, 502.58m },
                    { 230, null, 65, 1313.69m, 0m, 0m, 0m },
                    { 231, null, 65, 2625.12m, 1313.7m, 15m, 197.05m },
                    { 232, null, 65, 999999.99m, 2625.13m, 27.5m, 525.19m },
                    { 233, null, 66, 1372.81m, 0m, 0m, 0m },
                    { 234, null, 66, 2743.25m, 1372.82m, 15m, 205.92m },
                    { 220, null, 61, 999999.99m, 1800.01m, 27.5m, 360m },
                    { 135, null, 37, 3691.74m, 1845.88m, 11m, null },
                    { 133, null, 37, 1107.52m, 0m, 8m, null },
                    { 269, null, 73, 4664.68m, 3751.06m, 22.5m, 636.13m },
                    { 35, null, 10, 600m, 390.01m, 9m, null },
                    { 36, null, 10, 1200m, 600.01m, 11m, null },
                    { 37, null, 11, 360m, 0m, 8m, null },
                    { 38, null, 11, 600m, 360.01m, 9m, null },
                    { 39, null, 11, 1200m, 600.01m, 11m, null },
                    { 40, null, 12, 376.6m, 0m, 7.65m, null },
                    { 41, null, 12, 408m, 376.61m, 8.65m, null },
                    { 42, null, 12, 627.66m, 408.01m, 9m, null },
                    { 43, null, 12, 1255.32m, 627.67m, 11m, null },
                    { 44, null, 13, 376.6m, 0m, 7.65m, null },
                    { 45, null, 13, 408m, 376.61m, 8.65m, null },
                    { 46, null, 13, 627.66m, 408.01m, 9m, null },
                    { 47, null, 13, 1255.32m, 627.67m, 11m, null },
                    { 48, null, 14, 376.6m, 0m, 7.65m, null },
                    { 34, null, 10, 390m, 360.01m, 8.82m, null },
                    { 49, null, 14, 450m, 376.61m, 8.65m, null },
                    { 51, null, 14, 1255.32m, 627.67m, 11m, null },
                    { 52, null, 15, 376.6m, 0m, 7.65m, null },
                    { 53, null, 15, 453m, 376.61m, 8.65m, null },
                    { 54, null, 15, 627.66m, 453.01m, 9m, null },
                    { 55, null, 15, 1255.32m, 627.67m, 11m, null },
                    { 56, null, 16, 398.48m, 0m, 7.72m, null },
                    { 57, null, 16, 453m, 398.49m, 8.73m, null },
                    { 58, null, 16, 664.13m, 453.01m, 9m, null },
                    { 59, null, 16, 1328.25m, 664.14m, 11m, null },
                    { 60, null, 17, 398.48m, 0m, 7.72m, null },
                    { 61, null, 17, 453m, 398.49m, 8.73m, null }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "ValorAliquota", "ValorDeducao" },
                values: new object[,]
                {
                    { 62, null, 17, 664.13m, 453.01m, 9m, null },
                    { 63, null, 17, 1328.25m, 664.14m, 11m, null },
                    { 64, null, 18, 398.48m, 0m, 7.65m, null },
                    { 50, null, 14, 627.66m, 450.01m, 9m, null },
                    { 65, null, 18, 453m, 398.49m, 8.65m, null },
                    { 33, null, 10, 360m, 0m, 7.82m, null },
                    { 31, null, 9, 540.75m, 390.01m, 9m, null },
                    { 1, null, 1, 174.86m, 0m, 8m, null },
                    { 2, null, 1, 291.43m, 174.87m, 9m, null },
                    { 3, null, 1, 582.86m, 291.44m, 10m, null },
                    { 4, null, 2, 249.8m, 0m, 8m, null },
                    { 5, null, 2, 416.33m, 249.81m, 9m, null },
                    { 6, null, 2, 832.66m, 416.34m, 10m, null },
                    { 7, null, 3, 249.8m, 0m, 8m, null },
                    { 8, null, 3, 416.33m, 249.81m, 9m, null },
                    { 9, null, 3, 832.66m, 416.34m, 11m, null },
                    { 10, null, 4, 287.27m, 0m, 8m, null },
                    { 11, null, 4, 478.78m, 287.28m, 9m, null },
                    { 12, null, 4, 957.56m, 478.79m, 11m, null },
                    { 13, null, 5, 287.27m, 0m, 7.82m, null },
                    { 14, null, 5, 336m, 287.28m, 8.82m, null },
                    { 32, null, 9, 1081.5m, 540.76m, 11m, null },
                    { 15, null, 5, 478.78m, 336.01m, 9m, null },
                    { 17, null, 6, 287.27m, 0m, 7.82m, null },
                    { 18, null, 6, 360m, 287.28m, 8.82m, null },
                    { 19, null, 6, 478.78m, 360.01m, 9m, null },
                    { 20, null, 6, 957.56m, 478.79m, 11m, null },
                    { 21, null, 7, 309.56m, 0m, 7.82m, null },
                    { 22, null, 7, 360m, 309.57m, 8.82m, null },
                    { 23, null, 7, 515.93m, 360.01m, 9m, null },
                    { 24, null, 7, 1031.87m, 515.94m, 11m, null },
                    { 25, null, 8, 309.56m, 0m, 7.82m, null },
                    { 26, null, 8, 390m, 309.57m, 8.82m, null },
                    { 27, null, 8, 515.93m, 390.01m, 9m, null },
                    { 28, null, 8, 1031.87m, 515.94m, 11m, null },
                    { 29, null, 9, 324.45m, 0m, 7.82m, null },
                    { 30, null, 9, 390m, 324.46m, 8.82m, null },
                    { 16, null, 5, 957.56m, 478.79m, 11m, null },
                    { 134, null, 37, 1845.87m, 1107.53m, 9m, null },
                    { 66, null, 18, 664.13m, 453.01m, 9m, null },
                    { 68, null, 19, 398.48m, 0m, 7.65m, null },
                    { 103, null, 28, 840.47m, 0m, 7.65m, null }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "ValorAliquota", "ValorDeducao" },
                values: new object[,]
                {
                    { 104, null, 28, 1050m, 840.48m, 8.65m, null },
                    { 105, null, 28, 1400.77m, 1050.01m, 9m, null },
                    { 106, null, 28, 2801.56m, 1400.78m, 11m, null },
                    { 107, null, 29, 840.55m, 0m, 7.65m, null },
                    { 108, null, 29, 1050m, 840.56m, 8.65m, null },
                    { 109, null, 29, 1400.91m, 1050.01m, 9m, null },
                    { 110, null, 29, 2801.82m, 1400.92m, 11m, null },
                    { 111, null, 30, 868.29m, 0m, 7.65m, null },
                    { 112, null, 30, 1140m, 868.3m, 8.65m, null },
                    { 113, null, 30, 1447.14m, 1140.01m, 9m, null },
                    { 114, null, 30, 2894.28m, 1447.15m, 11m, null },
                    { 115, null, 31, 868.29m, 0m, 8m, null },
                    { 116, null, 31, 1447.14m, 868.3m, 9m, null },
                    { 102, null, 27, 2668.15m, 1334.08m, 11m, null },
                    { 117, null, 31, 2894.28m, 1447.15m, 11m, null },
                    { 119, null, 32, 1519.5m, 911.71m, 9m, null },
                    { 120, null, 32, 3038.99m, 1519.51m, 11m, null },
                    { 121, null, 33, 965.67m, 0m, 8m, null },
                    { 122, null, 33, 1609.45m, 965.68m, 9m, null },
                    { 123, null, 33, 3218.9m, 1609.46m, 11m, null },
                    { 124, null, 34, 1024.97m, 0m, 8m, null },
                    { 125, null, 34, 1708.27m, 1024.98m, 9m, null },
                    { 126, null, 34, 3416.24m, 1708.28m, 11m, null },
                    { 127, null, 35, 1040.22m, 0m, 8m, null },
                    { 128, null, 35, 1733.7m, 1040.23m, 9m, null },
                    { 129, null, 35, 3467.4m, 1733.71m, 11m, null },
                    { 130, null, 36, 1106.9m, 0m, 8m, null },
                    { 131, null, 36, 1844.83m, 1106.91m, 9m, null },
                    { 132, null, 36, 3689.66m, 1844.84m, 11m, null },
                    { 118, null, 32, 911.7m, 0m, 8m, null },
                    { 67, null, 18, 1328.25m, 664.14m, 11m, null },
                    { 101, null, 27, 1334.07m, 900.01m, 9m, null },
                    { 99, null, 27, 800.45m, 0m, 7.65m, null },
                    { 69, null, 19, 540m, 398.49m, 8.65m, null },
                    { 70, null, 19, 664.13m, 540.01m, 9m, null },
                    { 71, null, 19, 1328.25m, 664.14m, 11m, null },
                    { 72, null, 20, 429m, 0m, 7.65m, null },
                    { 73, null, 20, 540m, 429.01m, 8.65m, null },
                    { 74, null, 20, 715m, 540.01m, 9m, null },
                    { 75, null, 20, 1430m, 715.01m, 11m, null },
                    { 76, null, 21, 429m, 0m, 7.65m, null },
                    { 77, null, 21, 600m, 429.01m, 8.65m, null }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "ValorAliquota", "ValorDeducao" },
                values: new object[,]
                {
                    { 78, null, 21, 715m, 600.01m, 9m, null },
                    { 79, null, 21, 1430m, 715.01m, 11m, null },
                    { 80, null, 22, 468.47m, 0m, 7.65m, null },
                    { 81, null, 22, 600m, 468.48m, 8.65m, null },
                    { 82, null, 22, 780.78m, 600.01m, 9m, null },
                    { 100, null, 27, 900m, 800.46m, 8.65m, null },
                    { 83, null, 22, 1561.56m, 780.79m, 11m, null },
                    { 85, null, 23, 720m, 468.48m, 8.65m, null },
                    { 86, null, 23, 780.78m, 720.01m, 9m, null },
                    { 87, null, 23, 1561.56m, 780.79m, 11m, null },
                    { 88, null, 24, 560.81m, 0m, 7.65m, null },
                    { 89, null, 24, 720m, 560.82m, 8.65m, null },
                    { 90, null, 24, 934.67m, 720.01m, 9m, null },
                    { 91, null, 24, 1869.34m, 934.68m, 11m, null },
                    { 92, null, 25, 720m, 0m, 7.65m, null },
                    { 93, null, 25, 1200m, 720.01m, 9m, null },
                    { 94, null, 25, 2400m, 1200.01m, 11m, null },
                    { 95, null, 26, 752.62m, 0m, 7.65m, null },
                    { 96, null, 26, 780m, 752.63m, 8.65m, null },
                    { 97, null, 26, 1254.36m, 780.01m, 9m, null },
                    { 98, null, 26, 2508.72m, 1254.37m, 11m, null },
                    { 84, null, 23, 468.47m, 0m, 7.65m, null },
                    { 270, null, 73, 999999.99m, 4664.69m, 27.5m, 869.36m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_APIParametro_IdParametroTipoDado",
                table: "APIParametro",
                column: "IdParametroTipoDado");

            migrationBuilder.CreateIndex(
                name: "IX_APIParametroUsuario_IdParametro",
                table: "APIParametroUsuario",
                column: "IdParametro");

            migrationBuilder.CreateIndex(
                name: "IX_APIParametroUsuario_IdUsuario",
                table: "APIParametroUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_APITabela_IdTabelaTipo",
                table: "APITabela",
                column: "IdTabelaTipo");

            migrationBuilder.CreateIndex(
                name: "IX_APITabelaItem_IdTabela",
                table: "APITabelaItem",
                column: "IdTabela");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIParametroUsuario");

            migrationBuilder.DropTable(
                name: "APITabelaItem");

            migrationBuilder.DropTable(
                name: "APIParametro");

            migrationBuilder.DropTable(
                name: "APITabela");

            migrationBuilder.DropTable(
                name: "APIParametroTipoDado");

            migrationBuilder.DropTable(
                name: "APITabelaTipo");
        }
    }
}
