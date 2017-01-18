using System.Collections.Generic;
using DocAppBackendWithAuth.Entity.POCO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DocAppBackendWithAuth.Entity.Entity.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DocAppBackendWithAuth.Entity.Entity.MainContext";
            
        }

        protected override void Seed(DocAppBackendWithAuth.Entity.Entity.MainContext context)
        {

            InitialUserConfig.CreateInitialUser(context);

            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

            context.BaseUser.AddOrUpdate(new BaseUser
            {
                IsDeleted = false,
                Name = "Admin",
                SecondName = "Admin",
                User = manager.FindByName("Admin")

            });

            context.BaseUser.AddOrUpdate(new BaseUser
            {
                IsDeleted = false,
                Name = "Manager",
                SecondName = "Manager",
                User = manager.FindByName("Manager")

            });

            context.SaveChanges();
        }
    }
}
