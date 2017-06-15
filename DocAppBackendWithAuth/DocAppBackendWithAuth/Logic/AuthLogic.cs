using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DocAppBackendWithAuth.Entity.POCO;
using DocAppBackendWithAuth.Entity.POCO.Enum;
using DocAppBackendWithAuth.Entity.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DocAppBackendWithAuth.Common.IoCContainer;
using DocAppBackendWithAuth.Models;

namespace DocAppBackendWithAuth.Logic
{
    public class AuthLogic
    {

        public BaseUser getUserByUserId(string userId)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repositoryUser = context.GetRepository<IRepository<BaseUser>>();
                return repositoryUser.Find(new Entity.Specifications.POCO.User.ByUserId(userId)).First();
               
            }
        }

        public List<BaseUser> getUsers()
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repositoryUser = context.GetRepository<IRepository<BaseUser>>();
                return repositoryUser.GetAll(new List<Expression<Func<BaseUser, object>>>
                {
                    t => t.User
                }).ToList();
            }
        }

        public BaseUser createUser(string name, string firstname, string secondname, ApplicationUser userApp)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<BaseUser>>();

                var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context as DbContext));
                var identityUser = manager.FindById(userApp.Id);
                var user = new BaseUser
                {
                    Name = name,
                    SecondName = firstname,
                    Surname = secondname,
                    IsDeleted = false,
                    User = identityUser

                };
                repository.Add(user);
                context.SaveChanges();
                return user;
            }
        }

    }
}