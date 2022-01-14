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
        public Parametro(int idParametro, string nome, string descricao, int idParametroTipoDado)
        {
            IdParametro = idParametro;
            Nome = nome;
            Descricao = descricao;
            IdParametroTipoDado = idParametroTipoDado;
        }

        public Parametro(string nome, string descricao, int idParametroTipoDado)
        {
            Nome = nome;
            Descricao = descricao;
            IdParametroTipoDado = idParametroTipoDado;
        }

        public int IdParametro { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int IdParametroTipoDado { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual ParametroTipoDado ParametroTipoDado { get; private set; }
        public virtual IEnumerable<ParametroUsuario> ParametrosUsuarios { get; private set; }

        public void UpdateNome(string nome)
        {
            Nome = nome;
        }

        public void UpdateDescricao(string descricao)
        {
            Descricao = descricao;
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
