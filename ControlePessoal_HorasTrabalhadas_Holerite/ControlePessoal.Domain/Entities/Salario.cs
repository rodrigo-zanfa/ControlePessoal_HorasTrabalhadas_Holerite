using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class Salario : Entity
    {
        public Salario(int idUsuario, DateTime dataVigenciaInicial, double valor)
        {
            IdUsuario = idUsuario;
            DataVigenciaInicial = dataVigenciaInicial;
            Valor = valor;
        }

        public int IdSalario { get; private set; }
        public int IdUsuario { get; private set; }
        public DateTime DataVigenciaInicial { get; private set; }
        public double Valor { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual Usuario Usuario { get; private set; }

        public void UpdateIdUsuario(int idUsuario)
        {
            IdUsuario = idUsuario;
        }

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
