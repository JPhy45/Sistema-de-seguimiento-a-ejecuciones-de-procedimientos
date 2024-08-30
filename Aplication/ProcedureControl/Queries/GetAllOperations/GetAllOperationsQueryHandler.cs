using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Queries.GetAllOperations
{
    public class GetAllOperationsQueryHandler
        : IQueryHandler<GetAllOperationsQuery, IEnumerable<Operations>>
    {
        private readonly IProcedureControlRepository _ProcedureControlRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public GetAllOperationsQueryHandler(
            IProcedureControlRepository ProcedureControlRepository,
            IUnitOfWork UnitOfWork)
        {
            _ProcedureControlRepository = ProcedureControlRepository;
            _UnitOfWork = UnitOfWork;
        }

        public Task<IEnumerable<Operations>> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ProcedureControlRepository.GetAll<Operations>());
        }
    }
}
