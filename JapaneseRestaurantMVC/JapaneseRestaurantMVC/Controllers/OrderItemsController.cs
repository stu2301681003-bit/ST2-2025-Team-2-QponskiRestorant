using JapaneseRestaurant.Data;
using JapaneseRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JapaneseRestaurantMVC.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly AppDbContext _context;

        public OrderItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OrderItems/Create
        public IActionResult Create(int? orderId)
        {
            if (orderId == null)
                return BadRequest("OrderId is required");

            ViewData["OrderId"] = new SelectList(_context.Orders.Where(o => o.Id == orderId), "Id", "Id", orderId);
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name");

            return View(new OrderItem { OrderId = orderId.Value });
        }

        // POST: OrderItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,DishId,Quantity")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                // Calculate total price of this item
                var dish = await _context.Dishes.FindAsync(orderItem.DishId);
                if (dish == null)
                {
                    ModelState.AddModelError("DishId", "Selected dish does not exist");
                    ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderItem.OrderId);
                    ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name", orderItem.DishId);
                    return View(orderItem);
                }

                _context.OrderItems.Add(orderItem);

                // Update the order total
                var order = await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == orderItem.OrderId);
                if (order != null)
                {
                    order.TotalPrice = order.OrderItems.Sum(oi => oi.Quantity * oi.Dish.Price) + (orderItem.Quantity * dish.Price);
                    _context.Update(order);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Orders", new { id = orderItem.OrderId });
            }

            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderItem.OrderId);
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name", orderItem.DishId);
            return View(orderItem);
        }
    }
}
