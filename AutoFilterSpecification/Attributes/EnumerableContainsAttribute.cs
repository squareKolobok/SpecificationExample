using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutoFilterSpecification.Attributes
{
    public class EnumerableContainsAttribute : CompareMethodAttribute
    {
        public override Expression GetComparator(Expression property, Expression value)
        {
            return Expression.Call(typeof(Enumerable), "Contains", new[] { base.GetValueType(property) }, value, property);
        }
    }
}