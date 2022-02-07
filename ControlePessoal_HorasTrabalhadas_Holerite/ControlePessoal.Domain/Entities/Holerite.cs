using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class Holerite : Entity
    {
        public Holerite(int idUsuario, string descricao, DateTime dataInicialPonto, DateTime dataFinalPonto, DateTime dataPagamentoAdiantamento, DateTime dataPagamento, DateTime? dataInicialHoraExtraNormal, DateTime? dataFinalHoraExtraNormal, DateTime? dataInicialHoraExtraAdicional, DateTime? dataFinalHoraExtraAdicional)
        {
            IdUsuario = idUsuario;
            Descricao = descricao;
            DataInicialPonto = dataInicialPonto;
            DataFinalPonto = dataFinalPonto;
            DataPagamentoAdiantamento = dataPagamentoAdiantamento;
            DataPagamento = dataPagamento;
            DataInicialHoraExtraNormal = dataInicialHoraExtraNormal;
            DataFinalHoraExtraNormal = dataFinalHoraExtraNormal;
            DataInicialHoraExtraAdicional = dataInicialHoraExtraAdicional;
            DataFinalHoraExtraAdicional = dataFinalHoraExtraAdicional;
        }

        public int IdHolerite { get; private set; }
        public int IdUsuario { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataInicialPonto { get; private set; }
        public DateTime DataFinalPonto { get; private set; }
        public DateTime DataPagamentoAdiantamento { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime? DataInicialHoraExtraNormal { get; private set; }
        public DateTime? DataFinalHoraExtraNormal { get; private set; }
        public DateTime? DataInicialHoraExtraAdicional { get; private set; }
        public DateTime? DataFinalHoraExtraAdicional { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual Usuario Usuario { get; private set; }

        public void UpdateIdUsuario(int idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public void UpdateDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void UpdateDataInicialPonto(DateTime dataInicialPonto)
        {
            DataInicialPonto = dataInicialPonto;
        }

        public void UpdateDataFinalPonto(DateTime dataFinalPonto)
        {
            DataFinalPonto = dataFinalPonto;
        }

        public void UpdateDataPagamentoAdiantamento(DateTime dataPagamentoAdiantamento)
        {
            DataPagamentoAdiantamento = dataPagamentoAdiantamento;
        }

        public void UpdateDataPagamento(DateTime dataPagamento)
        {
            DataPagamento = dataPagamento;
        }

        public void UpdateDataInicialHoraExtraNormal(DateTime? dataInicialHoraExtraNormal)
        {
            DataInicialHoraExtraNormal = dataInicialHoraExtraNormal;
        }

        public void UpdateDataFinalHoraExtraNormal(DateTime? dataFinalHoraExtraNormal)
        {
            DataFinalHoraExtraNormal = dataFinalHoraExtraNormal;
        }

        public void UpdateDataInicialHoraExtraAdicional(DateTime? dataInicialHoraExtraAdicional)
        {
            DataInicialHoraExtraAdicional = dataInicialHoraExtraAdicional;
        }

        public void UpdateDataFinalHoraExtraAdicional(DateTime? dataFinalHoraExtraAdicional)
        {
            DataFinalHoraExtraAdicional = dataFinalHoraExtraAdicional;
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
