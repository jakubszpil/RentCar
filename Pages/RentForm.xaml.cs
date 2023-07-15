using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RentCar.Pages {
    /// <summary>
    /// Logika interakcji dla klasy RentForm.xaml
    /// </summary>
    public partial class RentForm : Page {
        Action<string> Navigate;

        public RentForm(Action<string> Navigate) {
            InitializeComponent();
            this.Navigate = Navigate;
        }

        public void OnSubmit(object sender, RoutedEventArgs e) {
            var name = NameInput.Text.ToString();
            var surname = SurnameInput.Text.ToString();
            var email = EmailInput.Text.ToString();
            int? phoneNumber = int.Parse(PhoneNumberInput.Text.ToString());
            var rentalDate = RentalDateInput.Text.ToString();
            var returnDate = ReturnDateInput.Text.ToString();
            int? carId = int.Parse(CarIdInput.Text.ToString());

            if (name == null || surname == null || email == null || phoneNumber == null || rentalDate == null || returnDate == null || carId == null) {
                MessageBox.Show("Uzupełnij wszystkie dane.", "Błąd walidacji", MessageBoxButton.OK);
                return;
            }

            using (var context = new RentCarContext())
            {
                var client = new Client {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    PhoneNumber = phoneNumber.ToString()
                };
                var car = context.Cars.Single(c => c.Id == carId);
                var rent = new Rent {
                    RentalDate = DateTime.Parse(rentalDate),
                    ReturnDate = DateTime.Parse(returnDate),
                    Client = client,
                    Car = car
                };

                context.Rents.Add(rent);
                context.SaveChanges();
            }

            Navigate("Rents");
        }

        public void OnReset(object sender, RoutedEventArgs e) { }

        private void RegexNumberCheck(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[0-9]{9}");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
