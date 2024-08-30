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

namespace Aplication.ProcedureControl.Commands.PhasesExecution.UpdatePhaseExecution
{
    public class UpdatePhaseExecutionCommandHandler : ICommandHandler<UpdatePhaseExecutionCommand>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePhaseExecutionCommandHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork unitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle(UpdatePhaseExecutionCommand request, CancellationToken cancellationToken)
        {
            _ExecutionRepository.UpdateExecution(request.PhaseExecution);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
