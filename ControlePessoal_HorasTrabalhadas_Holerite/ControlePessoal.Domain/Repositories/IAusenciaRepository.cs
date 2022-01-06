﻿using ControlePessoal.Domain.Entities;
using Core.CQRS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Repositories
{
    public interface IAusenciaRepository : IRepository<Ausencia>
    {
        IEnumerable<Ausencia> GetAllByUsuario(int idUsuario, DateTime dataInicial, DateTime dataFinal);
    }
}
