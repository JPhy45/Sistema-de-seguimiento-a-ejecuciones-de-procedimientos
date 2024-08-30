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


namespace Aplication.ProcedureControl.Queries.GetAllOperationsExecutions
{
    public class GetAllOperationsExecutionQueryHandler
        : IQueryHandler<GetAllOperationsExecutionQuery, IEnumerable<OperationExecution>>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public GetAllOperationsExecutionQueryHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork UnitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _UnitOfWork = UnitOfWork;
        }

        public Task<IEnumerable<OperationExecution>> Handle(GetAllOperationsExecutionQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ExecutionRepository.GetAllExecutions<OperationExecution>());
        }
    }
}