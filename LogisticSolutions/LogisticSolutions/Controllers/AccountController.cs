using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace LogisticSolutions.Controllers
{
    public class AccountController : Controller
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();
        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View("SignIn", "_LoginLayout");
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string prmUserId, string prmPassword, bool IsRememberMe)
        {
            string encryptedPassword = EncryptDecrypt.Encrypt(prmPassword);
            var loginDetails = AuthUser(prmUserId, encryptedPassword);

            if (loginDetails != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Username or Password";
            }
            return View();
        }
        public string AuthUser(string username, string encryptedPassword)
        {
            var StoredUserName = db.tblUserProfiles.Where(x => x.UserName == username).Select(y => y.UserName).FirstOrDefault();
            var StoredPassword = EncryptDecrypt.Decrypt(db.tblUserProfiles.Where(x => x.EncryptedPassword == encryptedPassword).Select(y => y.EncryptedPassword).FirstOrDefault());

            if (encryptedPassword.Equals(StoredPassword) && username.Equals(StoredUserName))
            {
                Session["UserName"] = username;
                return username;
            }

            else
                return null;
        }
    }
}