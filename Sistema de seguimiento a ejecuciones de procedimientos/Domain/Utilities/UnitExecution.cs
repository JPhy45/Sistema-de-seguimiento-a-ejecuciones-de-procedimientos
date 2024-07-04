using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;


namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities
{
    public class UnitExecution : Execution
    {
        #region Properties
        /// <summary>
        /// Procedimiento de unidades en ejecucion
        /// </summary>
        public UnitProcedure Unit { get; set; }
        public Guid UnitId { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// constructor para la ejecucion de una unidad
        /// </summary>
        /// <param name="unit"></param>
        public UnitExecution(UnitProcedure unit) : base()
        {

            this.Unit = unit;
            UnitId = unit.Id;  
        }
        public UnitExecution() : base()
        {
            Unit = new UnitProcedure();
            UnitId = Unit.Id;
        }
        #endregion

    }
}
