using gProtos;
using Aplication.ProcedureControl.Commands.CreatePhase;
using Aplication.ProcedureControl.Commands.DeletePhase;
using MediatR;
using AutoMapper;
using Grpc.Core;
using Aplication.ProcedureControl.Queries.GetPhaseById;
using Google.Protobuf.WellKnownTypes;
using Aplication.ProcedureControl.Queries.GetAllPhases;
using GrpcService.Mappers;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Aplication.ProcedureControl.Commands.UpdatePhase;

namespace GrpcService.Services
{
    public class PhasesService : Phase.PhaseBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PhasesService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<PhaseDTO> CreatePhase(CreatePhaseRequest request, ServerCallContext context)
        {
            var command = new CreatePhaseCommand(request.IdentificationCode, request.Name);
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<PhaseDTO>(result));
        }
        public override Task<NullablePhaseDTO> GetPhase(GetRequest request, ServerCallContext context)
        {
            var query = new GetPhaseByIdQuery(new Guid (request.Id));
            var result = _mediator.Send(query).Result;
            if (result is null)
                return Task.FromResult(new NullablePhaseDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullablePhaseDTO() {Phases = _mapper.Map<PhaseDTO>(result)});
        }
        public override Task<Phases> GetAllPhases(Empty request, ServerCallContext context)
        {
            var query = new GetAllPhasesQuery();
            var result = _mediator.Send(query).Result;
            var PhasesDTOs = new Phases();
            PhasesDTOs.Items.AddRange(result.Select(m => _mapper.Map<PhaseDTO> (m)));
            
            return Task.FromResult(PhasesDTOs);
        }
        public override Task<Empty> UpdatePhase(PhaseDTO request, ServerCallContext context)
        {
            var command = new UpdatePhaseCommand(_mapper.Map<Domain.Domain.Entities.Phases>(request));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeletePhase(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeletePhaseCommand(new Guid(request.Id));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

    }
}
