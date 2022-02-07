using Core.CQRS.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Commands.Holerite
{
    public class UpdateHoleriteCommand : Notifiable<Notification>, ICommand
    {
        public UpdateHoleriteCommand(int idHolerite, int idUsuario, string descricao, DateTime dataInicialPonto, DateTime dataFinalPonto, DateTime dataPagamentoAdiantamento, DateTime dataPagamento, DateTime? dataInicialHoraExtraNormal, DateTime? dataFinalHoraExtraNormal, DateTime? dataInicialHoraExtraAdicional, DateTime? dataFinalHoraExtraAdicional)
        {
            IdHolerite = idHolerite;
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

        public int IdHolerite { get; set; }
        public int IdUsuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicialPonto { get; set; }
        public DateTime DataFinalPonto { get; set; }
        public DateTime DataPagamentoAdiantamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime? DataInicialHoraExtraNormal { get; set; }
        public DateTime? DataFinalHoraExtraNormal { get; set; }
        public DateTime? DataInicialHoraExtraAdicional { get; set; }
        public DateTime? DataFinalHoraExtraAdicional { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateHoleriteCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(IdHolerite, 1, "IdHolerite", "Id do Holerite deve ser válido.")
                .IsGreaterOrEqualsThan(IdUsuario, 1, "IdUsuario", "Id do Usuário deve ser válido.")
                .IsGreaterOrEqualsThan(Descricao, 7, "Descricao", "Descrição do Holerite deve conter no mínimo 7 caracteres.")
                .IsLowerOrEqualsThan(Descricao, 100, "Descricao", "Descrição do Holerite deve conter no máximo 100 caracteres.")
                .IsGreaterOrEqualsThan(DataFinalPonto, DataInicialPonto, "DataFinalPonto", "Data Final do Ponto deve ser maior ou igual à Data Inicial do Ponto.")
                .IsGreaterOrEqualsThan(DataPagamentoAdiantamento, DataInicialPonto, "DataPagamentoAdiantamento", "Data de Pagamento do Adiantamento deve ser maior ou igual à Data Inicial do Ponto.")
                .IsGreaterOrEqualsThan(DataPagamento, DataInicialPonto, "DataPagamento", "Data de Pagamento deve ser maior ou igual à Data Inicial do Ponto."));
        }
    }
}
