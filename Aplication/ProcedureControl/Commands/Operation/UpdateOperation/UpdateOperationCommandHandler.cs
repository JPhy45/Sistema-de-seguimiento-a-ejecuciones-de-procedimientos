using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;

namespace Aplication.ProcedureControl.Commands.Operation.UpdateOperation
{ 
    public class UpdateOperationCommandHandler : ICommandHandler<UpdateOperationCommand>
{
    private readonly IProcedureControlRepository _procedureControlRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOperationCommandHandler(
        IProcedureControlRepository procedureControlRepository,
                    IUnitOfWork unitOfWork)
        {
            _procedureControlRepository = procedureControlRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
        {
            _procedureControlRepository.Update(request.Operation);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

