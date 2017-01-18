using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Ninject.Extensions.Xml;
using Ninject.Modules;
using Ninject.Parameters;

namespace DocAppBackendWithAuth.Common.IoCContainer
{
    public static class IoCContainer
    {
        private static readonly Lazy<StandardKernel> _kernel;

        /// <summary>
        ///     Инициализация ядра Ninject
        /// </summary>
        static IoCContainer()
        {
            _kernel =
                new Lazy<StandardKernel>(
                    () => new StandardKernel(new NinjectSettings {LoadExtensions = false}, new XmlExtensionModule()),
                    true);
        }

        /// <summary>
        ///     Ядро биндинга Ninject через XML конфигурацию
        /// </summary>
        public static TValue Get<TValue>()
        {
             return _kernel.Value.Get<TValue>(); 
        }

        /// <summary>
        /// Возвращает текущую реализацию для интерфейса или абстрактного класса
        /// </summary>
        /// <returns></returns>
        public static TEntity Get<TEntity>(ParamType type, string paramName, object paramValue)
        {

            TEntity element;
            switch (type)
            {
                case ParamType.Metadata:
                    element = _kernel.Value.Get<TEntity>(x => x.Get<string>(paramName) == paramValue.ToString());
                    break;
                case ParamType.ConstructorArgiment:
                    element = _kernel.Value.Get<TEntity>(new IParameter[] { new ConstructorArgument(paramName, paramValue) });
                    break;
                default:
                    throw new NotImplementedException();
            }
            
            return element;
        }


        /// <summary>
        ///     Ядро биндинга Ninject через XML конфигурацию
        /// </summary>
        public static IEnumerable<TValue> GetAll<TValue>()
        {
            return _kernel.Value.GetAll<TValue>();
        }

        public static void Bind(Type source, Type target, string paramName, string paramValue)
        {
            _kernel.Value.Bind(source).To(target).WithMetadata(paramName, paramValue);
        }

        public static void Bind(Type source, Type target)
        {
            _kernel.Value.Bind(source).To(target);
        }

        public static void Bind(Type source, object target, string paramName, string paramValue)
        {
            _kernel.Value.Bind(source).ToConstant(target).WithMetadata(paramName, paramValue);
        }

        private static readonly object Xmllocker = new object();
        /// <summary>
        /// Загружаем один xml ninject module
        /// </summary>
        public static void Load(string moduleName, string filePath)
        {
            lock (Xmllocker)
            {
                if (_kernel.Value.GetModules().All(t => t.Name != moduleName))
                {
                    _kernel.Value.Load(new[]
                        {
                            filePath
                        });
                }                
            }

        }

        private static readonly object OneModuleLocker = new object();
        /// <summary>
        /// Загружаем еще один Ninject-модуль
        /// </summary>
        /// <param name="module">модуль</param>
        public static void Load(INinjectModule module)
        {
            lock (OneModuleLocker)
            {
                if (_kernel.Value.GetModules().All(t => t.Name != module.GetType().FullName))
                {
                    _kernel.Value.Load(new[]
                        {
                            module
                        });
                }                
            }

        }

        private static readonly object ManyModuleLocker = new object();
        /// <summary>
        /// Загружаем еще коллекцию Ninject-модулей
        /// </summary>
        /// <param name="modules">Коллекция модулей</param>
        public static void Load(IEnumerable<INinjectModule> modules)
        {
            var result = new List<INinjectModule>();

            lock (ManyModuleLocker)
            {
                foreach (var module in modules)
                {
                    if (_kernel.Value.GetModules().All(t => t.Name != module.GetType().FullName))
                    {
                        result.Add(module);
                    }                
                }                
            }

            if (result.Any())
            {
                _kernel.Value.Load(result);
            }
        }


    }
}