using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePessoal.Infrastructure.Migrations
{
    public partial class _08Holerite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIHolerite",
                columns: table => new
                {
                    IdHolerite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataInicialPonto = table.Column<DateTime>(type: "date", nullable: false),
                    DataFinalPonto = table.Column<DateTime>(type: "date", nullable: false),
                    DataPagamentoAdiantamento = table.Column<DateTime>(type: "date", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "date", nullable: false),
                    DataInicialHoraExtraNormal = table.Column<DateTime>(type: "date", nullable: true),
                    DataFinalHoraExtraNormal = table.Column<DateTime>(type: "date", nullable: true),
                    DataInicialHoraExtraAdicional = table.Column<DateTime>(type: "date", nullable: true),
                    DataFinalHoraExtraAdicional = table.Column<DateTime>(type: "date", nullable: true),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIHolerite", x => x.IdHolerite);
                    table.ForeignKey(
                        name: "FK_APIHolerite_APIUsuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "APIUsuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APIHolerite_IdUsuario",
                table: "APIHolerite",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIHolerite");
        }
    }
}
