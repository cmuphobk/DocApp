using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Common.Types
{
    public class Interfaces
    {
        /// <summary>
        /// Имя родительского интерфейса
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Имя экшона родительского интерфейса
        /// </summary>
        public string NameAction { get; set; }
        /// <summary>
        /// Имя контроллера родительского интерфейса
        /// </summary>
        public string NameController { get; set; }
        /// <summary>
        /// Роли родительского интерфейса
        /// </summary>
        public List<Role> Roles { get; set; }
        /// <summary>
        /// Потомки родительского интерфейса
        /// </summary>
        public List<KeyValuePair<string, string>> Descendants { get; set; }
    }
}
