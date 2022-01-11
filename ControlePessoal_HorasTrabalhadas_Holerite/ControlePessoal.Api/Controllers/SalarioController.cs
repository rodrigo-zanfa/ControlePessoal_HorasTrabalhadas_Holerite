using ControlePessoal.Domain.Commands.Salario;
using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Handlers;
using ControlePessoal.Domain.Queries.Shared;
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
    public class SalarioController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public CommandResult Create([FromServices] SalarioHandler handler, [FromBody] CreateSalarioCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpPut]
        [Route("")]
        public CommandResult Update([FromServices] SalarioHandler handler, [FromBody] UpdateSalarioCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Salario> GetAll([FromServices] ISalarioRepository repository)
        {
            var result = repository.GetAll();

            return result;
        }

        [HttpGet]
        [Route("{idSalario}")]
        public Salario GetById([FromServices] ISalarioRepository repository, [FromRoute] int idSalario)
        {
            var result = repository.GetById(idSalario);

            return result;
        }

        [HttpGet]
        [Route("usuario")]
        public IEnumerable<Salario> GetAllByUsuario([FromServices] ISalarioRepository repository, [FromBody] GetAllByUsuarioQuery query)
        {
            var result = repository.GetAllByUsuario(query.IdUsuario, query.DataInicial, query.DataFinal);

            return result;
        }
    }
}
