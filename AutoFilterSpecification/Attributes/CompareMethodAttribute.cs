using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoFilterSpecification.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class CompareMethodAttribute : Attribute
    {
        public abstract Expression GetComparator(Expression property, Expression value);

        protected virtual Type GetValueType(Expression property)
        {
            var memberExpression = property as MemberExpression;
            
            return memberExpression.Member is MethodInfo 
                ? ((MethodInfo)memberExpression.Member).ReturnType 
                : ((PropertyInfo)memberExpression.Member).PropertyType;
        }
    }
}
