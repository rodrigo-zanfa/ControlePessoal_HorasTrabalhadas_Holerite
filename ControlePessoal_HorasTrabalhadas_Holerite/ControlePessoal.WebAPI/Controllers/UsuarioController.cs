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
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsuariosAsync([FromServices] DataContext dataContext)
        {
            var result = await dataContext
                .Usuarios
                .AsNoTracking()
                .OrderBy(x => x.IdUsuario)
                .ToListAsync();

            return result.Count == 0 ? NotFound() : Ok(result);
        }

        [HttpGet]
        [Route("{idUsuario}")]
        public async Task<IActionResult> GetUsuarioByIdAsync([FromServices] DataContext dataContext, [FromRoute] int idUsuario)
        {
            var result = await dataContext
                .Usuarios
                .AsNoTracking()
                //.FirstOrDefaultAsync(x => x.IdUsuario == idUsuario);  // TODO: testar para comparar qual dos casos (este ou o de baixo) gera um SQL mais performático
                .Where(x => x.IdUsuario == idUsuario)
                .FirstOrDefaultAsync();

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostUsuarioAsync([FromServices] DataContext dataContext, [FromBody] RequestPostUsuarioViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuario = new Usuario
            {
                Nome = request.Nome
            };

            try
            {
                await dataContext
                    .Usuarios
                    .AddAsync(usuario);
                await dataContext.SaveChangesAsync();

                return Created($"v1/[controller]/{usuario.IdUsuario}", usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Message: {ex.Message} || InnerException: {ex.InnerException}");
            }
        }
    }
}
