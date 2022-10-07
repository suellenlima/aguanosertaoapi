using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Services;

namespace AguaNoSertao.API
{
    public static class EndpointsMapper
    {
        public static WebApplication MapUserEndpoints(this WebApplication app)
        {
            app.MapPost("/login", (LoginService service, LoginDTO obj) => service.Logar(obj).CreateToken()).AllowAnonymous();
            app.MapPost("/login/cadastro", (LoginService service, LoginDTO obj) => service.CadastrarLogin(obj)).AllowAnonymous();

            return app;
        }
    }
}
