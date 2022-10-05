﻿using AguaNoSertao.Domain.Interfaces.Repositorys;
using AguaNoSertao.Domain.Mappers;
using AguaNoSertao.Domain.Services;
using AguaNoSertao.Infra.Data;
using AguaNoSertao.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AguaNoSertao.Infra.Ioc.Depedencias
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStrings")));
            services.AddTransient<IRepositoryLogin, RepositoryLogin>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DtoToModelMapping));
            services.AddScoped<LoginService>();

            return services;
        }
    }
}
