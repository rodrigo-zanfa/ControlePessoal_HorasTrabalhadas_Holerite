using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Model
{
    public class Ausencia
    {
        public int IdAusencia { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataAusencia { get; set; }
        public TimeSpan HoraInicialAusencia { get; set; }
        public TimeSpan HoraFinalAusencia { get; set; }
        public DateTime DataHoraInclusao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
