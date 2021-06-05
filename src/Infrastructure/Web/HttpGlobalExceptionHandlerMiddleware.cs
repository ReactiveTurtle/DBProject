using Toolkit.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Infrastructure.Web
{
    public static class HttpGlobalExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseHttpGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.Clear();
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/problem+json";

                    var errorResponse = new ErrorResponse("Unhandled exception");

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    switch (contextFeature?.Error)
                    {
                        case ValidationException _:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            errorResponse = new ErrorResponse
                            {
                                Title = "Validation failed",
                                Details = contextFeature.Error.Message
                            };
                            break;
                        case DomainException _:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            errorResponse = new ErrorResponse
                            {
                                Title = "Domain exception",
                                Details = contextFeature.Error.Message
                            };
                            break;
                        case EntityNotFoundException _:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            errorResponse = new ErrorResponse
                            {
                                Title = "Entity not found exception",
                                Details = contextFeature.Error.Message
                            };
                            break;
                        default:
                            errorResponse.Details = contextFeature?.Error.Message;
                            break;
                    }

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
                });
            });
        }
    }
}