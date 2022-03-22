using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Lollipop.API.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Lollipop.Persistence.Exceptions;
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is UserNotFoundException)
            {
                context.HttpContext.Response.StatusCode = 500;
            }
            else if(context.Exception is WrongPasswordException)
            {

                // Set the status code
                context.HttpContext.Response.StatusCode = 500;

            }
            else if(context.Exception is Exception)
            {
                context.HttpContext.Response.StatusCode = 500;

            }

            
            // Serialize using the settings provided
            ReadOnlyMemory<byte> readOnlyMemory = new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(context.Exception.Message));
            

            // Set the content type
            context.HttpContext.Response.ContentType = "application/json; charset=utf-8";

            // Write the content
            context.HttpContext.Response.Body.WriteAsync(readOnlyMemory);
            context.HttpContext.Response.Body.FlushAsync();
            
            context.Result = new JsonResult(context.Exception.Message);
            base.OnException(context);
        }
    }
}
