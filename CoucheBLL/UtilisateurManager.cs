using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheModel;
using CoucheDAL;

namespace CoucheBLL
{
    public class UtilisateurManager
    {
        public static int addUser(Utilisateur unUser)
        {
            int indice = UtilisateurService.AddUserr(unUser);
            return indice;

        }

        public static Utilisateur IsUser(Utilisateur unUser)
        {

            return UtilisateurService.IsUser(unUser);

        }


        public static Utilisateur IsExisteUser(string nom)
        {

            return UtilisateurService.IsExisteUser(nom);

        }

    }
}
