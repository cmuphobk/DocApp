using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DocAppBackendWithAuth.Common.Types
{
    public class ListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  IEnumerable<ListItem> Children { get; set; }

        //IdZone
        public int Metadata { get; set; }

        public bool IsGroup { get; set; }
    }
}
