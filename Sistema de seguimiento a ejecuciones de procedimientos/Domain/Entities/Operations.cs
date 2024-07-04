namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities
{
    public class Operations : Base
    {
        #region Properties
        /// <summary>
        /// secuencia de fases para una operacion
        /// </summary>
        public List<Phases> phases { get; set; }


        /// <summary>
        /// codigo de la unidad en la que se encuentra
        /// </summary>
        public string? UnitCode { get; set; }

        #endregion



        #region Constructor
        public Operations(string IC, string Name) : base(IC, Name)
        {

            phases = new List<Phases>();
        }
        public Operations() : base("A", "A")
        {
            this.phases = new List<Phases>();

        }
        #endregion

        #region Methods
        public ICollection<OperationPhase> OperationPhase { get; set; } = new List<OperationPhase>();
        public ICollection<ProcedureOperation> ProcedureOperation { get; set; } = new List<ProcedureOperation>();

        #endregion

    }
}
