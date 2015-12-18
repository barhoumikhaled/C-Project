using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheModel;
using CoucheDAL;

namespace CoucheBLL
{
    public class AddresseContactManager
    {
        public static AddresseContact GetAddress(int id)
        {
            return AdresseContactService.GetAddress(id);
        }
    }
}
