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


namespace Aplication.ProcedureControl.Commands.OperationsExecution.DeleteOperationExecution
{
    public class DeleteOperationExecutionCommandHandler : ICommandHandler<DeleteOperationExecutionCommand>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOperationExecutionCommandHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork unitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteOperationExecutionCommand request, CancellationToken cancellationToken)
        {
            var OperationExecutionToDelete = _ExecutionRepository.GetExecutionById<OperationExecution>(request.Id);
            if (OperationExecutionToDelete == null)
                return Task.CompletedTask;
            _ExecutionRepository.DeleteExecution(OperationExecutionToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

