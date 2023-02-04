using Application.MainModule;
using Application.MainModule.Interface;
using Application.Security.IJsonWebToken;
using Application.Security.JsonWebToken;
using Domain.MainModule.IRepository;
using Domain.MainModule.IUnitOfWork;
using Infrastructure.Data.MainModule.Repository;
using Infrastructure.Data.MainModule.UnitOfWork;
using Infrastructure.Email;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC
{
    public static class IocContainer
    {
        public static IServiceCollection AddDependencyInjectionInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtFactory, JwtFactory>();
            services.AddScoped<IEmailHelper, EmailHelper>();

            services.AddDependencyInjectionAppService();
            services.AddDependencyInjectionRepository();

            return services;
        }

        private static void AddDependencyInjectionAppService(this IServiceCollection services)
        {
            services.AddScoped<ISecurityAppService, SecurityAppService>();
            services.AddScoped<ILogSessionUserRepository, LogSessionUserRepository>();
            services.AddScoped<IMasterDetailAppService, MasterDetailAppService>();
       
            services.AddScoped<IUserAppService, UserAppService>();
        }

        private static void AddDependencyInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMaestroRepository, MaestroRepository>();
            services.AddScoped<IMaestroDetalleRepository, MaestroDetalleRepository>();
            services.AddScoped<IPagoComprasRepository, PagoComprasRepository>();
            services.AddScoped<IPagosIzipayRepository, PagosIzipayRepository>();
            services.AddScoped<IConfiguracionCorreoRepository, ConfiguracionCorreoRepository>();

        }
    }
}