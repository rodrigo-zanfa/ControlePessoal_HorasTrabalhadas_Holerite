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
    public class HoleriteMap : IEntityTypeConfiguration<Holerite>
    {
        public void Configure(EntityTypeBuilder<Holerite> builder)
        {
            builder.ToTable("APIHolerite");

            builder.Property(x => x.IdHolerite)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.IdUsuario)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.DataInicialPonto)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.DataFinalPonto)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.DataPagamentoAdiantamento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.DataPagamento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.DataInicialHoraExtraNormal)
                .IsRequired(false)
                .HasColumnType("date");

            builder.Property(x => x.DataFinalHoraExtraNormal)
                .IsRequired(false)
                .HasColumnType("date");

            builder.Property(x => x.DataInicialHoraExtraAdicional)
                .IsRequired(false)
                .HasColumnType("date");

            builder.Property(x => x.DataFinalHoraExtraAdicional)
                .IsRequired(false)
                .HasColumnType("date");

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdHolerite);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Holerites)
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
