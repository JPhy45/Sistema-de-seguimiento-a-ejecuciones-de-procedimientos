using AutoMapper;

namespace GrpcService.Mappers
{
    public class PhaseProfile : Profile
    {
        public PhaseProfile()
        {
            CreateMap<Domain.Domain.Entities.Phases, gProtos.PhaseDTO>().
                ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString())).
                ForMember(t => t.Description, o => o.MapFrom(s => s.Description)).
                ForMember(t => t.IdentificationCode, o => o.MapFrom(s => s.IdentificationCode)).
                ForMember(t => t.Name, o => o.MapFrom(s => s.Name));

            CreateMap<gProtos.PhaseDTO, Domain.Domain.Entities.Phases>().
                 ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id))).
                 ForMember(t => t.Description, o => o.MapFrom(s => s.Description)).
                 ForMember(t => t.IdentificationCode, o => o.MapFrom(s => s.IdentificationCode)).
                 ForMember(t => t.Name, o => o.MapFrom(s => s.Name));
        }


    }
}
