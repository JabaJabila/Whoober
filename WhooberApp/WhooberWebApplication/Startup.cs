using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Whoober_WebApplication.Authentication;
using Whoober_WebApplication.Authentication.Services;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;
using WhooberInfrastructure.Data.Seeding;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAbstractions;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAlgorithms;
using WhooberInfrastructure.Services;
using AuthenticateService=Whoober_WebApplication.Authentication.Services.AuthenticateService;
using IAuthenticateService=Whoober_WebApplication.Authentication.Services.IAuthenticateService;

namespace Whoober_WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration
        {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Whoober.Server", Version = "v1" });
            });
            services.AddScoped<IPassengerGenerator, SimplePassengerGenerator>();
            services.AddScoped<IDriverGenerator, SimpleDriverGenerator>();
            services.AddScoped<ICarGenerator, SimpleCarGenerator>();
            services.AddScoped<ICardGenerator, SimpleCardGenerator>();
            services.AddScoped<IDataSeeder, SimpleDataSeeder>();

            services.AddDbContext<WhooberContext>(
            options => options.UseSqlite(Configuration.GetConnectionString("Sqlite")));
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Whoober.Server v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}