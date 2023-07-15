namespace RentCar.Models {
    internal class RentItem {
        public System.DateTime RentalDate { get; set; }
        public System.DateTime ReturnDate { get; set; }
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarFuelType { get; set; }
        public int CarMileage { get; set; }
        public string CarBodyType { get; set; }
        public short CarProductionYear { get; set; }
        public double CarPrice { get; set; }
        public double CarDeposit { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public RentItem(Rent rent)
        {
            Id = rent.Id;
            RentalDate = rent.RentalDate;
            ReturnDate = rent.ReturnDate;
            CarId = rent.Car.Id;
            CarBrand = rent.Car.Brand;
            CarModel = rent.Car.Model;
            CarFuelType = rent.Car.FuelType;
            CarMileage = rent.Car.Mileage;
            CarBodyType = rent.Car.BodyType;
            CarProductionYear = rent.Car.ProductionYear;
            CarPrice = rent.Car.Price;
            CarDeposit = rent.Car.Deposit;
            ClientId = rent.Client.Id;
            ClientName = rent.Client.Name;
            ClientSurname = rent.Client.Surname;
            ClientEmail = rent.Client.Email;
            ClientPhoneNumber = rent.Client.PhoneNumber;
        }
    }
}
