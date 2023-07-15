using RentCar.Services;
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

namespace RentCar.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        Action<User> OnAuthSuccess = null;

        public Auth(Action<User> OnAuthSuccess)
        {
            InitializeComponent();
            this.OnAuthSuccess = OnAuthSuccess;
        }
        public async void OnSubmit(object sender, EventArgs e) {
            string username = UsernameInput.Text;
            string password = PasswordInput.Password;
            try {
                var user = await AuthService.Login(username, password);
                OnAuthSuccess(user);
            } catch (Exception) {
                MessageBox.Show("Nieprawidłowe dane. Sprawdź spójność danych.", "Nieprawidłowe dane.", MessageBoxButton.OKCancel);
                OnReset(sender, e);
            }
        }
        public void OnReset(object sender, EventArgs e) {
            UsernameInput.Text = String.Empty;
            PasswordInput.Password = String.Empty;
        }
    }
}
