using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Queries.GetAllPhases
{
    public class GetAllPhasesQueryHandler
        : IQueryHandler<GetAllPhasesQuery, IEnumerable<Phases>>
    {
        private readonly IProcedureControlRepository _ProcedureControlRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public GetAllPhasesQueryHandler(
            IProcedureControlRepository ProcedureControlRepository,
            IUnitOfWork UnitOfWork)
        {
            _ProcedureControlRepository = ProcedureControlRepository;
            _UnitOfWork = UnitOfWork;
        }

        public Task<IEnumerable<Phases>> Handle(GetAllPhasesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ProcedureControlRepository.GetAll<Phases>());
        }
    }
}
