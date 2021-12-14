using Core.CQRS.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Commands.Usuario
{
    public class CreateUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public CreateUsuarioCommand()
        {

        }

        public CreateUsuarioCommand(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateUsuarioCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(Nome, 10, "Nome", "Nome do Usuário deve conter no mínimo 10 caracteres.")
                .IsLowerOrEqualsThan(Nome, 100, "Nome", "Nome do Usuário deve conter no máximo 100 caracteres."));
        }
    }
}
