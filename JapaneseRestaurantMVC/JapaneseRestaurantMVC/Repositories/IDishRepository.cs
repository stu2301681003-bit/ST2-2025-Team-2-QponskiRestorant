using JapaneseRestaurant.Models;
using System.Collections.Generic;

namespace JapaneseRestaurant.Repositories
{
    public interface IDishRepository
    {
        IEnumerable<Dish> GetAll();
        Dish GetById(int id);
        void Add(Dish dish);
        void Update(Dish dish);
        void Delete(int id);
    }
}
