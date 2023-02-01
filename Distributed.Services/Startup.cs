using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Application.IoC;
using Application.MainModule.AutoMapper;
using Application.Security.JsonWebToken;
using Infrastructure.CrossCutting.JsonConverter;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.CrossCutting.Wrapper;
using Infrastructure.Data.MainModule.Context;
using Infrastructure.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Stimulsoft.Base;

namespace Distributed.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(opts =>
                opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddSignalR();
            services.AddAutoMapper(typeof(AutoMapperConfiguration).GetTypeInfo().Assembly);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddHttpContextAccessor();

            var jwtIssuerOptionsSection = Configuration.GetSection("JwtIssuerOptions");
            services.Configure<JwtIssuerOptions>(jwtIssuerOptionsSection);

            var emailSettingsSec = Configuration.GetSection("EmailSettings");
            services.Configure<EmailSettings>(emailSettingsSec);

            services.AddDependencyInjectionInterfaces();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtOptions = Configuration.GetSection("JwtIssuerOptions").Get<JwtIssuerOptions>();
                    options.ClaimsIssuer = jwtOptions.Issuer;
                    options.IncludeErrorDetails = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateActor = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = jwtOptions.SymmetricSecurityKey,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.SaveToken = true;

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                path.StartsWithSegments("/notification"))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddCors(options =>
            {
                var urlList = Configuration.GetSection("AllowedOrigin").GetChildren().ToArray()
                    .Select(c => c.Value?.TrimEnd('/'))
                    .ToArray();
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(urlList)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                options.JsonSerializerOptions.Converters.Add(new TrimStringConverter());
            });
            services.AddControllers()
                .AddNewtonsoftJson(
                    options =>
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                ).AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new DateTimeConverter()); });
            services.Configure<AzureADConfig>(Configuration.GetSection("AzureADConfig"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Gestión de Comité - Calidda", Version = "v1"});
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.
                        <br />Enter 'Bearer' [space] and then your token in the text input below.
                        <br />Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                if (File.Exists(xmlFile)) c.IncludeXmlComments(xmlFile);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //TODO: Quitar el comentario de esta parte cuando ya se pase a PRD
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "Distributed.Services v1"));
            //}
            EmailTemplates.Initialize(env);

            app.UseCors("CorsPolicy");

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            StiLicense.Key =
                "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHlbvjntpXcq87mXJnyue/5R+64darWzE1Ke8Qf3Pf1Ek1w/Gs" +
                "+RFnBR17LWsURw5DTBDC+XFN+iKgA7c7Xttwi1FP/YhwcudYC9epAVo4m7cDJ2ggBvTrI9RiM7hiyG+FJ2lOTse7lk" +
                "PNXId683xxaJXParjPPQYG+SJSxpd4gJHlXKUTW2jC4JCZBkCUluvxreyW2wAHehSSQK0XVgDCV3KJoRnIO99lmyki" +
                "8srhNd9sBQ89+ZavtRw05u05TjZUpkvS9n8KxenCrRhXWuRJ2ET/2Hut2xakCoI6uaqWGPo472EJrGa18iGkFUjyYh" +
                "I+0YrDv1xqDEnYF0vXQanZUNug7FMz4guKajTaDUXAxSu6s8+YG1nccCkw7/I5o0C/sQfw/RbM+VtHT7ZQWaWLweTX" +
                "ni/j4GCqgHxKYSXsa5qz1juWrASz0yRYNFcrM4XSearxlyalErjQAh7G6w0tRvQcQaDn8BWReNynzW+yKZHKpB7Ibq" +
                "bLeReIm0q7n4XlzKA+kvlq1afdPQwMpnueG4f8WQMH5x5SFIdn7ZWXVoLA==";
        }
    }
}