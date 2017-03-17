using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Protocols.WSTrust;
using JWT.Security.App_Start;

namespace JWT.Security.Controllers
{
    public class SecurityController : Controller
    {
        /// <summary>
        /// Gets the Base Url
        /// </summary>
        /// <value>string</value>
        public string BaseURL
        {
            get
            {
                var baseUrl = HttpContext.Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped);
                return baseUrl.EndsWith("/", StringComparison.OrdinalIgnoreCase) ? baseUrl : baseUrl + "/";
            }
        }

        // GET: Security
        public ActionResult Login()
        {
            Session["x-session"] = CreateToken();
            return new RedirectResult(BaseURL);
        }

        public WebToken Get()
        {
            //Web Service call;
            WebToken wt = new WebToken()
            {
                Authority = "Noida",
                Role = "ADMIN",
                Team = "NOIDA-ADMIN"
            };
            return wt;
        }
        public string CreateToken()
        {
            WebToken token = Get();
            var plainTextSecurityKey = "ABCD-12134-HAGS-JKSJA57";
            var signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(plainTextSecurityKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
            //Saml Decrypt
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            { 
                new Claim(ClaimTypes.Name,"Pankaj"),
                new Claim(ClaimTypes.Email,"Pankaj@Gmail.com"),
                new Claim("Authority",token.Authority),
                new Claim("Role",token.Role),
                new Claim("Team",token.Team)
            }, "Custom");

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                AppliesToAddress = "http://my.website.com",
                TokenIssuerName = BaseURL,
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Lifetime = new Lifetime(DateTime.Now, DateTime.Now.AddMinutes(2)),

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);
            return signedAndEncodedToken;
        }
    }
}