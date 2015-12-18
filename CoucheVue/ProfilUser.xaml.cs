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
    /// Logique d'interaction pour ProfilUser.xaml
    /// </summary>
    /// 
    class SortContactByName : IComparer<Contact>
    {
        public int Compare(Contact p1, Contact p2)
        {
            return p1.Nom.CompareTo(p2.Nom);
        }
    }

    class SortGroupByName : IComparer<Groupe>
    {
        public int Compare(Groupe p1, Groupe p2)
        {
            return p1.Name.CompareTo(p2.Name);
        }
    }
    public partial class ProfilUser:MetroWindow
    {
        public Utilisateur UnUser { get; set; }
        public List<Contact> MesContacts;
        public List<Groupe> MesGroupes;

        public List<Activities> mesActivities { get; set; }
        public Contact UnContact;
        public int ContactID;
        public int UserID;
        public int AddresseID;
        public string photodow="";

        public ProfilUser()
        {
            InitializeComponent();
        }

        private void ContactAjout_Click(object sender, RoutedEventArgs e)
        {
            AjoutContact ajoutContact = new AjoutContact();
            ajoutContact.UnUser = UnUser;
            ajoutContact.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MesContacts = new List<Contact>();
            MesContacts = ContactManager.GetMesContact(UnUser.UserId);
            SortContactByName scbn = new SortContactByName();
            MesContacts.Sort(scbn);
            MesGroupes = GroupeManager.getGroupes();
            SortGroupByName sgbn = new SortGroupByName();
            MesGroupes.Sort(sgbn);
            listGroupe.ItemsSource = MesGroupes;
            listContact.ItemsSource = MesContacts;

            mesActivities = ActivitiesManager.getActivities(UnUser.UserId);
            ActivityDateGrid.ItemsSource = mesActivities;
        }

        private void ajouter_activities_click(object sender, RoutedEventArgs e)
        {
            AjouterActivities ajout = new AjouterActivities(this);
            ajout.Show();
            
            this.IsEnabled = false;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nom.IsEnabled = false;
            prenom.IsEnabled = false;
            email.IsEnabled = false;
            photo.IsEnabled = false;
            rue.IsEnabled = false;
            numero.IsEnabled = false;
            codepostal.IsEnabled = false;
            ville.IsEnabled = false;
            province.IsEnabled = false;
            pays.IsEnabled = false;
            mettreAJour.IsEnabled = false;
            
            ListBox lb = (ListBox)sender;
            
            UnContact = (Contact)lb.SelectedItem;
            if (UnContact != null)
            {
                if (UnContact.Photo != "")
                    Contact_photo.Source = new BitmapImage(new Uri(UnContact.Photo));
                else
                {
                    string DirDebug = System.IO.Directory.GetCurrentDirectory();
                    int index = DirDebug.IndexOf("bin");
                    string path = DirDebug.Substring(0, index);
                    path += "\\Resources\\default_profile.png";
                    Contact_photo.Source = new BitmapImage(new Uri(path));
                }
                AddresseContact addC = AddresseContactManager.GetAddress(UnContact.ContactID);
                UnContact.UnAddresse = addC;
                DataContext = UnContact;
                ContactID = UnContact.ContactID;
                UserID = UnContact.UserId;
                AddresseID = UnContact.UnAddresse.AddresseID;
            }
            
            MesContacts = ContactManager.GetMesContact(UnUser.UserId);
            SortContactByName scbn = new SortContactByName();
            MesContacts.Sort(scbn);
            listContact.ItemsSource = MesContacts;
            
        }

        private void Editer_Button_Click(object sender, RoutedEventArgs e)
        {
            nom.IsEnabled = true;
            prenom.IsEnabled = true;
            email.IsEnabled = true;
            photo.Visibility = Visibility.Visible;
            photoLabel.Visibility = Visibility.Visible;
            rue.IsEnabled = true;
            numero.IsEnabled = true;
            codepostal.IsEnabled = true;
            ville.IsEnabled = true; 
            province.IsEnabled = true;
            pays.IsEnabled = true;
            mettreAJour.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContactManager.downloadContacts(UnUser.UserId) == -1)
                MessageBox.Show("Erreur lors du téléchargement du fichier");
        }

        private async void  mettreAJour_Click(object sender, RoutedEventArgs e)
        {
           // UnContact = (Contact)sender;
            UnContact = new Contact();
            AddresseContact adc = new AddresseContact();
            UnContact.UnAddresse = new AddresseContact();
            UnContact.UserId = UserID;
            UnContact.ContactID = ContactID;
            UnContact.Email = email.Text;
            UnContact.Nom = nom.Text;
            UnContact.PreNom = prenom.Text;
            UnContact.Photo = photodow;
            UnContact.UnAddresse.AddresseID = AddresseID;
            UnContact.UnAddresse.CodePostal = codepostal.Text;
            UnContact.UnAddresse.ContactID = ContactID;
            UnContact.UnAddresse.Num = numero.Text;
            UnContact.UnAddresse.Rue = rue.Text;
            UnContact.UnAddresse.Ville = ville.Text;
            UnContact.UnAddresse.Province = province.Text;
            UnContact.UnAddresse.Pays = pays.Text;
            Contact un = UnContact;

            if (ContactManager.UpdateContact(UnContact))
            {
                await this.ShowMessageAsync("Mis a jour", "Votre Mis a jour est faite avec Success !");
                //this.Close();
            }
            
        }

        private void photo_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            { 
                photodow = dlg.FileName; 
            }
        }



        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            UnContact = new Contact();
            UnContact.ContactID = ContactID;
            ContactManager.DeleteContact(UnContact);
            MesContacts = new List<Contact>();
            MesContacts = ContactManager.GetMesContact(UnUser.UserId);
            listContact.ItemsSource = MesContacts;

        }

        private void Search_Button_Click_1(object sender, RoutedEventArgs e)
        {
            MesContacts = ContactManager.SearchContact(search.Text);
            listContact.ItemsSource = MesContacts;
        }

        private void listGroupe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            Groupe gr = (Groupe)lb.SelectedItem;
            listContact.ItemsSource = ContactManager.GetContactByGroup(gr.Id);
            
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            mesActivities = ActivitiesManager.getActivities(UnUser.UserId);
            ActivityDateGrid.ItemsSource = mesActivities;
        }
    }



    


}
