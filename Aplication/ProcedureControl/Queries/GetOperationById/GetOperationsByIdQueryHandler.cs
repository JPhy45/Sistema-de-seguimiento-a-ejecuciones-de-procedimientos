using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Queries.GetOperationById
{ 
    public class GetOperationByIdQueryHandler
        : IQueryHandler<GetOperationByIdQuery, Operations?>
    {
        private readonly IProcedureControlRepository _ProcedureControlRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public GetOperationByIdQueryHandler(
            IProcedureControlRepository ProcedureControlRepository,
            IUnitOfWork UnitOfWork)
        {
            _ProcedureControlRepository = ProcedureControlRepository;
            _UnitOfWork = UnitOfWork;
        }

        public Task<Operations?> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ProcedureControlRepository.GetById<Operations>(request.Id));
        }
    }
}

