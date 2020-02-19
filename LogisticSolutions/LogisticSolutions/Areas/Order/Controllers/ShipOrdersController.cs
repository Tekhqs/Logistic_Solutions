using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticSolutions.Areas.Order.Controllers
{
    public class ShipOrdersController : Controller
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();

        // GET: ShippingOrders
        public ActionResult Index()
        {
            var shipOrder = db.tblShippingOrders.OrderByDescending(x=>x.CreatedOn).ToList();

            return View(shipOrder);
        }
        public ActionResult Create()
        {
            var source = db.tblOrderSources.Select(c => new
            {
                SourceID = c.SourceID,
                SourceName = c.SourceName
            })
            .OrderBy(x => x.SourceName).ToList();

            ViewBag.ShipSourceChannel = new SelectList(source, "SourceID", "SourceName");

            var account = db.tblPartners.Select(c => new
            {
                //PartnerID = c.PartnerID,
                AccountID = c.AccountID
            })
            .OrderBy(x => x.AccountID).ToList();

            ViewBag.Account = new SelectList(account, "AccountID", "AccountID");

            var shippingCarrier = db.tblShippingCarriers.Select(c => new
            {
                ShippingCarrierID = c.ShippingCarrierID,
                CarrierType = c.CarrierType
            })
            .OrderBy(x => x.CarrierType).ToList();

            ViewBag.ShippingCarrier = new SelectList(shippingCarrier, "ShippingCarrierID", "CarrierType");

            return View();
        }
        public JsonResult GetPartnerAddress(string accountID)
        {
            List<tblPartner> partnerAddress = db.tblPartners.Where(x => x.AccountID == accountID).ToList();


            return Json(
            partnerAddress.Select(x => new
            {
                BillingAddressID = x.BillingAddressID,
                ShippingAddressID = x.ShippingAddressID,
                BillingAddress1 = x.tblPartnerBillingAddress.Address1 + " " + x.tblPartnerBillingAddress.CityName + " " + x.tblPartnerBillingAddress.State_Province + " " + x.tblPartnerBillingAddress.Zip_PostalCode + " " + x.tblPartnerBillingAddress.tblCountry.CountryName,
                ShippingAddress1 = x.tblPartnerShippingAddress.ShipAddress1 + " " + x.tblPartnerShippingAddress.ShipCityName + " " + x.tblPartnerShippingAddress.ShipState_Province + " " + x.tblPartnerShippingAddress.ShipZip_PostalCode +" "+ x.tblPartnerShippingAddress.tblCountry.CountryName,
                PartnerID = x.PartnerID,
            }), JsonRequestBehavior.AllowGet);
        }
        public class order
        {
            public string OrderId { get; set; }
            public string ShippingAdress { get; set; }
            public string ShippingDate { get; set; }
            public string Status { get; set; }
            public string type { get; set; }



        }
    }
}