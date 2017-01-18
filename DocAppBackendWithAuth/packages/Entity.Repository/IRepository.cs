using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DocAppBackendWithAuth.Entity.Specifications;

namespace DocAppBackendWithAuth.Entity.Repository
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Возвращает все записи в виде IEnumerable
        /// </summary>
        /// <param name="properties">navigation-свойства, которые будут подгружены</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(IEnumerable<Expression<Func<TEntity, object>>> properties);

        /// <summary>
        /// Есть ли записи в таблице
        /// </summary>
        /// <returns></returns>
        bool Any();

        /// <summary>
        /// Есть ли записи в таблице
        /// </summary>
        /// <param name="criteria">условия поиска</param>
        /// <returns></returns>
        bool Any(ISpecification<TEntity> criteria);

        /// <summary>
        /// Ищем записи удовлетворяющие условию
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(ISpecification<TEntity> criteria);

        /// <summary>
        /// Ищем записи удовлетворяющие условию
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(ISpecification<TEntity> criteria, int count);

        /// <summary>
        /// Ищем записи удовлетворяющие условию
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(ISpecification<TEntity> criteria, IEnumerable<Expression<Func<TEntity, object>>> properties);

        /// <summary>
        /// Получаем определенные поля поки
        /// </summary>
        /// <param name="param"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        IEnumerable<dynamic> FindPart(FindParam<TEntity> param, Expression<Func<TEntity, dynamic>> fields);

        /// <summary>
        /// Ищем записи удовлетворяющие условию
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> Find(FindParam<TEntity> param);

        /// <summary>
        /// Количество элементов
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        int Count(ISpecification<TEntity> criteria);

        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <param name="element"></param>
        void Add(TEntity element);

        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="element"></param>
        void Remove(TEntity element);

        /// <summary>
        /// Удаляет сразу несколько записей
        /// </summary>
        /// <param name="listEntity">Список на удаление</param>
        void Remove(IEnumerable<TEntity> listEntity);

        /// <summary>
        /// Присоединить запись
        /// </summary>
        /// <param name="entity">Запись для присоединения</param>
        void Attach(TEntity entity);

        /// <summary>
        /// Присоединить запись и изменить статус
        /// </summary>
        /// <param name="entity">Запись для присоединения</param>
        void AttachAndSetModifiedState(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
    }
}
