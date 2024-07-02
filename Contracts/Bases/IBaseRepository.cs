using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;

namespace Contracts.Bases
{
    public interface IBaseRepository
    {
        /// <summary>
        /// agrega un elemento al soporte de datos
        /// </summary>
        /// <param name="bases"></param>
        void Add(Base bases);
        /// <summary>
        /// Obtiene un elemento del soporte de datos por el Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T? GetById<T>(Guid id) where T : Base;
        /// <summary>
        /// obtiene todos los valores del soporte de datos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>() where T : Base;
        /// <summary>
        /// Actualiza un elemento en el soporte de datos
        /// </summary>
        /// <param name="Bases"></param>
        void Update(Base Bases);
        /// <summary>
        /// Elimina un elemento del soporte de datos
        /// </summary>
        /// <param name="Bases"></param>
        void Delete(Base Bases);
    }
}
