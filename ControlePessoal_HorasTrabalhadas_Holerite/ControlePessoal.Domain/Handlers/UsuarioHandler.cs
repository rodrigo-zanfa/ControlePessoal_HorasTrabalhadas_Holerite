﻿using ControlePessoal.Domain.Commands.Usuario;
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
    public class UsuarioHandler : Notifiable<Notification>,
        IHandler<CreateUsuarioCommand>,
        IHandler<UpdateUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUsuarioCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar o Usuário.", command.Notifications);
            }

            // gerar a Entidade
            var entity = new Usuario(command.Nome);

            // salvar
            _repository.Create(entity);

            // retornar o resultado
            return new CommandResult(true, "Usuário criado com sucesso!", entity);
        }

        public ICommandResult Handle(UpdateUsuarioCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Não foi possível alterar o Usuário.", command.Notifications);
            }

            // recuperar a Entidade
            var entity = _repository.GetById(command.IdUsuario);
            if (entity == null)
            {
                return new CommandResult(false, "Usuário não encontrado.", null);
            }

            // alterar os dados
            entity.UpdateNome(command.Nome);

            // salvar
            _repository.Update(entity);

            // retornar o resultado
            return new CommandResult(true, "Usuário alterado com sucesso!", entity);
        }
    }
}
