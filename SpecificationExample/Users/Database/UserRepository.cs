using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoFilterSpecification;
using SpecificationExample.Users.Models;
using ApplicationContext = SpecificationExample.Database.ApplicationContext;
using UserDb = SpecificationExample.Database.User;

namespace SpecificationExample.Users.Database
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;
        private static Expression<Func<UserDb, User>> toBl = user => new User()
        {
            Id = user.Id,
            Name = user.Name
        };

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            var userDb = new UserDb()
            {
                Name = user.Name
            };

            context.Users.Add(userDb);
            context.SaveChanges();
        }

        public void ChangeUser(User user)
        {
            var userDb = GetUserDbByUserBl(user);

            userDb.Name = user.Name;
            userDb.DateUpdate = DateTime.Now;

            context.Users.Update(userDb);

            context.SaveChanges();
        }

        public User GetUser(Specification<User> where)
        {
            return context.Users.Select(toBl).Where(where).First();
        }

        public IEnumerable<User> GetUsers(Specification<User> where)
        {
            return context.Users.Select(toBl).Where(where);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.Select(toBl);
        }

        private UserDb GetUserDbByUserBl(User user)
        {
            return context.Users.First(x => x.Id == user.Id);
        }
    }
}