using JapaneseRestaurant.Data;
using JapaneseRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JapaneseRestaurant.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly AppDbContext _context;

        public DishRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Dish> GetAll() => _context.Dishes.ToList();

        public Dish GetById(int id) => _context.Dishes.Find(id);

        public void Add(Dish dish)
        {
            _context.Dishes.Add(dish);
            _context.SaveChanges();
        }

        public void Update(Dish dish)
        {
            _context.Dishes.Update(dish);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dish = _context.Dishes.Find(id);
            if (dish != null)
            {
                _context.Dishes.Remove(dish);
                _context.SaveChanges();
            }
        }
    }
}
