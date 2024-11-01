using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Extensions;
public static class BuilderExtension
{
    public static WebApplicationBuilder ConfigureDefaults(this WebApplicationBuilder builder, string appName = "DefaultAppName")
    {
        builder.ConfiguredDbContext();

        return builder;
    }

    private static WebApplicationBuilder ConfiguredDbContext(this WebApplicationBuilder builder)
    {
        

        return builder;
    }
}
