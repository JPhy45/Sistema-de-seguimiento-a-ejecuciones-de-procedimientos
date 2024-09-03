using AutoMapper;

namespace GrpcService.Mappers
{
    public class OperationExecutionProfile : Profile
    {
        public OperationExecutionProfile()
        {
            CreateMap<Domain.Domain.Utilities.OperationExecution, gProtos.OperationExecutionDTO>().
                ForMember(t => t.ID, o => o.MapFrom(s => s.Id.ToString())).
                ForMember(t => t.Operation, o => o.MapFrom(s => s.Operation)).
                ForMember(t => t.UpperCode, o => o.MapFrom(s => s.UpperCode)).
                ForMember(t => t.State, o => o.MapFrom(s => (gProtos.ExecutionState)s.State)).
                ForMember(t => t.StartTime, o => o.MapFrom(s => s.StartTime)).
                ForMember(t => t.EndTime, o => o.MapFrom(s => s.EndTime)).
                ForMember(t => t.OperationID, o => o.MapFrom(s => s.OperationId));

            CreateMap<gProtos.OperationExecutionDTO, Domain.Domain.Utilities.OperationExecution>().
                 ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.ID))).
                 ForMember(t => t.Operation, o => o.MapFrom(s => s.Operation)).
                 ForMember(t => t.UpperCode, o => o.MapFrom(s => s.UpperCode)).
                 ForMember(t => t.State, o => o.MapFrom(s => (Domain.Domain.Type.ExecutionState)s.State)).
                 ForMember(t => t.StartTime, o => o.MapFrom(s => s.StartTime)).
                 ForMember(t => t.EndTime, o => o.MapFrom(s => s.EndTime)).
                 ForMember(t => t.OperationId, o => o.MapFrom(s => s.OperationID));
        }


    }
}
