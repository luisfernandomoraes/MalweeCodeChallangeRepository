using System.Collections.Generic;
using System.Web;
using MalweeCodeChallenge.Core.Contracts.Enums;
using MalweeCodeChallenge.Core.Contracts.Interfaces;
using MalweeCodeChallenge.Core.Entities;
using MalweeCodeChallenge.Core.Infra.EntityFramework;
using MalweeCodeChallenge.Core.Infra.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MalweeCodeChallenge.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MalweeCodeChallenge.Core.Infra.EntityFramework.MalweeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MalweeCodeChallenge.Core.Infra.EntityFramework.MalweeContext context)
        {


            IRepository<Supplier> supplierRepository = new Repository<Supplier>(context);
            var suppliers = new List<Supplier>()
            {
                new Supplier() {Name = "Fornecedor A", UpdateDate = DateTime.Now,},
                new Supplier() {Name = "Fornecedor B", UpdateDate = DateTime.Now,},
                new Supplier() {Name = "Fornecedor C", UpdateDate = DateTime.Now,}

            };

            supplierRepository.AddRange(suppliers);

            //foreach (var s in suppliers)
            //{
            //    supplierRepository.AddOrUpdate(s);
            //}

            var userManager = new UserManager<Client>(new UserStore<Client>(context));
            var task = userManager.CreateAsync(new Client() {
                    Name = "Luís Fernando",
                    UserName = "lf@gmail.com",
                    Email = "lf@gmai.com",
                    State = StatesEnum.SC,
                    Neighborhood = "Fortaleza",
                    City = "Blumenau",
                    SupplierId = suppliers[0].IdDbKey,
                    UpdateDate = DateTime.Now,  },
                "P@ssw0rd0").Result;

            var user = context.Database.SqlQuery<string>("select top(1) Email from AspNetUsers").ToList().FirstOrDefault();



            context.SaveChanges();
        }
    }
}
