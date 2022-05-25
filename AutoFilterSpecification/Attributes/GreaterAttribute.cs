using System.Linq.Expressions;

namespace AutoFilterSpecification.Attributes
{
    public class GreaterAttribute : CompareMethodAttribute
    {
        public override Expression GetComparator(Expression property, Expression value)
        {
            var convertValue = Expression.Convert(value, GetValueType(property));
            return Expression.GreaterThan(property, convertValue);
        }
    }
}