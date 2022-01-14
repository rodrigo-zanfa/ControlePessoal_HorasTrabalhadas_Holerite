using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class TabelaTipo : Entity
    {
        // construtor usado apenas para a carga inicial de dados
        public TabelaTipo(int idTabelaTipo, string descricao)
        {
            IdTabelaTipo = idTabelaTipo;
            Descricao = descricao;
        }

        public TabelaTipo(string descricao)
        {
            Descricao = descricao;
        }

        public int IdTabelaTipo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual IEnumerable<Tabela> Tabelas { get; private set; }

        public void UpdateDescricao(string descricao)
        {
            Descricao = descricao;
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
