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
    public class UpdateSalarioCommand : Notifiable<Notification>, ICommand
    {
        public UpdateSalarioCommand(int idSalario, int idUsuario, DateTime dataVigenciaInicial, double valor)
        {
            IdSalario = idSalario;
            IdUsuario = idUsuario;
            DataVigenciaInicial = dataVigenciaInicial;
            Valor = valor;
        }

        public int IdSalario { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataVigenciaInicial { get; set; }
        public double Valor { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateSalarioCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(IdSalario, 1, "IdSalario", "Id da Ausência deve ser válido.")
                .IsGreaterOrEqualsThan(IdUsuario, 1, "IdUsuario", "Id do Usuário deve ser válido.")
                .IsGreaterThan(Valor, 0, "Valor", "Valor deve ser maior do que 0,00."));
        }
    }
}
