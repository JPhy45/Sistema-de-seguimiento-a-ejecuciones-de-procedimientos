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

namespace Aplication.ProcedureControl.Commands.OperationsExecution.CreateOperationExecution
{
    public class CreateOperationExecutionCommandHandler :
        ICommandHandler<CreateOperationExecutionCommand, OperationExecution>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOperationExecutionCommandHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork unitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _unitOfWork = unitOfWork;

        }
        public Task<OperationExecution> Handle(CreateOperationExecutionCommand request, CancellationToken cancellationToken)
        {
            OperationExecution result = new OperationExecution(
                request.Operation);
            _ExecutionRepository.AddExecution(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}