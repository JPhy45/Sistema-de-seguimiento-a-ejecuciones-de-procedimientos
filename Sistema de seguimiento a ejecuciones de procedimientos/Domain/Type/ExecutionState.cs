﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type
{
    /// <summary>
    /// clase enum para definir el estado de los procedimientos
    /// </summary>
    public enum ExecutionState
    {
        iddle,
        Running,
        Paused,
        Completed

    }
}
