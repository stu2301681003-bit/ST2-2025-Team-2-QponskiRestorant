using JapaneseRestaurant.Models;

namespace JapaneseRestaurant.Observer
{
    public interface IReservationObserver
    {
        void Update(Reservation reservation);
    }
}
