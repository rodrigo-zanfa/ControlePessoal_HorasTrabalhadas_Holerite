using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePessoal.Infrastructure.Migrations
{
    public partial class _04Salario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APISalario",
                columns: table => new
                {
                    IdSalario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    DataVigenciaInicial = table.Column<DateTime>(type: "date", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APISalario", x => x.IdSalario);
                    table.ForeignKey(
                        name: "FK_APISalario_APIUsuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "APIUsuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APISalario_IdUsuario",
                table: "APISalario",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APISalario");
        }
    }
}
