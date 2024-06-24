using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities
{
    /// <summary>
    ///  clase para relacionar Operaciones con Fases
    /// </summary>
    public class OperationPhase
    {
        /// <summary>
        /// Fase
        /// </summary>
        public Phases Phase { get; set; }
        /// <summary>
        /// ID de la fase
        /// </summary>
        public Guid PhaseId { get; set; }
        /// <summary>
        /// Operacion
        /// </summary>
        public Operations Operation { get; set; }
        /// <summary>
        /// Id de la operacion
        /// </summary>
        public Guid OperationId { get; set; }

    }
}
