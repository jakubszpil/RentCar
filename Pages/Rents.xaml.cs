using RentCar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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


            using (var context = new RentCarContext())
            {
                List<Rent> rents = context.Rents.ToList();
                List<RentItem> items = new List<RentItem>();

                foreach (var item in rents) items.Add(new RentItem(item));
 
                if (rents.Count == 0)  {
                    Table.Visibility = Visibility.Hidden;
                    TableInfo.Visibility = Visibility.Visible;
                } else {
                    RentsList.ItemsSource = items;
                }
            }

        }

        public void NavigateToRentForm(object sender, RoutedEventArgs e) {
            Navigate("RentForm");
        }

        public void RemoveRent(object sender, RoutedEventArgs e) {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                   "Czy na pewno chcesz usunąć wpis z historii wypożyczeń z bazy?",
                   "Potwierdź akcję",
                   MessageBoxButton.YesNoCancel,
                   MessageBoxImage.Warning
               );

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                short id = short.Parse(((Button)sender).Tag.ToString());

                using (var context = new RentCarContext())
                {
                    Rent rent = new Rent() { Id = id };
                    context.Rents.Attach(rent);
                    context.Rents.Remove(rent);
                    context.SaveChanges();
                }

                Navigate("Rents");
            }
        }
    }
}
