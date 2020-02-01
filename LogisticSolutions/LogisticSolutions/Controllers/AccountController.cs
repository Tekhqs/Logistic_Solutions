using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using LogisticSolutions.Models;
using System.Web.Security;

namespace LogisticSolutions.Controllers
{
    public class AccountController : Controller
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();
        LSMessages lsMsg = new LSMessages();

        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View("SignIn", "_LoginLayout");
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(string prmUserId, string prmPassword)
        {
            try
            {
                string encryptedPassword = EncryptDecrypt.Encrypt(prmPassword);
                var loginDetails = db.tblUserProfiles.Where(x => x.UserName == prmUserId && x.EncryptedPassword == encryptedPassword).FirstOrDefault();

                if (loginDetails != null)
                {
                    lsMsg.status = true;
                    lsMsg.message = "Login Successfull";
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    lsMsg.status = false;
                    lsMsg.message = "Invalid Username or Password";
                }
            }
            catch (Exception ex)
            {
                lsMsg.unknownStatus = true;
                lsMsg.unknownMessage = ex.Message;
            }

            var jsonResult = new
            {
                data = lsMsg
            };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn", "Account");
        }
    }
}