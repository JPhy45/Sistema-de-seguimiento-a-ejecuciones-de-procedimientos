using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Queries.GetAllUnit
{
    public class GetAllUnitQueryHandler
        : IQueryHandler<GetAllUnitQuery, IEnumerable<UnitProcedure>>
    {
        private readonly IProcedureControlRepository _ProcedureControlRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public GetAllUnitQueryHandler(
            IProcedureControlRepository ProcedureControlRepository,
            IUnitOfWork UnitOfWork)
        {
            _ProcedureControlRepository = ProcedureControlRepository;
            _UnitOfWork = UnitOfWork;
        }

        public Task<IEnumerable<UnitProcedure>> Handle(GetAllUnitQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ProcedureControlRepository.GetAll<UnitProcedure>());
        }
    }
}