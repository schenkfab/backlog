using backlog.Entities;
using backlog.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Middleware
{
    public class UserMiddleware
    {
        private readonly RequestDelegate next;

        public UserMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        private static string GetSubFromToken(String authorizationHeader)
        {
            var jwt = authorizationHeader.Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            var sub = token.Claims.Where(o => o.Type == "sub").FirstOrDefault().Value;

            return sub;
        }

        public async Task InvokeAsync(HttpContext context, IUserObject userObject, IUserRepository repository)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var authHeader = context.Request.Headers["Authorization"].ToString();
                var sub = GetSubFromToken(authHeader);
                User user = await repository.GetUserBySub(sub);
                if (user != null)
                {
                    userObject.Sub = sub;
                    userObject.Token = authHeader;
                    userObject.UserId = user.Id;
                }

                await next(context);
            } else
            {
                //context.Response.StatusCode = 401;
                //await context.Response.WriteAsync("Authorization Header is missing.");

                await next(context);
            }
        }
    }
}
