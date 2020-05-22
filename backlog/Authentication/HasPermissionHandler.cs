﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace backlog.Authentication
{
    public class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionRequirement requirement)
        {
            // If user does not have the scope claim, get out of here
            if (!context.User.HasClaim(c => c.Type == "permissions" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            // Split the scopes string into an array
            var permissions = context.User.FindAll(c => c.Type == "permissions" && c.Issuer == requirement.Issuer);

            // Succeed if the scope array contains the required scope
            if (permissions.Any(s => s.Value == requirement.Permission))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
