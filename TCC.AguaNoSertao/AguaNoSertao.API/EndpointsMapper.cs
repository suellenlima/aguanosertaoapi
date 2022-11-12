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
            app.MapPost("/login/recuperar", (LoginService service, RecuperarSenha obj) => service.RecuperarSenha(obj)).AllowAnonymous();
            app.MapPost("/login/alterar", (LoginService service, AlterarSenha obj) => service.AlterarSenha(obj)).AllowAnonymous();
            app.MapPost("/login/alterar/verificacao", (LoginService service, AlterarSenhaComVerificacao obj) => service.AlterarSenhaComVerificacao(obj)).AllowAnonymous();

            app.MapPost("/contato/form", (ContatoService service, ContatoFormDTO obj) => service.CadastrarFormularioContato(obj)).RequireAuthorization();

            app.MapGet("/perfil", (UsuarioService service) => service.ConsultarUsuario()).RequireAuthorization();
            app.MapPut("/perfil", (UsuarioService service, PerfilDTO obj) => service.UpdateUsuario(obj)).RequireAuthorization();

            return app;
        }
    }
}
