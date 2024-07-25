using Patterns.Architactural_Patterns.Models;
using System;
using System.Linq.Expressions;

namespace Patterns.Architactural_Patterns
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> ToExpression();
    }
    public class Specification_Pattern : ISpecification<Product>
    {
        private readonly string _category;

        public Specification_Pattern(string category)
        {
            _category = category;
        }

        public Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.Category == _category;
        }
    }
}
