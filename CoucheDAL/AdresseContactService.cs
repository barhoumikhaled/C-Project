using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheDAL;
using CoucheModel;
using System.Data.SqlClient;

namespace CoucheDAL
{
    public class AdresseContactService
    {
        static string str = @"Data Source=Issa; Initial Catalog=gestioncontact; Integrated security=True";

        public static AddresseContact GetAddress(int idContact)
        {
            AddresseContact UneAddresse; 

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select * from adressecontact where contactid = @id";

                    cmd.Parameters.Add(new SqlParameter("id", idContact));

                    UneAddresse = new AddresseContact();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UneAddresse.AddresseID = reader.GetInt32(0);
                            UneAddresse.ContactID = reader.GetInt32(1);
                            UneAddresse.Rue = reader.GetString(2);
                            UneAddresse.Num = reader.GetString(3);
                            UneAddresse.CodePostal = reader.GetString(4);
                            UneAddresse.Ville = reader.GetString(5);
                            UneAddresse.Province = reader.GetString(5);
                            UneAddresse.Pays = reader.GetString(5);
                        }
                    }
                }
            }
            return UneAddresse;
        }
    }
}
