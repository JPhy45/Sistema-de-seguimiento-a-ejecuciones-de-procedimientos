using AutoMapper;

namespace GrpcService.Mappers
{
    public class UnitExecutionProfile : Profile
    {
        public UnitExecutionProfile()
        {
            CreateMap<Domain.Domain.Utilities.UnitExecution, gProtos.UnitProcedureExecutionDTO>().
                ForMember(t => t.ID, o => o.MapFrom(s => s.Id.ToString())).
                ForMember(t => t.UnitProcedure, o => o.MapFrom(s => s.Unit)).
                ForMember(t => t.State, o => o.MapFrom(s => (gProtos.ExecutionState)s.State)).
                ForMember(t => t.StartTime, o => o.MapFrom(s => s.StartTime)).
                ForMember(t => t.EndTime, o => o.MapFrom(s => s.EndTime != null ? s.EndTime : s.StartTime)).
                ForMember(t => t.UnitID, o => o.MapFrom(s => s.UnitId));

            CreateMap<gProtos.UnitProcedureExecutionDTO, Domain.Domain.Utilities.UnitExecution>().
                 ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.ID))).
                 ForMember(t => t.Unit, o => o.MapFrom(s => s.UnitProcedure)).
                 ForMember(t => t.State, o => o.MapFrom(s => (Domain.Domain.Type.ExecutionState)s.State)).
                 ForMember(t => t.StartTime, o => o.MapFrom(s => s.StartTime)).
                 ForMember(t => t.EndTime, o => o.MapFrom(s => s.EndTime != null ? s.EndTime : "null")).
                 ForMember(t => t.UnitId, o => o.MapFrom(s => s.UnitID));
        }


    }
}
