using System;

namespace HotelReservation
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            decimal price = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            Season season = Enum.Parse<Season>(input[2]);

            decimal totalPrice = 0;
            if (input.Length == 4)
            {
                DiscountType discount = Enum.Parse<DiscountType>(input[3]);
                totalPrice = PriceCalcualtor.GetTotalPrice(price, numberOfDays, season, discount);
            }

            else
            {
                DiscountType discount = DiscountType.None;
                totalPrice = PriceCalcualtor.GetTotalPrice(price, numberOfDays, season, discount);
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

