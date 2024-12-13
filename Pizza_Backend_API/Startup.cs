﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzeriaAPI.Data;
using PizzeriaAPI.Services;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            // Konfiguracja Entity Framework Core
            services.AddDbContext<PizzeriaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Rejestracja usług
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IUżytkownicyService, UżytkownicyService>();
            services.AddScoped<IZamówieniaService, ZamówieniaService>();
            services.AddScoped<ITowaryService, TowaryService>();
            services.AddScoped<IMagazynService, MagazynService>();
            services.AddScoped<IFakturyService, FakturyService>();
            services.AddScoped<IPracownicyService, PracownicyService>();
            services.AddScoped<IPrzepisyKulinarneService, PrzepisyKulinarneService>();
            services.AddScoped<IDostawcyService, DostawcyService>();
            services.AddScoped<IZamówieniaFirmoweService, ZamówieniaFirmoweService>();
            services.AddScoped<IKontaktService, KontaktService>();

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Mapowanie endpointów
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}