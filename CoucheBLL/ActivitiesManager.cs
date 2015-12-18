using CoucheDAL;
using CoucheModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheBLL
{
    public class ActivitiesManager
    {
        public static List<Activities> getActivities(int id)
        {
            return ActivitiesServices.getActivities(id);
        }

        public static void addActivity(Activities act)
        { ActivitiesServices.addActivity(act); }
    }
}
