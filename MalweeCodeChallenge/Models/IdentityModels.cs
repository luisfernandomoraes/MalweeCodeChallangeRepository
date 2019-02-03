using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using MalweeCodeChallenge.Core.Contracts.Enums;
using MalweeCodeChallenge.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MalweeCodeChallenge.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    [Table("Client")]

    public class ApplicationDbContext : IdentityDbContext<Client>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasRequired(p => p.Supplier).WithMany().HasForeignKey(p => p.SupplierId);
            base.OnModelCreating(modelBuilder);
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}