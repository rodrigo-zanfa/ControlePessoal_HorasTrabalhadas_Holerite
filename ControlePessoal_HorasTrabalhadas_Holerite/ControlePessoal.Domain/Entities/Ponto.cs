using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class Ponto : Entity
    {
        public Ponto(int idUsuario, DateTime dataPonto, TimeSpan horaPonto)
        {
            IdUsuario = idUsuario;
            DataPonto = dataPonto;
            HoraPonto = new TimeSpan(horaPonto.Hours, horaPonto.Minutes, 0);
        }

        public int IdPonto { get; private set; }
        public int IdUsuario { get; private set; }
        public DateTime DataPonto { get; private set; }
        public TimeSpan HoraPonto { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual Usuario Usuario { get; private set; }

        public void UpdateIdUsuario(int idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public void UpdateDataPonto(DateTime dataPonto)
        {
            DataPonto = dataPonto;
        }

        public void UpdateHoraPonto(TimeSpan horaPonto)
        {
            HoraPonto = new TimeSpan(horaPonto.Hours, horaPonto.Minutes, 0);
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
