﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheModel
{
    public class AddresseUser
    {
        public int AddresseID { get; set; }
        public int UserID { get; set; }
        public string Rue { get; set; }
        public string Num { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string Pays { get; set; }

        public AddresseUser() { }
    }
}
