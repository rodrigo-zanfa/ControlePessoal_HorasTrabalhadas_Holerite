using ControlePessoal.Domain.Commands.Salario;
using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Repositories;
using Core.CQRS.Commands;
using Core.CQRS.Handlers;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Handlers
{
    public class SalarioHandler : Notifiable<Notification>,
        IHandler<CreateSalarioCommand>,
        IHandler<UpdateSalarioCommand>
    {
        private readonly ISalarioRepository _repository;

        public SalarioHandler(ISalarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateSalarioCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar o Salário.", command.Notifications);
            }

            // gerar a Entidade
            var entity = new Salario(command.IdUsuario, command.DataVigenciaInicial, command.Valor);

            // salvar
            _repository.Create(entity);

            // retornar o resultado
            return new CommandResult(true, "Salário criado com sucesso!", entity);
        }

        public ICommandResult Handle(UpdateSalarioCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível alterar o Salário.", command.Notifications);
            }

            // recuperar a Entidade
            var entity = _repository.GetById(command.IdSalario);
            if (entity == null)
            {
                return new CommandResult(false, "Salário não encontrado.", null);
            }

            // alterar os dados
            entity.UpdateIdUsuario(command.IdUsuario);
            entity.UpdateDataVigenciaInicial(command.DataVigenciaInicial);
            entity.UpdateValor(command.Valor);

            // salvar
            _repository.Update(entity);

            // retornar o resultado
            return new CommandResult(true, "Salário alterado com sucesso!", entity);
        }
    }
}
