using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MiAre_TestProject.Models;
using Microsoft.Ajax.Utilities;

namespace MiAre_TestProject.Controllers
{
    public class ManagementController : Controller
    {
        private MyDbContext db = new MyDbContext();
        
        public ActionResult ManageUsers()
        {
            User currentUser = null;
            if (Request.IsAuthenticated)
            {
                var currentId = (FormsIdentity)User.Identity;
                currentUser = db.GetUserByUsername(currentId.Ticket.Name);
            }
            
            if (currentUser == null || !currentUser.IsAdmin)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            }
            
            var users = db.Users.ToList();
            return View(users);
        }
        
        [Authorize]
        public ActionResult EditAddress(int id)
        {
            var user = db.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            User currentUser = null;
            if (Request.IsAuthenticated)
            {
                var currentId = (FormsIdentity)User.Identity;
                currentUser = db.GetUserByUsername(currentId.Ticket.Name);
            }
            
            if (currentUser == null || !(currentUser.IsAdmin || currentUser.Username == user.Username))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            }
            
            return View(user);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditAddress(User model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(u => u.Id == model.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                User currentUser = null;
                if (Request.IsAuthenticated)
                {
                    var currentId = (FormsIdentity)User.Identity;
                    currentUser = db.GetUserByUsername(currentId.Ticket.Name);
                }
            
                if (currentUser == null || !(currentUser.IsAdmin || currentUser.Username == user.Username))
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
                }
                
                var lastAddress = user.Address;
                user.DeserializePreviousAddresses();
                user.PreviousAddresses.Add(lastAddress);
                user.SerializePreviousAddresses();
                
                user.Address = model.Address;
                
                db.SaveChanges();
                return RedirectToAction("Index", controllerName:"Home");
            }
            return View(model);
        }
    }
}