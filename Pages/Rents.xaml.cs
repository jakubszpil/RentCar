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
    /// Logika interakcji dla klasy Rents.xaml
    /// </summary>
    public partial class Rents : Page
    {
        Action<string> Navigate;
        public Rents(Action<string> Navigate)
        {
            InitializeComponent();
            this.Navigate = Navigate;
        }
    }
}
