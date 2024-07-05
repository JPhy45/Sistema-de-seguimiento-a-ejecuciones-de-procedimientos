namespace Domain.Domain.Entities
{
    public class Operations : ProcedureControl
    {
        #region Properties
        /// <summary>
        /// secuencia de fases para una operacion
        /// </summary>
        public List<Phases> Phases { get; set; }

        /// <summary>
        /// Lista usada para la relacion de muchos a muchos
        /// </summary>
        public List<UnitProcedure>? UnitProcedures { get; set; }

        /// <summary>
        /// codigo de la unidad en la que se encuentra
        /// </summary>
        public string? UnitCode { get; set; }

        #endregion



        #region Constructor
        public Operations(string IC, string Name) : base(IC, Name)
        {

            Phases = new List<Phases>();
        }
        public Operations() : base("A", "A")
        {
            this.Phases = new List<Phases>();

        }
        #endregion

        #region Methods

        #endregion

    }
}
