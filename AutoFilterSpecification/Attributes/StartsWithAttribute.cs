using System;
using System.Linq.Expressions;

namespace AutoFilterSpecification.Attributes
{
    public class StartsWithAttribute : CompareMethodAttribute
    {
        public override Expression GetComparator(Expression property, Expression value)
        {
            var startsWith = typeof(string).GetMethod(nameof(string.StartsWith), new[] { typeof(string) });
            var toLower = typeof(string).GetMethod(nameof(string.ToLower), new Type[0]);
            var lowerProperty = Expression.Call(property, toLower);
            return Expression.Call(lowerProperty, startsWith, value);
        }
    }
}