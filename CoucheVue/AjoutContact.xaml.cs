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
using CoucheModel;
using CoucheBLL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace CoucheVue
{
    /// <summary>
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class AjoutContact : MetroWindow
    {
        string photo;
        Contact unContact;
        AddresseContact ContactAddress;
        List<Groupe> groupes;
        public Utilisateur UnUser { get; set; }


        public AjoutContact()
        {
            InitializeComponent();
            unContact = new Contact();
            ContactAddress = new AddresseContact();
            //unContact.UserId = UnUser.UserId;
            unContact.UnAddresse = ContactAddress;
            DataContext = unContact;
            groupes = GroupeManager.getGroupes();
        }

        private async void AjouterContact_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            //unContact = new Contact();
            //ContactAddress = new AddresseContact();
            //unContact.UserId = UnUser.UserId;
            //unContact.UnAddresse = ContactAddress;
            //DataContext = unContact;

            //ContactManager.GetMesContact();
            if (photo != null)
            {
                string DirDebug = System.IO.Directory.GetCurrentDirectory();
                int index = DirDebug.IndexOf("bin");
                string path = DirDebug.Substring(0, index);
                string destFile = path + "photo\\" + unContact.Email + ".jpg";
                System.IO.File.Copy(photo, destFile, true);
                unContact.Photo = destFile;
            }
            
            unContact.UserId = UnUser.UserId;
            int a=ContactManager.addContact(unContact);
            if (a > 0)
            {
                await this.ShowMessageAsync("Ajout de Contact Success", " Votre Contact est ajoute avec success !");
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

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (email.Text == "")
            {
                Label_Email.Content = "Cahmp Email Obligatoire";
            }
            else Label_Email.Content = "";
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
            if (codepostal.Text == "")
            {
                Label_codePostal.Content = "Cahmp Code postal Obligatoire";
            }
            else Label_codePostal.Content = "";
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


            if (nom.Text != "" && prenom.Text != "" && email.Text != "" && rue.Text != "" &&
                numero.Text != "" && codepostal.Text != ""
                && ville.Text != "" && province.Text != "" && pays.Text != "")
            {
                AjouterContact.IsEnabled = true;
            }
            else
                AjouterContact.IsEnabled = false;
        }

        private void pays_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nom.Text != "" && prenom.Text != "" && email.Text != "" && rue.Text != "" &&
                numero.Text != "" && codepostal.Text != ""
                && ville.Text != "" && province.Text != "" && pays.Text != "")
            {
                AjouterContact.IsEnabled = true;
            }
            else
                AjouterContact.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            groupebox.ItemsSource = groupes;
            
            
            
        }

        private void groupebox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unContact.Groupe = (Groupe)groupebox.SelectedItem;
            //MessageBox.Show(unContact.Groupe.Name);
        }

        private void photo_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                photo = dlg.FileName;
                
            }
        }

     

    }
}
