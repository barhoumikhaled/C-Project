using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CoucheBLL;
using CoucheModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Net.Mail;
using System.Text.RegularExpressions;


namespace CoucheVue
{
    /// <summary>
    /// Logique d'interaction pour InscriptionUser.xaml
    /// </summary>
    public partial class InscriptionUser : MetroWindow
    {
        public Utilisateur MonUtilisateur;
        public AddresseUser UserAddress;
        public InscriptionUser()
        {
            InitializeComponent();
            MonUtilisateur = new Utilisateur();
            UserAddress = new AddresseUser();
            MonUtilisateur.UnAddresse = UserAddress;
            DataContext = MonUtilisateur;
        }

        private async void inscription(object sender, RoutedEventArgs e)
        {
            int a = UtilisateurManager.addUser(MonUtilisateur);
            if (a > 0)
            {
                await this.ShowMessageAsync("Inscription Success ", " Votre Compte est ajoute avec success");
                this.Close();
            }
            
        }





        private void nom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nom.Text == "")
            {
                Label_nom.Content = "Cahmp Nom Obligatoire";
            }
            else Label_nom.Content = "";
        }

        private void prenom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prenom.Text == "")
            {
                Label_prenom.Content = "Cahmp Prenom Obligatoire";
            }
            else Label_prenom.Content = "";
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            string emailToTest;
            
            if (email.Text == "")
            {
                Label_Email.Content = "Cahmp Email Obligatoire";
            }
            else
            {
                if (IsValid(email.Text))
                {
                    emailToTest = email.Text;
                    Utilisateur ct = UtilisateurManager.IsExisteUser(emailToTest);
                    if (ct.Email != null)
                    {
                        Label_Email.Content = "Email Deja utilise !";
                    }
                    else Label_Email.Content = "";
                }
                else Label_Email.Content = "Format Email Invalid";
            }
        }

        private void mdp_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Mdp.Text == "")
            {
                Label_MotDePasse.Content = "Cahmp Mot de passe Obligatoire";
            }
            else Label_MotDePasse.Content = "";
        }

        private void rue_LostFocus(object sender, RoutedEventArgs e)
        {
            if (rue.Text == "")
            {
                Label_rue.Content = "Cahmp Rue Obligatoire";
            }
            else Label_rue.Content = "";
        }
        private void numero_LostFocus(object sender, RoutedEventArgs e)
        {
            if (numero.Text == "")
            {
                Label_numero.Content = "Cahmp Numero Obligatoire";
            }
            else Label_numero.Content = "";
        }
        private void codepostal_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex r = new Regex("[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]");
            if (codepostal.Text == "")
            {
                Label_codePostal.Content = "Cahmp Code postal Obligatoire";
            }

            else
            {
                if (r.IsMatch(codepostal.Text))
                {
                    Label_codePostal.Content = "";
                }
                else Label_codePostal.Content = "Code Postal doit etre comme cette forme A3A3A3";
            }
                
        }



        private void ville_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ville.Text == "")
            {
                Label_Ville.Content = "Cahmp Ville Obligatoire";
            }
            else Label_Ville.Content = "";
        }
        private void province_LostFocus(object sender, RoutedEventArgs e)
        {
            if (province.Text == "")
            {
                Label_province.Content = "Cahmp Province Obligatoire";
            }
            else Label_province.Content = "";
        }

        private void pays_LostFocus(object sender, RoutedEventArgs e)
        {


            if (pays.Text == "")
            {
                Label_pays.Content = "Cahmp Pays Obligatoire";
            }
            else Label_pays.Content = "";


            if (nom.Text != "" && prenom.Text != "" && email.Text != "" && Mdp.Text != "" && rue.Text != "" &&
                numero.Text != "" && codepostal.Text != ""
                && ville.Text != "" && province.Text != "" && pays.Text != "")
            {
                Inscrire.IsEnabled = true;
            }
            else
                Inscrire.IsEnabled = false;
        }

        private void pays_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nom.Text != "" && prenom.Text != "" && email.Text != "" && Mdp.Text != "" && rue.Text != "" &&
                numero.Text != "" && codepostal.Text != ""
                && ville.Text != "" && province.Text != "" && pays.Text != "")
            {
                Inscrire.IsEnabled = true;
            }
            else
                Inscrire.IsEnabled = false;
        }


    }
}
