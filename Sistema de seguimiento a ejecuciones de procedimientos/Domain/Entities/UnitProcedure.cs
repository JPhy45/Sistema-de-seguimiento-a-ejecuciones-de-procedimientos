namespace Domain.Domain.Entities
{
    public class UnitProcedure : ProcedureControl
    {
        #region Properties
        /// <summary>
        /// Cola para las operaciones
        /// </summary>
        public List<Operations> Operations { get; set; }

        /// <summary>
        /// Fecha y hora de inicio 
        /// </summary>
        public string? UnitCode { get; set; }
        #endregion

        #region Constructors
        public UnitProcedure(string ID, string Name) : base(ID, Name)
        {

            Operations = new List<Operations>();


        }

        public UnitProcedure() : base("A", "A") 
        {
            Operations = new List<Operations>();
        }
        #endregion


    }
}
