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

namespace Aplication.ProcedureControl.Commands.PhasesExecution.DeletePhaseExecution 
{
    public class DeletePhaseExecutionCommandHandler : ICommandHandler<DeletePhaseExecutionCommand>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePhaseExecutionCommandHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork unitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeletePhaseExecutionCommand request, CancellationToken cancellationToken)
        {
            var PhaseExecutionToDelete = _ExecutionRepository.GetExecutionById<PhaseExecution>(request.Id);
            if (PhaseExecutionToDelete == null)
                return Task.CompletedTask;
            _ExecutionRepository.DeleteExecution(PhaseExecutionToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
