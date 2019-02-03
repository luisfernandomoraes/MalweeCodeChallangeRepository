using System.Data.Entity;
using System.Reflection;
using MalweeCodeChallenge.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MalweeCodeChallenge.Core.Infra.EntityFramework
{
    public class MalweeContext:IdentityDbContext<Client>
    {
    
        public MalweeContext():base("DefaultConnection")
        {
           //Call seed.
        }   
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(MalweeContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
       
    }
}