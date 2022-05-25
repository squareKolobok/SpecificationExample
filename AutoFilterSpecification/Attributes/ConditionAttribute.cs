using System;
using System.Linq.Expressions;
using AutoFilterSpecification.Extensions;

namespace AutoFilterSpecification.Attributes
{
    public abstract class ConditionAttribute : Attribute
    {
        public abstract Expression<Func<T, bool>> GetSpecification<T>();
    }
}