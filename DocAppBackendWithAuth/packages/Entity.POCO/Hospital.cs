using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Hospital
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public List<Recall> Recalls { get; set; }
    }
}
