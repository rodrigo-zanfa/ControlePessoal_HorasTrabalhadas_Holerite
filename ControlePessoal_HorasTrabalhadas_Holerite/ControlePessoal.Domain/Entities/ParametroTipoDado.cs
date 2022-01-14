using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Entities
{
    public class ParametroTipoDado : Entity
    {
        // construtor usado apenas para a carga inicial de dados
        public ParametroTipoDado(int idParametroTipoDado, string descricao, int tamanhoMin, int tamanhoMax, string formato, double? intervaloMin, double? intervaloMax)
        {
            IdParametroTipoDado = idParametroTipoDado;
            Descricao = descricao;
            TamanhoMin = tamanhoMin;
            TamanhoMax = tamanhoMax;
            Formato = formato;
            IntervaloMin = intervaloMin;
            IntervaloMax = intervaloMax;
        }

        public ParametroTipoDado(string descricao, int tamanhoMin, int tamanhoMax, string formato, double? intervaloMin, double? intervaloMax)
        {
            Descricao = descricao;
            TamanhoMin = tamanhoMin;
            TamanhoMax = tamanhoMax;
            Formato = formato;
            IntervaloMin = intervaloMin;
            IntervaloMax = intervaloMax;
        }

        public int IdParametroTipoDado { get; private set; }
        public string Descricao { get; private set; }
        public int TamanhoMin { get; private set; }
        public int TamanhoMax { get; private set; }
        public string Formato { get; private set; }
        public double? IntervaloMin { get; private set; }
        public double? IntervaloMax { get; private set; }
        public DateTime DataHoraInclusao { get; private set; }
        public DateTime? DataHoraAlteracao { get; private set; }

        public virtual IEnumerable<Parametro> Parametros { get; private set; }

        public void UpdateDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void UpdateTamanhoMin(int tamanhoMin)
        {
            TamanhoMin = tamanhoMin;
        }

        public void UpdateTamanhoMax(int tamanhoMax)
        {
            TamanhoMax = tamanhoMax;
        }

        public void UpdateFormato(string formato)
        {
            Formato = formato;
        }

        public void UpdateIntervaloMin(double? intervaloMin)
        {
            IntervaloMin = intervaloMin;
        }

        public void UpdateIntervaloMax(double? intervaloMax)
        {
            IntervaloMax = intervaloMax;
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
