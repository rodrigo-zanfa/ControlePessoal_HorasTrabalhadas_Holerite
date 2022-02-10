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
        public async Task<IActionResult> CreateAsync([FromServices] UsuarioHandler handler, [FromBody] CreateUsuarioCommand command)
        {
            var result = (CommandResult)await handler.Handle(command);

            return result.Success ? Created($"/", result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateAsync([FromServices] UsuarioHandler handler, [FromBody] UpdateUsuarioCommand command)
        {
            var result = (CommandResult)await handler.Handle(command);

            return result.Success ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync([FromServices] IUsuarioRepository repository)
        {
            var result = await repository.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("{idUsuario}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] IUsuarioRepository repository, [FromRoute] int idUsuario)
        {
            var result = await repository.GetByIdAsync(idUsuario);

            return result != null ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("Parametro/{idParametro}/{idUsuario}/{dataVigencia}")]
        public async Task<IActionResult> GetParametroUsuarioByDataVigenciaAsync([FromServices] IParametroUsuarioRepository repository, [FromRoute] int idParametro, [FromRoute] int idUsuario, [FromRoute] DateTime dataVigencia)
        {
            try
            {
                var result = await repository.GetParametroUsuarioByDataVigenciaAsync(idParametro, idUsuario, dataVigencia);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Erro ao processar consulta do Parâmetro do Usuário || Message: {ex.Message} || InnerException: {ex.InnerException}";

                return StatusCode(StatusCodes.Status500InternalServerError, msg);
            }
        }

        [HttpGet]
        [Route("Salario/{idUsuario}/{dataVigencia}")]
        public async Task<IActionResult> GetSalarioByDataVigenciaAsync([FromServices] ISalarioRepository repository, [FromRoute] int idUsuario, [FromRoute] DateTime dataVigencia)
        {
            try
            {
                var result = await repository.GetSalarioByDataVigenciaAsync(idUsuario, dataVigencia);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Erro ao processar consulta do Salário do Usuário || Message: {ex.Message} || InnerException: {ex.InnerException}";

                return StatusCode(StatusCodes.Status500InternalServerError, msg);
            }
        }

        [HttpGet]
        [Route("Inss/Tabela/{dataVigencia}/{valorSalario}")]
        public async Task<IActionResult> GetTabelaInssCalculadaAsync([FromServices] ITabelaRepository repository, [FromRoute] DateTime dataVigencia, [FromRoute] double valorSalario)
        {
            try
            {
                var result = await repository.GetTabelaInssCalculadaAsync(dataVigencia, valorSalario);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Erro ao processar consulta do INSS do Usuário (Tabela) || Message: {ex.Message} || InnerException: {ex.InnerException}";

                return StatusCode(StatusCodes.Status500InternalServerError, msg);
            }
        }

        [HttpGet]
        [Route("Inss/Faixas/{dataVigencia}/{valorSalario}")]
        public async Task<IActionResult> GetFaixasInssCalculadaAsync([FromServices] ITabelaRepository repository, [FromRoute] DateTime dataVigencia, [FromRoute] double valorSalario)
        {
            try
            {
                var result = await repository.GetFaixasInssCalculadaAsync(dataVigencia, valorSalario);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Erro ao processar consulta do INSS do Usuário (Faixas) || Message: {ex.Message} || InnerException: {ex.InnerException}";

                return StatusCode(StatusCodes.Status500InternalServerError, msg);
            }
        }
    }
}
