using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiAre_TestProject.Models;

namespace MiAre_TestProject.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        
        // public ActionResult About()
        // {
        //     ViewBag.Message = "Your application description page.";
        //     return View();
        // }
        //
        // public ActionResult Contact()
        // {
        //     ViewBag.Message = "Your contact page.";
        //     return View();
        // }
    }
}