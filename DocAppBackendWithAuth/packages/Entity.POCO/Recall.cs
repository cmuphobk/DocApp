using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Recall
    {
        public int Id { get; set; }

        public BaseUser caller { get; set; }

        public Hospital hospital { get; set; }

        public Doctor doctor { get; set; }
    }
}
