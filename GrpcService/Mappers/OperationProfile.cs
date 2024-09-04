using AutoMapper;

namespace GrpcService.Mappers
{
    public class OperationProfile : Profile
    {
        public OperationProfile()
        {
            CreateMap<Domain.Domain.Entities.Operations, gProtos.OperationDTO>().
                ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString())).
                ForMember(t => t.Description, o => o.MapFrom(s => s.Description != null ? s.Description : "Null")).
                ForMember(t => t.IdentificationCode, o => o.MapFrom(s => s.IdentificationCode)).
                ForMember(t => t.Name, o => o.MapFrom(s => s.Name)).
                ForMember(t => t.Phases, o => o.MapFrom(s => s.Phases));

            CreateMap<gProtos.OperationDTO, Domain.Domain.Entities.Operations>().
                 ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id))).
                 ForMember(t => t.Description, o => o.MapFrom(s => s.Description)).
                 ForMember(t => t.IdentificationCode, o => o.MapFrom(s => s.IdentificationCode)).
                 ForMember(t => t.Name, o => o.MapFrom(s => s.Name)).
                 ForMember(t => t.Phases, o => o.MapFrom(s => s.Phases));
        }


    }
}
