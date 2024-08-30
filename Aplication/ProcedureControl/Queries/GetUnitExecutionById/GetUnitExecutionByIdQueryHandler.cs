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


namespace Aplication.ProcedureControl.Queries.GetUnitExecutionById
{
    public class GetUnitExecutionByIdQueryHandler
        : IQueryHandler<GetUnitExecutionByIdQuery, UnitExecution?>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public GetUnitExecutionByIdQueryHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork UnitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _UnitOfWork = UnitOfWork;
        }

        public Task<UnitExecution?> Handle(GetUnitExecutionByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ExecutionRepository.GetExecutionById<UnitExecution>(request.Id));
        }
    }
}
