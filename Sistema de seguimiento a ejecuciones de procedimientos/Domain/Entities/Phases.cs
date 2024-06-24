using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type;

namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities
{
    public class Phases : Base
    {
        public virtual ICollection<OperationPhase> OperationsPhase { get; set; } = new List<OperationPhase>();

        #region Constructors
        /// <summary>
        /// constructor de fases
        /// </summary>
        /// <param name="IC"></param>
        /// <param name="Name"></param>
        public Phases(string IC, string Name) : base (IC,Name)
        {

        }
        #endregion


    }
}
