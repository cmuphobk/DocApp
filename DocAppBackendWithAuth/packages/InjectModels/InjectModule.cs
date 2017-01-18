using System.Linq;
using DocAppBackendWithAuth.Entity.Entity;
using DocAppBackendWithAuth.Entity.POCO;
using DocAppBackendWithAuth.Entity.Repository;
using log4net;
using Ninject.Modules;

namespace DocAppBackendWithAuth.Common.InjectModels
{
    /// <summary>
    ///     Это общие биндинги Ninject 
    /// </summary>
    public class InjectModule : NinjectModule
    {
        public override void Load()
        {
            //Модель и единица работы
            Bind<IEntity>().To<MainContext>();

            // биндинг логера
            Bind<ILog>().ToMethod(i => LogManager.GetLogger(i.Parameters.Single(x => x.Name.Equals("NameLogger")).GetValue(i, i.Request.Target).ToString()));

            //Репозитарии
            BindRepository();

            //Логика
            BindLogic();
        }

        /// <summary>
        /// Биндим репозитарии
        /// </summary>
        private void BindRepository()
        {
            Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
         //   Bind<IRepository<User>>().To<GenericRepository<User>>();
        }

        /// <summary>
        /// Биндим логики на себя
        /// </summary>
        private void BindLogic()
        {

        }
    }
}