using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gitline.Data;
using Gitline.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Gitline.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Inventory.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Inventory record, IFormFile Imagepath)
        {
            var item = new Inventory();
            item.Name = record.Name;
            item.Type = record.Type;
            item.Brand = record.Brand;
            item.Price = record.Price;
            item.Rating = record.Rating;
            item.Description = record.Description;
            item.Stock = record.Stock;


            if (Imagepath != null)
            {
                if (Imagepath.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/inventory", Imagepath.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Imagepath.CopyTo(stream);
                    }
                    item.ImagePath = Imagepath.FileName;
                }
            }

            _context.Inventory.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
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

        [HttpPost]
        public IActionResult Edit(int? id, Inventory record)
        {
            var item = _context.Inventory.Where(i => i.ProductID == id).SingleOrDefault();
            item.Name = record.Name;
            item.Type = record.Type;
            item.Brand = record.Brand;
            item.Price = record.Price;
            item.Rating = record.Rating;
            item.Description = record.Description;
            item.Stock = record.Stock;

            _context.Inventory.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
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

            _context.Inventory.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
