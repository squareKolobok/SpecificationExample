using System;
using System.Linq.Expressions;

namespace AutoFilterSpecification.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TDestination, TReturn>> From<TSource, TDestination, TReturn>(
            this Expression<Func<TSource, TReturn>> source, 
            Expression<Func<TDestination, TSource>> mapFrom)
            => Expression.Lambda<Func<TDestination, TReturn>>(
                Expression.Invoke(source, mapFrom.Body), mapFrom.Parameters);
        
        public static Expression<Func<TResult, bool>> Transform<TResult, TSourse>(this Expression<Func<TSourse, bool>> source)
            => Expression.Lambda<Func<TResult,bool>>(source.Body, source.Parameters);
    }
}


