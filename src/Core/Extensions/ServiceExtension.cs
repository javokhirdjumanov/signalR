using Domain.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions;
public static class ServiceExtension
{
    public static WebApplication ConfigureDefaults(this WebApplication app, string? baseUrl = null)
    {
        app.UseCors();

        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

        app.UseHealthChecks("/healthy");
        app.UseAuthorization();

        return app;
    }
}
