using Core.Interface;
using Core.Services;
using Infraestructure.Data;
using Infraestructure.Interfaces;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace LibreriaNexosAPI
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
            
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibreriaNexosAPI", Version = "v1" });
            });

            services.AddDbContext<BDLibreriaNexosContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEditorialesService, EditorialesService>();
            services.AddScoped<ILibrosService, LibrosService>();
            services.AddScoped<IAutoresService, AutoresService>();


            services.AddScoped<IEditorialesRepository, EditorialesRepository>();
            services.AddScoped<ILibrosRepository, LibrosRepository>();
            services.AddScoped<IAutoresRepository, AutoresRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibreriaNexosAPI v1"));
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
