using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Entities;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AguaNoSertao.Domain.Services
{
    public class LoginService
    {
        private readonly IMapper mapper;

        public LoginService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public string ObterToken(LoginDTO login, string key)
        {
            if (login == null)
                throw new ArgumentNullException("É necessário informar email e senha.");

            if (string.IsNullOrEmpty(login.Email))
                throw new ArgumentException("É necessário informar o email.");

            if (string.IsNullOrEmpty(login.Senha))
                throw new ArgumentException("É necessário informar a senha.");

            var loginMapper = mapper.Map<Login>(login);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha512Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
