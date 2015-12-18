using CoucheBLL;
using CoucheModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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


namespace CoucheVue
{
    /// <summary>
    /// Logique d'interaction pour AjouterActivities.xaml
    /// </summary>
    public partial class AjouterActivities : MetroWindow
    {
        private ProfilUser interfaceUser;
        public List<Contact> MesContacts { get; set; }
        Activities activite;
        public AjouterActivities()
        {
            InitializeComponent();
        }
        public AjouterActivities(ProfilUser interfaceUser)
        {
            InitializeComponent();
            this.interfaceUser = interfaceUser;
            activite = new Activities();


        }

        private async void sauvegarde_Click(object sender, RoutedEventArgs e)
        {
            activite.IdUser = interfaceUser.UnUser.UserId;
            activite.Date = Convert.ToDateTime(date.Value.ToString());
            ActivitiesManager.addActivity(activite);
            await this.ShowMessageAsync("Notifications", "L'activité a été ajouté");
            this.Close();
            interfaceUser.mesActivities = ActivitiesManager.getActivities(interfaceUser.UnUser.UserId);
            interfaceUser.ActivityDateGrid.ItemsSource = interfaceUser.mesActivities;
            interfaceUser.IsEnabled = true;
        }



        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            interfaceUser.IsEnabled = true;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = activite;
            MesContacts = interfaceUser.MesContacts;
            contacts.ItemsSource = MesContacts;
        }

        private void contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            activite.IdContact = ((Contact)contacts.SelectedItem).ContactID;
        }



    }
}
