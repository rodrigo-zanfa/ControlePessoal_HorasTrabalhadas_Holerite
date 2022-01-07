using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(string nome)
        {
            Nome = nome;
        }

        public Usuario(int idUsuario, string nome)
        {
            IdUsuario = idUsuario;
            Nome = nome;
        }

        public int IdUsuario { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual IEnumerable<Ponto> Pontos { get; private set; }
        public virtual IEnumerable<Ausencia> Ausencias { get; private set; }

        public void UpdateNome(string nome)
        {
            Nome = nome;
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
