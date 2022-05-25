using System.Linq.Expressions;

namespace AutoFilterSpecification.Attributes
{
    public class GreaterOrEqualAttribute : CompareMethodAttribute
    {
        public override Expression GetComparator(Expression property, Expression value)
        {
            var convertValue = Expression.Convert(value, GetValueType(property));
            return Expression.GreaterThanOrEqual(property, convertValue);
        }
    }
}