using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type;

namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities
{
    public class Operations : Base
    {
        #region Properties
        /// <summary>
        /// secuencia de fases para una operacion
        /// </summary>
        public Queue<Phases> phases { get; set; }
        

        /// <summary>
        /// codigo de la unidad en la que se encuentra
        /// </summary>
        public string? UnitCode { get; set; }

        #endregion



        #region Constructor
        public Operations(string IC, string Name) : base(IC, Name)
        {
            
            phases = new Queue<Phases>();
        }
        public Operations(): base("A", "A")
        {
            this.phases = new Queue<Phases>();

        }
        #endregion

        #region Methods
        public ICollection<OperationPhase> OperationPhase { get; set; } = new List<OperationPhase>();
        public ICollection<ProcedureOperation> ProcedureOperation { get; set; } = new List <ProcedureOperation>();

        #endregion

    }
}
