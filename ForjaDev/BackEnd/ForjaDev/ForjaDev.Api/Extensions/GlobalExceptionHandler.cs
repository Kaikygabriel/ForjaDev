using Microsoft.AspNetCore.Diagnostics;

namespace ForjaDev.Api.Extensions;

public static class GlobalExceptionHandler
{
    public static WebApplication UseGlobalExceptionHandler(this WebApplication app)
        => (WebApplication)app.UseExceptionHandler(x =>
        {
            x.Run(async x =>
            {
                x.Response.StatusCode = 500;
                x.Response.ContentType = "application/json";

                var error = x.Features.Get<IExceptionHandlerFeature>();

                if (error is not null)
                {
                    
                    await x.Response.WriteAsJsonAsync(new
                    {
                        Message = error.Error.Message,
                        StackTrace = error.Error.StackTrace,
                        StatusCode = 500
                    });
                }

            });
        });

}