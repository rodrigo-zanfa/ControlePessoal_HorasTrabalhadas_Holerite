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
        public async Task<IActionResult> CreateAsync([FromServices] SalarioHandler handler, [FromBody] CreateSalarioCommand command)
        {
            var result = (CommandResult)await handler.Handle(command);

            return result.Success ? Created($"/", result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateAsync([FromServices] SalarioHandler handler, [FromBody] UpdateSalarioCommand command)
        {
            var result = (CommandResult)await handler.Handle(command);

            return result.Success ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync([FromServices] ISalarioRepository repository)
        {
            var result = await repository.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("{idSalario}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] ISalarioRepository repository, [FromRoute] int idSalario)
        {
            var result = await repository.GetByIdAsync(idSalario);

            return result != null ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("usuario")]
        public async Task<IActionResult> GetAllByUsuarioAsync([FromServices] ISalarioRepository repository, [FromBody] GetAllByUsuarioQuery query)
        {
            var result = await repository.GetAllByUsuarioAsync(query.IdUsuario, query.DataInicial, query.DataFinal);

            return result.Any() ? Ok(result) : NoContent();
        }
    }
}
