using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePessoal.Infrastructure.Migrations
{
    public partial class _01CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIUsuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIUsuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "APIPonto",
                columns: table => new
                {
                    IdPonto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    DataPonto = table.Column<DateTime>(type: "date", nullable: false),
                    HoraPonto = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIPonto", x => x.IdPonto);
                    table.ForeignKey(
                        name: "FK_APIPonto_APIUsuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "APIUsuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APIPonto_IdUsuario",
                table: "APIPonto",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIPonto");

            migrationBuilder.DropTable(
                name: "APIUsuario");
        }
    }
}
