using ControlePessoal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Infrastructure.Maps
{
    public class TabelaItemMap : IEntityTypeConfiguration<TabelaItem>
    {
        public void Configure(EntityTypeBuilder<TabelaItem> builder)
        {
            builder.ToTable("APITabelaItem");

            builder.Property(x => x.IdTabelaItem)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.IdTabela)
                .IsRequired();

            builder.Property(x => x.IntervaloInicial)
                .IsRequired()
                .HasColumnType("numeric(8, 2)");

            builder.Property(x => x.IntervaloFinal)
                .IsRequired()
                .HasColumnType("numeric(8, 2)");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("numeric(8, 2)");

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");  // usado apenas para a carga inicial de dados

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdTabelaItem);

            builder.HasOne(x => x.Tabela)
                .WithMany(x => x.TabelasItens)
                .HasForeignKey(x => x.IdTabela)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new TabelaItem(idTabelaItem: 1, idTabela: 1, intervaloInicial: 0.00, intervaloFinal: 174.86, valor: 8.00),
                new TabelaItem(idTabelaItem: 2, idTabela: 1, intervaloInicial: 174.87, intervaloFinal: 291.43, valor: 9.00),
                new TabelaItem(idTabelaItem: 3, idTabela: 1, intervaloInicial: 291.44, intervaloFinal: 582.86, valor: 10.00),
                new TabelaItem(idTabelaItem: 4, idTabela: 2, intervaloInicial: 0.00, intervaloFinal: 249.80, valor: 8.00),
                new TabelaItem(idTabelaItem: 5, idTabela: 2, intervaloInicial: 249.81, intervaloFinal: 416.33, valor: 9.00),
                new TabelaItem(idTabelaItem: 6, idTabela: 2, intervaloInicial: 416.34, intervaloFinal: 832.66, valor: 10.00),
                new TabelaItem(idTabelaItem: 7, idTabela: 3, intervaloInicial: 0.00, intervaloFinal: 249.80, valor: 8.00),
                new TabelaItem(idTabelaItem: 8, idTabela: 3, intervaloInicial: 249.81, intervaloFinal: 416.33, valor: 9.00),
                new TabelaItem(idTabelaItem: 9, idTabela: 3, intervaloInicial: 416.34, intervaloFinal: 832.66, valor: 11.00),
                new TabelaItem(idTabelaItem: 10, idTabela: 4, intervaloInicial: 0.00, intervaloFinal: 287.27, valor: 8.00),
                new TabelaItem(idTabelaItem: 11, idTabela: 4, intervaloInicial: 287.28, intervaloFinal: 478.78, valor: 9.00),
                new TabelaItem(idTabelaItem: 12, idTabela: 4, intervaloInicial: 478.79, intervaloFinal: 957.56, valor: 11.00),
                new TabelaItem(idTabelaItem: 13, idTabela: 5, intervaloInicial: 0.00, intervaloFinal: 287.27, valor: 7.82),
                new TabelaItem(idTabelaItem: 14, idTabela: 5, intervaloInicial: 287.28, intervaloFinal: 336.00, valor: 8.82),
                new TabelaItem(idTabelaItem: 15, idTabela: 5, intervaloInicial: 336.01, intervaloFinal: 478.78, valor: 9.00),
                new TabelaItem(idTabelaItem: 16, idTabela: 5, intervaloInicial: 478.79, intervaloFinal: 957.56, valor: 11.00),
                new TabelaItem(idTabelaItem: 17, idTabela: 6, intervaloInicial: 0.00, intervaloFinal: 287.27, valor: 7.82),
                new TabelaItem(idTabelaItem: 18, idTabela: 6, intervaloInicial: 287.28, intervaloFinal: 360.00, valor: 8.82),
                new TabelaItem(idTabelaItem: 19, idTabela: 6, intervaloInicial: 360.01, intervaloFinal: 478.78, valor: 9.00),
                new TabelaItem(idTabelaItem: 20, idTabela: 6, intervaloInicial: 478.79, intervaloFinal: 957.56, valor: 11.00),
                new TabelaItem(idTabelaItem: 21, idTabela: 7, intervaloInicial: 0.00, intervaloFinal: 309.56, valor: 7.82),
                new TabelaItem(idTabelaItem: 22, idTabela: 7, intervaloInicial: 309.57, intervaloFinal: 360.00, valor: 8.82),
                new TabelaItem(idTabelaItem: 23, idTabela: 7, intervaloInicial: 360.01, intervaloFinal: 515.93, valor: 9.00),
                new TabelaItem(idTabelaItem: 24, idTabela: 7, intervaloInicial: 515.94, intervaloFinal: 1031.87, valor: 11.00),
                new TabelaItem(idTabelaItem: 25, idTabela: 8, intervaloInicial: 0.00, intervaloFinal: 309.56, valor: 7.82),
                new TabelaItem(idTabelaItem: 26, idTabela: 8, intervaloInicial: 309.57, intervaloFinal: 390.00, valor: 8.82),
                new TabelaItem(idTabelaItem: 27, idTabela: 8, intervaloInicial: 390.01, intervaloFinal: 515.93, valor: 9.00),
                new TabelaItem(idTabelaItem: 28, idTabela: 8, intervaloInicial: 515.94, intervaloFinal: 1031.87, valor: 11.00),
                new TabelaItem(idTabelaItem: 29, idTabela: 9, intervaloInicial: 0.00, intervaloFinal: 324.45, valor: 7.82),
                new TabelaItem(idTabelaItem: 30, idTabela: 9, intervaloInicial: 324.46, intervaloFinal: 390.00, valor: 8.82),
                new TabelaItem(idTabelaItem: 31, idTabela: 9, intervaloInicial: 390.01, intervaloFinal: 540.75, valor: 9.00),
                new TabelaItem(idTabelaItem: 32, idTabela: 9, intervaloInicial: 540.76, intervaloFinal: 1081.50, valor: 11.00),
                new TabelaItem(idTabelaItem: 33, idTabela: 10, intervaloInicial: 0.00, intervaloFinal: 360.00, valor: 7.82),
                new TabelaItem(idTabelaItem: 34, idTabela: 10, intervaloInicial: 360.01, intervaloFinal: 390.00, valor: 8.82),
                new TabelaItem(idTabelaItem: 35, idTabela: 10, intervaloInicial: 390.01, intervaloFinal: 600.00, valor: 9.00),
                new TabelaItem(idTabelaItem: 36, idTabela: 10, intervaloInicial: 600.01, intervaloFinal: 1200.00, valor: 11.00),
                new TabelaItem(idTabelaItem: 37, idTabela: 11, intervaloInicial: 0.00, intervaloFinal: 360.00, valor: 8.00),
                new TabelaItem(idTabelaItem: 38, idTabela: 11, intervaloInicial: 360.01, intervaloFinal: 600.00, valor: 9.00),
                new TabelaItem(idTabelaItem: 39, idTabela: 11, intervaloInicial: 600.01, intervaloFinal: 1200.00, valor: 11.00),
                new TabelaItem(idTabelaItem: 40, idTabela: 12, intervaloInicial: 0.00, intervaloFinal: 376.60, valor: 7.65),
                new TabelaItem(idTabelaItem: 41, idTabela: 12, intervaloInicial: 376.61, intervaloFinal: 408.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 42, idTabela: 12, intervaloInicial: 408.01, intervaloFinal: 627.66, valor: 9.00),
                new TabelaItem(idTabelaItem: 43, idTabela: 12, intervaloInicial: 627.67, intervaloFinal: 1255.32, valor: 11.00),
                new TabelaItem(idTabelaItem: 44, idTabela: 13, intervaloInicial: 0.00, intervaloFinal: 376.60, valor: 7.65),
                new TabelaItem(idTabelaItem: 45, idTabela: 13, intervaloInicial: 376.61, intervaloFinal: 408.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 46, idTabela: 13, intervaloInicial: 408.01, intervaloFinal: 627.66, valor: 9.00),
                new TabelaItem(idTabelaItem: 47, idTabela: 13, intervaloInicial: 627.67, intervaloFinal: 1255.32, valor: 11.00),
                new TabelaItem(idTabelaItem: 48, idTabela: 14, intervaloInicial: 0.00, intervaloFinal: 376.60, valor: 7.65),
                new TabelaItem(idTabelaItem: 49, idTabela: 14, intervaloInicial: 376.61, intervaloFinal: 450.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 50, idTabela: 14, intervaloInicial: 450.01, intervaloFinal: 627.66, valor: 9.00),
                new TabelaItem(idTabelaItem: 51, idTabela: 14, intervaloInicial: 627.67, intervaloFinal: 1255.32, valor: 11.00),
                new TabelaItem(idTabelaItem: 52, idTabela: 15, intervaloInicial: 0.00, intervaloFinal: 376.60, valor: 7.65),
                new TabelaItem(idTabelaItem: 53, idTabela: 15, intervaloInicial: 376.61, intervaloFinal: 453.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 54, idTabela: 15, intervaloInicial: 453.01, intervaloFinal: 627.66, valor: 9.00),
                new TabelaItem(idTabelaItem: 55, idTabela: 15, intervaloInicial: 627.67, intervaloFinal: 1255.32, valor: 11.00),
                new TabelaItem(idTabelaItem: 56, idTabela: 16, intervaloInicial: 0.00, intervaloFinal: 398.48, valor: 7.72),
                new TabelaItem(idTabelaItem: 57, idTabela: 16, intervaloInicial: 398.49, intervaloFinal: 453.00, valor: 8.73),
                new TabelaItem(idTabelaItem: 58, idTabela: 16, intervaloInicial: 453.01, intervaloFinal: 664.13, valor: 9.00),
                new TabelaItem(idTabelaItem: 59, idTabela: 16, intervaloInicial: 664.14, intervaloFinal: 1328.25, valor: 11.00),
                new TabelaItem(idTabelaItem: 60, idTabela: 17, intervaloInicial: 0.00, intervaloFinal: 398.48, valor: 7.72),
                new TabelaItem(idTabelaItem: 61, idTabela: 17, intervaloInicial: 398.49, intervaloFinal: 453.00, valor: 8.73),
                new TabelaItem(idTabelaItem: 62, idTabela: 17, intervaloInicial: 453.01, intervaloFinal: 664.13, valor: 9.00),
                new TabelaItem(idTabelaItem: 63, idTabela: 17, intervaloInicial: 664.14, intervaloFinal: 1328.25, valor: 11.00),
                new TabelaItem(idTabelaItem: 64, idTabela: 18, intervaloInicial: 0.00, intervaloFinal: 398.48, valor: 7.65),
                new TabelaItem(idTabelaItem: 65, idTabela: 18, intervaloInicial: 398.49, intervaloFinal: 453.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 66, idTabela: 18, intervaloInicial: 453.01, intervaloFinal: 664.13, valor: 9.00),
                new TabelaItem(idTabelaItem: 67, idTabela: 18, intervaloInicial: 664.14, intervaloFinal: 1328.25, valor: 11.00),
                new TabelaItem(idTabelaItem: 68, idTabela: 19, intervaloInicial: 0.00, intervaloFinal: 398.48, valor: 7.65),
                new TabelaItem(idTabelaItem: 69, idTabela: 19, intervaloInicial: 398.49, intervaloFinal: 540.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 70, idTabela: 19, intervaloInicial: 540.01, intervaloFinal: 664.13, valor: 9.00),
                new TabelaItem(idTabelaItem: 71, idTabela: 19, intervaloInicial: 664.14, intervaloFinal: 1328.25, valor: 11.00),
                new TabelaItem(idTabelaItem: 72, idTabela: 20, intervaloInicial: 0.00, intervaloFinal: 429.00, valor: 7.65),
                new TabelaItem(idTabelaItem: 73, idTabela: 20, intervaloInicial: 429.01, intervaloFinal: 540.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 74, idTabela: 20, intervaloInicial: 540.01, intervaloFinal: 715.00, valor: 9.00),
                new TabelaItem(idTabelaItem: 75, idTabela: 20, intervaloInicial: 715.01, intervaloFinal: 1430.00, valor: 11.00),
                new TabelaItem(idTabelaItem: 76, idTabela: 21, intervaloInicial: 0.00, intervaloFinal: 429.00, valor: 7.65),
                new TabelaItem(idTabelaItem: 77, idTabela: 21, intervaloInicial: 429.01, intervaloFinal: 600.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 78, idTabela: 21, intervaloInicial: 600.01, intervaloFinal: 715.00, valor: 9.00),
                new TabelaItem(idTabelaItem: 79, idTabela: 21, intervaloInicial: 715.01, intervaloFinal: 1430.00, valor: 11.00),
                new TabelaItem(idTabelaItem: 80, idTabela: 22, intervaloInicial: 0.00, intervaloFinal: 468.47, valor: 7.65),
                new TabelaItem(idTabelaItem: 81, idTabela: 22, intervaloInicial: 468.48, intervaloFinal: 600.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 82, idTabela: 22, intervaloInicial: 600.01, intervaloFinal: 780.78, valor: 9.00),
                new TabelaItem(idTabelaItem: 83, idTabela: 22, intervaloInicial: 780.79, intervaloFinal: 1561.56, valor: 11.00),
                new TabelaItem(idTabelaItem: 84, idTabela: 23, intervaloInicial: 0.00, intervaloFinal: 468.47, valor: 7.65),
                new TabelaItem(idTabelaItem: 85, idTabela: 23, intervaloInicial: 468.48, intervaloFinal: 720.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 86, idTabela: 23, intervaloInicial: 720.01, intervaloFinal: 780.78, valor: 9.00),
                new TabelaItem(idTabelaItem: 87, idTabela: 23, intervaloInicial: 780.79, intervaloFinal: 1561.56, valor: 11.00),
                new TabelaItem(idTabelaItem: 88, idTabela: 24, intervaloInicial: 0.00, intervaloFinal: 560.81, valor: 7.65),
                new TabelaItem(idTabelaItem: 89, idTabela: 24, intervaloInicial: 560.82, intervaloFinal: 720.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 90, idTabela: 24, intervaloInicial: 720.01, intervaloFinal: 934.67, valor: 9.00),
                new TabelaItem(idTabelaItem: 91, idTabela: 24, intervaloInicial: 934.68, intervaloFinal: 1869.34, valor: 11.00),
                new TabelaItem(idTabelaItem: 92, idTabela: 25, intervaloInicial: 0.00, intervaloFinal: 720.00, valor: 7.65),
                new TabelaItem(idTabelaItem: 93, idTabela: 25, intervaloInicial: 720.01, intervaloFinal: 1200.00, valor: 9.00),
                new TabelaItem(idTabelaItem: 94, idTabela: 25, intervaloInicial: 1200.01, intervaloFinal: 2400.00, valor: 11.00),
                new TabelaItem(idTabelaItem: 95, idTabela: 26, intervaloInicial: 0.00, intervaloFinal: 752.62, valor: 7.65),
                new TabelaItem(idTabelaItem: 96, idTabela: 26, intervaloInicial: 752.63, intervaloFinal: 780.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 97, idTabela: 26, intervaloInicial: 780.01, intervaloFinal: 1254.36, valor: 9.00),
                new TabelaItem(idTabelaItem: 98, idTabela: 26, intervaloInicial: 1254.37, intervaloFinal: 2508.72, valor: 11.00),
                new TabelaItem(idTabelaItem: 99, idTabela: 27, intervaloInicial: 0.00, intervaloFinal: 800.45, valor: 7.65),
                new TabelaItem(idTabelaItem: 100, idTabela: 27, intervaloInicial: 800.46, intervaloFinal: 900.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 101, idTabela: 27, intervaloInicial: 900.01, intervaloFinal: 1334.07, valor: 9.00),
                new TabelaItem(idTabelaItem: 102, idTabela: 27, intervaloInicial: 1334.08, intervaloFinal: 2668.15, valor: 11.00),
                new TabelaItem(idTabelaItem: 103, idTabela: 28, intervaloInicial: 0.00, intervaloFinal: 840.47, valor: 7.65),
                new TabelaItem(idTabelaItem: 104, idTabela: 28, intervaloInicial: 840.48, intervaloFinal: 1050.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 105, idTabela: 28, intervaloInicial: 1050.01, intervaloFinal: 1400.77, valor: 9.00),
                new TabelaItem(idTabelaItem: 106, idTabela: 28, intervaloInicial: 1400.78, intervaloFinal: 2801.56, valor: 11.00),
                new TabelaItem(idTabelaItem: 107, idTabela: 29, intervaloInicial: 0.00, intervaloFinal: 840.55, valor: 7.65),
                new TabelaItem(idTabelaItem: 108, idTabela: 29, intervaloInicial: 840.56, intervaloFinal: 1050.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 109, idTabela: 29, intervaloInicial: 1050.01, intervaloFinal: 1400.91, valor: 9.00),
                new TabelaItem(idTabelaItem: 110, idTabela: 29, intervaloInicial: 1400.92, intervaloFinal: 2801.82, valor: 11.00),
                new TabelaItem(idTabelaItem: 111, idTabela: 30, intervaloInicial: 0.00, intervaloFinal: 868.29, valor: 7.65),
                new TabelaItem(idTabelaItem: 112, idTabela: 30, intervaloInicial: 868.30, intervaloFinal: 1140.00, valor: 8.65),
                new TabelaItem(idTabelaItem: 113, idTabela: 30, intervaloInicial: 1140.01, intervaloFinal: 1447.14, valor: 9.00),
                new TabelaItem(idTabelaItem: 114, idTabela: 30, intervaloInicial: 1447.15, intervaloFinal: 2894.28, valor: 11.00),
                new TabelaItem(idTabelaItem: 115, idTabela: 31, intervaloInicial: 0.00, intervaloFinal: 868.29, valor: 8.00),
                new TabelaItem(idTabelaItem: 116, idTabela: 31, intervaloInicial: 868.30, intervaloFinal: 1447.14, valor: 9.00),
                new TabelaItem(idTabelaItem: 117, idTabela: 31, intervaloInicial: 1447.15, intervaloFinal: 2894.28, valor: 11.00),
                new TabelaItem(idTabelaItem: 118, idTabela: 32, intervaloInicial: 0.00, intervaloFinal: 911.70, valor: 8.00),
                new TabelaItem(idTabelaItem: 119, idTabela: 32, intervaloInicial: 911.71, intervaloFinal: 1519.50, valor: 9.00),
                new TabelaItem(idTabelaItem: 120, idTabela: 32, intervaloInicial: 1519.51, intervaloFinal: 3038.99, valor: 11.00),
                new TabelaItem(idTabelaItem: 121, idTabela: 33, intervaloInicial: 0.00, intervaloFinal: 965.67, valor: 8.00),
                new TabelaItem(idTabelaItem: 122, idTabela: 33, intervaloInicial: 965.68, intervaloFinal: 1609.45, valor: 9.00),
                new TabelaItem(idTabelaItem: 123, idTabela: 33, intervaloInicial: 1609.46, intervaloFinal: 3218.90, valor: 11.00),
                new TabelaItem(idTabelaItem: 124, idTabela: 34, intervaloInicial: 0.00, intervaloFinal: 1024.97, valor: 8.00),
                new TabelaItem(idTabelaItem: 125, idTabela: 34, intervaloInicial: 1024.98, intervaloFinal: 1708.27, valor: 9.00),
                new TabelaItem(idTabelaItem: 126, idTabela: 34, intervaloInicial: 1708.28, intervaloFinal: 3416.24, valor: 11.00),
                new TabelaItem(idTabelaItem: 127, idTabela: 35, intervaloInicial: 0.00, intervaloFinal: 1040.22, valor: 8.00),
                new TabelaItem(idTabelaItem: 128, idTabela: 35, intervaloInicial: 1040.23, intervaloFinal: 1733.70, valor: 9.00),
                new TabelaItem(idTabelaItem: 129, idTabela: 35, intervaloInicial: 1733.71, intervaloFinal: 3467.40, valor: 11.00),
                new TabelaItem(idTabelaItem: 130, idTabela: 36, intervaloInicial: 0.00, intervaloFinal: 1106.90, valor: 8.00),
                new TabelaItem(idTabelaItem: 131, idTabela: 36, intervaloInicial: 1106.91, intervaloFinal: 1844.83, valor: 9.00),
                new TabelaItem(idTabelaItem: 132, idTabela: 36, intervaloInicial: 1844.84, intervaloFinal: 3689.66, valor: 11.00),
                new TabelaItem(idTabelaItem: 133, idTabela: 37, intervaloInicial: 0.00, intervaloFinal: 1107.52, valor: 8.00),
                new TabelaItem(idTabelaItem: 134, idTabela: 37, intervaloInicial: 1107.53, intervaloFinal: 1845.87, valor: 9.00),
                new TabelaItem(idTabelaItem: 135, idTabela: 37, intervaloInicial: 1845.88, intervaloFinal: 3691.74, valor: 11.00),
                new TabelaItem(idTabelaItem: 136, idTabela: 38, intervaloInicial: 0.00, intervaloFinal: 1174.86, valor: 8.00),
                new TabelaItem(idTabelaItem: 137, idTabela: 38, intervaloInicial: 1174.87, intervaloFinal: 1958.10, valor: 9.00),
                new TabelaItem(idTabelaItem: 138, idTabela: 38, intervaloInicial: 1958.11, intervaloFinal: 3916.20, valor: 11.00),
                new TabelaItem(idTabelaItem: 139, idTabela: 39, intervaloInicial: 0.00, intervaloFinal: 1247.70, valor: 8.00),
                new TabelaItem(idTabelaItem: 140, idTabela: 39, intervaloInicial: 1247.71, intervaloFinal: 2079.50, valor: 9.00),
                new TabelaItem(idTabelaItem: 141, idTabela: 39, intervaloInicial: 2079.51, intervaloFinal: 4159.00, valor: 11.00),
                new TabelaItem(idTabelaItem: 142, idTabela: 40, intervaloInicial: 0.00, intervaloFinal: 1317.07, valor: 8.00),
                new TabelaItem(idTabelaItem: 143, idTabela: 40, intervaloInicial: 1317.08, intervaloFinal: 2195.12, valor: 9.00),
                new TabelaItem(idTabelaItem: 144, idTabela: 40, intervaloInicial: 2195.13, intervaloFinal: 4390.24, valor: 11.00),
                new TabelaItem(idTabelaItem: 145, idTabela: 41, intervaloInicial: 0.00, intervaloFinal: 1399.12, valor: 8.00),
                new TabelaItem(idTabelaItem: 146, idTabela: 41, intervaloInicial: 1399.13, intervaloFinal: 2331.88, valor: 9.00),
                new TabelaItem(idTabelaItem: 147, idTabela: 41, intervaloInicial: 2331.89, intervaloFinal: 4663.75, valor: 11.00),
                new TabelaItem(idTabelaItem: 148, idTabela: 42, intervaloInicial: 0.00, intervaloFinal: 1556.94, valor: 8.00),
                new TabelaItem(idTabelaItem: 149, idTabela: 42, intervaloInicial: 1556.95, intervaloFinal: 2594.92, valor: 9.00),
                new TabelaItem(idTabelaItem: 150, idTabela: 42, intervaloInicial: 2594.93, intervaloFinal: 5189.82, valor: 11.00),
                new TabelaItem(idTabelaItem: 151, idTabela: 43, intervaloInicial: 0.00, intervaloFinal: 1659.38, valor: 8.00),
                new TabelaItem(idTabelaItem: 152, idTabela: 43, intervaloInicial: 1659.39, intervaloFinal: 2765.66, valor: 9.00),
                new TabelaItem(idTabelaItem: 153, idTabela: 43, intervaloInicial: 2765.67, intervaloFinal: 5531.31, valor: 11.00),
                new TabelaItem(idTabelaItem: 154, idTabela: 44, intervaloInicial: 0.00, intervaloFinal: 1693.72, valor: 8.00),
                new TabelaItem(idTabelaItem: 155, idTabela: 44, intervaloInicial: 1693.73, intervaloFinal: 2822.90, valor: 9.00),
                new TabelaItem(idTabelaItem: 156, idTabela: 44, intervaloInicial: 2822.91, intervaloFinal: 5645.80, valor: 11.00),
                new TabelaItem(idTabelaItem: 157, idTabela: 45, intervaloInicial: 0.00, intervaloFinal: 1751.81, valor: 8.00),
                new TabelaItem(idTabelaItem: 158, idTabela: 45, intervaloInicial: 1751.82, intervaloFinal: 2919.72, valor: 9.00),
                new TabelaItem(idTabelaItem: 159, idTabela: 45, intervaloInicial: 2919.73, intervaloFinal: 5839.45, valor: 11.00),
                new TabelaItem(idTabelaItem: 160, idTabela: 46, intervaloInicial: 0.00, intervaloFinal: 1830.29, valor: 8.00),
                new TabelaItem(idTabelaItem: 161, idTabela: 46, intervaloInicial: 1830.30, intervaloFinal: 3050.52, valor: 9.00),
                new TabelaItem(idTabelaItem: 162, idTabela: 46, intervaloInicial: 3050.53, intervaloFinal: 6101.06, valor: 11.00),
                new TabelaItem(idTabelaItem: 163, idTabela: 47, intervaloInicial: 0.00, intervaloFinal: 1045.00, valor: 7.50),
                new TabelaItem(idTabelaItem: 164, idTabela: 47, intervaloInicial: 1045.01, intervaloFinal: 2089.60, valor: 9.00),
                new TabelaItem(idTabelaItem: 165, idTabela: 47, intervaloInicial: 2089.61, intervaloFinal: 3134.40, valor: 12.00),
                new TabelaItem(idTabelaItem: 166, idTabela: 47, intervaloInicial: 3134.41, intervaloFinal: 6101.06, valor: 14.00),
                new TabelaItem(idTabelaItem: 167, idTabela: 48, intervaloInicial: 0.00, intervaloFinal: 1100.00, valor: 7.50),
                new TabelaItem(idTabelaItem: 168, idTabela: 48, intervaloInicial: 1100.01, intervaloFinal: 2203.48, valor: 9.00),
                new TabelaItem(idTabelaItem: 169, idTabela: 48, intervaloInicial: 2203.49, intervaloFinal: 3305.22, valor: 12.00),
                new TabelaItem(idTabelaItem: 170, idTabela: 48, intervaloInicial: 3305.23, intervaloFinal: 6433.57, valor: 14.00),
                new TabelaItem(idTabelaItem: 171, idTabela: 49, intervaloInicial: 0.00, intervaloFinal: 1212.00, valor: 7.50),
                new TabelaItem(idTabelaItem: 172, idTabela: 49, intervaloInicial: 1212.01, intervaloFinal: 2427.79, valor: 9.00),
                new TabelaItem(idTabelaItem: 173, idTabela: 49, intervaloInicial: 2427.80, intervaloFinal: 3641.69, valor: 12.00),
                new TabelaItem(idTabelaItem: 174, idTabela: 49, intervaloInicial: 3641.70, intervaloFinal: 7088.50, valor: 14.00)/*,
                new TabelaItem(idTabelaItem: , idTabela: , intervaloInicial: , intervaloFinal: , valor: ),
                new TabelaItem(idTabelaItem: , idTabela: , intervaloInicial: , intervaloFinal: , valor: ),
                new TabelaItem(idTabelaItem: , idTabela: , intervaloInicial: , intervaloFinal: , valor: ),
                new TabelaItem(idTabelaItem: , idTabela: , intervaloInicial: , intervaloFinal: , valor: )*/
                );
        }
    }
}
