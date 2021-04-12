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
            var list = _context.Inventory.ToList();
            return View(list);
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

            return View(item);
        }

        List<ProductOrder> li = new List<ProductOrder>();

        [HttpPost]
        public IActionResult AddtoCart(int id, string qty, Inventory pr)
        {
            var item = _context.Inventory.Where(i => i.ProductID == id).SingleOrDefault();
            var cart = SessionHelper.GetObjectFromJson<List<ProductOrder>>(HttpContext.Session, "cart");


            // ProductOrder p = new ProductOrder();
            var p = new ProductOrder();
            p.ProductOrderID = item.ProductID;
            p.Quantity = Convert.ToInt32(qty);
            p.Price = (int)item.Price;
            p.Total = (int)(item.Price * p.Quantity);


            li.Add(p);

            TempData["ProductOrder"]  = li;
            TempData.Keep();

            return RedirectToAction("Index");
    

        }

        public IActionResult Cart()
        {

            return View();
        }

    }
}
