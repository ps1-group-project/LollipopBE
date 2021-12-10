using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.Web.Helpers;
using Microsoft.Extensions.Configuration;

namespace Lollipop.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AccountController(IConfiguration config){
            _config = config;
        }
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            string redirectURL = _config.GetValue<string>("FrontEndAddress:Main");
            return Redirect(redirectURL);
        }

        [HttpPut]
        [Route("password-recovery")]
        public async Task<IActionResult> PasswordRecovery(string email){
            //we have to generate secret token
            string secretToken = "superSecretTokenHardToBreak";

            //then send it to the user's email provider
            //link that will be like this:
            string passRecFormURL = _config.GetValue<string>("FrontEndAddress:passRecForm");
            string link = passRecFormURL + "?secretToken="+secretToken;

            return Ok();
        }

        [HttpPut]
        [Route("password-change")]
        public async Task<IActionResult> PasswordChange(string secretToken, string newPassword){

            //search database for the secretToken

            //if exists and it's connected to the specific user

            //set the new password for the user
            string redirectURL = _config.GetValue<string>("FrontEndAddress:Main");

            return Redirect(redirectURL);
        }

        [HttpPost]
        public async Task<OkResult> New(string email, string password, string firstName, string lastName)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<OkResult> SignIn(string email,string password )
        {
            return Ok();
        }
    }
}
