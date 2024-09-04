using AutoMapper;

namespace GrpcService.Mappers
{
    public class PhaseExecutionProfile : Profile
    {
        public PhaseExecutionProfile() 
        {
            CreateMap<Domain.Domain.Utilities.PhaseExecution, gProtos.PhaseExecutionDTO>().
                ForMember(t => t.ID, o => o.MapFrom(s => s.Id.ToString())).
                ForMember(t => t.Phases, o => o.MapFrom(s => s.Phase)).
                ForMember(t => t.UpperCode, o => o.MapFrom(s => s.UpperCode != null ? s.UpperCode : "Null")).
                ForMember(t => t.State, o => o.MapFrom(s => (gProtos.ExecutionState)s.State)).
                ForMember(t => t.StartTime, o => o.MapFrom(s => s.StartTime)).
                ForMember(t => t.EndTime, o => o.MapFrom(s => s.EndTime != null ? s.EndTime : s.StartTime)).
                ForMember(t => t.PhaseID, o => o.MapFrom(s => s.PhaseId));

            CreateMap<gProtos.PhaseExecutionDTO, Domain.Domain.Utilities.PhaseExecution>().
                 ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.ID))).
                 ForMember(t => t.Phase, o => o.MapFrom(s => s.Phases)).
                 ForMember(t => t.UpperCode, o => o.MapFrom(s => s.UpperCode != null ? s.UpperCode : "Null")).
                 ForMember(t => t.State, o => o.MapFrom(s => (Domain.Domain.Type.ExecutionState)s.State)).
                 ForMember(t => t.StartTime, o => o.MapFrom(s => s.StartTime)).
                 ForMember(t => t.EndTime, o => o.MapFrom(s => s.EndTime != null ? s.EndTime : "Null")).
                 ForMember(t => t.PhaseId, o => o.MapFrom(s => s.PhaseID));
        }

       
    }
}
