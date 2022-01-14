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
                    Valor = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
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
                    { 2, null, "IRPF" }
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
                columns: new[] { "IdTabela", "DataHoraAlteracao", "DataVigenciaInicial", "Descricao", "IdTabelaTipo" },
                values: new object[,]
                {
                    { 27, null, new DateTime(2005, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/2005", 1 },
                    { 28, null, new DateTime(2006, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2006", 1 },
                    { 29, null, new DateTime(2006, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 08/2006", 1 },
                    { 30, null, new DateTime(2007, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2007", 1 },
                    { 31, null, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2008", 1 },
                    { 32, null, new DateTime(2008, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 03/2008", 1 },
                    { 33, null, new DateTime(2009, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 02/2009", 1 },
                    { 34, null, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2010", 1 },
                    { 35, null, new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2010", 1 },
                    { 36, null, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2011", 1 },
                    { 39, null, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2013", 1 },
                    { 38, null, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2012", 1 },
                    { 26, null, new DateTime(2004, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/2004", 1 },
                    { 40, null, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2014", 1 },
                    { 41, null, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2015", 1 },
                    { 42, null, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2016", 1 },
                    { 43, null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2017", 1 },
                    { 44, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2018", 1 },
                    { 45, null, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2019", 1 },
                    { 46, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2020", 1 },
                    { 47, null, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 03/2020", 1 },
                    { 37, null, new DateTime(2011, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 07/2011", 1 },
                    { 25, null, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2004", 1 },
                    { 22, null, new DateTime(2002, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2002", 1 },
                    { 23, null, new DateTime(2003, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2003", 1 },
                    { 1, null, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/1995", 1 },
                    { 2, null, new DateTime(1995, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/1995", 1 },
                    { 3, null, new DateTime(1995, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 08/1995", 1 },
                    { 4, null, new DateTime(1996, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/1996", 1 },
                    { 5, null, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/1997", 1 },
                    { 6, null, new DateTime(1997, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/1997", 1 },
                    { 7, null, new DateTime(1997, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/1997", 1 },
                    { 8, null, new DateTime(1998, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/1998", 1 },
                    { 9, null, new DateTime(1998, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/1998", 1 },
                    { 10, null, new DateTime(1998, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 12/1998", 1 },
                    { 24, null, new DateTime(2003, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2003", 1 },
                    { 11, null, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/1999", 1 }
                });

            migrationBuilder.InsertData(
                table: "APITabela",
                columns: new[] { "IdTabela", "DataHoraAlteracao", "DataVigenciaInicial", "Descricao", "IdTabelaTipo" },
                values: new object[,]
                {
                    { 13, null, new DateTime(1999, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 07/1999", 1 },
                    { 14, null, new DateTime(2000, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2000", 1 },
                    { 15, null, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 05/2000", 1 },
                    { 16, null, new DateTime(2000, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2000", 1 },
                    { 17, null, new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 07/2000", 1 },
                    { 18, null, new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 03/2001", 1 },
                    { 19, null, new DateTime(2001, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2001", 1 },
                    { 20, null, new DateTime(2001, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/2001", 1 },
                    { 21, null, new DateTime(2002, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 04/2002", 1 },
                    { 48, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2021", 1 },
                    { 12, null, new DateTime(1999, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 06/1999", 1 },
                    { 49, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INSS a partir de 01/2022", 1 }
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
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "Valor" },
                values: new object[,]
                {
                    { 111, null, 30, 868.29m, 0m, 7.65m },
                    { 112, null, 30, 1140m, 868.3m, 8.65m },
                    { 113, null, 30, 1447.14m, 1140.01m, 9m },
                    { 114, null, 30, 2894.28m, 1447.15m, 11m },
                    { 115, null, 31, 868.29m, 0m, 8m },
                    { 116, null, 31, 1447.14m, 868.3m, 9m },
                    { 117, null, 31, 2894.28m, 1447.15m, 11m },
                    { 118, null, 32, 911.7m, 0m, 8m },
                    { 119, null, 32, 1519.5m, 911.71m, 9m },
                    { 121, null, 33, 965.67m, 0m, 8m },
                    { 110, null, 29, 2801.82m, 1400.92m, 11m },
                    { 122, null, 33, 1609.45m, 965.68m, 9m },
                    { 123, null, 33, 3218.9m, 1609.46m, 11m },
                    { 124, null, 34, 1024.97m, 0m, 8m },
                    { 125, null, 34, 1708.27m, 1024.98m, 9m },
                    { 126, null, 34, 3416.24m, 1708.28m, 11m },
                    { 127, null, 35, 1040.22m, 0m, 8m },
                    { 128, null, 35, 1733.7m, 1040.23m, 9m },
                    { 120, null, 32, 3038.99m, 1519.51m, 11m },
                    { 109, null, 29, 1400.91m, 1050.01m, 9m },
                    { 107, null, 29, 840.55m, 0m, 7.65m },
                    { 129, null, 35, 3467.4m, 1733.71m, 11m },
                    { 89, null, 24, 720m, 560.82m, 8.65m },
                    { 90, null, 24, 934.67m, 720.01m, 9m },
                    { 91, null, 24, 1869.34m, 934.68m, 11m },
                    { 92, null, 25, 720m, 0m, 7.65m },
                    { 93, null, 25, 1200m, 720.01m, 9m },
                    { 94, null, 25, 2400m, 1200.01m, 11m },
                    { 95, null, 26, 752.62m, 0m, 7.65m },
                    { 96, null, 26, 780m, 752.63m, 8.65m },
                    { 108, null, 29, 1050m, 840.56m, 8.65m },
                    { 97, null, 26, 1254.36m, 780.01m, 9m },
                    { 99, null, 27, 800.45m, 0m, 7.65m },
                    { 100, null, 27, 900m, 800.46m, 8.65m },
                    { 101, null, 27, 1334.07m, 900.01m, 9m },
                    { 102, null, 27, 2668.15m, 1334.08m, 11m },
                    { 103, null, 28, 840.47m, 0m, 7.65m }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "Valor" },
                values: new object[,]
                {
                    { 104, null, 28, 1050m, 840.48m, 8.65m },
                    { 105, null, 28, 1400.77m, 1050.01m, 9m },
                    { 106, null, 28, 2801.56m, 1400.78m, 11m },
                    { 98, null, 26, 2508.72m, 1254.37m, 11m },
                    { 130, null, 36, 1106.9m, 0m, 8m },
                    { 132, null, 36, 3689.66m, 1844.84m, 11m },
                    { 88, null, 24, 560.81m, 0m, 7.65m },
                    { 155, null, 44, 2822.9m, 1693.73m, 9m },
                    { 156, null, 44, 5645.8m, 2822.91m, 11m },
                    { 157, null, 45, 1751.81m, 0m, 8m },
                    { 158, null, 45, 2919.72m, 1751.82m, 9m },
                    { 159, null, 45, 5839.45m, 2919.73m, 11m },
                    { 160, null, 46, 1830.29m, 0m, 8m },
                    { 161, null, 46, 3050.52m, 1830.3m, 9m },
                    { 162, null, 46, 6101.06m, 3050.53m, 11m },
                    { 154, null, 44, 1693.72m, 0m, 8m },
                    { 163, null, 47, 1045m, 0m, 7.5m },
                    { 165, null, 47, 3134.4m, 2089.61m, 12m },
                    { 166, null, 47, 6101.06m, 3134.41m, 14m },
                    { 167, null, 48, 1100m, 0m, 7.5m },
                    { 168, null, 48, 2203.48m, 1100.01m, 9m },
                    { 169, null, 48, 3305.22m, 2203.49m, 12m },
                    { 170, null, 48, 6433.57m, 3305.23m, 14m },
                    { 171, null, 49, 1212m, 0m, 7.5m },
                    { 172, null, 49, 2427.79m, 1212.01m, 9m },
                    { 164, null, 47, 2089.6m, 1045.01m, 9m },
                    { 131, null, 36, 1844.83m, 1106.91m, 9m },
                    { 153, null, 43, 5531.31m, 2765.67m, 11m },
                    { 151, null, 43, 1659.38m, 0m, 8m },
                    { 133, null, 37, 1107.52m, 0m, 8m },
                    { 134, null, 37, 1845.87m, 1107.53m, 9m },
                    { 135, null, 37, 3691.74m, 1845.88m, 11m },
                    { 136, null, 38, 1174.86m, 0m, 8m },
                    { 137, null, 38, 1958.1m, 1174.87m, 9m },
                    { 138, null, 38, 3916.2m, 1958.11m, 11m },
                    { 139, null, 39, 1247.7m, 0m, 8m },
                    { 140, null, 39, 2079.5m, 1247.71m, 9m },
                    { 152, null, 43, 2765.66m, 1659.39m, 9m },
                    { 141, null, 39, 4159m, 2079.51m, 11m },
                    { 143, null, 40, 2195.12m, 1317.08m, 9m },
                    { 144, null, 40, 4390.24m, 2195.13m, 11m },
                    { 145, null, 41, 1399.12m, 0m, 8m }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "Valor" },
                values: new object[,]
                {
                    { 146, null, 41, 2331.88m, 1399.13m, 9m },
                    { 147, null, 41, 4663.75m, 2331.89m, 11m },
                    { 148, null, 42, 1556.94m, 0m, 8m },
                    { 149, null, 42, 2594.92m, 1556.95m, 9m },
                    { 150, null, 42, 5189.82m, 2594.93m, 11m },
                    { 142, null, 40, 1317.07m, 0m, 8m },
                    { 87, null, 23, 1561.56m, 780.79m, 11m },
                    { 85, null, 23, 720m, 468.48m, 8.65m },
                    { 173, null, 49, 3641.69m, 2427.8m, 12m },
                    { 23, null, 7, 515.93m, 360.01m, 9m },
                    { 24, null, 7, 1031.87m, 515.94m, 11m },
                    { 25, null, 8, 309.56m, 0m, 7.82m },
                    { 26, null, 8, 390m, 309.57m, 8.82m },
                    { 27, null, 8, 515.93m, 390.01m, 9m },
                    { 28, null, 8, 1031.87m, 515.94m, 11m },
                    { 29, null, 9, 324.45m, 0m, 7.82m },
                    { 30, null, 9, 390m, 324.46m, 8.82m },
                    { 22, null, 7, 360m, 309.57m, 8.82m },
                    { 31, null, 9, 540.75m, 390.01m, 9m },
                    { 33, null, 10, 360m, 0m, 7.82m },
                    { 34, null, 10, 390m, 360.01m, 8.82m },
                    { 35, null, 10, 600m, 390.01m, 9m },
                    { 36, null, 10, 1200m, 600.01m, 11m },
                    { 37, null, 11, 360m, 0m, 8m },
                    { 38, null, 11, 600m, 360.01m, 9m },
                    { 39, null, 11, 1200m, 600.01m, 11m },
                    { 40, null, 12, 376.6m, 0m, 7.65m },
                    { 32, null, 9, 1081.5m, 540.76m, 11m },
                    { 41, null, 12, 408m, 376.61m, 8.65m },
                    { 21, null, 7, 309.56m, 0m, 7.82m },
                    { 19, null, 6, 478.78m, 360.01m, 9m },
                    { 1, null, 1, 174.86m, 0m, 8m },
                    { 2, null, 1, 291.43m, 174.87m, 9m },
                    { 3, null, 1, 582.86m, 291.44m, 10m },
                    { 4, null, 2, 249.8m, 0m, 8m },
                    { 5, null, 2, 416.33m, 249.81m, 9m },
                    { 6, null, 2, 832.66m, 416.34m, 10m },
                    { 7, null, 3, 249.8m, 0m, 8m },
                    { 8, null, 3, 416.33m, 249.81m, 9m },
                    { 20, null, 6, 957.56m, 478.79m, 11m },
                    { 9, null, 3, 832.66m, 416.34m, 11m },
                    { 11, null, 4, 478.78m, 287.28m, 9m }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "Valor" },
                values: new object[,]
                {
                    { 12, null, 4, 957.56m, 478.79m, 11m },
                    { 13, null, 5, 287.27m, 0m, 7.82m },
                    { 14, null, 5, 336m, 287.28m, 8.82m },
                    { 15, null, 5, 478.78m, 336.01m, 9m },
                    { 16, null, 5, 957.56m, 478.79m, 11m },
                    { 17, null, 6, 287.27m, 0m, 7.82m },
                    { 18, null, 6, 360m, 287.28m, 8.82m },
                    { 10, null, 4, 287.27m, 0m, 8m },
                    { 86, null, 23, 780.78m, 720.01m, 9m },
                    { 42, null, 12, 627.66m, 408.01m, 9m },
                    { 44, null, 13, 376.6m, 0m, 7.65m },
                    { 67, null, 18, 1328.25m, 664.14m, 11m },
                    { 68, null, 19, 398.48m, 0m, 7.65m },
                    { 69, null, 19, 540m, 398.49m, 8.65m },
                    { 70, null, 19, 664.13m, 540.01m, 9m },
                    { 71, null, 19, 1328.25m, 664.14m, 11m },
                    { 72, null, 20, 429m, 0m, 7.65m },
                    { 73, null, 20, 540m, 429.01m, 8.65m },
                    { 74, null, 20, 715m, 540.01m, 9m },
                    { 66, null, 18, 664.13m, 453.01m, 9m },
                    { 75, null, 20, 1430m, 715.01m, 11m },
                    { 77, null, 21, 600m, 429.01m, 8.65m },
                    { 78, null, 21, 715m, 600.01m, 9m },
                    { 79, null, 21, 1430m, 715.01m, 11m },
                    { 80, null, 22, 468.47m, 0m, 7.65m },
                    { 81, null, 22, 600m, 468.48m, 8.65m },
                    { 82, null, 22, 780.78m, 600.01m, 9m },
                    { 83, null, 22, 1561.56m, 780.79m, 11m },
                    { 84, null, 23, 468.47m, 0m, 7.65m },
                    { 76, null, 21, 429m, 0m, 7.65m },
                    { 43, null, 12, 1255.32m, 627.67m, 11m },
                    { 65, null, 18, 453m, 398.49m, 8.65m },
                    { 63, null, 17, 1328.25m, 664.14m, 11m },
                    { 45, null, 13, 408m, 376.61m, 8.65m },
                    { 46, null, 13, 627.66m, 408.01m, 9m },
                    { 47, null, 13, 1255.32m, 627.67m, 11m },
                    { 48, null, 14, 376.6m, 0m, 7.65m },
                    { 49, null, 14, 450m, 376.61m, 8.65m },
                    { 50, null, 14, 627.66m, 450.01m, 9m },
                    { 51, null, 14, 1255.32m, 627.67m, 11m },
                    { 52, null, 15, 376.6m, 0m, 7.65m },
                    { 64, null, 18, 398.48m, 0m, 7.65m }
                });

            migrationBuilder.InsertData(
                table: "APITabelaItem",
                columns: new[] { "IdTabelaItem", "DataHoraAlteracao", "IdTabela", "IntervaloFinal", "IntervaloInicial", "Valor" },
                values: new object[,]
                {
                    { 53, null, 15, 453m, 376.61m, 8.65m },
                    { 55, null, 15, 1255.32m, 627.67m, 11m },
                    { 56, null, 16, 398.48m, 0m, 7.72m },
                    { 57, null, 16, 453m, 398.49m, 8.73m },
                    { 58, null, 16, 664.13m, 453.01m, 9m },
                    { 59, null, 16, 1328.25m, 664.14m, 11m },
                    { 60, null, 17, 398.48m, 0m, 7.72m },
                    { 61, null, 17, 453m, 398.49m, 8.73m },
                    { 62, null, 17, 664.13m, 453.01m, 9m },
                    { 54, null, 15, 627.66m, 453.01m, 9m },
                    { 174, null, 49, 7088.5m, 3641.7m, 14m }
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
