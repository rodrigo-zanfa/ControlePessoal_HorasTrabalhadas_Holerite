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
    public class DataHoraPonto
    {
        public DateTime DataPonto { get; set; }
        public TimeSpan HoraPonto { get; set; }
    }

    public class CreateListPontosCommand : Notifiable<Notification>, ICommand
    {
        public int IdUsuario { get; set; }
        public IEnumerable<DataHoraPonto> Pontos { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateListPontosCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(IdUsuario, 1, "IdUsuario", "Id do Usuário deve ser válido.")
                .IsGreaterOrEqualsThan(Pontos, 1, "Pontos", "Lista de Pontos deve conter ao menos 1 item."));
        }
    }
}
