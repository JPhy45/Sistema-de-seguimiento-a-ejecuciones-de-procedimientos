using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;

namespace Aplication.ProcedureControl.Commands.UnitProcedures.UpdateUnitProcedure
{
    public class UpdateUnitProcedureCommandHandler : ICommandHandler<UpdateUnitProcedureCommand>
    {
        private readonly IProcedureControlRepository _procedureControlRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnitProcedureCommandHandler(
            IProcedureControlRepository procedureControlRepository,
                        IUnitOfWork unitOfWork)
        {
            _procedureControlRepository = procedureControlRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle(UpdateUnitProcedureCommand request, CancellationToken cancellationToken)
        {
            _procedureControlRepository.Update(request.UnitProcedure);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
