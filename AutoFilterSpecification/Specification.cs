using System;
using System.Linq.Expressions;
using AutoFilterSpecification.Extensions;

namespace AutoFilterSpecification
{
    public class Specification<T>
    {
        private readonly Expression<Func<T, bool>> _expression;

        private Func<T, bool> _func;

        public Specification(Expression<Func<T, bool>> expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public bool IsSatisfiedBy(T obj) => (_func ?? (_func = _expression.Compile()))(obj);

        public Specification<TParent> From<TParent>(Expression<Func<TParent, T>> mapFrom)
            => _expression.From(mapFrom);

        public static bool operator false(Specification<T> spec) => false;
        
        public static bool operator true(Specification<T> spec) => false;
        
        public static Specification<T> operator &(Specification<T> spec1, Specification<T> spec2)
            => new Specification<T>(spec1._expression.And(spec2._expression));

        public static Specification<T> operator |(Specification<T> spec1, Specification<T> spec2)
            => new Specification<T>(spec1._expression.Or(spec2._expression));

        public static Specification<T> operator !(Specification<T> spec)
            => new Specification<T>(spec._expression.Not());
        
        public static implicit operator Expression<Func<T, bool>>(Specification<T> spec)
            => spec?._expression;
        
        public static implicit operator Specification<T>(Expression<Func<T, bool>> expression)
            => new Specification<T>(expression);
    }
}
