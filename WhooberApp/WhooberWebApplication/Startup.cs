using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Whoober_WebApplication.Authentication;
using Whoober_WebApplication.Authentication.Services;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;
using WhooberInfrastructure.Services;

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
            services.AddDbContext<WhooberContext>(
            options => options.UseSqlite(Configuration.GetConnectionString("Sqlite")));
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = new PathString("/Auth/Login");
                });
            services.AddAuthorization(options => {
                options.AddPolicy(
                Role.Client.Name,
                policy => {
                    policy.RequireClaim(Role.Client.Name);
                    policy.RequireAuthenticatedUser();
                });
                options.AddPolicy(
                Role.Driver.Name,
                policy => {
                    policy.RequireClaim(Role.Driver.Name);
                    policy.RequireAuthenticatedUser();
                });
            });

            // services.AddAuthentication(Role.Client.Name)
            //     .AddCookie(options =>
            //     {
            //         options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth/LoginClient");
            //     });
            // services.AddAuthentication(Role.Driver.Name)
            //     .AddCookie(options =>
            //     {
            //         options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth/LoginDriver");
            //     });
            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy("Passenger", policy => policy.RequireClaim(Role.Client.Name));
            //     options.AddPolicy("Driver", policy => {
            //         policy.
            //         policy.RequireClaim(Role.Driver.Name).AuthenticationSchemes = new List<string>();
            //     });
            // });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseAuthentication();// аутентификация
            app.UseAuthorization();// авторизация

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void AddAuthenticationScheme(IServiceCollection services, string name, string loginPath)
        {
            services.AddAuthentication(name)
                .AddCookie(options => {
                    options.LoginPath = new PathString(loginPath);
                });
            services.AddAuthorization(options => {
                options.AddPolicy(name,
                policy => {
                    policy.AuthenticationSchemes = new List<string> {name};
                    policy.RequireClaim(name);
                });
            });
        }
    }
}