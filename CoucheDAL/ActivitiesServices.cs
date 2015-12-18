using CoucheModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheDAL
{
    public class ActivitiesServices
    {
        private static string str = @"Data Source=Issa; Initial Catalog=gestioncontact; Integrated security=True";
        public static List<Activities> getActivities(int id)
        {
            List<Activities> retour = new List<Activities>();
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //@toto, @name, @international ==> placeholder pour les parametres de la requetes
                    cmd.CommandText = @"select * from activities where id_user=@id;";

                    cmd.Parameters.Add(new SqlParameter("id", id));


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Activities act = new Activities();
                            act.ID = reader.GetInt32(0);
                            act.Name = reader.GetString(1);
                            act.Description = reader.GetString(2);
                            act.IdContact = reader.GetInt32(3);
                            act.IdUser = reader.GetInt32(4);
                            act.Date = reader.GetDateTime(5);
                            retour.Add(act);
                        }
                    }
                }
            }
            return retour;
        }

        public static void addActivity(Activities act)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT into activities values('" + act.Name + "','" + act.Description + "'," + act.IdContact + "," +
                        act.IdUser + ",'" + act.Date + "')";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
