using System.Linq.Expressions;

namespace AutoFilterSpecification.Attributes
{
    public class LessAttribute : CompareMethodAttribute
    {
        public override Expression GetComparator(Expression property, Expression value)
        {
            var convertValue = Expression.Convert(value, GetValueType(property));
            return Expression.LessThan(property, convertValue);
        }
    }
}