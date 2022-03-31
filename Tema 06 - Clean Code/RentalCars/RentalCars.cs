using System;
using System.Collections.Generic;

namespace RentalCars
{
    public class RentalCars
    {
        private readonly List<Rental> _rentals = new List<Rental>();
        

        public RentalCars(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
            rental.Customer.AddRental(rental);
        }
        public string CheckPriceCode(Car car)
        {

            return car.PriceCode.ToString();

        }
        private double amountOf(Rental each)
        {
            double thisAmount = 0;
            double pricePerDay = 20;
            switch (each.Car.PriceCode)
            {
                case PriceCode.Regular:
                    thisAmount += pricePerDay * 2;
                    if (each.DaysRented > 2)
                        thisAmount += (each.DaysRented - 2) * pricePerDay * 0.75;
                    break;
                case PriceCode.Premium:
                    thisAmount += each.DaysRented * pricePerDay * 1.5;
                    break;
                case PriceCode.Mini:
                    thisAmount += pricePerDay * 3 * 0.75;
                    if (each.DaysRented > 3)
                        thisAmount += (each.DaysRented - 3) * pricePerDay * 0.5;
                    break;
            }

            if (each.Customer.FrequentRenterPoints >= 5)
            {
                thisAmount = thisAmount * 0.95;
            }
            return thisAmount;
        }

        public int GetFrequentRenterPoints(Rental each)
        {
            if (each.Car.PriceCode == PriceCode.Premium
                    && each.DaysRented > 1)
            {
                return 2;
            }
            return 1;
        }
        public string Statement()
        {
          
            double totalAmount = 0;
            var frequentRenterPoints = 0;

            var r = "Rental Record for " + Name + "\n";
            r += "------------------------------\n";

            foreach (var each in _rentals)
            {
                double thisAmount = 0;

                thisAmount = amountOf(each);

                frequentRenterPoints += GetFrequentRenterPoints(each);
              

                each.Customer.FrequentRenterPoints += frequentRenterPoints;

                r += each.Customer.Name + "\t" + each.Car.Model + "\t" + each.DaysRented + "d \t" + thisAmount + " EUR\n";
                totalAmount += thisAmount;
            }
            r += "------------------------------\n";
            r += "Total revenue " + totalAmount + " EUR\n";

            return r;
        }
        
    }
}