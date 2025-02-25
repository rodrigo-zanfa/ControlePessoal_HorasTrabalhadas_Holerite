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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("APIUsuario");

            builder.Property(x => x.IdUsuario)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdUsuario);

            builder.HasData(
                new Usuario(idUsuario: 1, nome: "RODRIGO ZANFERRARI CARAÇA")
                );
        }
    }
}
