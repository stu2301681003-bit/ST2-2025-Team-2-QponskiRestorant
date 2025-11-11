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
//това е основният клас, който управлява резервациите и уведомява
//всички наблюдатели, когато бъде добавена нова

//когато се добави нова резервация AddReservation,
//тя извиква NotifyObservers и изпълнява методът Update на всеки наблюдател