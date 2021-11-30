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
using MailKit;
using Microsoft.Extensions.Configuration;
using Lollipop.Persistence.EmailSender;
using IMailService = Lollipop.Persistence.EmailSender.IMailService;

namespace Lollipop.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMailService _mailService;
        public AccountController(IConfiguration config, IMailService mailService){
            _config = config;
            _mailService = mailService;
        }
        //swagger doesn't like it to not have here http method
        //if we want the authorization works, we have to delte those
        [HttpGet]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        //swagger doesn't like it to not have here http method
        //if we wawnt to authorization work, we have to delete those
        [HttpPost]
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
            try
            {
                var mail = new EmailRequest();
                mail.toEmail = email;
                mail.Body = "Link for password reset: "+link;
                mail.Subject = "Password reset request";
                await _mailService.SendEmailAsync(mail);
                return Ok();
            }
            catch
            {
                throw;
            }

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
