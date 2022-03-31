using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalCars store = new RentalCars("Iasi Rentals");

            var customer1 = new Customer("Ion Popescu");
            var customer2 = new Customer("Mihai Chirica");
            var customer3 = new Customer("Gigi Becali");

            store.AddRental(new Rental(customer1, new Car(PriceCode.Regular, "Ford Focus"), 2));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Regular, "Renault Clio"), 3));
            store.AddRental(new Rental(customer1, new Car(PriceCode.Premium, "BMW 330i"), 1));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Volvo XC90"), 3));
            store.AddRental(new Rental(customer2, new Car(PriceCode.Mini, "Toyota Aygo"), 2));
            store.AddRental(new Rental(customer1, new Car(PriceCode.Mini, "Hyundai i10"), 4));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Volvo XC90"), 2));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Mercedes E320"), 1));

            Console.WriteLine(store.Statement());
            Console.ReadKey();

        }
    }
}
