using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Weight
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Symptom
        /// </summary>
        public Symptom Key { get; set; }

        /// <summary>
        /// weight
        /// </summary>
        public int Value { get; set; }

        public Weight()
        {

        }

        public Weight(Symptom _symptom, int _weight)
        {
            Key = _symptom;
            Value = _weight;
        }
    }
}
