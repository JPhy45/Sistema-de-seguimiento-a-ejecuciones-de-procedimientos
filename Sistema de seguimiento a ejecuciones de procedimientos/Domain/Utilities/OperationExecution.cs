using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;

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
        public OperationExecution(Operations operations) : base()
        {
            Operation = operations;
            OperationId = operations.Id;
        }
        public OperationExecution() : base()
        {
            Operation = new Operations();
            OperationId = Operation.Id;
        }
        #endregion
    }
}
