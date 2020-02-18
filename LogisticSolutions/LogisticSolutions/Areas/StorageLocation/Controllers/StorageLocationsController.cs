using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticSolutions.Areas.StorageLocation.Controllers
{
    public class StorageLocationsController : Controller
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();

        public ActionResult Create()
        {

            return View();

        }



    }
}