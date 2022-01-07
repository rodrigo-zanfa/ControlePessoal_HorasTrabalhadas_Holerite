using ControlePessoal.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Data.Maps
{
    public class PontoMap : IEntityTypeConfiguration<Ponto>
    {
        public void Configure(EntityTypeBuilder<Ponto> builder)
        {
            builder.ToTable("APIPonto");

            builder.Property(x => x.IdPonto)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.IdUsuario)
                .IsRequired();

            builder.Property(x => x.DataHoraPonto)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdPonto);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Pontos)
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
