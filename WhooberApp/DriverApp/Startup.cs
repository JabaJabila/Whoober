using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;
using WhooberInfrastructure.Data.Seeding;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAbstractions;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAlgorithms;
using WhooberInfrastructure.Hubs;
using WhooberInfrastructure.Services;

namespace DriverApp
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
            services.AddScoped<IPassengerGenerator, SimplePassengerGenerator>();
            services.AddScoped<IDriverGenerator, SimpleDriverGenerator>();
            services.AddScoped<ICarGenerator, SimpleCarGenerator>();
            services.AddScoped<ICardGenerator, SimpleCardGenerator>();
            services.AddScoped<IDataSeeder, EmptySeeder>();
            
            string dbConnectionString = Configuration.GetConnectionString("Sqlite");
            services.AddDbContext<WhooberContext>(options =>
                options.UseSqlite(dbConnectionString));
            
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = new PathString("/Auth/Login");
                });
            services.AddAuthorization(options => { 
                options.AddPolicy("Authorized", policy => policy.RequireAuthenticatedUser());
            });
            services.AddControllersWithViews();
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<DriverNotificationHub>("/signalHub");
            });
        }
    }
}