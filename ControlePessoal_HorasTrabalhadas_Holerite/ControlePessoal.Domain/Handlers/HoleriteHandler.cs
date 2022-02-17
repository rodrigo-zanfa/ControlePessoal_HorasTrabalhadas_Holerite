using ControlePessoal.Domain.Commands.Holerite;
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
    public class HoleriteHandler : Notifiable<Notification>,
        IHandler<CreateHoleriteCommand>,
        IHandler<UpdateHoleriteCommand>
    {
        private readonly IHoleriteRepository _repository;

        public HoleriteHandler(IHoleriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateHoleriteCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar o Holerite.", command.Notifications);
            }

            // gerar a Entidade
            var entity = new Holerite(command.IdUsuario, command.Descricao, command.DataInicialPonto, command.DataFinalPonto, command.DataPagamentoAdiantamento, command.DataPagamento, command.DataInicialHoraExtraNormal, command.DataFinalHoraExtraNormal, command.DataInicialHoraExtraAdicional, command.DataFinalHoraExtraAdicional);

            // salvar
            await _repository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Holerite criado com sucesso!", entity);
        }

        public async Task<ICommandResult> Handle(UpdateHoleriteCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível alterar o Holerite.", command.Notifications);
            }

            // recuperar a Entidade
            var entity = await _repository.GetByIdAsync(command.IdHolerite);
            if (entity == null)
            {
                return new CommandResult(false, "Holerite não encontrado.", null);
            }

            // alterar os dados
            entity.UpdateIdUsuario(command.IdUsuario);
            entity.UpdateDescricao(command.Descricao);
            entity.UpdateDataInicialPonto(command.DataInicialPonto);
            entity.UpdateDataFinalPonto(command.DataFinalPonto);
            entity.UpdateDataPagamentoAdiantamento(command.DataPagamentoAdiantamento);
            entity.UpdateDataPagamento(command.DataPagamento);
            entity.UpdateDataInicialHoraExtraNormal(command.DataInicialHoraExtraNormal);
            entity.UpdateDataFinalHoraExtraNormal(command.DataFinalHoraExtraNormal);
            entity.UpdateDataInicialHoraExtraAdicional(command.DataInicialHoraExtraAdicional);
            entity.UpdateDataFinalHoraExtraAdicional(command.DataFinalHoraExtraAdicional);

            // salvar
            await _repository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Holerite alterado com sucesso!", entity);
        }
    }
}
