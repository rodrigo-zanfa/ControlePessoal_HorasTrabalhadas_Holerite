using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePessoal.WebAPI.ViewModels
{
    public class RequestPostAusenciaViewModel
    {
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public DateTime DataAusencia { get; set; }
        [Required]
        public TimeSpan HoraInicialAusencia { get; set; }
        [Required]
        public TimeSpan HoraFinalAusencia { get; set; }
    }
}
