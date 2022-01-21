using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePessoal.Infrastructure.Migrations
{
    public partial class _07Parametros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "APIParametroTipoDado",
                keyColumn: "IdParametroTipoDado",
                keyValue: 1,
                column: "IntervaloMax",
                value: 999999.99m);

            migrationBuilder.InsertData(
                table: "APIParametroTipoDado",
                columns: new[] { "IdParametroTipoDado", "DataHoraAlteracao", "Descricao", "Formato", "IntervaloMax", "IntervaloMin", "TamanhoMax", "TamanhoMin" },
                values: new object[] { 5, null, "Número Inteiro 2 Dígitos", "", 99m, 0m, 2, 1 });

            migrationBuilder.InsertData(
                table: "APIParametro",
                columns: new[] { "IdParametro", "DataHoraAlteracao", "Descricao", "DescricaoDetalhada", "IdParametroTipoDado" },
                values: new object[] { 6, null, "Quantidade de Dependentes", "Quantidade de Dependentes que o Usuário possui, para fins de desconto do cálculo de IRRF", 5 });

            migrationBuilder.InsertData(
                table: "APIParametroUsuario",
                columns: new[] { "IdParametroUsuario", "DataHoraAlteracao", "DataVigenciaInicial", "IdParametro", "IdUsuario", "Valor" },
                values: new object[] { 6, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "APIParametroUsuario",
                keyColumn: "IdParametroUsuario",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "APIParametro",
                keyColumn: "IdParametro",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "APIParametroTipoDado",
                keyColumn: "IdParametroTipoDado",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "APIParametroTipoDado",
                keyColumn: "IdParametroTipoDado",
                keyValue: 1,
                column: "IntervaloMax",
                value: null);
        }
    }
}
