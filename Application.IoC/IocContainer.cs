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
            services.AddScoped<ISoccerCategoryAppService, SoccerCategoryAppService>();
            services.AddScoped<ILigueAppService, LigueAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ISportsAppService, SportsAppService>();
            services.AddScoped<ISportHitsAppService, SportHitsAppService>();
            services.AddScoped<ISportHitsDetailAppService, SportHitsDetailAppService>();
        }

        private static void AddDependencyInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMaestroRepository, MaestroRepository>();
            services.AddScoped<IMaestroDetalleRepository, MaestroDetalleRepository>();
            services.AddScoped<ICategoriaFutbolRepository, CategoriaFutbolRepository>();
            services.AddScoped<IDeporteResultadosRepository, DeporteResultadosRepository>();
            services.AddScoped<IDeportesRepository, DeportesRepository>();
            services.AddScoped<IFutbolSubCagoriaRepository, FutbolSubCagoriaRepository>();
            services.AddScoped<ILigasRepository, LigasRepository>();
            services.AddScoped<IMembresiaRepository, MembresiaRepository>();
            services.AddScoped<IPagoComprasRepository, PagoComprasRepository>();
            services.AddScoped<IPagosIzipayRepository, PagosIzipayRepository>();
            services.AddScoped<IPuntosPaqueteRepository, PuntosPaqueteRepository>();
            services.AddScoped<IPremiosRepository, PremiosRepository>();
            services.AddScoped<IPremiosAuditoriaRepository, PremiosAuditoriaRepository>();
            services.AddScoped<IUsuarioPuntoRepository, UsuarioPuntoRepository>();
            services.AddScoped<IConfiguracionCorreoRepository, ConfiguracionCorreoRepository>();
            services.AddScoped<IAciertosRepository, AciertosRepository>();
            services.AddScoped<IDetalleAciertosRepository, DetalleAciertosRepository>();

        }
    }
}