using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePessoal.WebAPI.ViewModels
{
    public class UsuarioViewModel
    {
        [Required]
        public string Nome { get; set; }
    }
}
