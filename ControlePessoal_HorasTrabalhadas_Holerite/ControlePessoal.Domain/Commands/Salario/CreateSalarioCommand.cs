using Core.CQRS.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Commands.Salario
{
    public class CreateSalarioCommand : Notifiable<Notification>, ICommand
    {
        public CreateSalarioCommand(int idUsuario, DateTime dataVigenciaInicial, double valor)
        {
            IdUsuario = idUsuario;
            DataVigenciaInicial = dataVigenciaInicial;
            Valor = valor;
        }

        public int IdUsuario { get; set; }
        public DateTime DataVigenciaInicial { get; set; }
        public double Valor { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateSalarioCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(IdUsuario, 1, "IdUsuario", "Id do Usuário deve ser válido.")
                .IsGreaterThan(Valor, 0, "Valor", "Valor deve ser maior do que 0,00."));
        }
    }
}
