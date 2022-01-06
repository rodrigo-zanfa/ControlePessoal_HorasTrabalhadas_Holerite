using ControlePessoal.Domain.Commands.Ausencia;
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
    public class AusenciaController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public CommandResult Create([FromServices] AusenciaHandler handler, [FromBody] CreateAusenciaCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpPut]
        [Route("")]
        public CommandResult Update([FromServices] AusenciaHandler handler, [FromBody] UpdateAusenciaCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Ausencia> GetAll([FromServices] IAusenciaRepository repository)
        {
            var result = repository.GetAll();

            return result;
        }

        [HttpGet]
        [Route("{idAusencia}")]
        public Ausencia GetById([FromServices] IAusenciaRepository repository, [FromRoute] int idAusencia)
        {
            var result = repository.GetById(idAusencia);

            return result;
        }

        [HttpGet]
        [Route("usuario")]
        public IEnumerable<Ausencia> GetAllByUsuario([FromServices] IAusenciaRepository repository, [FromBody] GetAllByUsuarioQuery query)
        {
            var result = repository.GetAllByUsuario(query.IdUsuario, query.DataInicial, query.DataFinal);

            return result;
        }
    }
}
