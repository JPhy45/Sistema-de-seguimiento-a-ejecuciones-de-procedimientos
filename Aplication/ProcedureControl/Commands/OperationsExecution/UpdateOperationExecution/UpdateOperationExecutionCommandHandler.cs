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

namespace Aplication.ProcedureControl.Commands.OperationsExecution.UpdateOperationExecution
{
    public class UpdateOperationExecutionCommandHandler : ICommandHandler<UpdateOperationExecutionCommand>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOperationExecutionCommandHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork unitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle(UpdateOperationExecutionCommand request, CancellationToken cancellationToken)
        {
            _ExecutionRepository.UpdateExecution(request.OperationExecution);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

