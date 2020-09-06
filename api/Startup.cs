using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using api.business;
using api.database;
using api.facade;
using api.interfaces;
using api.model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace api
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
            var builder = new MysqlConfiguration();
            Configuration.GetSection("database").Bind(builder);
            services.AddSingleton(builder);
            services.AddTransient<IUsuarios, UsuariosDatabase>();
            services.AddTransient<IJogos, JogosDatabase>();
            services.AddTransient<IJogadas, JogadasDatabase>();
            services.AddSingleton<UsuariosBusiness>();
            services.AddSingleton<UsuariosFacade>();
            services.AddSingleton<JogosBusiness>();
            services.AddSingleton<JogosFacade>();
            services.AddSingleton<JogadasBusiness>();
            services.AddSingleton<JogadaFacade>();

            services.AddCors(); // Make sure you call this previous to AddMvc
            services.AddControllers();
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
