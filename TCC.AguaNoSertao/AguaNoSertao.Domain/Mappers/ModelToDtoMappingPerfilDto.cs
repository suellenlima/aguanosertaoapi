using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Entities;

namespace AguaNoSertao.Domain.Mappers
{
    public class ModelToDtoMappingPerfilDto : DtoToModelMapping
    {
        public ModelToDtoMappingPerfilDto()
        {
            CreateMap<Usuario, PerfilDTO>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(x => x.DataNascimento))
            .ForPath(dest => dest.Logradouro, opt => opt.MapFrom(x => x.Endereco.Logradouro))
            .ForPath(dest => dest.Cep, opt => opt.MapFrom(x => x.Endereco.Cep))
            .ForPath(dest => dest.Estado, opt => opt.MapFrom(x => x.Endereco.Estado))
            .ForPath(dest => dest.Cidade, opt => opt.MapFrom(x => x.Endereco.Cidade));
        }
    }
}
