using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class ParametroUsuario : Entity
    {
        // construtor usado apenas para a carga inicial de dados
        public ParametroUsuario(int idParametroUsuario, int idParametro, int idUsuario, DateTime dataVigenciaInicial, string valor)
        {
            IdParametroUsuario = idParametroUsuario;
            IdParametro = idParametro;
            IdUsuario = idUsuario;
            DataVigenciaInicial = dataVigenciaInicial;
            Valor = valor;
        }

        public ParametroUsuario(int idParametro, int idUsuario, DateTime dataVigenciaInicial, string valor)
        {
            IdParametro = idParametro;
            IdUsuario = idUsuario;
            DataVigenciaInicial = dataVigenciaInicial;
            Valor = valor;
        }

        public int IdParametroUsuario { get; private set; }
        public int IdParametro { get; private set; }
        public int IdUsuario { get; private set; }
        public DateTime DataVigenciaInicial { get; private set; }
        public string Valor { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual Parametro Parametro { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        public void UpdateIdParametro(int idParametro)
        {
            IdParametro = idParametro;
        }

        public void UpdateIdUsuario(int idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public void UpdateDataVigenciaInicial(DateTime dataVigenciaInicial)
        {
            DataVigenciaInicial = dataVigenciaInicial;
        }

        public void UpdateValor(string valor)
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
