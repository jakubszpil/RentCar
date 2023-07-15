using System;
using System.Collections.Generic;
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

namespace RentCar.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy CarForm.xaml
    /// </summary>
    public partial class CarForm : Page
    {
        Action<string> Navigate;
        public CarForm(Action<string> Navigate) {
            InitializeComponent();
            this.Navigate = Navigate;
        }

        private void RegexIntCheck(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[0-9]{4}");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RegexDoubleCheck(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void OnSubmit(object sender, EventArgs e) {
            var brand = BrandInput.Text;
            var model = ModelInput.Text;
            var productionYear = ProductionYearInput.Text;
            var mileage = MileageInput.Text;
            var fuelType = FuelTypeInput.Text;
            var bodyType = BodyTypeInput.Text;
            var price = PriceInput.Text;
            var deposit = DepositInput.Text;


            if (
                brand == null || 
                model == null || 
                productionYear == null || 
                mileage == null || 
                fuelType == null ||
                bodyType == null ||
                price == null ||
                deposit == null) {

                MessageBox.Show("Uzupełnij wszystkie dane.", "Błąd walidacji", MessageBoxButton.OK);
                return;
            }

            using (var context = new RentCarContext()) {
                Car car = new Car
                {
                    Brand = brand,
                    Model = model,
                    ProductionYear = short.Parse(productionYear),
                    FuelType = fuelType,
                    BodyType = bodyType,
                    Mileage = int.Parse(mileage),
                    Price = double.Parse(price),
                    Deposit = double.Parse(deposit),
                };

                context.Cars.Add(car);
                context.SaveChanges();
            }

            Navigate("Dashboard");
        }
        public void OnReset(object sender, EventArgs e) {
            BrandInput.Text = String.Empty;
            ModelInput.Text = String.Empty;
            ProductionYearInput.Text = String.Empty;
            MileageInput.Text = String.Empty;
            FuelTypeInput.Text = String.Empty;
            BodyTypeInput.Text = String.Empty;
            PriceInput.Text = String.Empty;
            DepositInput.Text = String.Empty;
        }
    }
}
