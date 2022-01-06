using Core.CQRS.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Commands.Ausencia
{
    public class UpdateAusenciaCommand : Notifiable<Notification>, ICommand
    {
        public UpdateAusenciaCommand(int idAusencia, int idUsuario, DateTime dataAusencia, TimeSpan horaInicialAusencia, TimeSpan horaFinalAusencia)
        {
            IdAusencia = idAusencia;
            IdUsuario = idUsuario;
            DataAusencia = dataAusencia;
            HoraInicialAusencia = new TimeSpan(horaInicialAusencia.Hours, horaInicialAusencia.Minutes, 0);
            HoraFinalAusencia = new TimeSpan(horaFinalAusencia.Hours, horaFinalAusencia.Minutes, 0);
        }

        public int IdAusencia { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataAusencia { get; set; }
        public TimeSpan HoraInicialAusencia { get; set; }
        public TimeSpan HoraFinalAusencia { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateAusenciaCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(IdAusencia, 1, "IdAusencia", "Id da Ausência deve ser válido.")
                .IsGreaterOrEqualsThan(IdUsuario, 1, "IdUsuario", "Id do Usuário deve ser válido.")
                .IsGreaterThan(HoraFinalAusencia, HoraInicialAusencia, "HoraFinalAusencia", "Hora Final deve ser maior do que a Hora Inicial."));
        }
    }
}
