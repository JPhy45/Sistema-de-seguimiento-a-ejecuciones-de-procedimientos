using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities
{
    /// <summary>
    /// Clase para relacionar UnitProcedure-Operations para relacion de muchos a muchos
    /// </summary>
    public class ProcedureOperation
    {
        /// <summary>
        /// Id de la iperacion
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Operacion
        /// </summary>
        public Operations Operation { get; set; }
        /// <summary>
        /// Id del procedimiento
        /// </summary>
        public Guid ProcedureId { get; set; }
        /// <summary>
        /// Procedimiento de unidad
        /// </summary>
        public UnitProcedure UnitProcedure { get; set; }
    }
}
