using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Href
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }
    }
}
