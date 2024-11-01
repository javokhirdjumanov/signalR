using Microsoft.AspNetCore.Builder;

namespace Core.Extensions;
public static class ServiceExtension
{
    public static WebApplication ConfigureDefaults(this WebApplication app, string? baseUrl = null)
    {
        Log.Information("Started at: {0}. PID: {1}", DateTime.Now, Environment.ProcessId);

/*#if !DEBUG
        app.UseDefaultSwagger($"/gateway{baseUrl}");
#else
        app.UseDefaultSwagger(baseUrl);
#endif
        app.UseCors();*/

        //app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

        app.UseHealthChecks("/healthy");
        app.UseAuthorization();

        return app;
    }
}
