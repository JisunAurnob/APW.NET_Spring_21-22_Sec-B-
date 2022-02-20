using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
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
        [HttpPost]
        public ActionResult AddToCart(Cart c) 
        {
            testDBEntities db = new testDBEntities();
            var sameCart = (from ct in db.Carts where ct.PID == c.PID select ct).FirstOrDefault();
            if (sameCart != null)
            {
                sameCart.Qty += c.Qty;
                db.Entry(sameCart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Cart");
            }
            else
            {
                db.Carts.Add(c);
                db.SaveChanges();
                return RedirectToAction("Cart");
            }
        }

        public ActionResult Cart() 
        {
            testDBEntities db = new testDBEntities();
            //var data = db.Carts.Include(db.Products.Where());
            List<CartView> l = new List<CartView>();
            var data = (from c in db.Carts
                        join p in db.Products on c.PID equals p.PID
                        select new {c.CartID, c.Qty, c.PID, p.Name, p.Price}).ToList();
            foreach (var item in data)
            {
                CartView cv = new CartView();
                cv.CID = item.CartID;
                cv.Cqty = (int)item.Qty;
                cv.PID = (long)item.PID;
                cv.Pname = item.Name;
                cv.Pprice = item.Price;
                cv.CTotalPrice = int.Parse(item.Price) * (int)item.Qty;
                l.Add(cv);
            }
            return View(l);
        }

        public ActionResult DeleteCart(int id)
        {
            testDBEntities db = new testDBEntities();
            var carts = db.Carts.Find(id);
            db.Carts.Remove(carts);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }
    }
}