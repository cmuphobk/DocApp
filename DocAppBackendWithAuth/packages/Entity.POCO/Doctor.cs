using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Speciality { get; set; }

        public BaseUser User { get; set; }

        public Hospital Hospital { get; set; }

        public List<Recall> recalls { get; set; }

        public List<Disease> diseases { get; set; }
    }
}
