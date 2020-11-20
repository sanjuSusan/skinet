using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria => throw new NotImplementedException();

        public List<Expression<Func<T, object>>> include => throw new NotImplementedException();
    }
}
