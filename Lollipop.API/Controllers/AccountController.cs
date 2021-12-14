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
using Microsoft.Extensions.Configuration;
using Lollipop.Persistence.EmailSender;
using Lollipop.Persistence.DbContext;
using Lollipop.Core.Models;
using Newtonsoft.Json;
using Lollipop.Persistence.TokenService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Security.Claims;

namespace Lollipop.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMailService _mailService;
        private readonly LollipopDbContext _dbContext;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(IConfiguration config,
            IMailService mailService,
            LollipopDbContext context,
            ITokenService tokenService,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager){
            _dbContext = context;
            _config = config;
            _mailService = mailService;
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
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
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //generate token from claims
            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

            var _accesstToken = _tokenService.GenerateAccessToken((IEnumerable<System.Security.Claims.Claim>)claims);
            var _refreshToken = _tokenService.GenerateRefreshToken();
            return Ok(new {
                accessToken = _accesstToken,
                refreshToken = _refreshToken
            });
        }

        [HttpPut]
        [Route("password-recovery")]
        public async Task<IActionResult> PasswordRecovery(string email){

            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return StatusCode(500, new
                {
                    code = "Wrong email",
                    message = "Given email doesn't exist in database"
                });
            }
            string secretToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string passRecFormURL = _config.GetValue<string>("FrontEndAddress:passRecForm");
            string link = passRecFormURL + "?secretToken="+secretToken;
            try
            {
                var mail = _mailService.GenerateRecoveryEmail(email, link);
                await _mailService.SendEmailAsync(mail);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new
                {
                    code = "ServerError",
                    message = "Sending email operation failed"
                });
            }

        }

        [HttpPut]
        public async Task<IActionResult> PasswordChange(string email,string secretToken, string password){

            var user = await  _userManager.FindByEmailAsync(email);
            if(user!= null)
            {
                    var result = await _userManager.ResetPasswordAsync(user, secretToken, password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user,isPersistent: true);
                        var claims = await _userManager.GetClaimsAsync(user);

                        var _accesstToken = _tokenService.GenerateAccessToken(claims);
                        var _refreshToken = _tokenService.GenerateRefreshToken();
                        return Ok(new
                        {
                            accessToken = _accesstToken,
                            refreshToken = _refreshToken
                        });
                    }
                    return StatusCode(500, new { 
                    code = "ServerError",
                    message = "Changing password operation failed"
                    });
            }
            return StatusCode(500, new
            {
                code = "WrongEmail",
                message = "Given email doesn't exist in database"
            });

        }

        [HttpPost]
        public async Task<IActionResult> New(string email, string password, string firstName, string lastName, string userName)
        {
            var user = new AppUser { Email = email, firstName = firstName, lastName = lastName,UserName = userName };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);

                var claims = await _userManager.GetClaimsAsync(user);

                var _accesstToken = _tokenService.GenerateAccessToken(claims);
                var _refreshToken = _tokenService.GenerateRefreshToken();
                return Ok(new
                {
                    accessToken = _accesstToken,
                    refreshToken = _refreshToken
                });
            }
            return StatusCode(500, result.Errors);
            
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string email,string password )
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user!= null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
                if (result.Succeeded)
                {
                    var claims = await _userManager.GetClaimsAsync(user);

                    var _accesstToken = _tokenService.GenerateAccessToken(claims);
                    var _refreshToken = _tokenService.GenerateRefreshToken();
                    return Ok(new
                    {
                        accessToken = _accesstToken,
                        refreshToken = _refreshToken
                    });
                }
                return StatusCode(500,new {
                code = "SignInFailed",
                message = "Wrong password"
                });
            }
            

            return StatusCode(500,new { 
            code = "SignInFailed",
            message = "Wrong email"
            });
        }
    }
}
