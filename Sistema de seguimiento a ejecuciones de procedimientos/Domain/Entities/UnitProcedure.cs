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
        public UnitProcedure(string ID, string Name) : base(ID, Name)
        {

            Operations = new Queue<Operations>();


        }

        public UnitProcedure() : base("A", "A") { }
        #endregion


    }
}
