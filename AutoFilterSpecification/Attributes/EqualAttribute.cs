using System.Linq.Expressions;

namespace AutoFilterSpecification.Attributes
{
    public class EqualAttribute : CompareMethodAttribute
    {
        public override Expression GetComparator(Expression property, Expression value)
        {
            var convertValue = Expression.Convert(value, GetValueType(property));
            return Expression.Equal(property, convertValue);
        }
    }
}