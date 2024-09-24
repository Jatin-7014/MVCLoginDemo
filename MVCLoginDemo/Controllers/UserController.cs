using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MVCLoginDemo.Data;
using MVCLoginDemo.Models;
using MVCLoginDemo.ViewModel;

namespace MVCLoginDemo.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Query<User>().SingleOrDefault(u => u.UserName == loginVM.UserName);
                    if (user != null)
                    {
                        string hashedPassword=HashingService.HashPassword(loginVM.Password);
                        if (user.Password == hashedPassword)
                        {
                            FormsAuthentication.SetAuthCookie(loginVM.UserName, true);
                            return RedirectToAction("Index", "Employee");
                        }
                    }
                    ModelState.AddModelError("", "UserName/Password doesn't match");
                    return View();
                }
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    string hashedPassword = HashingService.HashPassword(user.Password);

                    User newUser = new User
                    {
                        UserName = user.UserName,
                        Password = hashedPassword
                    };
                    session.Save(newUser);
                    txn.Commit();
                    return RedirectToAction("Login");
                }
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}