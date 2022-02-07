using ControlePessoal.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Repositories
{
    public interface ITabelaRepository
    {
        Task<TabelaInss> GetTabelaInssCalculadaAsync(DateTime dataVigencia, double valorSalario);
        Task<IEnumerable<FaixaInss>> GetFaixasInssCalculadaAsync(DateTime dataVigencia, double valorSalario);
    }
}
