using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Entities;
using AutoMapper;

namespace AguaNoSertao.Domain.Mappers
{
    public class DtoToModelMappingLogin : DtoToModelMapping
    {
        public DtoToModelMappingLogin()
        {
            CreateMap<LoginDTO, Login>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(x => x.Senha))
            .ForMember(dest => dest.IsDisponivel, opt => opt.Ignore());
        }
    }
}
