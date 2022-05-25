using System.Linq.Expressions;

namespace AutoFilterSpecification.Attributes
{
    public class LessOrEqualAttribute : CompareMethodAttribute
    {
        public override Expression GetComparator(Expression property, Expression value)
        {
            var convertValue = Expression.Convert(value, GetValueType(property));
            return Expression.LessThanOrEqual(property, convertValue);
        }
    }
}