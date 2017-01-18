using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DocAppBackendWithAuth.Entity.POCO;
using System.Data.Entity.Migrations;

namespace DocAppBackendWithAuth.Entity.Entity
{
    /// <summary>
    /// Первоначальные пользователи в БД
    /// </summary>
    public static class InitialUserConfig
    {
        /// <summary>
        /// Создаем первоначальных пользователей
        /// </summary>
        public static  void CreateInitialUser(DocAppBackendWithAuth.Entity.Entity.MainContext context)
        {

            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            const string adminRole = "Admin";
            if (! roleManager.RoleExists(adminRole))
            {
                 roleManager.Create(new IdentityRole(adminRole));
            }


            const string managerRole = "Manager";
            if (! roleManager.RoleExists(managerRole))
            {
                 roleManager.Create(new IdentityRole(managerRole));
            }


            const string defaultPassword = "123456";


            //Создаем администратора
            const string adminUser = "Admin";
            if ( manager.FindByName(adminUser) == null)
            {

                var userAdmin = new IdentityUser
                {
                    UserName = adminUser,
                    Email = "cmuphob.k@gmail.com",
                    EmailConfirmed = true
                };
                 manager.Create(userAdmin, defaultPassword);

                userAdmin.Roles.Add(new IdentityUserRole()
                {
                    RoleId = roleManager.FindByName(adminRole).Id,
                    UserId = userAdmin.Id
                });
            }

            

            const string managerUser = "Manager";
            if ( manager.FindByName(managerUser) == null)
            {
                var userManager = new IdentityUser()
                {
                    UserName = managerUser,
                    Email = "cmuphob1.k@gmail.com",
                    EmailConfirmed = true
                };

                 manager.Create(userManager, defaultPassword);

                userManager.Roles.Add(new IdentityUserRole()
                {
                    RoleId = roleManager.FindByName(managerRole).Id,
                    UserId = userManager.Id
                });
            }

        }

    }
}