using Domain.Domain.Entities;

namespace Contracts.Procedures
{
    public interface IProcedureControlRepository
    {
        /// <summary>
        /// agrega un elemento al soporte de datos
        /// </summary>
        /// <param name="bases"></param>
        void Add(ProcedureControl bases);
        /// <summary>
        /// Obtiene un elemento del soporte de datos por el Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T? GetById<T>(Guid id) where T : ProcedureControl;
        /// <summary>
        /// obtiene todos los valores del soporte de datos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>() where T : ProcedureControl;
        /// <summary>
        /// Actualiza un elemento en el soporte de datos
        /// </summary>
        /// <param name="Bases"></param>
        void Update(ProcedureControl Bases);
        /// <summary>
        /// Elimina un elemento del soporte de datos
        /// </summary>
        /// <param name="Bases"></param>
        void Delete(ProcedureControl Bases);
    }
}
