using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Entities;
using AguaNoSertao.Domain.Helpers;
using AguaNoSertao.Domain.Interfaces.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AguaNoSertao.Domain.Services
{
    public class UsuarioService : BaseService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper, IHttpContextAccessor httpContextAcessor, IUsuarioRepository usuarioRepository) : base(mapper, httpContextAcessor)
        {
            _usuarioRepository = usuarioRepository;
        }

        public PerfilDTO ConsultarUsuario()
        {
            var usuario = _usuarioRepository.ConsultarUsuario(IdUsuario);

            var perfilDto = Mapper.Map<PerfilDTO>(usuario);

            return perfilDto;
        }

        public void UpdateUsuario(PerfilDTO perfilDTO)
        {
            if (!string.IsNullOrEmpty(perfilDTO.Email))
                if (!Util.ValidarEmail(perfilDTO.Email))
                    throw new ArgumentException("O e-mail informado não é valido.");

            var usuario = _usuarioRepository.ConsultarUsuario(IdUsuario);

            usuario.Nome = !string.IsNullOrEmpty(perfilDTO.Nome) ? perfilDTO.Nome : usuario.Nome;
            usuario.DataNascimento = perfilDTO.DataNascimento != null ? (DateTime)perfilDTO.DataNascimento : usuario.DataNascimento;
            usuario.Email = !string.IsNullOrEmpty(perfilDTO.Email) ? perfilDTO.Email : usuario.Email;
            usuario.Endereco.Logradouro = !string.IsNullOrEmpty(perfilDTO.Logradouro) ? perfilDTO.Logradouro : usuario.Endereco.Logradouro;
            usuario.Endereco.Cidade = !string.IsNullOrEmpty(perfilDTO.Cidade) ? perfilDTO.Cidade : usuario.Endereco.Cidade;
            usuario.Endereco.Cep = !string.IsNullOrEmpty(perfilDTO.Cep) ? Util.ExtrairNumeros(perfilDTO.Cep) : usuario.Endereco.Cep;
            usuario.Endereco.Estado = !string.IsNullOrEmpty(perfilDTO.Estado) ? perfilDTO.Estado : usuario.Endereco.Estado;

            _usuarioRepository.Update(usuario);
        }
    }
}
