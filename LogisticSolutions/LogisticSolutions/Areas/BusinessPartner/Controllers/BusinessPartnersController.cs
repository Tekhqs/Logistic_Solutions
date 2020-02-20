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
            var partner = db.tblPartners.Include("tblPartnerShippingAddress").Include("tblPartnerBillingAddress").OrderByDescending(x=>x.CreatedOn).ToList();
            
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
        public ActionResult Edit(int Id)
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
            var partner = db.tblPartners.Include("tblPartnerShippingAddress").Include("tblPartnerBillingAddress").FirstOrDefault(c => c.PartnerID == Id);
            return View(partner);

        }
        public PartialViewResult _ShippingRatesDetail(int shippingRateTypeID)
        {
            ViewBag.ShippingRateInBoundHandling = db.tblPartnerShippingRates.Where(x=>x.ShippingRateTypeID == shippingRateTypeID).ToList();
            return PartialView();
        }
    }
}