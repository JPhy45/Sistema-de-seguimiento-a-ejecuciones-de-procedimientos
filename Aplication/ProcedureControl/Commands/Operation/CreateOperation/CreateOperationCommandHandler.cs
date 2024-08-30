using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplication.ProcedureControl.Commands.Operation.CreateOperation
{ 
 public class CreateOperationCommandHandler :
        ICommandHandler<CreateOperationCommand, Operations>
{
    private readonly IProcedureControlRepository _procedureControlRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOperationCommandHandler(
        IProcedureControlRepository procedureControlRepository,
        IUnitOfWork unitOfWork)
    {
        _procedureControlRepository = procedureControlRepository;
        _unitOfWork = unitOfWork;

    }
    public Task<Operations> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
    {
        Operations result = new Operations(
            request.IC,
            request.Name);
            _procedureControlRepository.Add(result);
            _unitOfWork.SaveChanges();

        return Task.FromResult(result);
    }
}
}

