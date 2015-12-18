using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheModel
{
    public class Activities
    {
        public int ID { get; set; }
        public int IdUser { get; set; }
        public int IdContact { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
