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

namespace Aplication.ProcedureControl.Commands.UnitProceduresExecution.UpdateUnitProcedureExecution
{
    public class UpdateUnitExecutionCommandHandler : ICommandHandler<UpdateUnitExecutionCommand>
    {
        private readonly IExecutionRepository _ExecutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnitExecutionCommandHandler(
            IExecutionRepository ExecutionRepository,
            IUnitOfWork unitOfWork)
        {
            _ExecutionRepository = ExecutionRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle(UpdateUnitExecutionCommand request, CancellationToken cancellationToken)
        {
            _ExecutionRepository.UpdateExecution(request.UnitExecution);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}


