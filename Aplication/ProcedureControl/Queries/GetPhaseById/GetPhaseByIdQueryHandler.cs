using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Queries.GetPhaseById
{
    public class GetPhaseByIdQueryHandler
        : IQueryHandler<GetPhaseByIdQuery, Phases?>
    {
        private readonly IProcedureControlRepository _ProcedureControlRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public GetPhaseByIdQueryHandler(
            IProcedureControlRepository ProcedureControlRepository,
            IUnitOfWork UnitOfWork)
        {
            _ProcedureControlRepository = ProcedureControlRepository;
            _UnitOfWork = UnitOfWork;
        }

        public Task<Phases?> Handle(GetPhaseByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ProcedureControlRepository.GetById<Phases>(request.Id));
        }
    }
}