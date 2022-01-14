using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePessoal.Infrastructure.Migrations
{
    public partial class _06Parametros : Migration
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
                name: "APIParametro",
                columns: table => new
                {
                    IdParametro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
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
                table: "APIParametro",
                columns: new[] { "IdParametro", "DataHoraAlteracao", "Descricao", "IdParametroTipoDado", "Nome" },
                values: new object[,]
                {
                    { 1, null, "Horário de Entrada do Usuário", 4, "Horário de Entrada" },
                    { 2, null, "Horário de Saída do Usuário", 4, "Horário de Saída" },
                    { 3, null, "Intervalo Diário do Usuário entre períodos de trabalho", 4, "Intervalo Diário" },
                    { 4, null, "Tolerância Diária (em hh:mm) para desconsiderar cálculos de Hora Extra ou Desconto", 4, "Tolerância Diária" },
                    { 5, null, "Limite (em hh:mm) para considerar o que fica em Banco de Horas; o excedente será considerado para pagamento em folha mensal", 4, "Limite para Banco de Horas Diário" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIParametroUsuario");

            migrationBuilder.DropTable(
                name: "APIParametro");

            migrationBuilder.DropTable(
                name: "APIParametroTipoDado");
        }
    }
}
