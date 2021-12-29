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
                context.HttpContext.Response.StatusCode = 500;

            }
            else if(context.Exception is Exception)
            {
                context.HttpContext.Response.StatusCode = 500;

            }

            context.Result = new JsonResult(context.Exception.Message);
            base.OnException(context);
        }
    }
}
