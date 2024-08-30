using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Contracts.Executions;
using Domain.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Utilities;

namespace Aplication.ProcedureControl.Commands.UnitProceduresExecution.CreateUnitProcedureExecution
{
    public class CreateUnitProcedureExecutionCommandHandler :
        ICommandHandler<CreateUnitProcedureExecutionCommand, UnitExecution>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitProcedureExecutionCommandHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork unitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _unitOfWork = unitOfWork;

        }
        public Task<UnitExecution> Handle(CreateUnitProcedureExecutionCommand request, CancellationToken cancellationToken)
        {
            UnitExecution result = new UnitExecution(
                request.UnitProcedure);
            _ExecutionRepository.AddExecution(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}