using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lollipop.Persistence.TokenService
{
    public interface ITokenService
    {
        /// <summary>
        /// for generating access Token, we do it from user's claims
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        string GenerateAccessToken(IEnumerable<Claim> claims);
        /// <summary>
        /// for generating Refresh Token
        /// </summary>
        /// <returns></returns>
        string GenerateRefreshToken();
        /// <summary>
        /// for retrieving information from expired token, it's used for
        ///genereating new token after being outdated
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
