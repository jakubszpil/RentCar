using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace RentCar.Pages {
    /// <summary>
    /// Logika interakcji dla klasy Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page {
        Action<string> Navigate;

        public Dashboard(Action<string> Navigate) {
            InitializeComponent();
            this.Navigate = Navigate;

            using (var context = new RentCarContext()) {
                List<Car> cars = context.Cars.ToList();

                if (cars.Count == 0)  {
                    Table.Visibility = Visibility.Hidden;
                    TableInfo.Visibility = Visibility.Visible;
                } else {
                    CarsList.ItemsSource = cars;
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
