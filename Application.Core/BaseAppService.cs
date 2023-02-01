using Application.Security.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using Domain.MainModule.IUnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Application.Core
{
    public class BaseAppService
    {
        protected readonly IServiceProvider ServiceProvider;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly IConfiguration Configuration;
        public readonly AppUser CurrentUser;

        public BaseAppService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            UnitOfWork = serviceProvider.GetService<IUnitOfWork>();
            Mapper = serviceProvider.GetService<IMapper>();
            Configuration = serviceProvider.GetService<IConfiguration>();
            var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();

            CurrentUser = new AppUser(httpContextAccessor?.HttpContext?.User);
        }
    }
}