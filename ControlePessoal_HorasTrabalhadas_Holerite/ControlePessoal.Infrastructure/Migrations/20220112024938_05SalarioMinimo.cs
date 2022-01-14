using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePessoal.Infrastructure.Migrations
{
    public partial class _05SalarioMinimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APISalarioMinimo",
                columns: table => new
                {
                    IdSalarioMinimo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVigenciaInicial = table.Column<DateTime>(type: "date", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APISalarioMinimo", x => x.IdSalarioMinimo);
                });

            migrationBuilder.InsertData(
                table: "APISalarioMinimo",
                columns: new[] { "IdSalarioMinimo", "DataHoraAlteracao", "DataVigenciaInicial", "Valor" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1994, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.79m },
                    { 30, null, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1045m },
                    { 29, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1039m },
                    { 28, null, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 998m },
                    { 27, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 954m },
                    { 26, null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 937m },
                    { 25, null, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 880m },
                    { 24, null, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 788m },
                    { 23, null, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 724m },
                    { 22, null, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 678m },
                    { 21, null, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 622m },
                    { 20, null, new DateTime(2011, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 545m },
                    { 19, null, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 540m },
                    { 18, null, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 510m },
                    { 17, null, new DateTime(2009, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 465m },
                    { 16, null, new DateTime(2008, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 415m },
                    { 15, null, new DateTime(2007, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 380m },
                    { 14, null, new DateTime(2006, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350m },
                    { 13, null, new DateTime(2005, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300m },
                    { 12, null, new DateTime(2004, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 260m },
                    { 11, null, new DateTime(2003, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 240m },
                    { 10, null, new DateTime(2002, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m },
                    { 9, null, new DateTime(2001, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180m },
                    { 8, null, new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 151m },
                    { 7, null, new DateTime(1999, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 136m },
                    { 6, null, new DateTime(1998, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130m },
                    { 5, null, new DateTime(1997, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m },
                    { 4, null, new DateTime(1996, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112m },
                    { 3, null, new DateTime(1995, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m },
                    { 2, null, new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m },
                    { 31, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1100m },
                    { 32, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1212m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APISalarioMinimo");
        }
    }
}
