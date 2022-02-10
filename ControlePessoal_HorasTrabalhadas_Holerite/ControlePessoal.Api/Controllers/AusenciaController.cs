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
        public async Task<IActionResult> CreateAsync([FromServices] AusenciaHandler handler, [FromBody] CreateAusenciaCommand command)
        {
            var result = (CommandResult)await handler.Handle(command);

            return result.Success ? Created($"/", result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateAsync([FromServices] AusenciaHandler handler, [FromBody] UpdateAusenciaCommand command)
        {
            var result = (CommandResult)await handler.Handle(command);

            return result.Success ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync([FromServices] IAusenciaRepository repository)
        {
            var result = await repository.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("{idAusencia}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] IAusenciaRepository repository, [FromRoute] int idAusencia)
        {
            var result = await repository.GetByIdAsync(idAusencia);

            return result != null ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("usuario")]
        public async Task<IActionResult> GetAllByUsuarioAsync([FromServices] IAusenciaRepository repository, [FromBody] GetAllByUsuarioQuery query)
        {
            var result = await repository.GetAllByUsuarioAsync(query.IdUsuario, query.DataInicial, query.DataFinal);

            return result.Any() ? Ok(result) : NoContent();
        }
    }
}
