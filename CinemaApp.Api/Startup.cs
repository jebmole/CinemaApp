using CinemaApp.Application;
using CinemaApp.Application.Interfaces;
using CinemaApp.Application.Services;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Infrastructure.Filters;
using CinemaApp.Infrastructure.IntegrationServices;
using CinemaApp.Infrastructure.Persistance;
using CinemaApp.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Api
{
    public class Startup
    {
        private readonly string cinemaUIPolicy = "UIPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    //Se registra el manejo de excepciones de forma global
                    options.Filters.Add<GlobalExceptionFilter>();
                })
                .AddFluentValidation(); //Se agrega Fluent Validation como validador

            //Se habilitan los CORS
            services.AddCors(options =>
            {
                options.AddPolicy(cinemaUIPolicy,
                    policy => policy.WithOrigins("*").AllowAnyMethod());

            });

            //Se registran las dependencias del proyecto Application
            services.AddApplicationServices();

            //Se enlaza la cadena de conexion con el BD Context
            services.AddDbContext<CinemaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Cinema")));

            //Registrar las dependencias de los repositorios
            services.AddTransient<ISalaRepository, SalaRepository>();

            //Registrar las dependencias de los servicios
            services.AddTransient<ISalaService, SalaService>();
            services.AddTransient<IPeliculaService, PeliculaService>();

            //Registrar las dependencias de las integraciones
            services.AddTransient<IPeliculaIntegracion, TmdbIntegrationService>();

            //Registrar la autenticación con JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                //Se definen los parametros de validación del token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://localhost:44357",
                    ValidAudience = "https://localhost:44357",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfawdfsdfqwerwefcwaefewtwassdas"))
                };
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Cinema API",
                    Description = "Estas son los endpoints disponibles para la API Cinema"
                });

                //Obtener de forma dinamica el nombre del archivo
                var nombreArchivo = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                //Creamos una variable con la ruta completa del archivo
                var xmlPath = Path.Combine(AppContext.BaseDirectory, nombreArchivo);

                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Se utiliza el CORS
            app.UseCors(cinemaUIPolicy);

            //Se registra la autenticación
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //Especificar la url en donde se encuentra el swagger de la API
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema API v1");
                
                //Especificar que swagger sea la pagina por defecto
                options.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
