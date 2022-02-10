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
        public async Task<IActionResult> CreateAsync([FromServices] PontoHandler handler, [FromBody] CreatePontoCommand command)
        {
            var result = (CommandResult)await handler.Handle(command);

            return result.Success ? Created($"/", result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateAsync([FromServices] PontoHandler handler, [FromBody] UpdatePontoCommand command)
        {
            var result = (CommandResult)await handler.Handle(command);

            return result.Success ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync([FromServices] IPontoRepository repository)
        {
            var result = await repository.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("{idPonto}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] IPontoRepository repository, [FromRoute] int idPonto)
        {
            var result = await repository.GetByIdAsync(idPonto);

            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost]
        [Route("lista")]
        public async Task<IActionResult> CreateListAsync([FromServices] PontoHandler handler, [FromBody] CreateListPontosCommand command)
        {
            var result = (CommandResult)await handler.Handle(command);

            return result.Success ? Created($"/", result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("usuario")]
        public async Task<IActionResult> GetAllByUsuarioAsync([FromServices] IPontoRepository repository, [FromBody] GetAllByUsuarioQuery query)
        {
            var result = await repository.GetAllByUsuarioAsync(query.IdUsuario, query.DataInicial, query.DataFinal);

            return result.Any() ? Ok(result) : NoContent();
        }
    }
}
