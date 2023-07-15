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

namespace RentCar.UIComponents
{
    /// <summary>
    /// Logika interakcji dla klasy Navbar.xaml
    /// </summary>
    public partial class Navbar : UserControl { 


        public Action OnLogout = null;
        public Action<string> OnRouteChange = null;

        public Navbar(User user, Action OnLogout, Action<string> OnRouteChange)
        {
            InitializeComponent();
            this.OnLogout = OnLogout;
            this.OnRouteChange = OnRouteChange;
            UserNameLabel.Text = user.Username;
        }

        public void OnSignOut(object sender, EventArgs e)
        {
            OnLogout();
        }

        public void OnMenuButtonClick(object sender, EventArgs e)
        {
            string route = ((Button)sender).Tag.ToString();
            OnRouteChange(route);
        }
    }
}
