using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DocAppBackendWithAuth.Entity.Specifications;

namespace DocAppBackendWithAuth.Entity.Repository
{
    public class GenericRepository<TEntity> : BaseRepository, IRepository<TEntity> where TEntity : class
    {
        public GenericRepository(IEntity context)
            : base(context)
        {

        }
        /// <summary>
        /// Возвращает все записи в виде IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return FindInner(new FindParam<TEntity>());
        }

        /// <summary>
        /// Возвращает все записи в виде IEnumerable
        /// </summary>
        /// <param name="properties">navigation-свойства, которые будут подгружены</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll(IEnumerable<Expression<Func<TEntity, object>>> properties)
        {
            return FindInner(new FindParam<TEntity>()
            {
                Property = properties
            });
        }

        /// <summary>
        /// Есть ли записи в таблице
        /// </summary>
        /// <returns></returns>
        public bool Any()
        {
            return UnitOfWork.GetModel<TEntity>().AsQueryable().Any();
        }

        /// <summary>
        /// Есть ли записи в таблице
        /// </summary>
        /// <param name="criteria">условия поиска</param>
        /// <returns></returns>
        public bool Any(ISpecification<TEntity> criteria)
        {
            return UnitOfWork.GetModel<TEntity>().AsQueryable().Where(criteria.GetPredicate()).Any();
        }

        /// <summary>
        /// Ищем записи удовлетворяющие условию
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(ISpecification<TEntity> criteria)
        {
            return FindInner(new FindParam<TEntity>()
            {
                Criteria = criteria
            });
        }

        /// <summary>
        /// Ищем записи удовлетворяющие условию
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(ISpecification<TEntity> criteria, int count)
        {
            return FindInner(new FindParam<TEntity>()
            {
                Criteria = criteria,
                Take = count
            });
        }

        /// <summary>
        /// Ищем записи удовлетворяющие условию
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(ISpecification<TEntity> criteria,
            IEnumerable<Expression<Func<TEntity, object>>> properties)
        {
            return FindInner(new FindParam<TEntity>()
            {
                Criteria = criteria,
                Property = properties
            });
        }

        public IEnumerable<dynamic> FindPart(FindParam<TEntity> param, Expression<Func<TEntity, dynamic>> fields)
        {
            bool isDistinct = param.IsDistinct;
            param.IsDistinct = false;
            IQueryable<dynamic> result = FindInner(param).Select(fields);
            if (isDistinct)
            {
                result = result.Distinct();
            }
            return result;
        }

        public IEnumerable<TEntity> Find(FindParam<TEntity> param)
        {
            return FindInner(param);
        }
        
        private IQueryable<TEntity> FindInner(FindParam<TEntity> param)
        {
            IQueryable<TEntity> dbSet = UnitOfWork.GetModel<TEntity>();
            if (param.Property != null)
            {
                foreach (var expression in param.Property)
                {
                    dbSet = dbSet.Include(expression);
                }
            }
            if (param.Criteria != null)
            {
                dbSet = dbSet.Where(param.Criteria.GetPredicate());
            }

            if (param.OrderByNumber != null)
            {
                foreach (var predicate in param.OrderByNumber)
                {
                    dbSet = dbSet.OrderBy(predicate);
                }
            }


            if (param.Skip != null)
            {
                dbSet = dbSet.Skip((int)param.Skip);
            }

            if (param.Take != null)
            {
                dbSet = dbSet.Take((int)param.Take);
            }

            if (param.AsNoTracking)
            {
                dbSet = dbSet.AsNoTracking();
            }

            if (param.IsDistinct)
            {
                dbSet = dbSet.Distinct();

            }

            return dbSet;

            
        }

        public int Count(ISpecification<TEntity> criteria)
        {
            return UnitOfWork.GetModel<TEntity>().Count(criteria.GetPredicate());
        }

        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <param name="element"></param>
        public void Add(TEntity element)
        {
            UnitOfWork.GetModel<TEntity>().Add(element);
        }

        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="element"></param>
        public void Remove(TEntity element)
        {
            UnitOfWork.GetModel<TEntity>().Remove(element);
        }

        /// <summary>
        /// Удаляет сразу несколько записей
        /// </summary>
        /// <param name="listEntity">Список на удаление</param>
        public void Remove(IEnumerable<TEntity> listEntity)
        {
            foreach (var entity in listEntity)
            {
                Remove(entity);
            }
        }

        /// <summary>
        /// Присоединить запись
        /// </summary>
        /// <param name="entity">Запись для присоединения</param>
        public void Attach(TEntity entity)
        {
            UnitOfWork.GetModel<TEntity>().Attach(entity);
        }

        /// <summary>
        /// Присоединить запись и изменить статус
        /// </summary>
        /// <param name="entity">Запись для присоединения</param>
        public void AttachAndSetModifiedState(TEntity entity)
        {
            UnitOfWork.GetModel<TEntity>().Attach(entity);
            // для Mock репозитария не меняем статус
            if (UnitOfWork.ObjectStateManager != null)
            {
                UnitOfWork.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            }
        }

        /// <summary>
        /// Изменяем объект
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            UnitOfWork.ApplyCurrentValues(entity);
        }

    }
}
