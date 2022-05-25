using System;
using System.Linq.Expressions;

namespace AutoFilterSpecification.Attributes
{
    public class StringContainsAttribute : CompareMethodAttribute
    {
        public override Expression GetComparator(Expression property, Expression value)
        {
            var convertValue = Expression.Convert(value, GetValueType(property));
            var contains = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
            var toLower = typeof(string).GetMethod(nameof(string.ToLower), new Type[0]);
            var lowerProperty = Expression.Call(property, toLower);
            return Expression.Call(lowerProperty, contains, convertValue);
        }
    }
}