using AutoFilterSpecification;
using SpecificationExample.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SpecificationExample.Users.Database
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void ChangeUser(User user);
        IEnumerable<User> GetUsers(Specification<User> where);
        IEnumerable<User> GetUsers();
        User GetUser(Specification<User> where);
    }
}