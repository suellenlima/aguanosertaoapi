using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Entities;
using AguaNoSertao.Domain.Helpers;
using AguaNoSertao.Domain.Interfaces.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AguaNoSertao.Domain.Services
{
    public class LoginService : BaseService
    {
        private readonly ILoginRepository _repositoryLogin;

        public LoginService(ILoginRepository repositoryLogin, IMapper mapper, IHttpContextAccessor httpContextAcessor) : base (mapper, httpContextAcessor)
        {
            _repositoryLogin = repositoryLogin;
        }

        public void CadastrarLogin(LoginDTO login)
        {
            if (string.IsNullOrEmpty(login.Nome))
                throw new ArgumentException("É necessário informar um nome");

            if (string.IsNullOrEmpty(login.Email))
                throw new ArgumentException("É necessário informar o e-mail.");

            if (!Util.ValidarEmail(login.Email))
                throw new ArgumentException("O e-mail informado não é valido.");

            if (string.IsNullOrEmpty(login.Senha))
                throw new ArgumentException("É necessário informar a senha.");

            if (login.Senha.Length < 6)
                throw new ArgumentException("A senha deve ter no mínimo 6 caracteres.");

            var loginMapper = Mapper.Map<Login>(login);

            var buscaLogin = _repositoryLogin.ConsultarEmailLogin(loginMapper.Email);

            if (buscaLogin != null)
                throw new ArgumentException("Este usuário, já está cadastrado no sistema. Solicite a recuperação de senha.");

            Login novoLogin = new()
            {
                Email = login.Email,
                Senha = login.Senha,
                IsDisponivel = true, //TODO ENQUANTO NÃO FOI DESENVOLVIDO A INTEGRATION, O USUARIO ESTA ATIVO AUTOMATICAMENTE.
                DataCadastro = DateTime.Now,
                Usuario = new Usuario
                {
                    Nome = login.Nome,
                    Email = login.Email
                }
            };

            _repositoryLogin.Add(novoLogin);

        }

        public UsuarioIds Logar(LoginDTO login)
        {
            if (string.IsNullOrEmpty(login.Email))
                throw new ArgumentException("É necessário informar o e-mail.");

            if (string.IsNullOrEmpty(login.Senha))
                throw new ArgumentException("É necessário informar a senha.");

            var loginMapper = Mapper.Map<Login>(login);

            var buscaLogin = _repositoryLogin.ConsultarLogin(loginMapper.Email, loginMapper.Senha);

            if (buscaLogin == null)
                throw new ArgumentException("O usuário/senha inválido.");

            if (!buscaLogin.IsDisponivel)
                throw new ArgumentException("O usuário não está ativado. Por favor, ative o usuário no link informado no e-mail, ou solicite o reenvio da ativação.");

            UsuarioIds usuarioIds = new()
            {
                IdLogin = buscaLogin.Id,
                IdUsuario = buscaLogin.Usuario.Id
            };

            return usuarioIds;
        }
    }
}
