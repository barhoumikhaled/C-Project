using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheModel
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Groupe() { }
        public Groupe(int Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
