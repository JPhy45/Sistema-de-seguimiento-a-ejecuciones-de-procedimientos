using AutoMapper;

namespace GrpcService.Mappers
{
    public class UnitProcedureProfile : Profile
    {
        public UnitProcedureProfile()
        {
            CreateMap<Domain.Domain.Entities.UnitProcedure, gProtos.UnitProcedureDTO>().
                ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString())).
                ForMember(t => t.Description, o => o.MapFrom(s => s.Description != null ? s.Description : "Null")).
                ForMember(t => t.IdentificationCode, o => o.MapFrom(s => s.IdentificationCode)).
                ForMember(t => t.Name, o => o.MapFrom(s => s.Name)).
                ForMember(t => t.Operations, o => o.MapFrom(s => s.Operations));

            CreateMap<gProtos.UnitProcedureDTO, Domain.Domain.Entities.UnitProcedure>().
                 ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id))).
                 ForMember(t => t.Description, o => o.MapFrom(s => s.Description)).
                 ForMember(t => t.IdentificationCode, o => o.MapFrom(s => s.IdentificationCode)).
                 ForMember(t => t.Name, o => o.MapFrom(s => s.Name)).
                 ForMember(t => t.Operations, o => o.MapFrom(s => s.Operations));
        }


    }
}
