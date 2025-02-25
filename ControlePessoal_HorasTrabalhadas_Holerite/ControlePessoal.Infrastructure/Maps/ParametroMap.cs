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
                .UseIdentityColumn()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.DescricaoDetalhada)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(300);

            builder.Property(x => x.IdParametroTipoDado)
                .IsRequired();

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));  // usado apenas para a carga inicial de dados

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdParametro);

            builder.HasOne(x => x.ParametroTipoDado)
                .WithMany(x => x.Parametros)
                .HasForeignKey(x => x.IdParametroTipoDado)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Parametro(idParametro: 1, descricao: "Horário de Entrada", descricaoDetalhada: "Horário de Entrada do Usuário", idParametroTipoDado: 4),
                new Parametro(idParametro: 2, descricao: "Horário de Saída", descricaoDetalhada: "Horário de Saída do Usuário", idParametroTipoDado: 4),
                new Parametro(idParametro: 3, descricao: "Intervalo Diário", descricaoDetalhada: "Intervalo Diário do Usuário entre períodos de trabalho", idParametroTipoDado: 4),
                new Parametro(idParametro: 4, descricao: "Tolerância Diária", descricaoDetalhada: "Tolerância Diária (em hh:mm) para desconsiderar cálculos de Hora Extra ou Desconto", idParametroTipoDado: 4),
                new Parametro(idParametro: 5, descricao: "Limite para Banco de Horas Diário", descricaoDetalhada: "Limite (em hh:mm) para considerar o que fica em Banco de Horas; o excedente será considerado para pagamento em folha mensal", idParametroTipoDado: 4),
                new Parametro(idParametro: 6, descricao: "Quantidade de Dependentes", descricaoDetalhada: "Quantidade de Dependentes que o Usuário possui, para fins de desconto do cálculo de IRRF", idParametroTipoDado: 5)/*,
                new Parametro(idParametro: , descricao: "", descricaoDetalhada: "", idParametroTipoDado: ),
                new Parametro(idParametro: , descricao: "", descricaoDetalhada: "", idParametroTipoDado: ),
                new Parametro(idParametro: , descricao: "", descricaoDetalhada: "", idParametroTipoDado: ),
                new Parametro(idParametro: , descricao: "", descricaoDetalhada: "", idParametroTipoDado: )*/
                );
        }
    }
}
