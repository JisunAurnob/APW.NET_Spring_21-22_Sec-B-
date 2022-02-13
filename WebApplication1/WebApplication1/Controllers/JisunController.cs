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
    public class JisunController : Controller
    {
        // GET: Jisun
        public ActionResult FirstPage()
        {
            ViewBag.Message = "MD. Jisun Abedin Aurnob";
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(user u)
        {
            if (ModelState.IsValid)
            {
                //db insertion or authentication authorization
                testDBEntities db = new testDBEntities();
                db.users.Add(u);
                db.SaveChanges();
                return RedirectToAction("SubmitReg");
            }
            return View(u);
        }

        public ActionResult SubmitReg()
        {
            testDBEntities db = new testDBEntities();
            var data =  db.users.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult EditUser(int id) 
        {
            testDBEntities db = new testDBEntities();
            var user = db.users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(user u)
        {
            if (ModelState.IsValid)
            {
                testDBEntities db = new testDBEntities();
                var obj = db.users.Where(value => value.UserID == u.UserID).First();
                obj.Name = u.Name;
                obj.Email = u.Email;
                obj.Dob = u.Dob;
                obj.Phone = u.Phone;
                obj.Username = u.Username;
                obj.Password = u.Password;
                obj.Gender = u.Gender;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SubmitReg");
            }
            return View(u);
        }
    }
}