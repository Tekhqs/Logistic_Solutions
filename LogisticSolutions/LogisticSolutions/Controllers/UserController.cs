using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticSolutions.Controllers
{
    public class UserController : Controller
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();

        // GET: User
        public ActionResult Index()
        {
            var Users = db.tblUserProfiles.ToList();

            return View(Users);
        }

        public ActionResult Create()
        {
            ViewBag.Group = db.tblSecurityGroups.ToList();
            ViewBag.Wearhouse = db.tblWarehouseMasters.ToList();
            return View();
        }
       
    }
}