using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticSolutions.Areas.WareHouse.Controllers
{
    public class WareHousesController : Controller
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();

        public ActionResult Create(int? id)
        {
            var country = db.tblCountries.Select(c => new
            { 
                CountryID = c.CountryID,
                CountryName = c.CountryName
            }).Distinct().OrderBy(x => x.CountryName).ToList();
            ViewBag.Country = country;

            if(id==0 || id == null)
            {
                tblWarehouseMaster warehouse = new tblWarehouseMaster();

                return View(warehouse);
            }
            else
            {
                var wareHouse = db.tblWarehouseMasters.Where(c => c.WarehouseID == id).FirstOrDefault();
                return View(wareHouse);
            }

            
        }
        public ActionResult index()
        {
            var wareHouse = db.tblWarehouseMasters.ToList();
            return View(wareHouse);
        }

    }
}