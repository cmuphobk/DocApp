using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class OutpatientCard
    {
        public int Id { get; set; }

        public Patient Patient { get; set; }

        public List<Disease> Diseases { get; set; }
    } 
}
