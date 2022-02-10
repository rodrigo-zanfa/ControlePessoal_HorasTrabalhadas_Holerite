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

        public async Task<ICommandResult> Handle(CreateAusenciaCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar a Ausência.", command.Notifications);
            }

            // gerar a Entidade
            var entity = new Ausencia(command.IdUsuario, command.DataAusencia, command.HoraInicialAusencia, command.HoraFinalAusencia);

            // salvar
            await _repository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Ausência criada com sucesso!", entity);
        }

        public async Task<ICommandResult> Handle(UpdateAusenciaCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível alterar a Ausência.", command.Notifications);
            }

            // recuperar a Entidade
            var entity = await _repository.GetByIdAsync(command.IdAusencia);
            if (entity == null)
            {
                return new CommandResult(false, "Ausência não encontrada.", null);
            }

            // alterar os dados
            entity.UpdateIdUsuario(command.IdUsuario);
            entity.UpdateDataAusencia(command.DataAusencia);
            entity.UpdateHoraInicialAusencia(command.HoraInicialAusencia);
            entity.UpdateHoraFinalAusencia(command.HoraFinalAusencia);

            // salvar
            await _repository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Ausência alterada com sucesso!", entity);
        }
    }
}
