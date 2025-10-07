using Microsoft.AspNetCore.Mvc;
using QponskiRestorant.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

// Alias the correct AppDbContext to resolve ambiguity
using DB = QponskiRestorant.DataBase.AppDbContext;

namespace QponskiRestorant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly DB _context;

        public ItemsController(DB context)
        {
            _context = context;
        }

        // ✅ GET: api/items - Return all items
        [HttpGet]
        public ActionResult<IEnumerable<Items>> GetAllItems()
        {
            var items = _context.Items.ToList();
            return Ok(items);
        }

        // ✅ GET: api/items/byname?name=Pizza - Search item by exact or partial name
        [HttpGet("byname")]
        public ActionResult<IEnumerable<Items>> GetItemsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Search term cannot be empty.");
            }

            var matchingItems = _context.Items
                .Where(i => EF.Functions.Like(i.Name, $"%{name}%")) // partial match
                .ToList();

            if (!matchingItems.Any())
            {
                return NotFound($"No items found matching: '{name}'.");
            }

            return Ok(matchingItems);
        }
    }
}
//if you'd like to support pagination, sorting, or advanced filters as well.