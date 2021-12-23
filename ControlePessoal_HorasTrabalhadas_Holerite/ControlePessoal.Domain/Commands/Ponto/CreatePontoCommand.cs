using Core.CQRS.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Commands.Ponto
{
    public class CreatePontoCommand : Notifiable<Notification>, ICommand
    {
        public CreatePontoCommand(int idUsuario, DateTime dataPonto, TimeSpan horaPonto)
        {
            IdUsuario = idUsuario;
            DataPonto = dataPonto;
            HoraPonto = new TimeSpan(horaPonto.Hours, horaPonto.Minutes, 0);
        }

        public int IdUsuario { get; set; }
        public DateTime DataPonto { get; set; }
        public TimeSpan HoraPonto { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreatePontoCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(IdUsuario, 1, "IdUsuario", "Id do Usuário deve ser válido."));
        }
    }
}
