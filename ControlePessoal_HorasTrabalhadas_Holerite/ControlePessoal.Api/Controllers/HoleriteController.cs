using ControlePessoal.Domain.Commands.Holerite;
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
    public class HoleriteController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public CommandResult Create([FromServices] HoleriteHandler handler, [FromBody] CreateHoleriteCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpPut]
        [Route("")]
        public CommandResult Update([FromServices] HoleriteHandler handler, [FromBody] UpdateHoleriteCommand command)
        {
            var result = (CommandResult)handler.Handle(command);

            return result;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Holerite> GetAll([FromServices] IHoleriteRepository repository)
        {
            var result = repository.GetAll();

            return result;
        }

        [HttpGet]
        [Route("{idHolerite}")]
        public Holerite GetById([FromServices] IHoleriteRepository repository, [FromRoute] int idHolerite)
        {
            var result = repository.GetById(idHolerite);

            return result;
        }

        [HttpGet]
        [Route("usuario")]
        public IEnumerable<Holerite> GetAllByUsuario([FromServices] IHoleriteRepository repository, [FromBody] GetAllByUsuarioQuery query)
        {
            var result = repository.GetAllByUsuario(query.IdUsuario, query.DataInicial, query.DataFinal);

            return result;
        }
    }
}
