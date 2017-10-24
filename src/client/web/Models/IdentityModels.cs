using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace web.Models
{
    public class IdentityModels : GenericPrincipal
    {
        public IdentityModels(IIdentity identity, string[] roles) : base(identity, roles)
        {
        }
        public string Roles { get; set; }
        public override bool IsInRole(string role)
        {
            if (string.IsNullOrEmpty(this.Roles))
                return false;
            return this.Roles.Split(',').Contains(role);
        }
    }
}