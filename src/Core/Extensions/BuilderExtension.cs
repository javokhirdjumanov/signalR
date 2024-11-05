using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Npgsql;
using System;
using System.Reflection;

namespace Core.Extensions;
public static class BuilderExtension
{
    public static WebApplicationBuilder ConfigureDefaults(this WebApplicationBuilder builder, string app = "Default")
    {
        builder.Configuration.AddJsonFile(Path.Join(AppContext.BaseDirectory, $"appsettings.json"), optional: false);

        builder.Configuration.AddEnvironmentVariables("APP");

        IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        builder.Services.AddSingleton(httpContextAccessor);

        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        builder.Logging.ClearProviders();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                 new OpenApiInfo()
                 {
                     Title = app,
                     Version = "v1"
                 });

            var xmlFile = $"{Assembly.GetEntryAssembly()!.GetName().Name}.xml";
            var xmlPath = Path.Join(AppContext.BaseDirectory, xmlFile);

            options.IncludeXmlComments(xmlPath);
        });

        builder.Services.AddHealthChecks();

        builder.Services.AddCors(options =>
             options.AddDefaultPolicy(policyBuilder =>
                  policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        builder.Services.AddHttpClient();
        builder.Services.AddMemoryCache();
        //builder.Services.AddScoped<GlobalExceptionHandlerMiddleware>();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return builder;
    }

    public static WebApplicationBuilder ConfiguredDbContext<TContext>(this WebApplicationBuilder builder, string connectionString)
        where TContext : DbContext
    {
        builder.Services.AddDbContextPool<TContext>(optionsBuilder =>
        {
            var dataSourceBuilder =
                new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString(connectionString))
                    .EnableDynamicJson();

            optionsBuilder
                .UseNpgsql(dataSourceBuilder.Build(), options => { });
        });

        return builder;
    }
}
