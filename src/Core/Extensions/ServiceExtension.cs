using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Core.Extensions;
public static class ServiceExtension
{
    public static WebApplication ConfigureDefaults(this WebApplication app, string? baseUrl = null)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

        app.UseHealthChecks("/healthy");
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}
