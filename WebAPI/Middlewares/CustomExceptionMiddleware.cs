using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Services;

namespace WebAPI.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILoggerService _loggerService;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);
                //System.Diagnostics.Debug.WriteLine(message);
                //Console.WriteLine(message);

                await _next(context);
                //throw new NotImplementedException();
                watch.Stop();

                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path
                    + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms ";
                _loggerService.Write(message);
                //System.Diagnostics.Debug.WriteLine(message);

            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("test error");


                watch.Stop();
                await HandleException(context, e, watch);








            }



        }


        private Task HandleException(HttpContext context, Exception e, Stopwatch watch)
        {
            //throw new NotImplementedException();
            string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode
                + "Error message : " + e.Message + " in " + watch.Elapsed.TotalMilliseconds;
            System.Diagnostics.Debug.WriteLine(message);


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new { error = e.Message }, Formatting.None);

            return context.Response.WriteAsync(result);


        }

    }


    public static class CustomExceptionMiddleWareExtension
    {

        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }


    }




}
