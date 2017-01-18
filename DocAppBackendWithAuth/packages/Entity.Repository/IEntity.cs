using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace DocAppBackendWithAuth.Entity.Repository
{
    public interface IEntity:IDisposable
    {
        /// <summary>
        /// Получаем предикат для запроса
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IDbSet<TEntity> GetModel<TEntity>() where TEntity : class;

        /// <summary>
        /// Сохраняем изменения
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Отклоняем изменения
        /// </summary>
        void RejectChanges();

        /// <summary>
        ///  Поддерживает состояние объекта и обеспечивает управление идентификаторами для экземпляров типов сущностей и экземпляров отношений 
        /// </summary>
        ObjectStateManager ObjectStateManager { get; }

        /// <summary>
        /// Изменение существующего объекта
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="state"></param>
        void ChangeState<TEntity>(TEntity entity, EntityState state) where TEntity : class;

        /// <summary>
        /// Применяем текущие значения к объекту
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity ApplyCurrentValues<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Получаем репозитарий для типа
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <returns></returns>
        TRepository GetRepository<TRepository>() where TRepository : class;

    }
}
