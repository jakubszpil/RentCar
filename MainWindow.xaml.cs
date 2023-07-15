using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using RentCar.Pages;
using RentCar.Properties;
using RentCar.UIComponents;

namespace RentCar
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void Navigate(string route) {
            switch(route)
            {
                case "Dashboard":
                    RouterView.Content = new Dashboard(Navigate);
                    break;
                case "Rents":
                    RouterView.Content = new Rents(Navigate);
                    break;
                case "CarForm":
                    RouterView.Content = new CarForm(Navigate);
                    break;
                case "RentForm":
                    RouterView.Content = new RentForm(Navigate);
                    break;
            }
        }

        public void OnAuthSuccess(User user)
        {
            RouterView.Content = new Dashboard(Navigate);
            Navbar.Content = new Navbar(user, OnLogout, Navigate);
        }

        public void OnLogout()
        {
            RouterView.Content = new Auth(OnAuthSuccess);
            Navbar.Content = null;
        }

        public MainWindow()
        {
            InitializeComponent();
           
            DataContext = this;
            RouterView.Content = new Auth(OnAuthSuccess);
        }
    }
}
