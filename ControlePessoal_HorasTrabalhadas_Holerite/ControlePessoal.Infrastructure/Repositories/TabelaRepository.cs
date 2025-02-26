using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Entities.Shared;
using ControlePessoal.Domain.Repositories;
using ControlePessoal.Infrastructure.Contexts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Infrastructure.Repositories
{
    public class TabelaRepository : ITabelaRepository
    {
        private readonly DataContext _dataContext;

        public TabelaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TabelaInss> GetTabelaInssCalculadaAsync(DateTime dataVigencia, double valorSalario)
        {
            var result = new TabelaInss();

            var listaFaixaInss = await GetFaixasInssCalculadaAsync(dataVigencia, valorSalario);

            result.Faixas = listaFaixaInss;
            result.ValorTotalInss = listaFaixaInss.Sum(x => x.ValorCalculadoSalario);

            return result;
        }

        public async Task<IEnumerable<FaixaInss>> GetFaixasInssCalculadaAsync(DateTime dataVigencia, double valorSalario)
        {
            var result = new List<FaixaInss>();

            var listaTabelaItem = await GetTabelaItemAsync(1, dataVigencia);

            foreach (var tabelaItem in listaTabelaItem)
            {
                var valorCalculadoFaixa = Math.Round((tabelaItem.IntervaloFinal - tabelaItem.IntervaloInicial) * tabelaItem.ValorAliquota / 100, 2);

                if (valorSalario > tabelaItem.IntervaloFinal)  // caso o salário seja maior que o limite da faixa, a referência de cálculo será o próprio valor calculado da faixa
                {
                    result.Add(new FaixaInss
                    {
                        IntervaloInicial = tabelaItem.IntervaloInicial,
                        IntervaloFinal = tabelaItem.IntervaloFinal,
                        ValorAliquota = tabelaItem.ValorAliquota,
                        ValorCalculadoFaixa = valorCalculadoFaixa,
                        ValorCalculadoSalario = valorCalculadoFaixa
                    });
                }
                else if (valorSalario >= tabelaItem.IntervaloInicial && valorSalario <= tabelaItem.IntervaloFinal)  // caso o salário esteja entre os intervalos da faixa, a referência de cálculo será o proporcional)
                {
                    var valorCalculadoFaixaProporcional = Math.Round((valorSalario - tabelaItem.IntervaloInicial) * tabelaItem.ValorAliquota / 100, 2);

                    result.Add(new FaixaInss
                    {
                        IntervaloInicial = tabelaItem.IntervaloInicial,
                        IntervaloFinal = tabelaItem.IntervaloFinal,
                        ValorAliquota = tabelaItem.ValorAliquota,
                        ValorCalculadoFaixa = valorCalculadoFaixa,
                        ValorCalculadoSalario = valorCalculadoFaixaProporcional
                    });
                }
                else
                {
                    result.Add(new FaixaInss
                    {
                        IntervaloInicial = tabelaItem.IntervaloInicial,
                        IntervaloFinal = tabelaItem.IntervaloFinal,
                        ValorAliquota = tabelaItem.ValorAliquota,
                        ValorCalculadoFaixa = valorCalculadoFaixa,
                        ValorCalculadoSalario = 0
                    });
                }
            }

            return result;
        }

        public async Task<TabelaIrrf> GetTabelaIrrfCalculadaAsync(DateTime dataVigencia, double valorSalario, double valorInss, int qtdDependentes)
        {
            var result = new TabelaIrrf();

            result.ValorSalario = valorSalario;
            result.ValorDeducaoInss = valorInss;
            result.QtdDependentes = qtdDependentes;
            var tabela = await GetTabelaAsync(2, dataVigencia);
            result.ValorDeducaoPorDependente = tabela.ValorDeducaoDependente ?? 0;
            result.ValorDeducaoTotalDependentes = result.QtdDependentes * result.ValorDeducaoPorDependente;
            result.ValorBaseCalculoIrrf = result.ValorSalario - result.ValorDeducaoInss - result.ValorDeducaoTotalDependentes;

            var faixaIrrf = await GetFaixaIrrfCalculadaAsync(dataVigencia, result.ValorBaseCalculoIrrf);

            result.Faixa = faixaIrrf;
            result.ValorTotalIrrf = faixaIrrf.ValorCalculadoSalario;

            return result;
        }

        public async Task<FaixaIrrf> GetFaixaIrrfCalculadaAsync(DateTime dataVigencia, double valorBaseCalculoIrrf)
        {
            var result = new FaixaIrrf();

            var listaTabelaItem = await GetTabelaItemAsync(2, dataVigencia);

            foreach (var tabelaItem in listaTabelaItem)
            {
                if (valorBaseCalculoIrrf >= tabelaItem.IntervaloInicial && valorBaseCalculoIrrf <= tabelaItem.IntervaloFinal)  // caso a base de cálculo esteja entre os intervalos da faixa
                {
                    var valorCalculadoFaixa = Math.Round(valorBaseCalculoIrrf * tabelaItem.ValorAliquota / 100, 2);
                    var valorCalculadoSalario = Math.Round(valorCalculadoFaixa - tabelaItem.ValorDeducao.Value, 2);

                    result = new FaixaIrrf
                    {
                        IntervaloInicial = tabelaItem.IntervaloInicial,
                        IntervaloFinal = tabelaItem.IntervaloFinal,
                        ValorAliquota = tabelaItem.ValorAliquota,
                        ValorCalculadoFaixa = valorCalculadoFaixa,
                        ValorDeducaoFaixa = tabelaItem.ValorDeducao.Value,
                        ValorCalculadoSalario = valorCalculadoSalario
                    };

                    break;
                }
            }

            return result;
        }

        private async Task<IEnumerable<TabelaItem>> GetTabelaItemAsync(int idTabelaTipo, DateTime dataVigencia)
        {
            var listaTabelaItem = await _dataContext.Database.GetDbConnection().QueryAsync<TabelaItem>("GetTabelaItem",
                new { p_IdTabelaTipo = idTabelaTipo, p_DataVigencia = dataVigencia },
                commandType: CommandType.StoredProcedure);

            return listaTabelaItem;
        }

        private async Task<Tabela> GetTabelaAsync(int idTabelaTipo, DateTime dataVigencia)
        {
            var tabela = await _dataContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<Tabela>("GetTabela",
                new { p_IdTabelaTipo = idTabelaTipo, p_DataVigencia = dataVigencia },
                commandType: CommandType.StoredProcedure);

            return tabela;
        }
    }
}
