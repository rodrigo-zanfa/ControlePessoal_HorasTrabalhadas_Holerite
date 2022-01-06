using ControlePessoal.Domain.Commands.Usuario;
using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Handlers;
using ControlePessoal.Domain.Repositories;
using Core.CQRS.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePessoal.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public CommandResult Create([FromServices] UsuarioHandler handler, [FromBody] CreateUsuarioCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpPut]
        [Route("")]
        public CommandResult Update([FromServices] UsuarioHandler handler, [FromBody] UpdateUsuarioCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Usuario> GetAll([FromServices] IUsuarioRepository repository)
        {
            var result = repository.GetAll();

            return result;
        }

        [HttpGet]
        [Route("{idUsuario}")]
        public Usuario GetById([FromServices] IUsuarioRepository repository, [FromRoute] int idUsuario)
        {
            var result = repository.GetById(idUsuario);

            return result;
        }
    }
}
