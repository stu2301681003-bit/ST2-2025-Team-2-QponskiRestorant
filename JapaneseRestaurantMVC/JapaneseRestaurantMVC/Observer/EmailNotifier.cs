using JapaneseRestaurant.Models;
using System;

//observer
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
//когато ReservationManager го уведоми за нова резервация,
//той реагира тук, като симулира изпращане на имейл