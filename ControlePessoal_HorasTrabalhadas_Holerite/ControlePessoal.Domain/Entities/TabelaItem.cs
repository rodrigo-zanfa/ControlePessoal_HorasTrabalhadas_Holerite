using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class TabelaItem : Entity
    {
        // construtor usado apenas para a carga inicial de dados
        public TabelaItem(int idTabelaItem, int idTabela, double intervaloInicial, double intervaloFinal, double valorAliquota, double? valorDeducao)
        {
            IdTabelaItem = idTabelaItem;
            IdTabela = idTabela;
            IntervaloInicial = intervaloInicial;
            IntervaloFinal = intervaloFinal;
            ValorAliquota = valorAliquota;
            ValorDeducao = valorDeducao;
        }

        public TabelaItem(int idTabela, double intervaloInicial, double intervaloFinal, double valorAliquota, double? valorDeducao)
        {
            IdTabela = idTabela;
            IntervaloInicial = intervaloInicial;
            IntervaloFinal = intervaloFinal;
            ValorAliquota = valorAliquota;
            ValorDeducao = valorDeducao;
        }

        public int IdTabelaItem { get; private set; }
        public int IdTabela { get; private set; }
        public double IntervaloInicial { get; private set; }
        public double IntervaloFinal { get; private set; }
        public double ValorAliquota { get; private set; }
        public double? ValorDeducao { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual Tabela Tabela { get; private set; }

        public void UpdateIdTabela(int idTabela)
        {
            IdTabela = idTabela;
        }

        public void UpdateIntervaloInicial(double intervaloInicial)
        {
            IntervaloInicial = intervaloInicial;
        }

        public void UpdateIntervaloFinal(double intervaloFinal)
        {
            IntervaloFinal = intervaloFinal;
        }

        public void UpdateValorAliquota(double valorAliquota)
        {
            ValorAliquota = valorAliquota;
        }

        public void UpdateValorDeducao(double valorDeducao)
        {
            ValorDeducao = valorDeducao;
        }

        public void UpdateDataHoraInclusao(DateTime dataHoraInclusao)
        {
            DataHoraInclusao = dataHoraInclusao;
        }

        public void UpdateDataHoraAlteracao(DateTime dataHoraAlteracao)
        {
            DataHoraAlteracao = dataHoraAlteracao;
        }
    }
}
