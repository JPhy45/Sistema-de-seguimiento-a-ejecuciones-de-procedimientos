using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;


namespace Aplication.ProcedureControl.Commands.UpdatePhase
{
    public class UpdatePhaseCommandHandler :ICommandHandler<UpdatePhaseCommand>
    {
        private readonly IProcedureControlRepository _procedureControlRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePhaseCommandHandler(
            IProcedureControlRepository procedureControlRepository,
            IUnitOfWork unitOfWork)
        {
            _procedureControlRepository = procedureControlRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle (UpdatePhaseCommand request, CancellationToken cancellationToken)
        {
            _procedureControlRepository.Update(request.Phase);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
