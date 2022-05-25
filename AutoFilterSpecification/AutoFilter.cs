using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoFilterSpecification.Attributes;
using AutoFilterSpecification.Extensions;

namespace AutoFilterSpecification
{
    public class AutoFilter<TFilter>
    {
        private readonly TFilter source;

        public AutoFilter(TFilter source)
        {
            this.source = source;
        }

        public Expression<Func<TResult,bool>> GetFilter<TResult>(FilterCombine filterCombine = FilterCombine.And)
        {
            var Lambdas = new List<Expression<Func<TResult, bool>>>();
            var targetProperties = typeof(TResult).GetProperties();
            var properties = typeof(TFilter)
                .GetProperties()
                .Where(x => x.GetValue(source) != null)
                .ToList();

            foreach(var property in properties)
            {
                var expression = GetExpressionForProperty<TResult>(property, targetProperties);

                if (expression != null)
                    Lambdas.Add(expression);
            }

            if (Lambdas.Count == 0)
                return new Specification<TResult>(x => true);

            if (filterCombine == FilterCombine.And)
                return new Specification<TResult>(Lambdas.Aggregate((l, r) => l.And(r)));

            return new Specification<TResult>(Lambdas.Aggregate((l, r) => l.Or(r)));
        }

        private Expression<Func<TResult,bool>> GetExpressionForProperty<TResult>(PropertyInfo filterProperty, IEnumerable<PropertyInfo> targetProperties)
        {
            if (IsNotFilter(filterProperty))
                    return null;;

            var isCondition = TryGetCondition<TResult>(out var expression, filterProperty);
                
            if (isCondition)
                return expression;

            var targetProperty = GetProperty(filterProperty, targetProperties);

            if (targetProperty == null)
                return null;

            if (!isCondition)
                return BuildExpressionForTarget<TResult>(filterProperty, targetProperty);
            
            return null;
        }

        private bool IsNotFilter(PropertyInfo filterProperty)
        {
            return filterProperty.GetCustomAttribute(typeof(NotFilterAttribute)) != null;
        }

        private PropertyInfo GetProperty(PropertyInfo filterProperty, IEnumerable<PropertyInfo> targetProperties)
        {            
            var bindingAttribute = filterProperty.GetCustomAttribute<BindingByAttribute>();
            var propertyName = bindingAttribute != null ? bindingAttribute.PropertyName : filterProperty.Name;

            return targetProperties.FirstOrDefault(x => x.Name.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase));
        }

        private bool TryGetCondition<TResult>(out Expression<Func<TResult,bool>> specification, PropertyInfo filterProperty)
        {
            var conditionAtribute = filterProperty.GetCustomAttribute<ConditionAttribute>();
            var isPropertyBool = filterProperty.PropertyType == typeof(bool?) ||
                filterProperty.PropertyType == typeof(bool);
            specification = null;

            if (conditionAtribute == null || !isPropertyBool)
                return false;

            var filterValue = filterProperty.GetValue(source);
            var valueBool = (bool)filterValue;

            if (valueBool)
                specification = conditionAtribute.GetSpecification<TResult>();

            return valueBool;
        }

        private Expression<Func<TResult, bool>> BuildExpressionForTarget<TResult>(PropertyInfo filterProperty, PropertyInfo targetProperty)
        {
            var filterValue = filterProperty.GetValue(source);
            var compareAttribute = filterProperty.GetCustomAttribute<CompareMethodAttribute>();
            var parameter = Expression.Parameter(typeof(TResult));

            Expression expressionProperty = Expression.Property(parameter, targetProperty);
            Expression value = Expression.Constant(filterValue);
            Expression body;

            if (compareAttribute != null)
            {
                body = compareAttribute.GetComparator(expressionProperty, value);
            }
            else
            {
                value = Expression.Convert(value, targetProperty.PropertyType);
                body = Expression.Equal(expressionProperty, value);
            }

            return Expression.Lambda<Func<TResult, bool>>(body, parameter);
        }
    }
}