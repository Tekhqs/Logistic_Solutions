using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticSolutions.Areas.BusinessPartner.Controllers
{
    public class BusinessPartnersController : Controller
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();
        public ActionResult Index()
        {
            var partner = db.tblPartners.ToList();
            ViewBag.ShippingRateInBoundHandling = db.tblPartnerShippingRates.ToList();
            return View(partner);
        }
        public ActionResult Create()
        {
            var customer = db.tblLSCustomers.Select(c => new
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName
            })
            .OrderBy(x => x.CompanyName).ToList();

            ViewBag.Customer = new SelectList(customer, "CustomerID", "CompanyName");

            var country = db.tblCountries.Select(c => new
            {
                CountryID = c.CountryID,
                CountryName = c.CountryName
            })
            .OrderBy(x => x.CountryName).ToList();

            ViewBag.Country = new SelectList(country, "CountryID", "CountryName");
            

            return View();
        }
    }
}