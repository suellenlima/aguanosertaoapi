using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Entities;
using AguaNoSertao.Domain.Helpers;
using AguaNoSertao.Domain.Interfaces.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaNoSertao.Domain.Services
{
    public class ContatoService : BaseService
    {
        private readonly IContatoFormRepository _contatoFormRepository;

        public ContatoService(IMapper mapper, IContatoFormRepository contatoFormRepository, IHttpContextAccessor httpContextAcessor) : base(mapper, httpContextAcessor)
        {
            _contatoFormRepository = contatoFormRepository;
        }

        public void CadastrarFormularioContato(ContatoFormDTO contato)
        {
            if (string.IsNullOrEmpty(contato.Nome))
                throw new ArgumentException("É necessário informar o nome.");

            if (string.IsNullOrEmpty(contato.Email))
                throw new ArgumentException("É necessário informar o e-mail.");

            if (!Util.ValidarEmail(contato.Email))
                throw new ArgumentException("O e-mail informado não é valido.");

            if (string.IsNullOrEmpty(contato.Mensagem))
                throw new ArgumentException("É necessário informar a mensagem.");

            var telefone = Util.ExtrairNumeros(contato.Telefone);

            contato.Telefone = telefone;

            if (string.IsNullOrEmpty(contato.Telefone))
                throw new ArgumentException("É necessário informar um telefone válido.");

            var contatoMapper = Mapper.Map<ContatoForm>(contato);

            _contatoFormRepository.Add(contatoMapper);
        }
    }
}
