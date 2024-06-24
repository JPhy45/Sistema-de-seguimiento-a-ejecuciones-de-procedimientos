using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Common;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities
{
    public abstract class Execution : Entity
    {
        #region properties
        /// <summary>
        /// tiempo de inicio de la ejecucion
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// tiempo del fin de la ejecucion
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// estado de la ejecucion
        /// </summary>
        public ExecutionState State { get; set; }

        #endregion
        public Execution() 
        {
            StartTime = DateTime.Now;
            State = ExecutionState.iddle;

        }
    }

}
