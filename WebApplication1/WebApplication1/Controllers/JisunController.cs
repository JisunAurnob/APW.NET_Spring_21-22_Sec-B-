using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        [HttpGet]
        public ActionResult Login()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            ViewBag.Message = "";
            if (ModelState.IsValid)
            {
                testDBEntities db = new testDBEntities();
                var data = (from u in db.users
                          where u.Username.Equals(user.Username) &&
                          u.Password.Equals(user.Password)
                          select u).FirstOrDefault();
                if (data != null)
                {
                    FormsAuthentication.SetAuthCookie(data.Username, false);
                    Session["Username"] = data.Username;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Message = "Your Username Or Password May Be Incorrect";
                }
            }

            return View();
        }
        [Authorize]
        //[AllowAnonymous]
        public ActionResult Dashboard() 
        {
            //if (Session["Username"]==null)
            //{
            //    return RedirectToAction("Login");
            //}
            return View();
        }
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return View("FirstPage");
        }
    }
}