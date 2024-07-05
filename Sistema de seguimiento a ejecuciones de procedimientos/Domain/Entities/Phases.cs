namespace Domain.Domain.Entities
{
    public class Phases : ProcedureControl
    {
        /// <summary>
        /// Lista de operaciones para la relacion de muchos a muchos
        /// </summary>
        public List<Operations>? operations;

        #region Constructors
        /// <summary>
        /// constructor de fases
        /// </summary>
        /// <param name="IC"></param>
        /// <param name="Name"></param>
        public Phases(string IC, string Name) : base(IC, Name)
        {

        }
        public Phases() : base("A", "A") { }
        #endregion


    }
}
