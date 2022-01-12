using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class SalarioMinimo : Entity
    {
        // construtor usado apenas para a carga inicial de dados
        public SalarioMinimo(int idSalarioMinimo, DateTime dataVigenciaInicial, double valor)
        {
            IdSalarioMinimo = idSalarioMinimo;
            DataVigenciaInicial = dataVigenciaInicial;
            Valor = valor;
        }

        public SalarioMinimo(DateTime dataVigenciaInicial, double valor)
        {
            DataVigenciaInicial = dataVigenciaInicial;
            Valor = valor;
        }

        public int IdSalarioMinimo { get; private set; }
        public DateTime DataVigenciaInicial { get; private set; }
        public double Valor { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public void UpdateDataVigenciaInicial(DateTime dataVigenciaInicial)
        {
            DataVigenciaInicial = dataVigenciaInicial;
        }

        public void UpdateValor(double valor)
        {
            Valor = valor;
        }

        public void UpdateDataHoraInclusao(DateTime dataHoraInclusao)
        {
            DataHoraInclusao = dataHoraInclusao;
        }

        public void UpdateDataHoraAlteracao(DateTime dataHoraAlteracao)
        {
            DataHoraAlteracao = dataHoraAlteracao;
        }
    }
}
