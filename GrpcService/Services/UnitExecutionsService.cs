using gProtos;
using MediatR;
using AutoMapper;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Update.Internal;
using GrpcService.Mappers;
using Aplication.ProcedureControl.Commands.UnitProceduresExecution.CreateUnitProcedureExecution;
using Aplication.ProcedureControl.Queries.GetUnitExecutionById;
using Aplication.ProcedureControl.Queries.GetAllUnitExecution;
using Aplication.ProcedureControl.Commands.UnitProceduresExecution.UpdateUnitProcedureExecution;
using Aplication.ProcedureControl.Commands.UnitProceduresExecution.DeleteUnitProcedureExecution;

namespace GrpcService.Services
{
    public class UnitExecutionsService : UnitProcedureExecution.UnitProcedureExecutionBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UnitExecutionsService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<UnitProcedureExecutionDTO> CreateUnitProcedureExecution(CreateUnitProcedureExecutionRequest request, ServerCallContext context)
        {
            var command = new CreateUnitProcedureExecutionCommand(_mapper.Map<Domain.Domain.Entities.UnitProcedure>(request.UnitProcedure));
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<UnitProcedureExecutionDTO>(result));
        }
        public override Task<NullableUnitProcedureExecutionDTO> GetUnitProcedureExecution(GetRequest request, ServerCallContext context)
        {
            var query = new GetUnitExecutionByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;
            if (result is null)
                return Task.FromResult(new NullableUnitProcedureExecutionDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableUnitProcedureExecutionDTO() { UnitProcedureExecution = _mapper.Map<UnitProcedureExecutionDTO>(result) });
        }
        public override Task<UnitProcedureExecutions> GetAllUnitProcedureExecution(Empty request, ServerCallContext context)
        {
            var query = new GetAllUnitExecutionQuery();
            var result = _mediator.Send(query).Result;
            var UnitProcedureExecutionDTOs = new UnitProcedureExecutions();
            UnitProcedureExecutionDTOs.Items.AddRange(result.Select(m => _mapper.Map<UnitProcedureExecutionDTO>(m)));

            return Task.FromResult(UnitProcedureExecutionDTOs);
        }
        public override Task<Empty> UpdateUnitProcedureExecution(UnitProcedureExecutionDTO request, ServerCallContext context)
        {
            var command = new UpdateUnitExecutionCommand(_mapper.Map<Domain.Domain.Utilities.UnitExecution>(request));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteUnitProcedureExecution(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteUnitExecutionCommand(new Guid(request.Id));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

    }
}
