using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Commands.CreatePhase
{
    public class CreatePhaseCommandHandler:
        ICommandHandler<CreatePhaseCommand, Phases>
    {
        private readonly IProcedureControlRepository _procedureControlRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePhaseCommandHandler(
            IProcedureControlRepository procedureControlRepository,
            IUnitOfWork unitOfWork)
        {
            _procedureControlRepository = procedureControlRepository;
            _unitOfWork = unitOfWork;

        }
        public Task<Phases> Handle(CreatePhaseCommand request, CancellationToken cancellationToken)
        {
            Phases result = new Phases(
                request.IC,
                request.name);
            _procedureControlRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
