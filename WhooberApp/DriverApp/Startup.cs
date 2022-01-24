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
            
            string dbConnectionString = Configuration.GetConnectionString("MySql");
            services.AddDbContext<WhooberContext>(options => options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));
            
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            
            // services.AddSignalR().AddHubOptions<DriverNotificationHub>(options =>
            // {
            //     options.ClientTimeoutInterval = 
            // })

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = new PathString("/Auth/Login");
                });
            services.AddAuthorization(options => { 
                options.AddPolicy("Authorized", policy => policy.RequireAuthenticatedUser());
            });
            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                // endpoints.MapHub<DriverNotificationHub>("/driverNotification");
            });
        }
    }
}