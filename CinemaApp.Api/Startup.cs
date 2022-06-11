using CinemaApp.Application;
using CinemaApp.Application.Interfaces;
using CinemaApp.Application.Services;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Infrastructure.Filters;
using CinemaApp.Infrastructure.IntegrationServices;
using CinemaApp.Infrastructure.Persistance;
using CinemaApp.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Api
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
            services
                .AddControllers(options =>
                {
                    //Se registra el manejo de excepciones de forma global
                    options.Filters.Add<GlobalExceptionFilter>();
                })
                .AddFluentValidation(); //Se agrega Fluent Validation como validador

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
