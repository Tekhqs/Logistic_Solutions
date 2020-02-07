using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticSolutions.Controllers
{
    public class HomeController : Controller
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();

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
            var Users = db.tblUserProfiles.ToList();
           
            return View(Users);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Group = db.tblSecurityGroups.ToList();
            ViewBag.Wearhouse = db.tblWarehouseMasters.ToList();










            return View();
        }
        public ActionResult UserEdit(int id)
        {
            ViewBag.Group = db.tblSecurityGroups.ToList();
            ViewBag.Wearhouse = db.tblWarehouseMasters.ToList();
            var User = db.tblUserProfiles.Where(c=>c.UserID==id). FirstOrDefault();
            User.EncryptedPassword = User.EncryptedPassword = EncryptDecrypt.Decrypt(User.EncryptedPassword);












            return View(User);
        }
        [HttpPost]
        public JsonResult UserEdit(tblUserProfile userProfile)
        {
            try
            {
                var userId = Convert.ToInt32(Session["UserId"]);

                var User = db.tblUserProfiles.Where(c => c.UserID == userProfile.UserID).FirstOrDefault();
                User.UpdatedBy = userId;
                User.UpdatedOn = DateTime.Now;
                User.Email = userProfile.Email;
                User.EncryptedPassword = EncryptDecrypt.Encrypt(userProfile.EncryptedPassword);
                User.SecurityGroupID = userProfile.SecurityGroupID;
                User.WarehouseID = userProfile.WarehouseID;
                User.isActive = userProfile.isActive;
                User.PhoneNumber = userProfile.PhoneNumber;
                User.Mobile = userProfile.Mobile;
               
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
       




            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Contact(tblUserProfile userProfile)
        {
            try
            {
                var userId = Convert.ToInt32(Session["UserId"]);
                userProfile.EncryptedPassword = EncryptDecrypt.Encrypt(userProfile.EncryptedPassword);
                userProfile.CreatedOn = DateTime.Now;
                userProfile.CreatedBy = userId;
                userProfile.CustomerID = 2;
                db.tblUserProfiles.Add(userProfile);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
           

            return Json(true, JsonRequestBehavior.AllowGet);

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
        public JsonResult ChangePassword(string COldPassword, string CPassword)
        {
            var userId = Convert.ToInt32(Session["UserId"]);
            var USerpassword = db.tblUserProfiles.Where(c => c.UserID == userId).FirstOrDefault().EncryptedPassword;



            var oldPassword =EncryptDecrypt.Decrypt(USerpassword);
            if (oldPassword == COldPassword)
            {
                var User = db.tblUserProfiles.Where(c => c.UserID == userId).FirstOrDefault();
                User.EncryptedPassword = EncryptDecrypt.Encrypt(CPassword);
                db.SaveChanges();

                return Json(true, JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }



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