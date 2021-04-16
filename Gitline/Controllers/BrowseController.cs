using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gitline.Data;
using Gitline.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.ProductOrder.Where(i => i.ProductOrderID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            _context.ProductOrder.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult CheckOut(int? id,Order record)
        {
     

            var product = _context.ProductOrder.Where(i => i.ProductOrderID == (int)id).SingleOrDefault(); // gets chosen product record
            if (product == null) 
                return RedirectToAction("Index", "Browse"); 

            var o = new Order();
            o.OrderAddress = record.OrderAddress;
            o.OrderCity = record.OrderCity;
            o.OrderZip = record.OrderZip;
            o.OrderEmail = record.OrderEmail;
            o.dateTime = DateTime.Now;
            o.OrderPhone = record.OrderPhone;
            o.OrderUser = record.OrderUser;
            o.Product = product;

            _context.Order.Add(o);
            _context.SaveChanges();

            using (MailMessage mail = new MailMessage("gitline2525@gmail.com", record.OrderEmail))
            {
                mail.Subject = "Gitline Order Receipt";

                string message = "Hello, " + o.OrderUser + " Your order is now confirmed!<br/><br/>" +
                    "Here are the details: <br/><br/>" +
                    "Order Id: <strong>" + o.OrderId + "</strong><br/><br/>" +
                    "Product: <strong>" + o.Product.ProductName + "</strong>      x" + o.Product.Quantity + "<br/><br/>" +
                    "Address: <strong>" + o.OrderAddress + "</strong><br/><br/>" +
                    "City: <strong>" + o.OrderCity + "</strong><br/><br/>" +
                    "Zip: <strong>" + o.OrderZip + "</strong><br/><br/>" +
                    "Email: <strong>" + o.OrderEmail + "</strong><br/><br/>" +
                    "Phone: <strong>" + o.OrderPhone + "</strong><br/><br/>" +
                    "Date: <strong>" + o.dateTime + "</strong><br/><br/> Thank you for purchasing!";

                mail.Body = message;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("gitline2525@gmail.com", "Gitline123");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Email sent.";
                }
            }


            return RedirectToAction("Confirm");
        }

        public IActionResult Confirm()
        {
            var cart = _context.Order.Include(p => p.Product).ToList();
            var model = new OrderViewModel()
            {
                OrderList = cart
                
            };

      

            return View(model);
        }

        //[HttpPost]
        //public IActionResult Confirm(Order record)
        //{
        //    using (MailMessage mail = new MailMessage("gitline2525@gmail.com", record.OrderEmail))
        //    {
        //        mail.Subject = "Gitline Order Receipt";

        //        string message = "Hello, Your order is now confirmed!<br/><br/>" +
        //            "Here are the details: <br/><br/>" +
        //            "Order Id: <strong>" + record.OrderId + "</strong><br/><br/>";
                 


        //        mail.Body = message;
        //        mail.IsBodyHtml = true;

        //        using (SmtpClient smtp = new SmtpClient())
        //        {
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.EnableSsl = true;
        //            NetworkCredential NetworkCred = new NetworkCredential("gitline2525@gmail.com", "Gitline123");
        //            smtp.UseDefaultCredentials = true;
        //            smtp.Credentials = NetworkCred;
        //            smtp.Port = 587;
        //            smtp.Send(mail);
        //            ViewBag.Message = "Email sent.";
        //        }
        //    }
        //    return View();
        //}

        public IActionResult DeleteC(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.Order.Where(i => i.OrderId == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            _context.Order.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
