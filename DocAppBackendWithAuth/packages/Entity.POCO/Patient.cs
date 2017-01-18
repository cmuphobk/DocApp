using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Patient
    {
        public int Id { get; set; }

        public BaseUser User { get; set; }

    }
}
