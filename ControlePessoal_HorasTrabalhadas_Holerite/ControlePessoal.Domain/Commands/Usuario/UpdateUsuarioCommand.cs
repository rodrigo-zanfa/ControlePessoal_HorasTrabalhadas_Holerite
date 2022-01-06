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
    public class UpdateUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUsuarioCommand(int idUsuario, string nome)
        {
            IdUsuario = idUsuario;
            Nome = nome;
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateUsuarioCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(IdUsuario, 1, "IdUsuario", "Id do Usuário deve ser válido.")
                .IsGreaterOrEqualsThan(Nome, 10, "Nome", "Nome do Usuário deve conter no mínimo 10 caracteres.")
                .IsLowerOrEqualsThan(Nome, 100, "Nome", "Nome do Usuário deve conter no máximo 100 caracteres."));
        }
    }
}
