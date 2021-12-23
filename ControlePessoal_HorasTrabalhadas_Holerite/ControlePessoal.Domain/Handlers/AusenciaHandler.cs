using ControlePessoal.Domain.Commands.Ausencia;
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
    public class AusenciaHandler : Notifiable<Notification>,
        IHandler<CreateAusenciaCommand>,
        IHandler<UpdateAusenciaCommand>
    {
        private readonly IAusenciaRepository _repository;

        public AusenciaHandler(IAusenciaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateAusenciaCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar a Ausência.", command.Notifications);
            }

            // gerar a Entidade
            var ausencia = new Ausencia(command.IdUsuario, command.DataAusencia, command.HoraInicialAusencia, command.HoraFinalAusencia);

            // salvar
            _repository.Create(ausencia);

            // retornar o resultado
            return new CommandResult(true, "Ausência criada com sucesso!", ausencia);
        }

        public ICommandResult Handle(UpdateAusenciaCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível alterar a Ausência.", command.Notifications);
            }

            // recuperar a Entidade
            var ausencia = _repository.GetById(command.IdAusencia);
            if (ausencia == null)
            {
                return new CommandResult(false, "Ausência não encontrada.", null);
            }

            // alterar os dados
            ausencia.UpdateIdUsuario(command.IdUsuario);
            ausencia.UpdateDataAusencia(command.DataAusencia);
            ausencia.UpdateHoraInicialAusencia(command.HoraInicialAusencia);
            ausencia.UpdateHoraFinalAusencia(command.HoraFinalAusencia);

            // salvar
            _repository.Update(ausencia);

            // retornar o resultado
            return new CommandResult(true, "Ausência alterada com sucesso!", ausencia);
        }
    }
}
