using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Commands.DeletePhase
{
    public class DeletePhaseCommandHandler: ICommandHandler<DeletePhaseCommand>
    {
        private readonly IProcedureControlRepository _procedureControlRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePhaseCommandHandler(
            IProcedureControlRepository procedureControlRepository,
            IUnitOfWork unitOfWork)
        {
            _procedureControlRepository = procedureControlRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeletePhaseCommand request, CancellationToken cancellationToken)
        {
            var PhaseToDelete = _procedureControlRepository.GetById<Phases>(request.Id);
            if (PhaseToDelete == null)
                return Task.CompletedTask;
            _procedureControlRepository.Delete(PhaseToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
