using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Lollipop.API.Filters
{
    public class CORSActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "https://projektz-46d76.web.app, http://localhost:3000, https://lollipop-fe-main.herokuapp.com");
                filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, PATCH");
                filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "X-Requested-With, Accept, Access-Control-Allow-Origin, Content-Type,Access-Control-Allow-Headers, Authorization");
                filterContext.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Set-Cookie");
                filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            //filterContext.HttpContext.SignInAsync()

            base.OnActionExecuting(filterContext);
        }
    }
}
