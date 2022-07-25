using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.FileProviders;
using NLog;
using SoarexApi.AutoMapper;
using SoarexApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.ConfigureCors();
    builder.Services.ConfigureIISIntegration();
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAutoMapper(typeof(MappingProfile));
    builder.Services.ConfigureSqlContext(builder.Configuration);
    builder.Services.AddAuthentication();
    builder.Services.ConfigureIdentity();
    builder.Services.ConfigureJWT(builder.Configuration);
    builder.Services.ConfigureRepositoryManager();
    builder.Services.ConfigureLoggerService();
    builder.Services.ConfigureBaseService();
    builder.Services.ConfigureTermService();
    builder.Services.ConfigureUtilityService();
    builder.Services.ConfigurePrivacyPolicyService();
    builder.Services.ConfigureEnquiryService();
    builder.Services.ConfigureCustomerFeedbackService();
    builder.Services.ConfigureContactService();
    builder.Services.ConfigureAboutUsService();
    builder.Services.ConfigureAuthenticationService();
    builder.Services.ConfigureGlobalService();
}

var app = builder.Build();
{
    //nlog config
    LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
    using var scope = app.Services.CreateScope();
    var logger = scope.ServiceProvider.GetService<ILoggerManager>();
    app.ConfigureExceptionHandler(logger);

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
        RequestPath = new PathString("/Resources")
    });
    app.UseCors("CorsPolicy");
    app.UseForwardedHeaders(
        new ForwardedHeadersOptions 
        { ForwardedHeaders = ForwardedHeaders.All }
        );
    app.UseRouting();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
