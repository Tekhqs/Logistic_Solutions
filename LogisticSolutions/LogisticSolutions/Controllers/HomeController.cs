using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticSolutions.Controllers
{
    public class HomeController : Controller
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            IList<user> UserList = new List<user>() {
                new user(){ UserId="55670-122-PA",
                    User ="Steve Horton",
                    EmailAdress ="Steve@gmail.com",
                    Status="Active",
                    plans="Basic",
                    DateCreated="28 Feb 2020",
                    UserROle="Admin",
                    SinceActivetime="3"


                }, new user(){ UserId="55670-122-PA",
                  User ="Steve Horton",
                    EmailAdress ="Steve@gmail.com",
                    Status="Pending",
                    plans="Advanced",
                    DateCreated="28 Feb 2020",
                    UserROle="User",
                    SinceActivetime="3"


                }, new user(){ UserId="55670-122-PA",
                    User ="Steve Horton",
                    EmailAdress ="Steve@gmail.com",
                    Status="Inactive",
                    plans="Pro",
                    DateCreated="28 Feb 2020",
                    UserROle="Admin",
                    SinceActivetime="3"

                },

            };
            ViewBag.users = UserList;
            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Order()
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


        public class user
        {
            public string UserId { get; set; }
            public string User { get; set; }
            public string EmailAdress { get; set; }
            public string Status { get; set; }
            public string SinceActivetime { get; set; }
            public string plans { get; set; }
            public string DateCreated { get; set; }
            public string UserROle { get; set; }


        }
        public class order
        {
            public string OrderId { get; set; }
            public string ShippingAdress { get; set; }
            public string ShippingDate { get; set; }
            public string Status { get; set; }
            public string type { get; set; }



        }

        public JsonResult DonutChart()
        {


            int[] Parcels = { 1, 2, 4, 50, 16, 32, 64, 128, 25 };
            int[] orders = { 1, 2, 4, 8, 16, 32, 64, 128, 256 };
            int[] Receiving = { 1, 2, 4, 8, 16, 32, 64, 128, 150, 6 };
            int[] Users = { 1, 2, 4, 8, 64, 64, 64, 128, 256 };
            double[] SROrderX = { 7.0, 6.9, 23.3, 18.3, 13.9, 9.6 };
            double[] SROrderY = { 4.2, 5.7, 8.5, 11.9, 15.2, 17.0 };
            double[] MROrderY = { 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0 };
            double[] MSOrderY = { 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0 };
            double Revenue = 80;

            var result = new
            {
                order = orders,
                parcels = Parcels,
                receiving=Receiving,
                users=Users,
                sROrderX=SROrderX,
                sROrderY=SROrderY,
                mROrderY=MROrderY,
                mSOrderY = MSOrderY,
                revenue= Revenue
            };


            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }
}