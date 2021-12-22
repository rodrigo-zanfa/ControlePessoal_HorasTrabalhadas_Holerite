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
    public class UpdatePontoCommand : Notifiable<Notification>, ICommand
    {
        public UpdatePontoCommand(int idPonto, int idUsuario, DateTime dataPonto, TimeSpan horaPonto)
        {
            IdPonto = idPonto;
            IdUsuario = idUsuario;
            DataPonto = dataPonto;
            HoraPonto = horaPonto;
        }

        public int IdPonto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataPonto { get; set; }
        public TimeSpan HoraPonto { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdatePontoCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(IdPonto, 1, "IdPonto", "Id do Ponto deve ser válido.")
                .IsGreaterOrEqualsThan(IdUsuario, 1, "IdUsuario", "Id do Usuário deve ser válido."));
        }
    }
}
