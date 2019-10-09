using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


namespace WebApp
{
    [Route("api")]
    public class LoginController : Controller
    {
        private readonly IAccountDatabase _db;

        public LoginController(IAccountDatabase db)
        {
            _db = db;
        }

        [HttpPost("sign-in")]
        public async Task Login(string userName)
        {
            var account = await _db.FindByUserNameAsync(userName);
            if (account != null)
            {
                //TODO 1: Generate auth cookie for user 'userName' with external id
                HttpContext.Response.Cookies.Append("ExternalId", account.ExternalId.ToString());

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.UserName),
                    // new Claim("ExternalId", account.ExternalId),
                    new Claim(ClaimTypes.Role, account.Role),
                };
                var userIdentity = new ClaimsIdentity(claims, "login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity));
            }
            //TODO 2: return 404 if user not found
            else
            {
                HttpContext.Response.StatusCode = 404;
            }

        }
    }
}