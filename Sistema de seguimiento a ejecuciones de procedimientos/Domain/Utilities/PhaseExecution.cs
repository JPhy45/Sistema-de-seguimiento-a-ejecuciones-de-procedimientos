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
     public class PhaseExecution : Execution
    {
        #region Properties
        /// <summary>
        /// Fase que se esta ejecutando
        /// </summary>
        public Phases Phase { get; set; }
        /// <summary>
        /// El codigo de gerarquia superior en este caso de operaciones
        /// </summary>
        public string? UpperCode { get; set; }
        /// <summary>
        /// llave foranea para las fases
        /// </summary>
        public Guid PhaseId { get; set; }
        #endregion




        #region Constructors
        /// <summary>
        /// constructor para la ejecucion de una fase
        /// </summary>
        /// <param name="phase"></param>
        public PhaseExecution(Phases phase) 
        {
            Phase = phase;
        }
        public PhaseExecution() { }
        #endregion
    }
}
