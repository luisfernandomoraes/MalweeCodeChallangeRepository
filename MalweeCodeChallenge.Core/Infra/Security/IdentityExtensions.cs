using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace MalweeCodeChallenge.Core.Infra.Security
{
    public static class IdentityExtensions
    {
        public static string GetName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("Name");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}