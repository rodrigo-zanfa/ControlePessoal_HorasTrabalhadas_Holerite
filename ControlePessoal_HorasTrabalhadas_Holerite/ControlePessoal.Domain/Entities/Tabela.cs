﻿using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class Tabela : Entity
    {
        // construtor usado apenas para a carga inicial de dados
        public Tabela(int idTabela, int idTabelaTipo, DateTime dataVigenciaInicial, string descricao)
        {
            IdTabela = idTabela;
            IdTabelaTipo = idTabelaTipo;
            DataVigenciaInicial = dataVigenciaInicial;
            Descricao = descricao;
        }

        public Tabela(int idTabelaTipo, DateTime dataVigenciaInicial, string descricao)
        {
            IdTabelaTipo = idTabelaTipo;
            DataVigenciaInicial = dataVigenciaInicial;
            Descricao = descricao;
        }

        public int IdTabela { get; private set; }
        public int IdTabelaTipo { get; private set; }
        public DateTime DataVigenciaInicial { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual TabelaTipo TabelaTipo { get; private set; }
        public virtual IEnumerable<TabelaItem> TabelasItens { get; private set; }

        public void UpdateIdTabelaTipo(int idTabelaTipo)
        {
            IdTabelaTipo = idTabelaTipo;
        }

        public void UpdateDataVigenciaInicial(DateTime dataVigenciaInicial)
        {
            DataVigenciaInicial = dataVigenciaInicial;
        }

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
