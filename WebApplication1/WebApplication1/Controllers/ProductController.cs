using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            testDBEntities db = new testDBEntities();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddProduct() 
        { 
            return View(); 
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                testDBEntities db = new testDBEntities();
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            testDBEntities db = new testDBEntities();
            var products = db.Products.Find(id);
            return View(products);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                testDBEntities db = new testDBEntities();
                var obj = db.Products.Where(value => value.PID == p.PID).First();
                obj.Name = p.Name;
                obj.Price = p.Price;
                obj.Qty = p.Qty;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        
        public ActionResult DeleteProduct(int id)
        {
            testDBEntities db = new testDBEntities();
            var products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddToCart() 
        { 
            return View();
        }
    }
}