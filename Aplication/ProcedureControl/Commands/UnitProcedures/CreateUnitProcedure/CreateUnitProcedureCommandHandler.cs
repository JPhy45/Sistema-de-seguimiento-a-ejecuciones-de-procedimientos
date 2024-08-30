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

namespace Aplication.ProcedureControl.Commands.UnitProcedures.CreateUnitProcedure
{
    public class CreateUnitProcedureCommandHandler :
           ICommandHandler<CreateUnitProcedureCommand, UnitProcedure>
    {
        private readonly IProcedureControlRepository _procedureControlRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitProcedureCommandHandler(
            IProcedureControlRepository procedureControlRepository,
            IUnitOfWork unitOfWork)
        {
            _procedureControlRepository = procedureControlRepository;
            _unitOfWork = unitOfWork;

        }
        public Task<UnitProcedure> Handle(CreateUnitProcedureCommand request, CancellationToken cancellationToken)
        {
            UnitProcedure result = new UnitProcedure(
                request.IC,
                request.Name);
            _procedureControlRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}