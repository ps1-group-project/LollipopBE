using Lollipop.Persistence.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lollipop.Persistence.DbContext;
using Lollipop.Core.Models;

namespace Lollipop.API.Controllers
{
    [Route("[controller]/[action]")]
    public class TokenController : ControllerBase
    {
        readonly LollipopDbContext userContext;
        readonly ITokenService tokenService;
        public TokenController(LollipopDbContext userContext, ITokenService tokenService)
        {
            this.userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        //for refreshing access tokens
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel is null)
            {
                return BadRequest("Invalid client request");
            }
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default

            var user = new AppUser();
            //at below code, we have to find user from our database
            //var user = userContext.LoginModels.SingleOrDefault(u => u.UserName == username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }
            var newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            userContext.SaveChanges();
            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }

        //it's for signing out, because to log out user have to be logged in
        [HttpPost, Authorize]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;

            var user = new AppUser();
            //var user = userContext.LoginModels.SingleOrDefault(u => u.UserName == username);
            if (user == null) return BadRequest();
            user.RefreshToken = null;
            userContext.SaveChanges();
            return NoContent();
        }
    }
}
