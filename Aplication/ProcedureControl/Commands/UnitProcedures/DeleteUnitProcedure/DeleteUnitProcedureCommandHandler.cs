using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Commands.UnitProcedures.DeleteUnitProcedure
{
    public class DeleteUnitProcedureCommandHandler : ICommandHandler<DeleteUnitProcedureCommand>
    {
        private readonly IProcedureControlRepository _procedureControlRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnitProcedureCommandHandler(
            IProcedureControlRepository procedureControlRepository,
            IUnitOfWork unitOfWork)
        {
            _procedureControlRepository = procedureControlRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteUnitProcedureCommand request, CancellationToken cancellationToken)
        {
            var UnitProcedureToDelete = _procedureControlRepository.GetById<UnitProcedure>(request.Id);
            if (UnitProcedureToDelete == null)
                return Task.CompletedTask;
            _procedureControlRepository.Delete(UnitProcedureToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
