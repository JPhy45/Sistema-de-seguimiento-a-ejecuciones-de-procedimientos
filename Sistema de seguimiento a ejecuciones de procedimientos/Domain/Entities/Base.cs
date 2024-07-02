using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Common;

namespace Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities
{
    public abstract class Base : Entity
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
        public Base(string IC, string Name)
        {
            this.IdentificationCode = IC;
            this.Name = Name;
        }
        #endregion
    }
}
