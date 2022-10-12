using Microsoft.OpenApi.Models;

namespace AguaNoSertao.API
{
    public static class SwaggerFactory
    {
        public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
        {
            return services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Agua no Sertão",
                    Description = "API responsável por fornecer os dados necessários para as aplicações de web site e mobile do projeto agua no sertão. </br></br> Caso possua duvidas ou deseje reportar um problema, entre em contato conosco."
                });
            });
        }
    }
}
