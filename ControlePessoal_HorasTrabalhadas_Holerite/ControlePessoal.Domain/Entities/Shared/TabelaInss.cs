using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities.Shared
{
    public class FaixaInss
    {
        public double IntervaloInicial { get; set; }
        public double IntervaloFinal { get; set; }
        public double ValorAliquota { get; set; }
        public double ValorCalculadoFaixa { get; set; }
        public double ValorCalculadoSalario { get; set; }
    }

    public class TabelaInss
    {
        public double ValorTotalInss { get; set; }
        public IEnumerable<FaixaInss> Faixas { get; set; }
    }
}
