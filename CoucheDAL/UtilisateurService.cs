using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheModel;

namespace CoucheDAL
{
    public class UtilisateurService
    {

        public static int AddUserr(Utilisateur unUser)
        {
            string str = @"Data Source=Issa; Initial Catalog=gestioncontact; Integrated security=True";
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into utilisateur(nom, prenom, email, mdp, photo) OUTPUT INSERTED.userid values('" + unUser.Nom + "','" + unUser.PreNom + "','" + unUser.Email + "','" + unUser.Mdp + "','" + unUser.Photo + "')";
                    cmd.ExecuteNonQuery();
                    int insertedId = (int)cmd.ExecuteScalar();

                    cmd.CommandText = "insert into adresseuser(userid, rue, num, codepostal, ville, province, pays) values('" + insertedId + "','" + unUser.UnAddresse.Rue + "','" + unUser.UnAddresse.Num + "','" + unUser.UnAddresse.CodePostal + "','" + unUser.UnAddresse.Ville + "','" + unUser.UnAddresse.Province + "','" + unUser.UnAddresse.Pays + "')";
                    cmd.ExecuteNonQuery();

                    return insertedId;
                }
            }
        }


        public static Utilisateur IsExisteUser(string nom)
        {
            string str = @"Data Source=Issa; Initial Catalog=gestioncontact; Integrated security=True";
            Utilisateur User = new Utilisateur();
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"select * from utilisateur where email = @email";
                    cmd.Parameters.Add(new SqlParameter("email", nom));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //User = new Utilisateur();
                            //recuperer un stu avec l'objet reader
                            User.UserId = reader.GetInt32(0);
                            User.Nom = reader.GetString(1);
                            User.PreNom = reader.GetString(2);
                            User.Email = reader.GetString(3);
                            User.Mdp = reader.GetString(4);
                            User.Photo = reader.GetString(5);
                        }
                        return User;
                    }
                }
            }
        }

        public static Utilisateur IsUser(Utilisateur unUser)
        {
            string str = @"Data Source=Issa; Initial Catalog=gestioncontact; Integrated security=True";
            Utilisateur User = new Utilisateur();
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"select * from utilisateur where email = @email and
                    mdp= @mdp";
                    cmd.Parameters.Add(new SqlParameter("email", unUser.Email));
                    cmd.Parameters.Add(new SqlParameter("mdp", unUser.Mdp));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //User = new Utilisateur();
                            //recuperer un stu avec l'objet reader
                            User.UserId = reader.GetInt32(0);
                            User.Nom = reader.GetString(1);
                            User.PreNom = reader.GetString(2);
                            User.Email = reader.GetString(3);
                            User.Mdp = reader.GetString(4);
                            User.Photo = reader.GetString(5);
                        }
                        return User;
                    }
                }
            }
        }




    }
}
