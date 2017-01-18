using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Disease
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Symptom> Symptoms { get; set; }

        public Diagnos Diagnos { get; set; }

        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        public DateTime dateDisease { get; set; }

        public OutpatientCard Card { get; set; }
    }
}
