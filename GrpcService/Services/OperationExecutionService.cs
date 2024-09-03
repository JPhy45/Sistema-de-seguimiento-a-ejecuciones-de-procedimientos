using gProtos;
using MediatR;
using AutoMapper;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Aplication.ProcedureControl.Commands.CreatePhaseExecution;
using GrpcService.Mappers;
using Aplication.ProcedureControl.Commands.OperationsExecution.CreateOperationExecution;
using Aplication.ProcedureControl.Queries.GetOperationExecutionById;
using Aplication.ProcedureControl.Queries.GetAllOperationsExecutions;
using Aplication.ProcedureControl.Commands.OperationsExecution.UpdateOperationExecution;
using Aplication.ProcedureControl.Commands.OperationsExecution.DeleteOperationExecution;

namespace GrpcService.Services
{
    public class OperationExecutionsService : OperationExecution.OperationExecutionBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OperationExecutionsService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<OperationExecutionDTO> CreateOperationExecution(CreateOperationExecutionRequest request, ServerCallContext context)
        {
            var command = new CreateOperationExecutionCommand(_mapper.Map<Domain.Domain.Entities.Operations>(request.Operation));
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<OperationExecutionDTO>(result));
        }
        public override Task<NullableOperationExecutionDTO> GetOperationExecution(GetRequest request, ServerCallContext context)
        {
            var query = new GetOperationExecutionByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;
            if (result is null)
                return Task.FromResult(new NullableOperationExecutionDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableOperationExecutionDTO() { OperationExecution = _mapper.Map<OperationExecutionDTO>(result) });
        }
        public override Task<OperationExecutions> GetAllOperationExecution(Empty request, ServerCallContext context)
        {
            var query = new GetAllOperationsExecutionQuery();
            var result = _mediator.Send(query).Result;
            var OperationExecutionDTOs = new OperationExecutions();
            OperationExecutionDTOs.Items.AddRange(result.Select(m => _mapper.Map<OperationExecutionDTO>(m)));

            return Task.FromResult(OperationExecutionDTOs);
        }
        public override Task<Empty> UpdateOperationExecution(OperationExecutionDTO request, ServerCallContext context)
        {
            var command = new UpdateOperationExecutionCommand(_mapper.Map<Domain.Domain.Utilities.OperationExecution>(request));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteOperationExecution(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteOperationExecutionCommand(new Guid(request.Id));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

    }
}
