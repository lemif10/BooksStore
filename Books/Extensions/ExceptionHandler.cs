﻿using System.Net;
using Books.Common.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace Books.Extensions;

public static class ExceptionHandler
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "*");

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                    await context.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        Error = "Internal Server Error.",
                        Message = $"{contextFeature.Error.Message}"
                    }.ToString());
            });
        });
    }
}
