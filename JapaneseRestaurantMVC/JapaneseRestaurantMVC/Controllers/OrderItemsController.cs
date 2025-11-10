using JapaneseRestaurant.Data;
using JapaneseRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace JapaneseRestaurantMVC.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly AppDbContext _context;

        public OrderItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index()
        {
            var orderItems = _context.OrderItems
                .Include(o => o.Order)
                .Include(o => o.Dish);
            return View(await orderItems.ToListAsync());
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: OrderItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,DishId,Quantity")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // ✅ Остава си тук, връща към OrderItems
            }

            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderItem.OrderId);
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name", orderItem.DishId);
            return View(orderItem);
        }
    }
}
