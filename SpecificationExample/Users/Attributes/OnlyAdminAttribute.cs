using System;
using System.Linq.Expressions;
using AutoFilterSpecification;
using AutoFilterSpecification.Attributes;
using AutoFilterSpecification.Extensions;
using SpecificationExample.Users.Models;

namespace SpecificationExample.Users.Attributes
{
    public class OnlyAdminAttribute : ConditionAttribute
    {
        public override Expression<Func<T, bool>> GetSpecification<T>()
        {
            if (typeof(T) != typeof(User))
                throw new ArgumentException();

            Expression<Func<User,bool>> spec = Specifications.Admins;

            return spec.Transform<T, User>();
        }
    }
}