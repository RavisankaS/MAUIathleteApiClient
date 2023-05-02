using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSIRIWARDENAGE1_Test3.Models
{
    public class Sport
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Sport> Sports { get; set; }  = new HashSet<Sport>();
    }
}
