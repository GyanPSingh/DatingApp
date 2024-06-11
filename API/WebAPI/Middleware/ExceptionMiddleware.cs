using System.Net;
using System.Text.Json;
using WebAPI.Errors;

namespace WebAPI.Middleware
{

    public class GlobalExceptionHandlingMiddleware : IMiddleware
  {
      // private readonly RequestDelegate _next;
      private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

      public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
      {
          //   _next = next;
          _logger = logger;
      }

      public async Task InvokeAsync(HttpContext context, RequestDelegate next)
      {
          try
          {
              await next(context);
          }
          catch (Exception ex)
          {
              _logger.LogError(ex, ex.Message);
              context.Response.ContentType = "application/json";
              context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

              var response = new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");

              //var response = _env.IsDevelopment()
              //? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
              //: new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");

              var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

              var json = JsonSerializer.Serialize(response, options);
              await context.Response.WriteAsync(json);

          }







          //public async Task InvokeAsync(HttpContext context, RequestDelegate next)
          //{
          //    try
          //    {
          //        await _next(context);
          //    }
          //    catch (Exception ex)
          //    {
          //        _logger.LogError(ex, ex.Message);
          //        context.Response.ContentType = "application/json";
          //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

          //        var response = _env.IsDevelopment()
          //        ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
          //        : new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");

          //        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

          //        var json = JsonSerializer.Serialize(response, options);
          //        await context.Response.WriteAsync(json);
          //    }
          //}

          // public async Task InvokeAync(HttpContext context)
          // {
          //     try
          //     {
          //         await _next(context);
          //     }
          //     catch (Exception ex)
          //     {
          //         _logger.LogError(ex, ex.Message);
          //         context.Response.ContentType = "application/json";
          //         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

          //         var response = _env.IsDevelopment()
          //         ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
          //         : new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");

          //         var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

          //         var json = JsonSerializer.Serialize(response, options);
          //         await context.Response.WriteAsync(json);
          //     }
          // }
      }
      // public static class RequestErrorMiddlewareExtensions
      // {
      //     public static IApplicationBuilder UseRequestException(
      //         this IApplicationBuilder builder)
      //     {
      //         return builder.UseMiddleware<ExceptionMiddleware>();
      //     }
      // }

  }
   
}
 