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
    public class ParametroMap : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("APIParametro");

            builder.Property(x => x.IdParametro)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(300);

            builder.Property(x => x.IdParametroTipoDado)
                .IsRequired();

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");  // usado apenas para a carga inicial de dados

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdParametro);

            builder.HasOne(x => x.ParametroTipoDado)
                .WithMany(x => x.Parametros)
                .HasForeignKey(x => x.IdParametroTipoDado)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Parametro(idParametro: 1, nome: "Horário de Entrada", descricao: "Horário de Entrada do Usuário", idParametroTipoDado: 4),
                new Parametro(idParametro: 2, nome: "Horário de Saída", descricao: "Horário de Saída do Usuário", idParametroTipoDado: 4),
                new Parametro(idParametro: 3, nome: "Intervalo Diário", descricao: "Intervalo Diário do Usuário entre períodos de trabalho", idParametroTipoDado: 4),
                new Parametro(idParametro: 4, nome: "Tolerância Diária", descricao: "Tolerância Diária (em hh:mm) para desconsiderar cálculos de Hora Extra ou Desconto", idParametroTipoDado: 4),
                new Parametro(idParametro: 5, nome: "Limite para Banco de Horas Diário", descricao: "Limite (em hh:mm) para considerar o que fica em Banco de Horas; o excedente será considerado para pagamento em folha mensal", idParametroTipoDado: 4)/*,
                new Parametro(idParametro: , nome: "", descricao: "", idParametroTipoDado: ),
                new Parametro(idParametro: , nome: "", descricao: "", idParametroTipoDado: ),
                new Parametro(idParametro: , nome: "", descricao: "", idParametroTipoDado: ),
                new Parametro(idParametro: , nome: "", descricao: "", idParametroTipoDado: )*/
                );
        }
    }
}
