using gProtos;
using MediatR;
using AutoMapper;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Aplication.ProcedureControl.Commands.Operation.CreateOperation;
using Aplication.ProcedureControl.Queries.GetOperationById;
using Aplication.ProcedureControl.Queries.GetAllOperations;
using System.CodeDom;
using Aplication.ProcedureControl.Commands.Operation.UpdateOperation;
using Aplication.ProcedureControl.Commands.Operation.DeleteOperation;

namespace GrpcService.Services
{
    public class OperationsService : Operation.OperationBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OperationsService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<OperationDTO> CreateOperation(CreateOperationRequest request, ServerCallContext context)
        {
            var command = new CreateOperationCommand(request.IdentificationCode, request.Name);
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<OperationDTO>(result));
        }
        public override Task<NullableOperationDTO> GetOperation(GetRequest request, ServerCallContext context)
        {
            var query = new GetOperationByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;
            if (result is null)
                return Task.FromResult(new NullableOperationDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableOperationDTO() { Operations = _mapper.Map<OperationDTO>(result) });
        }
        public override Task<Operations> GetAllOperations(Empty request, ServerCallContext context)
        {
            var query = new GetAllOperationsQuery();
            var result = _mediator.Send(query).Result;
            var OperationDTOs = new Operations();
            OperationDTOs.Items.AddRange(result.Select(m => _mapper.Map<OperationDTO>(m)));

            return Task.FromResult(OperationDTOs);
        }
        public override Task<Empty> UpdateOperations(OperationDTO request, ServerCallContext context)
        {
            var command = new UpdateOperationCommand(_mapper.Map<Domain.Domain.Entities.Operations>(request));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteOperation(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteOperationCommand(new Guid(request.Id));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

    }
}
