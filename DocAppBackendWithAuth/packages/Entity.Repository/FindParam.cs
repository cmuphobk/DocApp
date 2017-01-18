using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DocAppBackendWithAuth.Entity.Specifications;

namespace DocAppBackendWithAuth.Entity.Repository
{
    public class FindParam<TEntity>
    {
        public ISpecification<TEntity> Criteria { get; set; }

        public IEnumerable<Expression<Func<TEntity, object>>> Property { get; set; }

        public int? Take { get; set; }

        public int? Skip { get; set; }

        public IEnumerable<Expression<Func<TEntity, int>>> OrderByNumber { get; set; }

        public bool AsNoTracking { get; set; }

        public bool IsDistinct { get; set; }

    }
}
