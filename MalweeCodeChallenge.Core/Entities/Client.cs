using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MalweeCodeChallenge.Core.Contracts.Abstracts;
using MalweeCodeChallenge.Core.Contracts.Enums;
using MalweeCodeChallenge.Core.Contracts.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MalweeCodeChallenge.Core.Entities
{
    public class Client : IdentityUser, IEntity
    {
        public Client()
        {
            this.IdDbKey = Guid.NewGuid().ToString();
        }
        public string IdDbKey { get; set; }
        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public StatesEnum? State { get; set; }
        public virtual Supplier Supplier { get; set; }
        public string SupplierId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Client> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


    }
}