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
    public class ParametroTipoDadoMap : IEntityTypeConfiguration<ParametroTipoDado>
    {
        public void Configure(EntityTypeBuilder<ParametroTipoDado> builder)
        {
            builder.ToTable("APIParametroTipoDado");

            builder.Property(x => x.IdParametroTipoDado)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(x => x.TamanhoMin)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.TamanhoMax)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Formato)
                .IsRequired(false)
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(x => x.IntervaloMin)
                .IsRequired(false)
                .HasColumnType("numeric(8, 2)");

            builder.Property(x => x.IntervaloMax)
                .IsRequired(false)
                .HasColumnType("numeric(8, 2)");

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");  // usado apenas para a carga inicial de dados

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdParametroTipoDado);

            builder.HasData(
                new ParametroTipoDado(idParametroTipoDado: 1, descricao: "Monetário", tamanhoMin: 1, tamanhoMax: 9, formato: "", intervaloMin: null, intervaloMax: null),
                new ParametroTipoDado(idParametroTipoDado: 2, descricao: "Percentual", tamanhoMin: 1, tamanhoMax: 6, formato: "", intervaloMin: 0.00, intervaloMax: 100.00),
                new ParametroTipoDado(idParametroTipoDado: 3, descricao: "Data", tamanhoMin: 10, tamanhoMax: 10, formato: "dd/MM/yyyy", intervaloMin: null, intervaloMax: null),
                new ParametroTipoDado(idParametroTipoDado: 4, descricao: "Hora", tamanhoMin: 5, tamanhoMax: 5, formato: "hh:mm", intervaloMin: null, intervaloMax: null)/*,
                new ParametroTipoDado(idParametroTipoDado: , descricao: "", tamanhoMin: , tamanhoMax: , formato: "", intervaloMin: null, intervaloMax: null),
                new ParametroTipoDado(idParametroTipoDado: , descricao: "", tamanhoMin: , tamanhoMax: , formato: "", intervaloMin: null, intervaloMax: null),
                new ParametroTipoDado(idParametroTipoDado: , descricao: "", tamanhoMin: , tamanhoMax: , formato: "", intervaloMin: null, intervaloMax: null),
                new ParametroTipoDado(idParametroTipoDado: , descricao: "", tamanhoMin: , tamanhoMax: , formato: "", intervaloMin: null, intervaloMax: null)*/
                );
        }
    }
}
