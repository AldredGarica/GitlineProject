using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gitline.Data;
using Gitline.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Gitline.Helpers;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Gitline.Controllers
{
    public class BrowseController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BrowseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var productList = _context.Inventory.ToList();

            var model = new StoreViewModel()
            {
                ProductList = productList
            };
            return View(model);
        }



        public IActionResult AddtoCart(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.Inventory.Where(i => i.ProductID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            var model = new StoreViewModel();
            model.Product = item;
            return View(model);
        }



        [HttpPost]
        public IActionResult AddtoCart(int? id, StoreViewModel record)
        {
            var product = _context.Inventory.Where(i => i.ProductID == (int)id).SingleOrDefault(); // gets chosen product record
            if (product == null) // checks if product is not existing
                return RedirectToAction("Index", "Browse"); // redirects to browse page if record is not found

            var order = new ProductOrder(); // creates a cart record
            order.Product = product;
            order.ProductId = id;
            order.Quantity = record.Quantity;
            order.ProductName = product.Name;
            order.Price = product.Price;
            order.Total = product.Price * record.Quantity;
            _context.ProductOrder.Add(order); // inserts a record
            _context.SaveChanges();
            return RedirectToAction("Index", "Browse"); // redirects to browse page after adding a cart record

        }

        public IActionResult Cart()
        {

            var cart = _context.ProductOrder.Include(p => p.Product).ToList();
            var model = new StoreViewModel()
            {
                CartList = cart
            };
            return View(model);
        }


    }
}
