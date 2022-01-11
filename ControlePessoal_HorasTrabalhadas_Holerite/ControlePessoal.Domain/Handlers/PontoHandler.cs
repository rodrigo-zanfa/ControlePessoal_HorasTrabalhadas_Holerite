using ControlePessoal.Domain.Commands.Ponto;
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
    public class PontoHandler : Notifiable<Notification>,
        IHandler<CreatePontoCommand>,
        IHandler<UpdatePontoCommand>,
        IHandler<CreateListPontosCommand>
    {
        private readonly IPontoRepository _repository;

        public PontoHandler(IPontoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreatePontoCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar o Ponto.", command.Notifications);
            }

            // gerar a Entidade
            var entity = new Ponto(command.IdUsuario, command.DataPonto, command.HoraPonto);

            // salvar
            _repository.Create(entity);

            // retornar o resultado
            return new CommandResult(true, "Ponto criado com sucesso!", entity);
        }

        public ICommandResult Handle(UpdatePontoCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível alterar o Ponto.", command.Notifications);
            }

            // recuperar a Entidade
            var entity = _repository.GetById(command.IdPonto);
            if (entity == null)
            {
                return new CommandResult(false, "Ponto não encontrado.", null);
            }

            // alterar os dados
            entity.UpdateIdUsuario(command.IdUsuario);
            entity.UpdateDataPonto(command.DataPonto);
            entity.UpdateHoraPonto(command.HoraPonto);

            // salvar
            _repository.Update(entity);

            // retornar o resultado
            return new CommandResult(true, "Ponto alterado com sucesso!", entity);
        }

        public ICommandResult Handle(CreateListPontosCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar os Pontos.", command.Notifications);
            }

            foreach (var item in command.Pontos)
            {
                // gerar a Entidade
                var entity = new Ponto(command.IdUsuario, item.DataPonto, item.HoraPonto);

                // salvar
                _repository.Create(entity);
            }

            // retornar o resultado
            return new CommandResult(true, "Pontos criados com sucesso!", command);
        }
    }
}
