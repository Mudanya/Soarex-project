using Contracts;
using Entities;
using Entities.Models;
using LoggerServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Services;
using System.Text;

namespace SoarexApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("SoarexApi")));
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApplicationUser>(opt =>
           {
               opt.Password.RequireNonAlphanumeric = true;
               opt.Password.RequiredLength = 8;
               opt.Password.RequireLowercase = true;
               opt.Password.RequireDigit = true;
               opt.Password.RequireUppercase = true;
               opt.User.RequireUniqueEmail = true;
           });
            builder = new IdentityBuilder(
                builder.UserType,
                typeof(IdentityRole),
                builder.Services);
            builder.AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositorymanager, Repositorymanager>();
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SoarexJwtKey");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
            AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }
        public static void ConfigureCors(this IServiceCollection services)
        => services.AddCors(
            options =>
                options.AddPolicy("CorsPolicy", builder =>
                    {
                        builder.WithOrigins("http://localhost:4200");
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    })
            );
        public static void ConfigureIISIntegration(this IServiceCollection service)
        => service.Configure<IISOptions>(options => { });

        public static void ConfigureLoggerService(this IServiceCollection services)
        => services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureBaseService(this IServiceCollection services)
        => services.AddScoped<BaseService>();
        public static void ConfigureUtilityService(this IServiceCollection services)
        => services.AddScoped<UtilityService>();
        public static void ConfigureTermService(this IServiceCollection services)
        => services.AddScoped<TermService>();
        public static void ConfigurePrivacyPolicyService(this IServiceCollection services)
        => services.AddScoped<PrivacyPolicyService>();
        public static void ConfigureEnquiryService(this IServiceCollection services)
        => services.AddScoped<EnquiryService>();
        public static void ConfigureCustomerFeedbackService(this IServiceCollection services)
        => services.AddScoped<CustomerFeedbackService>();
        public static void ConfigureContactService(this IServiceCollection services)
        => services.AddScoped<ContactService>();
        public static void ConfigureAboutUsService(this IServiceCollection services)
        => services.AddScoped<AboutUsService>();
        public static void ConfigureAuthenticationService(this IServiceCollection services)
        => services.AddScoped<IAuthenticationManager,AuthenticationManager>();

        public static void ConfigureGlobalService(this IServiceCollection services)
            => services.AddScoped<GlobalService>();
        public static void ConfigureKeyAreasService(this IServiceCollection services)
            => services.AddScoped<KeyAreasService>();
    }
}
