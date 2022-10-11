using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Entities;

namespace AguaNoSertao.Domain.Mappers
{
    public class DtoToModelMappingContatoForm : DtoToModelMapping
    {
        public DtoToModelMappingContatoForm()
        {
            CreateMap<ContatoFormDTO, ContatoForm>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
            .ForMember(dest => dest.Mensagem, opt => opt.MapFrom(x => x.Mensagem))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.Telefone, opt => opt.MapFrom(x => x.Telefone));
        }
    }
}
