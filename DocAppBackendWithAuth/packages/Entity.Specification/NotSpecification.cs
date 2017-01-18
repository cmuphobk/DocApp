using System;
using System.Linq.Expressions;
using DocAppBackendWithAuth.Entity.Specifications.Expressions;

namespace DocAppBackendWithAuth.Entity.Specifications
{
    public class NotSpecification<T> : Specification<T>
    {

        public NotSpecification(Specification<T> specification):
            base(((Expression<Func<T, bool>>)specification).Not())
        {
        }
    }
}
