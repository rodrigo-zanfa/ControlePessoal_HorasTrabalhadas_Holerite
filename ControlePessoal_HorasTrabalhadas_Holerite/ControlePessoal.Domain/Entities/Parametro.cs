using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class Parametro : Entity
    {
        // construtor usado apenas para a carga inicial de dados
        public Parametro(int idParametro, string descricao, string descricaoDetalhada, int idParametroTipoDado)
        {
            IdParametro = idParametro;
            Descricao = descricao;
            DescricaoDetalhada = descricaoDetalhada;
            IdParametroTipoDado = idParametroTipoDado;
        }

        public Parametro(string descricao, string descricaoDetalhada, int idParametroTipoDado)
        {
            Descricao = descricao;
            DescricaoDetalhada = descricaoDetalhada;
            IdParametroTipoDado = idParametroTipoDado;
        }

        public int IdParametro { get; private set; }
        public string Descricao { get; private set; }
        public string DescricaoDetalhada { get; private set; }
        public int IdParametroTipoDado { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual ParametroTipoDado ParametroTipoDado { get; private set; }
        public virtual IEnumerable<ParametroUsuario> ParametrosUsuarios { get; private set; }

        public void UpdateDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void UpdateDescricaoDetalhada(string descricaoDetalhada)
        {
            DescricaoDetalhada = descricaoDetalhada;
        }

        public void UpdateIdParametroTipoDado(int idParametroTipoDado)
        {
            IdParametroTipoDado = idParametroTipoDado;
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
