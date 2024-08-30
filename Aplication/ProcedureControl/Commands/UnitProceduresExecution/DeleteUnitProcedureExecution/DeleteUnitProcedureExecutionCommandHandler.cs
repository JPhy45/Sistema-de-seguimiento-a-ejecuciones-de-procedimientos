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

namespace Aplication.ProcedureControl.Commands.UnitProceduresExecution.DeleteUnitProcedureExecution
{
    public class DeleteUnitExecutionCommandHandler : ICommandHandler<DeleteUnitExecutionCommand>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnitExecutionCommandHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork unitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteUnitExecutionCommand request, CancellationToken cancellationToken)
        {
            var UnitExecutionToDelete = _ExecutionRepository.GetExecutionById<UnitExecution>(request.Id);
            if (UnitExecutionToDelete == null)
                return Task.CompletedTask;
            _ExecutionRepository.DeleteExecution(UnitExecutionToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

