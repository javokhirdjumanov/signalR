using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Domain.Middlewares;
public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            if (ex is ApiException apiException)
            {
                context.Response.StatusCode = apiException.StatusCode;
                //await context.Response.WriteAsJsonAsync<WrapperGeneric<object>>(WrapperGeneric<object>.ResultFromException(ex, (HttpStatusCode)apiException.StatusCode));
            }
            else
            {
                context.Response.StatusCode = 500;
                //await context.Response.WriteAsJsonAsync<WrapperGeneric<object>>(WrapperGeneric<object>.ResultFromException(ex));
            }
        }
    }
}
