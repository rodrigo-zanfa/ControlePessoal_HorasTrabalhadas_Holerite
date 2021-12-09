using ControlePessoal.Data;
using ControlePessoal.Model;
using ControlePessoal.WebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePessoal.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PontoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPontosByUsuarioAsync([FromServices] DataContext dataContext, [FromBody] RequestGetAllPontosByUsuarioViewModel request)
        {
            var dataInicial = request.DataInicial.AddHours(-request.DataInicial.Hour).AddMinutes(-request.DataInicial.Minute).AddSeconds(-request.DataInicial.Second);
            var dataFinal = new DateTime(request.DataFinal.Year, request.DataFinal.Month, request.DataFinal.Day, 23, 59, 59);

            var result = await dataContext
                .Pontos
                .AsNoTracking()
                .Where(x => x.IdUsuario == request.IdUsuario && x.DataHoraPonto >= dataInicial && x.DataHoraPonto <= dataFinal)
                .OrderBy(x => x.DataHoraPonto)
                .ToListAsync();

            return result.Count == 0 ? NotFound() : Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostPontoAsync([FromServices] DataContext dataContext, [FromBody] RequestPostPontoViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ponto = new Ponto
            {
                IdUsuario = request.IdUsuario,
                DataHoraPonto = request.DataHoraPonto.AddSeconds(-request.DataHoraPonto.Second),
                DataHoraInclusao = DateTime.Now
            };

            try
            {
                await dataContext
                    .Pontos
                    .AddAsync(ponto);
                await dataContext.SaveChangesAsync();

                return Created($"v1/[controller]/{ponto.IdPonto}", ponto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Message: {ex.Message} || InnerException: {ex.InnerException}");
            }
        }

        [HttpPost]
        [Route("many")]
        public async Task<IActionResult> PostListPontosAsync([FromServices] DataContext dataContext, [FromBody] RequestPostListPontosViewModel request)
        {
            bool success = true;
            string exceptionMessage = "";

            if (!ModelState.IsValid)
                return BadRequest();

            foreach (var dataHoraPonto in request.DataHoraPonto)
            {
                var ponto = new Ponto
                {
                    IdUsuario = request.IdUsuario,
                    DataHoraPonto = dataHoraPonto.AddSeconds(-dataHoraPonto.Second),
                    DataHoraInclusao = DateTime.Now
                };

                try
                {
                    await dataContext
                        .Pontos
                        .AddAsync(ponto);
                    await dataContext.SaveChangesAsync();

                    //return Created($"v1/[controller]/{ponto.IdPonto}", ponto);
                }
                catch (Exception ex)
                {
                    //return StatusCode(StatusCodes.Status500InternalServerError, $"Message: {ex.Message} || InnerException: {ex.InnerException}");
                    success = false;
                    exceptionMessage = $"Message: {ex.Message} || InnerException: {ex.InnerException}";
                    break;
                }
            }

            if (success)
                return Created($"v1/[controller]/{request.IdUsuario}", request);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, exceptionMessage);
        }
    }
}
