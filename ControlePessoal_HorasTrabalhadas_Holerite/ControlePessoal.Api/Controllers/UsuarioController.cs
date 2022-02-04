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

        [HttpGet("Parametro/{idParametro}/{idUsuario}/{dataVigencia}")]
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

        [HttpGet("Salario/{idUsuario}/{dataVigencia}")]
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

        [HttpGet("Inss/Tabela/{dataVigencia}/{valorSalario}")]
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

        [HttpGet("Inss/Faixas/{dataVigencia}/{valorSalario}")]
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
