using Lollipop.Persistence.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lollipop.Persistence.DbContext;
using Lollipop.Core.Models;
using Lollipop.API.Filters;

namespace Lollipop.API.Controllers
{
    [CORSActionFilter]
    [Route("[controller]/[action]")]
    public class TokenController : ControllerBase
    {
        readonly LollipopDbContext dbContext;
        readonly ITokenService tokenService;
        public TokenController(LollipopDbContext dbContext, ITokenService tokenService)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        //for refreshing access tokens
        [HttpPost]
        public IActionResult Refresh(TokenApi tokens)
        {
            if (tokens is null)
            {
                return BadRequest("Invalid client request");
            }
            string accessToken = tokens.AccessToken;
            string refreshToken = tokens.RefreshToken;
            var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default


            var user = dbContext.Users.SingleOrDefault(u => u.UserName == username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }
            var newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            dbContext.SaveChanges();
            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }

        //it's for signing out, because to log out user have to be logged in
        [HttpPost, Authorize]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;

            var user = dbContext.Users.SingleOrDefault(u => u.UserName == username);
            if (user == null) return BadRequest();
            user.RefreshToken = null;
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
