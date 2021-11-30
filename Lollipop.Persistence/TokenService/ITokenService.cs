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
        //for generating access Token, we do it from user's claims
        string GenerateAccessToken(IEnumerable<Claim> claims);
        //for generating Refresh Token
        string GenerateRefreshToken();
        //for retrieving information from expired token, it's used for
        //genereating new token after being outdated
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
