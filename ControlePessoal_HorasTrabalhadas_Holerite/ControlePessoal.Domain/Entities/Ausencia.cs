using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class Ausencia : Entity
    {
        public Ausencia(int idUsuario, DateTime dataAusencia, TimeSpan horaInicialAusencia, TimeSpan horaFinalAusencia)
        {
            IdUsuario = idUsuario;
            DataAusencia = dataAusencia;
            HoraInicialAusencia = new TimeSpan(horaInicialAusencia.Hours, horaInicialAusencia.Minutes, 0);
            HoraFinalAusencia = new TimeSpan(horaFinalAusencia.Hours, horaFinalAusencia.Minutes, 0);
        }

        public int IdAusencia { get; private set; }
        public int IdUsuario { get; private set; }
        public DateTime DataAusencia { get; private set; }
        public TimeSpan HoraInicialAusencia { get; private set; }
        public TimeSpan HoraFinalAusencia { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual Usuario Usuario { get; private set; }

        public void UpdateIdUsuario(int idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public void UpdateDataAusencia(DateTime dataAusencia)
        {
            DataAusencia = dataAusencia;
        }

        public void UpdateHoraInicialAusencia(TimeSpan horaInicialAusencia)
        {
            HoraInicialAusencia = new TimeSpan(horaInicialAusencia.Hours, horaInicialAusencia.Minutes, 0);
        }

        public void UpdateHoraFinalAusencia(TimeSpan horaFinalAusencia)
        {
            HoraFinalAusencia = new TimeSpan(horaFinalAusencia.Hours, horaFinalAusencia.Minutes, 0);
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
