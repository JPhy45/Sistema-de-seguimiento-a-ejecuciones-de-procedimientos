using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;

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
        public PhaseExecution(Phases phase) : base()
        {
            Phase = phase;
            PhaseId = phase.Id;
        }
        public PhaseExecution() : base()
        {
            Phase = new Phases();
            PhaseId = Phase.Id;
        }
        #endregion
    }
}
