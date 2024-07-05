using Domain.Domain.Common;

namespace Domain.Domain.Entities
{
    public abstract class ProcedureControl : Entity
    {
        #region Properties

        /// <summary>
        /// codigo identificador
        /// </summary>
        public string IdentificationCode { get; set; }
        /// <summary>
        /// nombre de las operaciones
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// descripcion de las operaciones
        /// </summary>
        public string? Description { get; set; }
        #endregion

        #region Constructors
        public ProcedureControl(string IC, string Name)
        {
            this.IdentificationCode = IC;
            this.Name = Name;
        }
        #endregion
    }
}
