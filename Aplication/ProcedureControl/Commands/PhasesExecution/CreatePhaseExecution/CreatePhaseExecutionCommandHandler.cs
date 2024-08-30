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


namespace Aplication.ProcedureControl.Commands.CreatePhaseExecution
{
    public class CreatePhaseExecutionCommandHandler :
        ICommandHandler<CreatePhaseExecutionCommand, PhaseExecution> 
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePhaseExecutionCommandHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork unitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _unitOfWork = unitOfWork;

        }
        public Task<PhaseExecution> Handle(CreatePhaseExecutionCommand request, CancellationToken cancellationToken)
        {
            PhaseExecution result = new PhaseExecution(
                request.Phase);
            _ExecutionRepository.AddExecution(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
