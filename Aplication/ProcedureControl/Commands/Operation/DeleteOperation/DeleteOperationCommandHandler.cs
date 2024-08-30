using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Commands.Operation.DeleteOperation
{
    public class DeleteOperationCommandHandler : ICommandHandler<DeleteOperationCommand>
    {
        private readonly IProcedureControlRepository _procedureControlRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOperationCommandHandler(
            IProcedureControlRepository procedureControlRepository,
            IUnitOfWork unitOfWork)
        {
            _procedureControlRepository = procedureControlRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
        {
            var OperationToDelete = _procedureControlRepository.GetById<Operations>(request.Id);
            if (OperationToDelete == null)
                return Task.CompletedTask;
            _procedureControlRepository.Delete(OperationToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
