using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheModel
{
    public class Utilisateur
    {
        public int UserId { get; set; }
        public string Nom { get; set; }
        public string PreNom { get; set; }
        public string Email { get; set; }
        public string Mdp { get; set; }
        public string Photo { get; set; }
        public AddresseUser UnAddresse { get; set; }

    }
}
