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
    public class SalarioMinimoMap : IEntityTypeConfiguration<SalarioMinimo>
    {
        public void Configure(EntityTypeBuilder<SalarioMinimo> builder)
        {
            builder.ToTable("APISalarioMinimo");

            builder.Property(x => x.IdSalarioMinimo)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.DataVigenciaInicial)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("numeric(8, 2)");

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));  // usado apenas para a carga inicial de dados

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdSalarioMinimo);

            builder.HasData(
                new SalarioMinimo(idSalarioMinimo: 1, dataVigenciaInicial: new DateTime(1994, 07, 01), valor: 64.79),
                new SalarioMinimo(idSalarioMinimo: 2, dataVigenciaInicial: new DateTime(1994, 09, 01), valor: 70.00),
                new SalarioMinimo(idSalarioMinimo: 3, dataVigenciaInicial: new DateTime(1995, 05, 01), valor: 100.00),
                new SalarioMinimo(idSalarioMinimo: 4, dataVigenciaInicial: new DateTime(1996, 05, 01), valor: 112.00),
                new SalarioMinimo(idSalarioMinimo: 5, dataVigenciaInicial: new DateTime(1997, 05, 01), valor: 120.00),
                new SalarioMinimo(idSalarioMinimo: 6, dataVigenciaInicial: new DateTime(1998, 05, 01), valor: 130.00),
                new SalarioMinimo(idSalarioMinimo: 7, dataVigenciaInicial: new DateTime(1999, 05, 01), valor: 136.00),
                new SalarioMinimo(idSalarioMinimo: 8, dataVigenciaInicial: new DateTime(2000, 04, 03), valor: 151.00),
                new SalarioMinimo(idSalarioMinimo: 9, dataVigenciaInicial: new DateTime(2001, 04, 01), valor: 180.00),
                new SalarioMinimo(idSalarioMinimo: 10, dataVigenciaInicial: new DateTime(2002, 04, 01), valor: 200.00),
                new SalarioMinimo(idSalarioMinimo: 11, dataVigenciaInicial: new DateTime(2003, 04, 01), valor: 240.00),
                new SalarioMinimo(idSalarioMinimo: 12, dataVigenciaInicial: new DateTime(2004, 05, 01), valor: 260.00),
                new SalarioMinimo(idSalarioMinimo: 13, dataVigenciaInicial: new DateTime(2005, 05, 01), valor: 300.00),
                new SalarioMinimo(idSalarioMinimo: 14, dataVigenciaInicial: new DateTime(2006, 04, 01), valor: 350.00),
                new SalarioMinimo(idSalarioMinimo: 15, dataVigenciaInicial: new DateTime(2007, 04, 01), valor: 380.00),
                new SalarioMinimo(idSalarioMinimo: 16, dataVigenciaInicial: new DateTime(2008, 03, 01), valor: 415.00),
                new SalarioMinimo(idSalarioMinimo: 17, dataVigenciaInicial: new DateTime(2009, 02, 01), valor: 465.00),
                new SalarioMinimo(idSalarioMinimo: 18, dataVigenciaInicial: new DateTime(2010, 01, 01), valor: 510.00),
                new SalarioMinimo(idSalarioMinimo: 19, dataVigenciaInicial: new DateTime(2011, 01, 01), valor: 540.00),
                new SalarioMinimo(idSalarioMinimo: 20, dataVigenciaInicial: new DateTime(2011, 03, 01), valor: 545.00),
                new SalarioMinimo(idSalarioMinimo: 21, dataVigenciaInicial: new DateTime(2012, 01, 01), valor: 622.00),
                new SalarioMinimo(idSalarioMinimo: 22, dataVigenciaInicial: new DateTime(2013, 01, 01), valor: 678.00),
                new SalarioMinimo(idSalarioMinimo: 23, dataVigenciaInicial: new DateTime(2014, 01, 01), valor: 724.00),
                new SalarioMinimo(idSalarioMinimo: 24, dataVigenciaInicial: new DateTime(2015, 01, 01), valor: 788.00),
                new SalarioMinimo(idSalarioMinimo: 25, dataVigenciaInicial: new DateTime(2016, 01, 01), valor: 880.00),
                new SalarioMinimo(idSalarioMinimo: 26, dataVigenciaInicial: new DateTime(2017, 01, 01), valor: 937.00),
                new SalarioMinimo(idSalarioMinimo: 27, dataVigenciaInicial: new DateTime(2018, 01, 01), valor: 954.00),
                new SalarioMinimo(idSalarioMinimo: 28, dataVigenciaInicial: new DateTime(2019, 01, 01), valor: 998.00),
                new SalarioMinimo(idSalarioMinimo: 29, dataVigenciaInicial: new DateTime(2020, 01, 01), valor: 1039.00),
                new SalarioMinimo(idSalarioMinimo: 30, dataVigenciaInicial: new DateTime(2020, 02, 01), valor: 1045.00),
                new SalarioMinimo(idSalarioMinimo: 31, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: 1100.00),
                new SalarioMinimo(idSalarioMinimo: 32, dataVigenciaInicial: new DateTime(2022, 01, 01), valor: 1212.00)
                );
        }
    }
}
