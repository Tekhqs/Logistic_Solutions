﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticSolutions.Areas.Order.Controllers
{
    public class PurchaseOrdersController:Controller
    {
        public ActionResult Index()
        {
            IList<order> OrderList = new List<order>() {
                new order(){
                   OrderId  ="55670-122-PA",
                   ShippingAdress="New Adarish Para Road, Rangpur ",
                   ShippingDate="28 feb 2020",
                   Status="Pending",
                   type="Online"

                },
                new order(){
                   OrderId  ="55670-122-PA",
                   ShippingAdress="New Adarish Para Road, Rangpur ",
                   ShippingDate="28 feb 2020",
                   Status="Deliverd",
                   type="Offline"

                },
                new order(){
                   OrderId  ="55670-122-PA",
                   ShippingAdress="New Adarish Para Road, Rangpur ",
                   ShippingDate="28 feb 2020",
                   Status="Unpaid",
                   type="Online"

                },
                new order(){
                   OrderId  ="55670-122-PA",
                   ShippingAdress="New Adarish Para Road, Rangpur ",
                   ShippingDate="28 feb 2020",
                   Status="Paid",
                   type="Offline"

                },

            };
            ViewBag.orders = OrderList;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult UserData(string text)
        {
            IList<order> result = new List<order>() {
                new order(){
                   OrderId  ="55670-122-PA",
                   ShippingAdress="New Adarish Para Road, Rangpur ",
                   ShippingDate="28 feb 2020",
                   Status="Pending",
                   type="Online"

                },
                new order(){
                   OrderId  ="55670-122-PA",
                   ShippingAdress="New Adarish Para Road, Rangpur ",
                   ShippingDate="28 feb 2020",
                   Status="Deliverd",
                   type="Offline"

                },
                new order(){
                   OrderId  ="55670-122-PA",
                   ShippingAdress="New Adarish Para Road, Rangpur ",
                   ShippingDate="28 feb 2020",
                   Status="pu",
                   type="Online"

                },
                new order(){
                   OrderId  ="55670-122-PA",
                   ShippingAdress="New Adarish Para Road, Rangpur ",
                   ShippingDate="28 feb 2020",
                   Status="Paid",
                   type="Offline"

                },

            };
            if (!string.IsNullOrEmpty(text))
            {
                result = result.Where(p => p.Status.ToUpper().Contains(text.ToUpper())).ToList();

            }
            return Json(result, JsonRequestBehavior.AllowGet);


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