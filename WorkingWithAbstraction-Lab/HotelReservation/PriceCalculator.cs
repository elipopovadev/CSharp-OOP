using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalcualtor
    {
        public static decimal GetTotalPrice(decimal pricePerDay, int numberOfDays, Season season, DiscountType discountType)
        {        
            decimal priceBeforeDiscount = pricePerDay * numberOfDays * (int)season;
            decimal discount = priceBeforeDiscount * (int)discountType / 100;
            decimal totalPrice = priceBeforeDiscount - discount;
            return totalPrice;
        }
    }
}
