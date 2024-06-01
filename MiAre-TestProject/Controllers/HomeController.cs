using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var userName = User.Identity.Name;
            var user = db.GetUserByUsername(userName);

            if (user != null)
            {
                user.DeserializePreviousAddresses();
                return View(user);
            }
            
            return View();
        }
    }
}