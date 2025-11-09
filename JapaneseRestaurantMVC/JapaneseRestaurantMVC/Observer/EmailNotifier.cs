using JapaneseRestaurant.Models;
using System;

namespace JapaneseRestaurant.Observer
{
    public class EmailNotifier : IReservationObserver
    {
        public void Update(Reservation reservation)
        {
            Console.WriteLine($"Email sent: New reservation for {reservation.Name} at {reservation.Date}");
        }
    }
}
