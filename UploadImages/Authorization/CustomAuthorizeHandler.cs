using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UploadImages.Authorization
{
    public class CustomAuthorizeHandler 
    {
        private readonly RequestDelegate _next;

        public CustomAuthorizeHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["X-Account-Id"];
            if (authHeader != null && authHeader.StartsWith("Basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring("Basic ".Length).Trim();
                Console.WriteLine(token);
                var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                //This is just for sample, as in our case, we have int Id, we could combine id & name
                if (credentialstring == "admin")
                {
                    var claims = new[] { new Claim("Id", credentialstring), new Claim(ClaimTypes.Role, "Admin") };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    context.User = new ClaimsPrincipal(identity);
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                context.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Not Authroized\"");
            }
            await _next(context);
        }
    }

}

