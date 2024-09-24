using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLoginDemo.Data;
using MVCLoginDemo.Models;

namespace MVCLoginDemo.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var data = session.Query<Employee>().ToList();
                return View(data);
            }
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    session.Save(employee);
                    txn.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
        public ActionResult About()
        {
            return View();
        }
    }
}