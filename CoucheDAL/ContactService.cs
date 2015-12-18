using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheModel;
using CoucheDAL;
using System.Data.SqlClient;
using System.Data;

namespace CoucheDAL
{
    public class ContactService
    {
        static string str = @"Data Source=Issa; Initial Catalog=gestioncontact; Integrated security=True";


        public static int AddContact(Contact unContact)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into contact(userid, nom, prenom, email, photo,groupId) OUTPUT INSERTED.contactid values('" + unContact.UserId + "','" + unContact.Nom + "','" + unContact.PreNom + "','" + unContact.Email + "','" + unContact.Photo +"',"+ unContact.Groupe.Id+")";

                    int insertedId = (int)cmd.ExecuteScalar();

                    cmd.CommandText = "insert into adressecontact(contactid, rue, num, codepostal, ville, province, pays) values('" + insertedId + "','" + unContact.UnAddresse.Rue + "','" + unContact.UnAddresse.Num + "','" + unContact.UnAddresse.CodePostal + "','" + unContact.UnAddresse.Ville + "','" + unContact.UnAddresse.Province + "','" + unContact.UnAddresse.Pays + "')";
                    cmd.ExecuteNonQuery();

                    return insertedId;
                }
            }
        }


        public static List<Contact> SearchContact(string nom)
        {
            List<Contact> MesContacts = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //@toto, @name, @international ==> placeholder pour les parametres de la requetes
                    cmd.CommandText = @"select * from contact where nom like @nom";

                    cmd.Parameters.Add(new SqlParameter("nom", "%" + nom + "%"));


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contact ct = new Contact();
                            //recuperer un stu avec l'objet reader

                            ct.ContactID = reader.GetInt32(0);
                            ct.UserId = reader.GetInt32(1);
                            ct.Nom = reader.GetString(2);
                            ct.PreNom = reader.GetString(3);
                            ct.Email = reader.GetString(4); 
                            ct.Photo = reader.GetString(6);
                            ct.Groupe.Id = reader.GetInt32(5);
                            MesContacts.Add(ct);
                        }
                    }
                }
            }
            return MesContacts;
        }


        public static List<Contact> GetContactByGroup(int id)
        {
            List<Contact> MesContacts = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //@toto, @name, @international ==> placeholder pour les parametres de la requetes
                    cmd.CommandText = @"select * from contact where groupId = @groupId";

                    cmd.Parameters.Add(new SqlParameter("groupId", id));


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contact ct = new Contact();
                            //recuperer un stu avec l'objet reader

                            ct.ContactID = reader.GetInt32(0);
                            ct.UserId = reader.GetInt32(1);
                            ct.Nom = reader.GetString(2);
                            ct.PreNom = reader.GetString(3);
                            ct.Email = reader.GetString(4);
                            ct.Photo = reader.GetString(6);
                            ct.Groupe.Id = reader.GetInt32(5);
                            MesContacts.Add(ct);
                        }
                    }
                }
            }
            return MesContacts;
        }


        public static void DelateContact(Contact unContact)
        {
            //string str = @"Data Source=Issa; Initial Catalog=gestioncontact; Integrated security=True";
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //using (SqlTransaction st = conn.BeginTransaction())
                    {
                        cmd.Parameters.Add(new SqlParameter("contactid", unContact.ContactID));
                        cmd.CommandText = "DELETE from adressecontact where contactid=@contactid";
                        cmd.ExecuteNonQuery();
                        
                        cmd.CommandText = "DELETE from activities where id_contact=@contactid";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "DELETE from contact where contactid=@contactid";
                        cmd.ExecuteNonQuery();

                        //st.Commit();
                    }



                }
            }
        }



        public static bool UpdateContact(Contact unContact)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //using (SqlTransaction st = conn.BeginTransaction())
                    {
                        cmd.CommandText = "update contact set userid=@userid, nom=@nom, prenom=@prenom, email=@email, photo=@photo where contactid=@contactid";
                        cmd.Parameters.Add(new SqlParameter("userid", unContact.UserId));
                        cmd.Parameters.Add(new SqlParameter("nom", unContact.Nom));
                        cmd.Parameters.Add(new SqlParameter("prenom", unContact.PreNom));
                        cmd.Parameters.Add(new SqlParameter("email", unContact.Email));
                        cmd.Parameters.Add(new SqlParameter("photo", unContact.Photo));
                        cmd.Parameters.Add(new SqlParameter("contactid", unContact.ContactID));

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "update adressecontact set contactid=@id, rue=@rue, num=@num, codepostal=@codepostal, ville=@ville, province=@province, pays=@pays where contactid=@id";
                        cmd.Parameters.Add(new SqlParameter("id", unContact.ContactID));
                        cmd.Parameters.Add(new SqlParameter("rue", unContact.UnAddresse.Rue));
                        cmd.Parameters.Add(new SqlParameter("num", unContact.UnAddresse.Num));
                        cmd.Parameters.Add(new SqlParameter("codepostal", unContact.UnAddresse.CodePostal));
                        cmd.Parameters.Add(new SqlParameter("ville", unContact.UnAddresse.Ville));
                        cmd.Parameters.Add(new SqlParameter("province", unContact.UnAddresse.Province));
                        cmd.Parameters.Add(new SqlParameter("pays", unContact.UnAddresse.Pays));
                        //cmd.Parameters.Add(new SqlParameter("id", unContact.ContactID));

                        cmd.ExecuteNonQuery();
                        result = true;
                        //     st.Commit();
                    }

                }
             }
            return result;
        }


        public static List<Contact> GetMesContact(int iduser)
        {
            List<Contact> MesContacts = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //@toto, @name, @international ==> placeholder pour les parametres de la requetes
                    cmd.CommandText = @"select * from contact where userid = @id";

                    cmd.Parameters.Add(new SqlParameter("id", iduser));


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contact ct = new Contact();
                            //recuperer un stu avec l'objet reader

                            ct.ContactID = reader.GetInt32(0);
                            ct.UserId = reader.GetInt32(1);
                            ct.Nom = reader.GetString(2);
                            ct.PreNom = reader.GetString(3);
                            ct.Email = reader.GetString(4);
                            
                            ct.Photo = reader.GetString(6);
                            ct.Groupe.Id = reader.GetInt32(5);

                            MesContacts.Add(ct);
                        }
                    }
                }
            }



            return MesContacts;
        }


    }
}
