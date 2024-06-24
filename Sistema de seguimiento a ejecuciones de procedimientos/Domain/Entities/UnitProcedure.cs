using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type;

namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities
{
    public class UnitProcedure : Base
    {
        #region Properties
        /// <summary>
        /// Cola para las operaciones
        /// </summary>
        public Queue<Operations> Operations { get; set; }
        
        /// <summary>
        /// Fecha y hora de inicio 
        /// </summary>
        public string? UnitCode { get; set; }
        public ICollection<ProcedureOperation> ProcedureOperation { get; set; } = new List<ProcedureOperation>();

        #endregion

        #region Constructors
        public UnitProcedure(string ID, string Name) : base (ID, Name)
        {
            
            Operations = new Queue<Operations>();
       

        }

        #endregion

        
    }
}
