using JapaneseRestaurant.Models;
using System.Collections.Generic;

namespace JapaneseRestaurant.Observer
{
    public class ReservationManager
    {
        private readonly List<IReservationObserver> _observers = new();

        public void Subscribe(IReservationObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IReservationObserver observer)
        {
            _observers.Remove(observer);
        }

        public void AddReservation(Reservation reservation)
        {
            // Тук добавяте резервацията в DB (по желание чрез Repository)
            Notify(reservation);
        }

        private void Notify(Reservation reservation)
        {
            foreach (var observer in _observers)
            {
                observer.Update(reservation);
            }
        }
    }
}
