using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePessoal.WebAPI.ViewModels
{
    public class RequestPostListPontosViewModel
    {
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public IEnumerable<DateTime> DataHoraPonto { get; set; }
    }
}
