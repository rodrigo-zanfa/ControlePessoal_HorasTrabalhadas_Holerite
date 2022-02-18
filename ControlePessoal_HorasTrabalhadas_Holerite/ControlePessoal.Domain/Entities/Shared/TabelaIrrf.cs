using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities.Shared
{
    public class FaixaIrrf
    {
        public double IntervaloInicial { get; set; }
        public double IntervaloFinal { get; set; }
        public double ValorAliquota { get; set; }
        public double ValorCalculadoFaixa { get; set; }
        public double ValorDeducaoFaixa { get; set; }
        public double ValorCalculadoSalario { get; set; }
    }

    public class TabelaIrrf
    {
        public double ValorSalario { get; set; }
        public double ValorDeducaoInss { get; set; }
        public int QtdDependentes { get; set; }
        public double ValorDeducaoPorDependente { get; set; }
        public double ValorDeducaoTotalDependentes { get; set; }
        public double ValorBaseCalculoIrrf { get; set; }
        public double ValorTotalIrrf { get; set; }
        public FaixaIrrf Faixa { get; set; }
    }
}
