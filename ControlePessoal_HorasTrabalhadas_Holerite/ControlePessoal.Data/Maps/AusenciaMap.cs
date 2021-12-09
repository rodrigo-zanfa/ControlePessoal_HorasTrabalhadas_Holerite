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
    public class AusenciaMap : IEntityTypeConfiguration<Ausencia>
    {
        public void Configure(EntityTypeBuilder<Ausencia> builder)
        {
            builder.ToTable("APIAusencia");

            builder.HasKey(x => x.IdAusencia);

            builder.Property(x => x.IdAusencia)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.IdUsuario)
                .IsRequired();

            builder.Property(x => x.DataAusencia)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.HoraInicialAusencia)
                .IsRequired()
                .HasColumnType("time");

            builder.Property(x => x.HoraFinalAusencia)
                .IsRequired()
                .HasColumnType("time");

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Ausencias)
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
