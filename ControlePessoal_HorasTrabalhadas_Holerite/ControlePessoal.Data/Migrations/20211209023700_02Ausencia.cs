using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePessoal.Data.Migrations
{
    public partial class _02Ausencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIAusencia",
                columns: table => new
                {
                    IdAusencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    DataAusencia = table.Column<DateTime>(type: "date", nullable: false),
                    HoraInicialAusencia = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFinalAusencia = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIAusencia", x => x.IdAusencia);
                    table.ForeignKey(
                        name: "FK_APIAusencia_APIUsuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "APIUsuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APIAusencia_IdUsuario",
                table: "APIAusencia",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIAusencia");
        }
    }
}
