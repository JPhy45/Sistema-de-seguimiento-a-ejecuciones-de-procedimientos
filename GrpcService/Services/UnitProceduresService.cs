using gProtos;
using Aplication.ProcedureControl.Commands.CreatePhase;
using Aplication.ProcedureControl.Commands.DeletePhase;
using MediatR;
using AutoMapper;
using Grpc.Core;
using Aplication.ProcedureControl.Queries.GetPhaseById;
using Google.Protobuf.WellKnownTypes;
using Aplication.ProcedureControl.Queries.GetAllPhases;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Aplication.ProcedureControl.Commands.UpdatePhase;
using Aplication.ProcedureControl.Commands.UnitProcedures.CreateUnitProcedure;
using Aplication.ProcedureControl.Queries.GetAllUnit;
using Aplication.ProcedureControl.Queries.GetUnitById;
using Aplication.ProcedureControl.Commands.UnitProcedures.UpdateUnitProcedure;

namespace GrpcService.Services
{
    public class UnitProceduresService : UnitProcedure.UnitProcedureBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UnitProceduresService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<UnitProcedureDTO> CreateUnitProcedure(CreateUnitProcedureRequest request, ServerCallContext context)
        {
            var command = new CreateUnitProcedureCommand(request.IdentificationCode, request.Name);
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<UnitProcedureDTO>(result));
        }
        public override Task<NullableUnitProcedureDTO> GetUnitProcedure(GetRequest request, ServerCallContext context)
        {
            var query = new GetUnitByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;
            if (result is null)
                return Task.FromResult(new NullableUnitProcedureDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableUnitProcedureDTO() { UnitProcedure = _mapper.Map<UnitProcedureDTO>(result) });
        }
        public override Task<UnitProcedures> GetAllUnitProcedures(Empty request, ServerCallContext context)
        {
            var query = new GetAllUnitQuery();
            var result = _mediator.Send(query).Result;
            var UnitProcedureDTOs = new UnitProcedures();
            UnitProcedureDTOs.Items.AddRange(result.Select(m => _mapper.Map<UnitProcedureDTO>(m)));

            return Task.FromResult(UnitProcedureDTOs);
        }
        public override Task<Empty> UpdateUnitProcedure(UnitProcedureDTO request, ServerCallContext context)
        {
            var command = new UpdateUnitProcedureCommand(_mapper.Map<Domain.Domain.Entities.UnitProcedure>(request));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteUnitProcedure(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeletePhaseCommand(new Guid(request.Id));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

    }
}
