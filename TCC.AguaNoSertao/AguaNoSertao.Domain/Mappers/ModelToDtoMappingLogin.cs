using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Entities;

namespace AguaNoSertao.Domain.Mappers
{
    public class ModelToDtoMappingLogin : DtoToModelMapping
    {
        public ModelToDtoMappingLogin()
        {
            CreateMap<Login, LoginDTO>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(x => x.Senha));
        }
    }
}
