using AguaNoSertao.Domain.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;


namespace AguaNoSertao.Domain.Services
{
    public class BaseService
    {
        protected readonly IMapper Mapper;
        protected readonly IHttpContextAccessor? HttpContextAcessor;

        protected readonly int IdLogin;
        protected readonly int IdUsuario;

        public BaseService(IMapper mapper, IHttpContextAccessor httpContextAcessor)
        {
            Mapper = mapper;
            HttpContextAcessor = httpContextAcessor;
            IdLogin = HttpContextAcessor?.GetClaim<int>("id-login") ?? 0;
            IdUsuario = HttpContextAcessor?.GetClaim<int>("id-usuario") ?? 0;
        }
    }
}
