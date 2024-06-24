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
    public class OperationExecution : Execution
    {
        #region Properties
        /// <summary>
        /// Operacion que se ejecuta
        /// </summary>
        public Operations Operation { get; set; }
        /// <summary>
        /// variable para guardar el codigo de la gerarquia superior en este caso el de las Unidades de procedimiento
        /// </summary>
        public string? UpperCode { get; set; }
        /// <summary>
        /// id de la o
        /// </summary>
        public Guid OperationId { get; set; }
        #endregion

        #region Constructors
        public OperationExecution (Operations operations) 
        {
            Operation = operations;
        }
        public OperationExecution() { }
        #endregion
    }
}
