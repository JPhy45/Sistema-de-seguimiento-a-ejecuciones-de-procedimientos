using Domain.Domain.Utilities;

namespace Contracts.Executions
{
    public interface IExecutionRepository
    {
        /// <summary>
        /// Agrega una ejecucion al soporte de datos
        /// </summary>
        /// <param name="execution"></param>
        void AddExecution(Execution execution);
        /// <summary>
        /// Obtiene una ejecucion del soporte de datos por su Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        T? GetExecutionById<T>(Guid Id) where T : Execution;
        /// <summary>
        /// obtiene todas las ejecuciones del soporte de datos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAllExecutions<T>() where T : Execution;
        /// <summary>
        /// Actualiza una ejecucion
        /// </summary>
        /// <param name="execution"></param>
        void UpdateExecution(Execution execution);
        /// <summary>
        /// Elimina una ejecucion del soporte de datos
        /// </summary>
        /// <param name="execution"></param>
        void DeleteExecution(Execution execution);
    }
}
