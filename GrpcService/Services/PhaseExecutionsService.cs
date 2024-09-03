using gProtos;
using MediatR;
using AutoMapper;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Aplication.ProcedureControl.Commands.CreatePhaseExecution;
using GrpcService.Mappers;
using Aplication.ProcedureControl.Queries.GetPhaseExecutionById;
using Aplication.ProcedureControl.Queries.GetAllPhaseExecution;
using Aplication.ProcedureControl.Commands.PhasesExecution.UpdatePhaseExecution;
using Aplication.ProcedureControl.Commands.PhasesExecution.DeletePhaseExecution;

namespace GrpcService.Services
{
    public class PhaseExecutionsService : PhaseExecution.PhaseExecutionBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PhaseExecutionsService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<PhaseExecutionDTO> CreatePhaseExecution(CreatePhaseExecutionRequest request, ServerCallContext context)
        {
            var command = new CreatePhaseExecutionCommand(_mapper.Map<Domain.Domain.Entities.Phases>(request.Phase));
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<PhaseExecutionDTO>(result));
        }
        public override Task<NullablePhaseExecutionDTO> GetPhaseExecution(GetRequest request, ServerCallContext context)
        {
            var query = new GetPhaseExecutionByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;
            if (result is null)
                return Task.FromResult(new NullablePhaseExecutionDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullablePhaseExecutionDTO() { PhaseExecution = _mapper.Map<PhaseExecutionDTO>(result) });
        }
        public override Task<PhaseExecutions> GetAllPhaseExecution(Empty request, ServerCallContext context)
        {
            var query = new GetAllPhasesExecutionQuery();
            var result = _mediator.Send(query).Result;
            var PhaseExecutionDTOs = new PhaseExecutions();
            PhaseExecutionDTOs.Items.AddRange(result.Select(m => _mapper.Map<PhaseExecutionDTO>(m)));

            return Task.FromResult(PhaseExecutionDTOs);
        }
        public override Task<Empty> UpdatePhaseExecution(PhaseExecutionDTO request, ServerCallContext context)
        {
            var command = new UpdatePhaseExecutionCommand(_mapper.Map<Domain.Domain.Utilities.PhaseExecution>(request));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeletePhaseExecution(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeletePhaseExecutionCommand(new Guid(request.Id));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

    }
}
