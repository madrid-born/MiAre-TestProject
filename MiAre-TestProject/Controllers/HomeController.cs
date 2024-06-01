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
            var currentuser = db.Users.SingleOrDefault(u => u.Username == userName);

            if (currentuser != null)
            {
                var user = new User()
                {
                    Name = currentuser.Name,
                    Email = currentuser.Email,
                    IsAdmin = currentuser.IsAdmin,
                    Username = currentuser.Username,
                    Address = currentuser.Address,
                    PreviousAddresses = currentuser.PreviousAddresses
                };
                return View(user);
            }
            
            return View();
        }
    }
}