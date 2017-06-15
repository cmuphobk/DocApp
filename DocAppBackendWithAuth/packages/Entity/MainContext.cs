using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using DocAppBackendWithAuth.Common.IoCContainer;
using DocAppBackendWithAuth.Entity.POCO;
using DocAppBackendWithAuth.Entity.Repository;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DocAppBackendWithAuth.Entity.Entity
{
    /// <summary>
    /// Контекст для работы с данными
    /// </summary>
    public class MainContext : IdentityDbContext<IdentityUser>, IEntity
    {
        public MainContext()
            : base(/*RoleEnvironment.GetConfigurationSettingValue("MainContext"), throwIfV1Schema: false*/)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// Регистр постановлений на оплату
        /// </summary>
        public DbSet<BaseUser> BaseUser { get; set; }

        /// <summary>
        /// Диагноз
        /// </summary>
        public DbSet<Diagnos> Diagnos { get; set; }

        /// <summary>
        /// Симптом
        /// </summary>
        public DbSet<Symptom> Symptom { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public DbSet<Weight> Weight { get; set; }

        /// <summary>
        /// Симптом
        /// </summary>
        public DbSet<Departament> Departament { get; set; }

        /// <summary>
        /// Симптом
        /// </summary>
        public DbSet<Group> Group { get; set; }

        /// <summary>
        /// Диалог
        /// </summary>
        public DbSet<Dialog> Dialog { get; set; }
        /// <summary>
        /// Сообщение
        /// </summary>
        public DbSet<Message> Message { get; set; }
        /// <summary>
        /// Изображение
        /// </summary>
        public DbSet<Image> Image { get; set; }
        /// <summary>
        /// Ссылка
        /// </summary>
        public DbSet<Href> Href { get; set; }
        /// <summary>
        /// Документ
        /// </summary>
        public DbSet<Document> Document { get; set; }
        /// <summary>
        /// Болезнь
        /// </summary>
        public DbSet<Disease> Disease { get; set; }
        /// <summary>
        /// Доктор
        /// </summary>
        public DbSet<Doctor> Doctor { get; set; }
        /// <summary>
        /// Лечебное заведение
        /// </summary>
        public DbSet<Hospital> Hospital { get; set; }
        /// <summary>
        /// Амбулаторная карт
        /// </summary>
        public DbSet<OutpatientCard> OutpatientCard { get; set; }
        /// <summary>
        /// Пациент
        /// </summary>
        public DbSet<Patient> Patient { get; set; }
        /// <summary>
        /// Отзыв
        /// </summary>
        public DbSet<Recall> Recall { get; set; }

        public IDbSet<TEntity> GetModel<TEntity>() where TEntity : class
        {

            if(typeof(TEntity) == typeof(BaseUser))
            {
                return (IDbSet<TEntity>)BaseUser;
            }
            else if (typeof(TEntity) == typeof(Diagnos))
            {
                return (IDbSet<TEntity>)Diagnos;
            }
            else if (typeof(TEntity) == typeof(Symptom))
            {
                return (IDbSet<TEntity>)Symptom;
            } 
            else if (typeof(TEntity) == typeof(Weight))
            {
                return (IDbSet<TEntity>)Weight;
            }
            else if (typeof(TEntity) == typeof(Departament))
            {
                return (IDbSet<TEntity>)Departament;
            }
            else if (typeof(TEntity) == typeof(Group))
            {
                return (IDbSet<TEntity>)Group;
            }
            else if (typeof(TEntity) == typeof(Dialog))
            {
                return (IDbSet<TEntity>)Dialog;
            }
            else if (typeof(TEntity) == typeof(Message))
            {
                return (IDbSet<TEntity>)Message;
            }
            else if (typeof(TEntity) == typeof(Image))
            {
                return (IDbSet<TEntity>)Image;
            }
            else if (typeof(TEntity) == typeof(Href))
            {
                return (IDbSet<TEntity>)Href;
            }
            else if (typeof(TEntity) == typeof(Document))
            {
                return (IDbSet<TEntity>)Document;
            }
            else if (typeof(TEntity) == typeof(Disease))
            {
                return (IDbSet<TEntity>)Disease;
            }
            else if (typeof(TEntity) == typeof(Doctor))
            {
                return (IDbSet<TEntity>)Doctor;
            }
            else if (typeof(TEntity) == typeof(Hospital))
            {
                return (IDbSet<TEntity>)Hospital;
            }
            else if (typeof(TEntity) == typeof(OutpatientCard))
            {
                return (IDbSet<TEntity>)OutpatientCard;
            }
            else if (typeof(TEntity) == typeof(Patient))
            {
                return (IDbSet<TEntity>)Patient;
            }
            else if (typeof(TEntity) == typeof(Recall))
            {
                return (IDbSet<TEntity>)Recall;
            }
            else
            {
                throw new NotImplementedException(String.Format("Неизвестный тип - {0}", typeof(TEntity)));
            }
        }

        public void RejectChanges()
        {
            var context = ((IObjectContextAdapter)this).ObjectContext;
            foreach (var change in this.ChangeTracker.Entries())
            {
                if (change.State == EntityState.Modified)
                {
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, change.Entity);
                }
                if (change.State == EntityState.Added)
                {
                    context.Detach(change.Entity);
                }
            }
        }

        public ObjectStateManager ObjectStateManager
        {
            get { return ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager; }
        }

        /// <summary>
        /// Изменение существующего объекта
        /// </summary>
        public void ChangeState<TEntity>(TEntity entity, EntityState state) where TEntity : class
        {
            Entry(entity).State = state;
            Entry(entity).CurrentValues.SetValues(entity);
        }

        public TEntity ApplyCurrentValues<TEntity>(TEntity entity) where TEntity : class
        {
            return ((IObjectContextAdapter)this).ObjectContext.ApplyCurrentValues(entity.GetType().Name, entity);
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return IoCContainer.Get<TRepository>(ParamType.ConstructorArgiment, "context", this);
        }

        public static MainContext Create()
        {
            return new MainContext();
        }
    }
}
