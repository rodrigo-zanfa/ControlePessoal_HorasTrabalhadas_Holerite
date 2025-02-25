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
    public class SalarioMap : IEntityTypeConfiguration<Salario>
    {
        public void Configure(EntityTypeBuilder<Salario> builder)
        {
            builder.ToTable("APISalario");

            builder.Property(x => x.IdSalario)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.IdUsuario)
                .IsRequired();

            builder.Property(x => x.DataVigenciaInicial)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("numeric(8, 2)");

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdSalario);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Salarios)
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
