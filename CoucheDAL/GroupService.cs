using CoucheModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheDAL
{
   public  class GroupService
    {
        public static List<Groupe> getGroupes()
        {

            string str = @"Data Source=Issa; Initial Catalog=gestioncontact; Integrated security=True";
            List<Groupe> retour=new List<Groupe>();
            using(SqlConnection conn=new SqlConnection(str))
            { conn.Open();
            using(SqlCommand command=conn.CreateCommand())
            {
                command.CommandText = "select * from groupe;";
                using (SqlDataReader reader = command.ExecuteReader()) {

               if (reader.HasRows)
               {
                   while(reader.Read())
                       retour.Add(new Groupe(reader.GetInt32(0),reader.GetString(1)));
               }
                }
            }
            }
            return retour;
        }
    }
}
