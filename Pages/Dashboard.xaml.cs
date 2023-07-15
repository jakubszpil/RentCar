using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace RentCar.Pages {
    /// <summary>
    /// Logika interakcji dla klasy Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page {
        Action<string> Navigate;
        CollectionViewSource carsResource;

        public Dashboard(Action<string> Navigate) {
            InitializeComponent();
            this.Navigate = Navigate;
            this.carsResource = (CollectionViewSource)(FindResource("carsResource"));

            using (var context = new RentCarContext()) {
                context.Cars.Load();

                var localCars = context.Cars.Local;

                if (localCars.Count == 0) {
                    Table.Visibility = Visibility.Hidden;
                    TableInfo.Visibility = Visibility.Visible;
                } else {
                    this.carsResource.Source = localCars;
                }
            }
        }

        public void NavigateToCarForm(object sender, RoutedEventArgs e) {
            Navigate("CarForm");
        }

        public void RemoveCar(object sender, RoutedEventArgs e) {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Czy na pewno chcesz usunąć samochód z bazy?", 
                "Potwierdź akcję", 
                MessageBoxButton.YesNoCancel, 
                MessageBoxImage.Warning
            );

            if (messageBoxResult == MessageBoxResult.Yes) {
                short id = short.Parse(((Button)sender).Tag.ToString());

                using (var context = new RentCarContext())
                {
                    Car car = new Car() { Id = id };
                    context.Cars.Attach(car);
                    context.Cars.Remove(car);
                    context.SaveChanges();
                }

                Navigate("Dashboard");
            }

        }
    }
}
