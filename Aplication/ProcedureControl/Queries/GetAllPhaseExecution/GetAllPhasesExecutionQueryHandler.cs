using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Utilities;
using Contracts.Executions;

namespace Aplication.ProcedureControl.Queries.GetAllPhaseExecution
{
    public class GetAllPhasesExecutionQueryHandler
        : IQueryHandler<GetAllPhasesExecutionQuery, IEnumerable<PhaseExecution>>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public GetAllPhasesExecutionQueryHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork UnitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _UnitOfWork = UnitOfWork;
        }

        public Task<IEnumerable<PhaseExecution>> Handle(GetAllPhasesExecutionQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ExecutionRepository.GetAllExecutions<PhaseExecution>());
        }
    }
}
