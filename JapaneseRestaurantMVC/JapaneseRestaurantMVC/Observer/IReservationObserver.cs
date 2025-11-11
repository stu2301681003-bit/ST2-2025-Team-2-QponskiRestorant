using JapaneseRestaurant.Models;

namespace JapaneseRestaurant.Observer
{
    public interface IReservationObserver
    {
        void Update(Reservation reservation);
    }
}
//определя какво могат да правят всички observer-и