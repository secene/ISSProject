using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IISProject.Data;
using IISProject.Models;
using Microsoft.AspNetCore.Identity;

namespace IISProject.Controllers
{
    public class ProductsForUser : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ProductsForUser(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> CheckCart()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = _context.Orders.Where(x => x.UserId == user.Id.ToString());
            return View(orders);
        }
        // GET: ProductsForUser
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: ProductsForUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public ActionResult ErrorRedirect()
        {
            return View();
        }
        public async Task<IActionResult> Order(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Products.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(int id, [Bind("Id,Name,ModificationData,Quantity,Price,WantedQuantity")] Product product)
        {
            if (product.Quantity < product.WantedQuantity)
            {
                return RedirectToAction(nameof(ErrorRedirect));
            }

            Order orders = new Order();

            if(id != product.Id)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                try
                {
                    product.Quantity = product.Quantity - product.WantedQuantity;
                    orders.Name = product.Name;
                    orders.Quantity = product.WantedQuantity;
                    orders.Price = product.Price * product.WantedQuantity;
                    orders.OrderDate = DateTime.Now;
                    orders.UserId = user.Id;
                    _context.Products.Update(product);
                    _context.Orders.Add(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

    }
}
