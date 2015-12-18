using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheModel
{
    public class Contact
    {

        public int ContactID { get; set; }
        public int UserId { get; set; }
        public string Nom { get; set; }
        public string PreNom { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public Groupe Groupe { get; set; }
        public AddresseContact UnAddresse { get; set; }
        public Contact()
        {
            Groupe = new Groupe();
        }
    }
}
