﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CQRS.Commands
{
    public interface ICommand
    {
        void Validate();
    }
}
