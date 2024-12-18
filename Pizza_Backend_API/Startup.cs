using Microsoft.AspNetCore.Builder;
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
            
            services.AddSwaggerGen();
            
            // Konfiguracja Entity Framework Core
            services.AddDbContext<PizzeriaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            // CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

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
            services.AddScoped<ITekstyService, TekstyService>();
            services.AddScoped<IOpinieService, OpinieService>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                // Middleware Swaggera
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizzeria API v1");
                });
            }
            
            // Enable CORS
            app.UseCors("AllowAllOrigins");

            app.UseRouting();

            // Mapowanie endpointów
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}