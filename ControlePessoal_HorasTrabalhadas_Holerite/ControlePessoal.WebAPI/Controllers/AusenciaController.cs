using ControlePessoal.Data;
using ControlePessoal.Model;
using ControlePessoal.WebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePessoal.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AusenciaController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostAusenciaAsync([FromServices] DataContext dataContext, [FromBody] RequestPostAusenciaViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ausencia = new Ausencia
            {
                IdUsuario = request.IdUsuario,
                DataAusencia = request.DataAusencia,
                HoraInicialAusencia = new TimeSpan(request.HoraInicialAusencia.Hours, request.HoraInicialAusencia.Minutes, 0),
                HoraFinalAusencia = new TimeSpan(request.HoraFinalAusencia.Hours, request.HoraFinalAusencia.Minutes, 0),
                DataHoraInclusao = DateTime.Now
            };

            try
            {
                await dataContext
                    .Ausencias
                    .AddAsync(ausencia);
                await dataContext.SaveChangesAsync();

                return Created($"v1/[controller]/{ausencia.IdAusencia}", ausencia);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Message: {ex.Message} || InnerException: {ex.InnerException}");
            }
        }
    }
}
