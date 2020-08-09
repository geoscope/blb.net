using System;
using System.Text;
using BLB.Api.Net.Hydrators;
using BLB.Api.Net.Interfaces;
using BLB.Api.Net.Middleware;
using BLB.Api.Net.Services;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Repositories;
using BLB.Shared.Net.Helpers;
using BLB.Shared.Net.Interfaces;
using BLB.Shared.Net.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace BLB.Api.Net
{
    public class Startup
    {
        private bool _isDevelopmentEnvironment = true;
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            app.UseMiddleware<StoreAuthorizationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/api/health");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Retrieve App Settings:
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            // Configure JWT:
            var key = Encoding.ASCII.GetBytes(appSettings.JwtSharedSecret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = !_isDevelopmentEnvironment;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = appSettings.JwtValidateIssuer,
                    ValidateAudience = appSettings.JwtValidateAudience,
                    ValidateLifetime = appSettings.JwtValidateLifetime,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddControllers();
            services.AddHealthChecks();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = appSettings.CacheHost;
                options.InstanceName = appSettings.CacheInstanceName;
            });

            services.AddSingleton<ISecurityHelper, SecurityHelper>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGenericHydrator<Domain.Net.Models.Category, Domain.Net.Models.Dto.Category>, CategoryDtoHydrator>();
        }
    }
}