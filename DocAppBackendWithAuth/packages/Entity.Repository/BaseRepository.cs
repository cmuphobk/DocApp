using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.Repository
{
    public abstract class BaseRepository
    {
        /// <summary>
        /// Единица работы
        /// </summary>
        protected readonly IEntity UnitOfWork;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Единица работы</param>
        protected BaseRepository(IEntity context)
        {
            UnitOfWork = context;
        }
    }
}
