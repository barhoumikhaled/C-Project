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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoucheModel;
using CoucheBLL;
using MahApps.Metro.Controls;

namespace CoucheVue
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public Utilisateur MonUtilisateur;

        public MainWindow()
        {

            InitializeComponent();
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            if (password.Text != "" && login.Text != "" && login.Foreground != Brushes.Gray && password.Foreground != Brushes.Gray)
            {
                connect.IsEnabled = true;
                connect.Style = this.Resources["connectStyle"] as Style;
            }
            if (login.Foreground == Brushes.Gray)
            { login.BorderBrush = Brushes.Red; }

            if (password.Foreground == Brushes.Gray)
            {
                password.Text = "";
                password.Foreground = Brushes.Black;
            }

        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Password";
                password.Foreground = Brushes.Gray;
            }
        }

        private void Login_GotFocus(object sender, RoutedEventArgs e)
        {
            if (password.Text != "" && login.Text != "" && login.Foreground != Brushes.Gray && password.Foreground != Brushes.Gray)
            {
                connect.IsEnabled = true;
                connect.Style = this.Resources["connectStyle"] as Style;
            }
            if (login.Foreground == Brushes.Gray)
            {
                login.Text = "";
                login.Foreground = Brushes.Black;
            }
            /*  if (password.Foreground == Brushes.Gray)
              { password.BorderBrush = Brushes.Red; }*/

        }

        private void Login_LostFocus(object sender, RoutedEventArgs e)
        {
            if (login.Text == "")
            {
                login.Text = "Login";
                login.Foreground = Brushes.Gray;

            }
        }

        private void connexion(object sender, RoutedEventArgs e)
        {
            MonUtilisateur = new Utilisateur();
            MonUtilisateur.Email = login.Text;
            MonUtilisateur.Mdp = password.Text;
            DataContext = MonUtilisateur;
            Utilisateur userToTest = UtilisateurManager.IsUser(MonUtilisateur);
            if (MonUtilisateur.Email == userToTest.Email && MonUtilisateur.Mdp == userToTest.Mdp)
            {
                ProfilUser profil = new ProfilUser();
                profil.UnUser = userToTest;
                profil.Show();
                this.Close();
                //AjoutContact winProfil = new AjoutContact();
                //winProfil.UnUser = userToTest;
                //winProfil.Show();
            }
        }

        private void Login_TextChange(object sender, TextChangedEventArgs e)
        {
            if (login != null && password != null)
            {
                if (login.Foreground == Brushes.Gray)
                {
                    login.Text = "";
                    login.Foreground = Brushes.Black;
                }

                if (password.Foreground == Brushes.Gray)
                { password.BorderBrush = Brushes.Red; }

                if (password.Text != "" && login.Text != "" && login.Foreground != Brushes.Gray && password.Foreground != Brushes.Gray)
                {
                    connect.IsEnabled = true;
                    connect.Style = this.Resources["connectStyle"] as Style;
                }
            }


        }

        private void Password_TextChange(object sender, TextChangedEventArgs e)
        {

            if (login != null && password != null)
            {
                if (password.Text != "" && login.Text != "" && login.Foreground != Brushes.Gray && password.Foreground != Brushes.Gray)
                {
                    connect.IsEnabled = true;
                    connect.Style = this.Resources["connectStyle"] as Style;
                }
                if (login.Foreground == Brushes.Gray)
                { login.BorderBrush = Brushes.Red; }

                if (password.Foreground == Brushes.Gray)
                {
                    password.Text = "";
                    password.Foreground = Brushes.Black;
                }
            }

        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            InscriptionUser IU = new InscriptionUser();
            IU.Show();
            //this.Hide();
            //this.Close();

        }


    }
}
