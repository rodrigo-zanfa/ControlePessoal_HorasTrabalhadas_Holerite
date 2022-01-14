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
    public class TabelaTipoMap : IEntityTypeConfiguration<TabelaTipo>
    {
        public void Configure(EntityTypeBuilder<TabelaTipo> builder)
        {
            builder.ToTable("APITabelaTipo");

            builder.Property(x => x.IdTabelaTipo)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");  // usado apenas para a carga inicial de dados

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdTabelaTipo);

            builder.HasData(
                new TabelaTipo(idTabelaTipo: 1, descricao: "INSS"),
                new TabelaTipo(idTabelaTipo: 2, descricao: "IRRF")/*,
                new TabelaTipo(idTabelaTipo: , descricao: ""),
                new TabelaTipo(idTabelaTipo: , descricao: ""),
                new TabelaTipo(idTabelaTipo: , descricao: ""),
                new TabelaTipo(idTabelaTipo: , descricao: "")*/
                );
        }
    }
}
