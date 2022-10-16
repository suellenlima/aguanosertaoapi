﻿using AguaNoSertao.Domain.DTO;
using AguaNoSertao.Domain.Services;

namespace AguaNoSertao.API
{
    public static class EndpointsMapper
    {
        public static WebApplication MapUserEndpoints(this WebApplication app)
        {
            app.MapPost("/login", (LoginService service, LoginDTO obj) => service.Logar(obj).CreateToken()).AllowAnonymous();
            app.MapPost("/login/cadastro", (LoginService service, LoginDTO obj) => service.CadastrarLogin(obj)).AllowAnonymous();
            app.MapPost("/login/alterarsenha", (LoginService service, AlterarSenha obj) => service.AlterarSenha(obj)).RequireAuthorization();

            app.MapPost("/contato/form", (ContatoService service, ContatoFormDTO obj) => service.CadastrarFormularioContato(obj)).RequireAuthorization();

            app.MapGet("/perfil", (UsuarioService service) => service.ConsultarUsuario()).RequireAuthorization();
            app.MapPut("/perfil", (UsuarioService service, PerfilDTO obj) => service.UpdateUsuario(obj)).RequireAuthorization();

            return app;
        }
    }
}
