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
    public class UsuarioHandler : Notifiable<Notification>, IHandler<CreateUsuarioCommand>
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
                //AddNotifications(command);
                return new CommandResult(false, "Não foi possível criar o Usuário.", command.Notifications);
            }

            // gerar a Entidade
            var usuario = new Usuario(command.Nome);

            // salvar
            _repository.Create(usuario);

            // retornar o resultado
            return new CommandResult(true, "Usuário criado com sucesso!", usuario);
        }
    }
}
