using ControlePessoal.Domain.Commands.Ponto;
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
    public class PontoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public CommandResult Create([FromServices] PontoHandler handler, [FromBody] CreatePontoCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpPut]
        [Route("")]
        public CommandResult Update([FromServices] PontoHandler handler, [FromBody] UpdatePontoCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Ponto> GetAll([FromServices] IPontoRepository repository)
        {
            var result = repository.GetAll();

            return result;
        }

        [HttpGet]
        [Route("{idPonto}")]
        public Ponto GetById([FromServices] IPontoRepository repository, [FromRoute] int idPonto)
        {
            var result = repository.GetById(idPonto);

            return result;
        }

        [HttpPost]
        [Route("lista")]
        public CommandResult CreateList([FromServices] PontoHandler handler, [FromBody] CreateListPontosCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpGet]
        [Route("usuario")]
        public IEnumerable<Ponto> GetAllByUsuario([FromServices] IPontoRepository repository, [FromBody] GetAllByUsuarioQuery query)
        {
            var result = repository.GetAllByUsuario(query.IdUsuario, query.DataInicial, query.DataFinal);

            return result;
        }
    }
}
