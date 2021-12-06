using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Model
{
    public class Ponto
    {
        public int IdPonto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataHoraPonto { get; set; }
        public DateTime DataHoraInclusao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
