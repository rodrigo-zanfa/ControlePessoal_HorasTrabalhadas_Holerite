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
    public class ParametroUsuarioMap : IEntityTypeConfiguration<ParametroUsuario>
    {
        public void Configure(EntityTypeBuilder<ParametroUsuario> builder)
        {
            builder.ToTable("APIParametroUsuario");

            builder.Property(x => x.IdParametroUsuario)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.IdParametro)
                .IsRequired();

            builder.Property(x => x.IdUsuario)
                .IsRequired();

            builder.Property(x => x.DataVigenciaInicial)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.Valor)
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

            builder.HasKey(x => x.IdParametroUsuario);

            builder.HasOne(x => x.Parametro)
                .WithMany(x => x.ParametrosUsuarios)
                .HasForeignKey(x => x.IdParametro)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.ParametrosUsuarios)
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new ParametroUsuario(idParametroUsuario: 1, idParametro: 1, idUsuario: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: "09:00"),
                new ParametroUsuario(idParametroUsuario: 2, idParametro: 2, idUsuario: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: "18:00"),
                new ParametroUsuario(idParametroUsuario: 3, idParametro: 3, idUsuario: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: "01:00"),
                new ParametroUsuario(idParametroUsuario: 4, idParametro: 4, idUsuario: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: "00:10"),
                new ParametroUsuario(idParametroUsuario: 5, idParametro: 5, idUsuario: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: "02:00")/*,
                new ParametroUsuario(idParametroUsuario: , idParametro: , idUsuario: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: ""),
                new ParametroUsuario(idParametroUsuario: , idParametro: , idUsuario: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: ""),
                new ParametroUsuario(idParametroUsuario: , idParametro: , idUsuario: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: ""),
                new ParametroUsuario(idParametroUsuario: , idParametro: , idUsuario: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), valor: "")*/
                );
        }
    }
}
