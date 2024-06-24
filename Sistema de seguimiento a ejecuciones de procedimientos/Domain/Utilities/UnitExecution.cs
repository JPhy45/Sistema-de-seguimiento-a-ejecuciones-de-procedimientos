using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Common;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type;


namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities
{
    public class UnitExecution : Execution
    {
        #region Properties
        /// <summary>
        /// Procedimiento de unidades en ejecucion
        /// </summary>
        public UnitProcedure Unit {  get; set; }
        public Guid UnitId { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// constructor para la ejecucion de una unidad
        /// </summary>
        /// <param name="unit"></param>
        public UnitExecution (UnitProcedure unit)
        {

        this.Unit = unit;
        }
        public UnitExecution() { }
        #endregion

    }
}
