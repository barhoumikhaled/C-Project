using CoucheDAL;
using CoucheModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheBLL
{
    public class GroupeManager
    {
        public static List<Groupe> getGroupes()
        {
            return GroupService.getGroupes();
        }
    }
}
